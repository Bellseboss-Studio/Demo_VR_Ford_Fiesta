using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoingMechanicMono : MonoBehaviour
{
    [SerializeField] private GameObject teleport;

    private bool stayInPosition;
    private bool playerTakeInHandHidraulic;
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

    public void SayWhatIsTheNextStep(){
        //Enable audio to what is the next step
    }

    internal bool PlayerTakeTheHidraulic()
    {
        return playerTakeInHandHidraulic;
    }

    public void PlayerTakeTheHidraulicInHand(bool yesOrNot){
        playerTakeInHandHidraulic = yesOrNot;
    }
}
