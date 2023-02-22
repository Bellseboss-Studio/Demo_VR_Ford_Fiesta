using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

namespace Bellseboss.Audio.Scripts
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundPlayer : MonoBehaviour
    {
        [SerializeField] public SoundCollectionSO m_SoundCollecionSO;
        [SerializeField] private AudioSource m_AS = null;
        [SerializeField] private AudioMixerGroup m_AudioOutput = null;
        [SerializeField] private Event m_SoundFinished;
        [SerializeField] private bool m_isLooped;
        private int clipIndex;
        private void Awake()
        {
            clipIndex = Random.Range(0, m_SoundCollecionSO.SoundCollection.Length);
            m_AS.clip = m_SoundCollecionSO.SoundCollection[clipIndex];
            CheckForDependencies();
        
        }
        private void OnEnable()
        {
            StartCoroutine(nameof(PlayLoopedSound));
        }

        private void OnDisable()
        {
            StopCoroutine(nameof(PlayLoopedSound));
        }

        private IEnumerator PlayLoopedSound()
        {
            
            if (m_isLooped)
            {
                if (!m_AS.isPlaying)
                {
                    m_AS.Play();
                    yield return new WaitForSeconds(m_AS.clip.length);
                    StartCoroutine(nameof(PlayLoopedSound));
                }
            }
            else
            {
                m_AS.PlayOneShot(m_AS.clip);
                yield return new WaitForSeconds(m_AS.clip.length);
                if (m_SoundFinished != null)
                {
                    m_SoundFinished.Occurred();
                }
                gameObject.SetActive(false);
            }
           
        }
        private IEnumerator StopLoopedSound(float timeUntilStop)
        {
            yield return new WaitForSeconds(timeUntilStop);
            StopCoroutine(nameof(PlayLoopedSound));
            gameObject.SetActive(false);
        }
        private void CheckForDependencies()
        {
       
            if (m_AS == null)
            {
                m_AS = GetComponent<AudioSource>();
            }

            if (m_AudioOutput == null)
            {
                ServiceLocator.Instance.GetService<IDebugMediator>().LogR($"No Output on {this.gameObject.scene}");
            }
            else
            {
                m_AS.outputAudioMixerGroup = m_AudioOutput;
            }
            
            gameObject.SetActive(false);
        }
    
    }
}
