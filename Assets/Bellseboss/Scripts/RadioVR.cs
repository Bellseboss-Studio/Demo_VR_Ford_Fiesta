using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class RadioVR : MonoBehaviour
{
    [SerializeField] private XRSimpleInteractable interactable;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip[] clips;
    private bool isActivate;
    private int index;
    

    private void Start()
    {
        interactable.selectEntered.AddListener(arg =>
        {
            ServiceLocator.Instance.GetService<IDebugMediator>().LogL("ClickIn");
        });
        interactable.selectExited.AddListener(arg =>
        {
            ServiceLocator.Instance.GetService<IDebugMediator>().LogL("ClickOut and active music");
            source.volume = !isActivate ? 1 : 0;
            isActivate = !isActivate;
        });
        
    }

    public void NextSong()
    {
        UpdateClip();
        index++;
        if (index > clips.Length - 1)
        {
            index = 0;
        }
    }

    private void UpdateClip()
    {
        source.clip = clips[index];
    }

    public void PreviousSong()
    {
        UpdateClip();
        index--;
        if (index < 0)
        {
            index = clips.Length - 1;
        }
    }
}