using System.Collections;
using UnityEngine;

public class AudioIntro : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip customization, driverExperience, doingMechanic;
    [SerializeField] private Animator customizationAnim, driverExperienceAnim, doingMechanicAnim;
    [SerializeField] private GameObject customTeleport, experienceTeleport, doingTeleport;
    private bool _finishedToPlay;
    private int _election;
    public void StartAudio()
    {
        StartCoroutine(PlaySound());
        ShowAllIcons();
    }

    public void ShowAllIcons()
    {
        SetStateOfIcons(true);
    }

    private void SetStateOfIcons(bool isActive)
    {
        customizationAnim.gameObject.SetActive(isActive);
        driverExperienceAnim.gameObject.SetActive(isActive);
        doingMechanicAnim.gameObject.SetActive(isActive);
    }

    public bool HasAudioFinished()
    {
        //ServiceLocator.Instance.GetService<IDebugMediator>().LogL($"audioSource.isPlaying {audioSource.isPlaying}");
        return _finishedToPlay;
    }

    public void StartOptionCarCustomization()
    {
        audioSource.clip = customization;
        StartCoroutine(PlaySound());
    }

    public void StartAnimationCarCustomization()
    {
        //states or directly 
        customizationAnim.SetTrigger("option");
    }

    public void StartOptionDriverExperience()
    {
        audioSource.clip = driverExperience;
        StartCoroutine(PlaySound());
    }

    public void StartAnimationDriverExperience()
    {
        driverExperienceAnim.SetTrigger("option");
    }

    public void StartOptionDoingMechanic()
    {
        audioSource.clip = doingMechanic;
        StartCoroutine(PlaySound());
    }

    public void StartAnimationDoingMechanic()
    {
        doingMechanicAnim.SetTrigger("option");
    }

    private IEnumerator PlaySound()
    {
        audioSource.Play();
        _finishedToPlay = false;
        while (audioSource.isPlaying)
        {
            yield return null;
        }
        _finishedToPlay = true;
    }

    public void SetElection(int e)
    {
        _election = e;
    }

    public int GetElection()
    {
        return _election;
    }

    public void HideAllIcons()
    {
        SetStateOfIcons(false);
    }

    public void HideTeleportsToEnvironment()
    {
        customTeleport.SetActive(false);
        experienceTeleport.SetActive(false);
        doingTeleport.SetActive(false);
    }

    public void ShowTeleport(int index)
    {
        switch (index)
        {
            case 1:
                customTeleport.SetActive(true);
                break;
            case 2:
                experienceTeleport.SetActive(true);
                break;
            case 3:
                doingTeleport.SetActive(true);
                break;
        }
    }
}