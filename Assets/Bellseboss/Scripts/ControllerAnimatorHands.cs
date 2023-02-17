using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerAnimatorHands : MonoBehaviour
{
    [SerializeField] private InputActionProperty pitchAnimationAction;
    [SerializeField] private InputActionProperty gripAnimationAction;
    [SerializeField] private Animator anim;

    // Update is called once per frame
    void Update()
    {
        var triggerValue = pitchAnimationAction.action.ReadValue<float>();
        anim.SetFloat("Trigger",triggerValue);
        
        var gripValue = gripAnimationAction.action.ReadValue<float>();
        anim.SetFloat("Grip",gripValue);
    }
}
