using UnityEngine;
using System.Collections;
using Event = Bellseboss.Audio.Scripts.Event;

public class AudioSequencer : MonoBehaviour
{
    private bool _finishedToPlay;
    
    [SerializeField] public GameObject[] m_AudioSteps;


    #region AudioSteps
    public void PlayInitialAudio()
    {
        StartCoroutine(ActivateAudioSource(m_AudioSteps[0]));
    }
    public void PlayOptionCarCustomizationAudio()
    {
        StartCoroutine(ActivateAudioSource(m_AudioSteps[1]));
    }
    public void PlayDriverExperienceAudio()
    {
        StartCoroutine(ActivateAudioSource(m_AudioSteps[2]));
    }
    public void PlayOptionMechanicExperienceAudio()
    {
        StartCoroutine(ActivateAudioSource(m_AudioSteps[3]));
    }
    
    #endregion AudioSteps

    public bool HasAudioFinished()
    {
        return _finishedToPlay;
    }
    private IEnumerator ActivateAudioSource(GameObject go)
    {
        //audioSource.Play();
        go.SetActive(true);
        _finishedToPlay = false;
        while (go.activeInHierarchy)
        {
            yield return null;
        }
        _finishedToPlay = true;
    }
}
