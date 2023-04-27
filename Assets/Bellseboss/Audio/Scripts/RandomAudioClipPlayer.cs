using System;
using System.Collections;
using System.Collections.Generic;
using Bellseboss.Audio.Scripts;
using UnityEngine;
using UnityEngine.Audio;
using Event = Bellseboss.Audio.Scripts.Event;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]
public class RandomAudioClipPlayer : MonoBehaviour
{
    [SerializeField] private bool m_UseSoundCollecionSO;
    [SerializeField] private SoundCollectionSO m_SoundCollection;
    [SerializeField] private List<AudioClip> m_AudioClips = new List<AudioClip>();
    [SerializeField] private AudioSource m_Audiosource;
    [SerializeField] private AudioMixerGroup m_AudioMixerGroup;
    [SerializeField] private bool m_RandomizePitch = false;

    [Range(0f, 0.5f)] 
    [SerializeField] private float m_PitchVariation = 0f;
    [Range(0f, 1f)]
    [SerializeField] private float m_InitialPitch = 1f;

    [SerializeField] private bool m_PlayOnEnable = false;
    [SerializeField] private bool m_DeactivateAfterPlaying = false;

    [SerializeField] private bool m_SendEventOnFinished;
    [SerializeField] private Event m_Event;

    private void OnEnable()
    {
        CheckDependencies();
        
        if (m_UseSoundCollecionSO)
        {
            CacheAudioClips();
        }
        if (m_PlayOnEnable)
        {
            StartCoroutine(PlaySound());
        }
        
    }

    public void TriggerSound()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(PlaySound());
        }
    }

    private void OnFinishedSendEvent()
    {
        if (!m_Event)
        {
            m_Event = new Event();
            m_Event.name = "Audio_Finished";
        }
        m_Event.Occurred();
    }

    public IEnumerator PlaySound()
    {
        m_Audiosource.pitch = m_RandomizePitch
            ? Random.Range(m_InitialPitch - m_PitchVariation, m_InitialPitch + m_PitchVariation)
            : m_InitialPitch;
        AudioClip clip = m_AudioClips[Random.Range(0, m_AudioClips.Count)];
        m_Audiosource.PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length);
        if (m_SendEventOnFinished)
        {
            OnFinishedSendEvent();
        }
        if (m_DeactivateAfterPlaying)
        {
            gameObject.SetActive(false);
        }
    }

    private void CheckDependencies()
    {
        if (m_Audiosource == null)
        {
            m_Audiosource = GetComponent<AudioSource>();
        }

        if (m_AudioMixerGroup == null)
        {
            Debug.Log("Audio output not assigned in: " + gameObject.name);
        }
        else
        {
            m_Audiosource.outputAudioMixerGroup = m_AudioMixerGroup;
        }

        if (m_SoundCollection == null && m_UseSoundCollecionSO)
        {
            Debug.Log("Sound collection not present in: " + gameObject.name);
        }
    }

    private void CacheAudioClips()
    {
        foreach (AudioClip audioClip in m_SoundCollection.SoundCollection)
        {
            m_AudioClips.Add(audioClip);
        }
    }
}
