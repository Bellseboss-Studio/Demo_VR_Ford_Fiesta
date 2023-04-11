using UnityEngine;

public class StatesOfDemo : MonoBehaviour
{
    [SerializeField] private AudioIntro audioIntro;

    [SerializeField] private WaitingForSelectOptionMono waiting;

    [SerializeField] private CarCustomMono carCustom;

    [SerializeField] private ExperienceOfDriving experience;

    [SerializeField] private DoingMechanicMono doingMechanic;

    [SerializeField] private GameObject teleportToGoToBegging;

    private TeaTime _intro, _waitingForChoice, _customizationCar, _experienceOfDriving, _workshopOfChangeTire;
    
    void Start()
    {

        _intro = this.tt().Pause().Add(() =>
            {
                //Sound Play in audio of begin
                GetAudioIntro().StartAudio();
                GetAudioIntro().HideTeleportsToEnvironment();
                ServiceLocator.Instance.GetService<IDebugMediator>().LogL("Start intro");
            })
            .Wait(() => GetAudioIntro().HasAudioFinished(), 0.5f)
            .Add(() =>
            {
                ServiceLocator.Instance.GetService<IDebugMediator>().LogL("Start Car Custom");
                //Play sound the second audio
                GetAudioIntro().StartOptionCarCustomization();
                //activate animation to show the icon
                GetAudioIntro().StartAnimationCarCustomization();
                //first icon
            })
            .Wait(() => GetAudioIntro().HasAudioFinished(), 0.1f)
            .Add(() =>
            {
                ServiceLocator.Instance.GetService<IDebugMediator>().LogL("Start Driver experience");
                //Play sound the third audio
                GetAudioIntro().StartOptionDriverExperience();
                //activate animation to show the icon
                GetAudioIntro().StartAnimationDriverExperience();
                //second icon
            })
            .Wait(() => GetAudioIntro().HasAudioFinished(), 0.1f)
            .Add(() =>
            {
                ServiceLocator.Instance.GetService<IDebugMediator>().LogL("Start Doing mechanic");
                //Play sound the fourth audio
                GetAudioIntro().StartOptionDoingMechanic();
                //activate animation to show the icon
                GetAudioIntro().StartAnimationDoingMechanic();
                //third icon
            })
            .Wait(() => GetAudioIntro().HasAudioFinished(), 0.1f)
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
                audioIntro.HideAllIcons();
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
            }).Wait(()=>true,10)
            .Add(() =>
            {
                ServiceLocator.Instance.GetService<IDebugMediator>().LogL($"Show whats is the next action");
                ServiceLocator.Instance.GetService<IDebugMediator>().LogL($"Mark the tire and tornillo and waiting to start the hidraulic gun");
            })
            .Add(() => _waitingForChoice.Play());
        _intro.Play();
    }

    public TeaTime GetTeaTime()
    {
        return this.tt();
    }

    public void HideOptionsToDoing()
    {
        audioIntro.HideAllIcons();
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

    public AudioIntro GetAudioIntro()
    {
        return audioIntro;
    }

    public WaitingForSelectOptionMono GetWaitingMono()
    {
        return waiting;
    }

    public void ShowButtonToUi()
    {
        audioIntro.ShowAllIcons();
    }

    public void ShowOptionsInBegging()
    {
        ServiceLocator.Instance.GetService<IDebugMediator>().LogL($"ResetAllComponents");
        GetWaitingMono().SetOption(0);
        _waitingForChoice.Restart();
    }
}