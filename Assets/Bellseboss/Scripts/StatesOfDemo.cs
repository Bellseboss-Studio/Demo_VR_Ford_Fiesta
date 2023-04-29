using System;
using UnityEngine;
using UnityEngine.Serialization;
using Event = Bellseboss.Audio.Scripts.Event;

public class StatesOfDemo : MonoBehaviour
{
    [FormerlySerializedAs("audioIntro")] [SerializeField] private AnimationManager animationManager;

    [SerializeField] private AudioSequencer m_AudioSequencer;
    
    [SerializeField] private WaitingForSelectOptionMono waiting;

    [SerializeField] private CarCustomMono carCustom;

    [SerializeField] private ExperienceOfDriving experience;

    [SerializeField] private DoingMechanicMono doingMechanic;

    [SerializeField] private GameObject teleportToGoToBegging;

    private TeaTime _intro, _waitingForChoice, _customizationCar, _experienceOfDriving, _workshopOfChangeTire, _waitingForWantExitOrStayInExperience, _wantGoBackToBeging;

    private void Awake()
    {
        CheckDependencies();
    }

    void Start()
    {
        
        _intro = this.tt().Pause().Add(() =>
            {
                //Sound Play in audio of begin
                SetAnimAndIcons().ShowAllIcons();
                PlayVOStepAudio().PlayInitialAudio();
                SetAnimAndIcons().HideTeleportsToEnvironment();
                ServiceLocator.Instance.GetService<IDebugMediator>().LogL("Start intro");
            })
            .Wait(() => PlayVOStepAudio().HasAudioFinished(), 0.5f)
            .Add(() =>
            {
                ServiceLocator.Instance.GetService<IDebugMediator>().LogL("Start Car Custom");
                //Play sound the second audio
                PlayVOStepAudio().PlayOptionCarCustomizationAudio();
               //activate animation to show the icon
                SetAnimAndIcons().StartAnimationCarCustomization();
                //first icon
            })
            .Wait(() => PlayVOStepAudio().HasAudioFinished(), 0.1f)
            .Add(() =>
            {
                ServiceLocator.Instance.GetService<IDebugMediator>().LogL("Start Driver experience");
                //Play sound the third audio
                PlayVOStepAudio().PlayDriverExperienceAudio();
                //activate animation to show the icon
                SetAnimAndIcons().StartAnimationDriverExperience();
                //second icon
            })
            .Wait(() => PlayVOStepAudio().HasAudioFinished(), 0.1f)
            .Add(() =>
            {
                ServiceLocator.Instance.GetService<IDebugMediator>().LogL("Start Doing mechanic");
                //Play sound the fourth audio
                PlayVOStepAudio().PlayOptionMechanicExperienceAudio();
                //activate animation to show the icon
                SetAnimAndIcons().StartAnimationDoingMechanic();
                //third icon
            })
            .Wait(() => PlayVOStepAudio().HasAudioFinished(), 0.1f)
            .Add(() => _waitingForChoice.Play());

        _waitingForChoice = this.tt().Pause()
            .Add(() =>
            {
                ServiceLocator.Instance.GetService<IDebugMediator>().LogL($"Start Waiting");
                ShowButtonToUi();
                waiting.SetOption(0);
            })
            .Wait(() => GetWaitingMono().HasSelectedAnything(), 0.1f).Add(() =>
            {
                switch (GetWaitingMono().GetOption())
                {
                    case 1:
                        _customizationCar.Play();
                        break;
                    case 2:
                        _experienceOfDriving.Play();
                        break;
                    case 3:
                        _workshopOfChangeTire.Play();
                        break;
                    default:
                        break;
                }
            });

        _customizationCar = this.tt().Pause()
            .Add(() =>
            {
                HideOptionsToDoing();
                HideTeleportToGoToBegging();
                GetCarCustomMono().ShowPointToTeleport();
            })
            .Add(() =>
            {
                GetCarCustomMono().EnablePanelAndMechanics();
                GetCarCustomMono().StartExplanationInAudio();
            }).Wait(() => GetCarCustomMono().WannaGoingToOtherPlace(), 0.1f)
            .Add(() =>
            {
                //Reset all position
                GetCarCustomMono().HidePointToTeleport();
                ShowTeleportToGoToBegging();
                GetCarCustomMono().DisablePanelAndMechanics();
            })
            .Add(() => _waitingForChoice.Play());

        _experienceOfDriving = this.tt().Pause()
            .Add(() =>
            {
                experience.EnableTeleportInDoor();
                animationManager.HideAllIcons();
                HideTeleportToGoToBegging();
            }).Wait(()=>experience.HasTeleportInDoor(),0.5f)
            .Add(() =>
            {
                //Enable teleport into car
                experience.EnableTeleportIntoCar();
            })
            .Wait(()=>experience.StayIntoCar(),0.1f)
            .Add(() =>
            {
                //Stay into car
                experience.EnableTeleportOutCar();
            })
            .Wait(()=>!experience.StayIntoCar(),0.5f)
            .Add(() =>
            {
                teleportToGoToBegging.SetActive(true);
            })
            .Add(() => _waitingForChoice.Play());

        _workshopOfChangeTire = this.tt().Pause()
            .Add(() =>
            {
                doingMechanic.EnableTeleport();
                HideTeleportToGoToBegging();
                animationManager.HideAllIcons();
            }).Wait(()=>doingMechanic.StayInPositionToDoing(),0.5f)
            .Add(() =>
            {
                doingMechanic.SayWhatIsTheNextStep();//audio para decirle que Precione el boton
                doingMechanic.ShowButton();
            }).Wait(()=>doingMechanic.IsPlayerPressButton(), 0.5f)
            .Add(()=>{
                //Elevate the car
                doingMechanic.StartSoundToElevetateCar();
            })
            .Wait(()=>doingMechanic.IsPlayerWatchingTheCar(), 0.5f)
            .Add(()=>{
                doingMechanic.StartToLiftTheCar();
            })
            .Wait(()=>doingMechanic.IsFinishedToLiftTheCar(), 0.5f)
            .Add(()=>{
                doingMechanic.StartSoundFromToolBox();
            })
            .Wait(()=>doingMechanic.IsPlayerTouchTheToolBox(),0.5f)
            .Add(()=>{
                doingMechanic.StartAnimationToToolBox();
            })
            .Wait(()=>doingMechanic.IsFinishedTheAnimationOfToolBox(), 0.5f)
            .Add(()=>{
                doingMechanic.ShowSphereIntoPistol();
            })
            .Wait(()=>doingMechanic.PlayerTakeTheHidraulic(), 0.5f)
            .Add(()=>{
                doingMechanic.SayWhatIsTheNextStep();//audio para decirle que tome el coso
                doingMechanic.ShowTeleportWhentThePlayerWillGoToChangeTireOfCar();
            })
            .Wait(()=>doingMechanic.IsPlayerInTeleportNextToCarForChangeOfTire(), 0.5f)
            .Add(()=>{
                //audio para decirle que active el taladro y lo coloque en el perno para sacar el tornillo
                doingMechanic.SayWhatIsTheNextStep();
            })
            .Wait(()=>doingMechanic.IsPlayerGetOutTheFirstBolt())
            .Add(()=>{
                //Say good job and retired the next bolt
                doingMechanic.SayWhatIsTheNextStep();
            })
            .Wait(()=>doingMechanic.IsAllBoltRemoved(), 0.5f)
            .Add(()=>{
                //Dice que ahora debe de quitar la llanta y la coloque en el sitio
                doingMechanic.SayWhatIsTheNextStep();
                doingMechanic.ShowTheAreaWhentPlayerLeaveTheTireInThePlace();
            })
            .Wait(()=>doingMechanic.IsTireRemovedInTheCorrectPlace(), 0.5f)
            .Add(()=>{
                //Dice: que ahora mire el espacio que quedo.
                doingMechanic.SayWhatIsTheNextStep();
            })
            .Wait(()=>doingMechanic.IsPlayerWatchingTheEmptyZone(),0.5f)
            .Add(()=>{
                doingMechanic.StartAnimationToBreakSystem();
                _waitingForWantExitOrStayInExperience.Play();
            });

            _waitingForWantExitOrStayInExperience = this.tt().Pause()
            .Wait(()=>doingMechanic.IsPlayerWatchAllComponentsOrWatchTheBegingOfExperience(), 0.5f)
            .Add(()=>{
                doingMechanic.ShowQuestionIfWantGoToTheBeginOfExperience();
            })
            .Wait(()=>doingMechanic.IsPlayerDecidedForAnyOption(), 0.5f)
            .Add(() => {
                ServiceLocator.Instance.GetService<IDebugMediator>().LogR($"User Selected {doingMechanic.WhatWasTheOptionSelected()}");
                switch(doingMechanic.WhatWasTheOptionSelected()){
                    case 0://Stay In Tire Change
                        _waitingForWantExitOrStayInExperience.Restart();
                        break;
                    case 1://Want to exit
                        _wantGoBackToBeging.Restart();
                        break;
                }
            });
        _wantGoBackToBeging = this.tt().Pause()
        .Add(()=>{
            ShowTeleportToGoToBegging();
        })
        .Wait(()=>IsPlayerTeleportIntoBeging(), 0.5f);

        
        _intro.Play();
    }

    

