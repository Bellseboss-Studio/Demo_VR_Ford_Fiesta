using System.Collections;
using System.Collections.Generic;
using Bellseboss.Audio.Scripts;
using UnityEngine;
using UnityEngine.Audio;

namespace Audio.Scripts
{
	[RequireComponent(typeof(AudioSource))]
	public class AmbienceSoundPlayer : MonoBehaviour
	{
		[SerializeField] private bool m_UseSoundCollection = false;
		private bool m_UseCorroutine = false;
		[SerializeField] private SoundCollectionSO m_SoundCollectionSO;
		[SerializeField] private List<AudioClip> m_AudioClips = new List<AudioClip>();
		[SerializeField] private AudioSource m_AudioSource = null;
		[SerializeField] private AudioMixerGroup m_AudioOutput = null;
		private int m_AudioClipsIndex = 0;
		private double m_ClipLength; 
		private void Awake()
		{
			CheckForDependencies();
			CacheAudioClips();
		}

		private void CacheAudioClips()
		{
			if (m_SoundCollectionSO != null && m_UseSoundCollection)
			{
				m_UseCorroutine = true;
				foreach (AudioClip audioClip in m_SoundCollectionSO.SoundCollection)
				{
					m_AudioClips.Add(audioClip);
				}
			}
		}

		private void OnEnable()
		{
			if (m_UseCorroutine)
			{
				StartCoroutine(PlayAmbienceSounds());
			}
			else
			{
				PlaySimpleAmbienceLoop();
			}
		}

		private void PlaySimpleAmbienceLoop()
		{
			m_AudioSource.clip = m_AudioClips[m_AudioClipsIndex];
			m_AudioSource.loop = true;
			m_AudioSource.Play();
		}

		private IEnumerator PlayAmbienceSounds()
		{
			m_AudioClipsIndex = Random.Range(0, m_AudioClips.Count);
			m_AudioSource.clip = m_AudioClips[m_AudioClipsIndex];
			m_ClipLength = m_AudioClips[m_AudioClipsIndex].length;
			m_AudioSource.Play();
			yield return new WaitForSeconds((float)m_ClipLength);
			PlayAmbienceSounds();
		}
		
		public void DisableAmbience(float timeUntilStop)
		{
			if (gameObject.activeInHierarchy)
			{
				StartCoroutine(StopAmbienceSound(timeUntilStop));
			}
			
				
		}

		private IEnumerator StopAmbienceSound(float timeUntilStop)
		{
			yield return new WaitForSeconds(timeUntilStop);

			if (m_UseCorroutine)
			{
				StopCoroutine(PlayAmbienceSounds());
			}
			else
			{
				m_AudioSource.Stop();
			}
			
			gameObject.SetActive(false);
		}

		private void CheckForDependencies()
		{
			if (m_AudioSource == null)
			{
				m_AudioSource = GetComponent<AudioSource>();
			}

			//This check is necessary to make sure the AudioSource is routed through the correct Audio Mixer Group.
			if (m_AudioOutput == null)
			{
				Debug.Log($"Audio Output needs to be assigned on this gameObject: {gameObject.name}");
			}
			else
			{
				m_AudioSource.outputAudioMixerGroup = m_AudioOutput;
			}
		}
	}
}
