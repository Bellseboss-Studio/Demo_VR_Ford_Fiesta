using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class RadioVR : MonoBehaviour
{
    [SerializeField] private XRSimpleInteractable interactable;
    [SerializeField] private AudioSource source;
    private bool isActivate;
    

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
}