    private bool isPlayerTeleportingToBeging;

    public void PlayerTeleportingToBeging(bool yesOrNot){
        isPlayerTeleportingToBeging = yesOrNot;
    }

    private bool IsPlayerTeleportIntoBeging()
    {
        return isPlayerTeleportingToBeging;
    }

    public TeaTime GetTeaTime()
    {
        return this.tt();
    }

    public void HideOptionsToDoing()
    {
        animationManager.HideAllIcons();
    }

    public CarCustomMono GetCarCustomMono()
    {
        return carCustom;
    }

    public void ShowTeleportToGoToBegging()
    {
        teleportToGoToBegging.SetActive(true);
    }

    public void HideTeleportToGoToBegging()
    {
        teleportToGoToBegging.SetActive(false);
    }

    public AnimationManager SetAnimAndIcons()
    {
        return animationManager;
    }
    public AudioSequencer PlayVOStepAudio()
    {
        return m_AudioSequencer;
    }
    public WaitingForSelectOptionMono GetWaitingMono()
    {
        return waiting;
    }

    public void ShowButtonToUi()
    {
        animationManager.ShowAllIcons();
    }

    public void ShowOptionsInBegging()
    {
        ServiceLocator.Instance.GetService<IDebugMediator>().LogL($"ResetAllComponents");
        GetWaitingMono().SetOption(0);
        _waitingForChoice.Restart();
    }
    
    private void CheckDependencies()
    {
        if (m_AudioSequencer == null)
        {
            m_AudioSequencer = FindObjectOfType<AudioSequencer>();
        }
    }
}