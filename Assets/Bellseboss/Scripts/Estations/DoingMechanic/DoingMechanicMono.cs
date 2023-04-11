using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoingMechanicMono : MonoBehaviour
{
    [SerializeField] private GameObject teleport;

    private bool stayInPosition;
    internal void EnableTeleport()
    {
        teleport.SetActive(true);
    }

    internal bool StayInPositionToDoing()
    {
        return stayInPosition;
    }

    public void SetStayInPosition(bool stay){
        stayInPosition = stay;
    }
}
