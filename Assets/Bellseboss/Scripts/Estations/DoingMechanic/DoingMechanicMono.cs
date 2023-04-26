using System;
using UnityEngine;

public class DoingMechanicMono : MonoBehaviour
{
    [SerializeField] private AudioClip clipToFirstStep, soundElevatorCar, SFXButton;
    [SerializeField] private GameObject teleport;

    [SerializeField] private AudioSource sourceButton, sourceElevator, sourceGeneral;
    [SerializeField] private ButtonComponent button;
    [SerializeField] private PlayerWatchTheCar waching;

    [SerializeField] private LiftCarWithAnimation liftCar;

    [SerializeField] private ToolBocComponent toolbox;

    private bool stayInPosition;
    private bool playerTakeInHandHidraulic;

    private bool playerPressButton;

    private void Start() {
        button.onButtonPress.AddListener(()=>{
            playerPressButton = true;
        });
        button.onButtonRelease.AddListener(()=>{
            playerPressButton = false;
        });
        button.gameObject.SetActive(false);
    }
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
        sourceGeneral.PlayOneShot(clipToFirstStep);
        sourceButton.clip = SFXButton;
        sourceButton.Play();
    }

    internal bool PlayerTakeTheHidraulic()
    {
        return playerTakeInHandHidraulic;
    }

    public void PlayerTakeTheHidraulicInHand(bool yesOrNot){
        playerTakeInHandHidraulic = yesOrNot;
    }

    public bool IsPlayerPressButton()
    {
        return playerPressButton;
    }

    internal void ShowButton()
    {
        button.gameObject.SetActive(true);
    }

    internal void StartSoundToElevetateCar()
    {
        sourceElevator.clip = soundElevatorCar;
        sourceElevator.Play();
        waching.ShowCubeLookAt();
    }

    internal bool IsPlayerWatchingTheCar()
    {
        return waching.IsWaching();
    }

    internal void StartToLiftTheCar()
    {
        waching.HideCubeLookAt();
        liftCar.StartLift();
    }

    internal bool IsFinishedToLiftTheCar()
    {
        return liftCar.IsFinishedTheAnimation;
    }

    internal void StartSoundFromToolBox()
    {
        toolbox.StartSoundForWatch();
    }

    internal bool IsPlayerTouchTheToolBox()
    {
        return toolbox.IsToolBoxTouched();
    }

    internal void StartAnimationToToolBox()
    {
        toolbox.StartAnimationToOpenBox();
    }

    internal bool IsFinishedTheAnimationOfToolBox()
    {
        return toolbox.IsAnimationToOpenToolBoxFinished();
    }

    internal void ShowSphereIntoPistol()
    {
        throw new NotImplementedException();
    }

    internal void ShowTeleportWhentThePlayerWillGoToChangeTireOfCar()
    {
        throw new NotImplementedException();
    }

    internal bool IsPlayerInTeleportNextToCarForChangeOfTire()
    {
        throw new NotImplementedException();
    }

    internal bool IsPlayerGetOutTheFirstBolt()
    {
        throw new NotImplementedException();
    }

    internal bool IsAllBoltRemoved()
    {
        throw new NotImplementedException();
    }

    internal void ShowTheAreaWhentPlayerLeaveTheTireInThePlace()
    {
        throw new NotImplementedException();
    }

    internal bool IsTireRemovedInTheCorrectPlace()
    {
        throw new NotImplementedException();
    }

    internal bool IsPlayerWatchingTheEmptyZone()
    {
        throw new NotImplementedException();
    }

    internal void StartAnimationToBreakSystem()
    {
        throw new NotImplementedException();
    }

    internal bool IsPlayerWatchAllComponentsOrWatchTheBegingOfExperience()
    {
        throw new NotImplementedException();
    }

    internal void ShowQuestionIfWantGoToTheBeginOfExperience()
    {
        throw new NotImplementedException();
    }

    internal bool IsPlayerDecidedForAnyOption()
    {
        throw new NotImplementedException();
    }

    internal int WhatWasTheOptionSelected()
    {
        throw new NotImplementedException();
    }
}
