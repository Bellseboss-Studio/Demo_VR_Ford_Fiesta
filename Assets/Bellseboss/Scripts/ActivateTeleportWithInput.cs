using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTeleportWithInput : MonoBehaviour
{
    [SerializeField] private GameObject leftTeleport, rightTeleport;
    [SerializeField] private InputActionProperty leftActivate, rightActivate;

    // Update is called once per frame
    void Update()
    {
        leftTeleport.SetActive(leftActivate.action.ReadValue<float>() > 0.1f);
        //rightTeleport.SetActive(rightActivate.action.ReadValue<float>() > 0.1f);
    }
}
