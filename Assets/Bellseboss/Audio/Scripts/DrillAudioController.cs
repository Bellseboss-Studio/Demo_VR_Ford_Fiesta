using System;
using System.Collections;
using System.Collections.Generic;
using Bellseboss.Audio.Scripts;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
public class DrillAudioController : MonoBehaviour
{
    [Header("Audioclips")] 
    [SerializeField] private AudioClip m_Start;
    [SerializeField] private AudioClip m_Run;
    [SerializeField] private AudioClip m_End;

    private bool m_IsPressed; 

    [Header("Audiosource")] 
    [SerializeField] private AudioSource m_As;
    
    private float m_StartSoundLength;

    private void Awake()
    {
        m_StartSoundLength =  m_Start.length;
    }
    
    public void PlayDrillSoundSequence()
    {
        m_IsPressed = true;
        StartCoroutine(nameof(ActivateDrillAudio));
    }
    private void PlayRunSound()
    {
        m_As.loop = true;
        m_As.clip = m_Run;
        m_As.Play();
    }
    public void PlayEndReleaseSound()
    {
        m_IsPressed = false;
        m_As.loop = false;
        m_As.Stop();
        m_As.PlayOneShot(m_End);
    }
    private IEnumerator ActivateDrillAudio()
    {
        if (m_As.isPlaying)
        {
            m_As.Stop();
        }
        m_As.PlayOneShot(m_Start);
        yield return new WaitForSeconds(m_StartSoundLength);
        if (m_IsPressed)
        {
            PlayRunSound();  
        }
    }
}

