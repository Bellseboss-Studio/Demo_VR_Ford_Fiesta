using System;
using UnityEngine;

public class DoingMechanicMono : MonoBehaviour
{
    [SerializeField] private AudioClip clipToFirstStep, soundElevatorCar, SFXButton;
    [SerializeField] private GameObject teleport, teleportForChangeTireOfCar;

    [SerializeField] private AudioSource sourceButton, sourceElevator, sourceGeneral;
    [SerializeField] private ButtonComponent button;
    [SerializeField] private PlayerWatchTheCar waching;

    [SerializeField] private LiftCarWithAnimation liftCar;

    [SerializeField] private ToolBocComponent toolbox;
    [SerializeField] private EmisorComponent pistolEmisorComponent;
    [SerializeField] private ChangeTires listOfTires;
    [SerializeField] private BehaviorOfCylinder behaviorOfCilinder;

    private bool stayInPosition;
    private bool playerTakeInHandHidraulic;

    private bool playerPressButton;

    private bool isPlayerTeleportedInNextToChangeTire;
    private bool isTheFirstBoltRemoved, isAllBoltRemoved;

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
        sourceButton.clip = SFXButton;
        sourceButton.loop = true;
        sourceButton.Play();
    }

    internal void StartSoundToElevetateCar()
    {
        sourceButton.Stop();
        sourceElevator.clip = soundElevatorCar;
        sourceElevator.loop = true;
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
        sourceElevator.Stop();
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
        pistolEmisorComponent.gameObject.SetActive(true);
    }

    internal void ShowTeleportWhentThePlayerWillGoToChangeTireOfCar()
    {
        //StopRotationOFCarAndSetupInAScpecificRotation
        behaviorOfCilinder.ResetRotation();
        teleportForChangeTireOfCar.SetActive(true);
        //Activate Bolt in tire
        foreach(var tire in listOfTires.ElementCurrents){
            var removeBolt = tire.GetComponent<RemoveRimBolts>();
            removeBolt.Configurate();
            removeBolt.onRemoveTheFirstBolt += IsRemovedTheFirstBolt;
            removeBolt.onRemoveAllBolt += RemoveAllBolt;
        }
        pistolEmisorComponent.Disable();
    }

    private void RemoveAllBolt(){
        isAllBoltRemoved = true;
    }

    private void IsRemovedTheFirstBolt(){
        isTheFirstBoltRemoved = true;
    }

    public void IsPlayerNextToChangeTireCar(bool yesOrNot){
        isPlayerTeleportedInNextToChangeTire = yesOrNot;
    }

    internal bool IsPlayerInTeleportNextToCarForChangeOfTire()
    {
        return isPlayerTeleportedInNextToChangeTire;
    }

    internal bool IsPlayerGetOutTheFirstBolt()
    {
        return isTheFirstBoltRemoved;
    }

    internal bool IsAllBoltRemoved()
    {
        return isAllBoltRemoved;
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
