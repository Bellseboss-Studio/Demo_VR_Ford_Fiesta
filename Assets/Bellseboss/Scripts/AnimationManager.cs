using System.Collections;
using UnityEngine;
using Event = Bellseboss.Audio.Scripts.Event;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private Animator customizationAnim, driverExperienceAnim, doingMechanicAnim;
    [SerializeField] private GameObject customTeleport, experienceTeleport, doingTeleport;
    private bool _finishedToPlay;
    private int _election;
    
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

    public void NotifyAudioFinished()
    {
        _finishedToPlay = true;
        HasAudioFinished();
    }
    
    public void StartAnimationCarCustomization()
    {
        //states or directly 
        customizationAnim.SetTrigger("option");
    }
    
    public void StartAnimationDriverExperience()
    {
        driverExperienceAnim.SetTrigger("option");
    }
    
    public void StartAnimationDoingMechanic()
    {
        doingMechanicAnim.SetTrigger("option");
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