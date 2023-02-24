public class AudioIntroAndShowIcons : StateInDemo
{
    private readonly IBeggingState _mediator;
    private bool _firstPartIsFinished;
    private bool _secondPartIsFinished;
    private bool _thirdPartIsFinished;
    private bool _fourthPartIsFinished;
    
    public AudioIntroAndShowIcons(IBeggingState mediator) : base(mediator)
    {
        _mediator = mediator;
    }

    protected override void CreateState()
    {
        _state.Pause().Add(() =>
            {
                //Sound Play in audio of begin
                _mediator.GetAudioIntro().StartAudio();
                _mediator.GetAudioIntro().HideTeleportsToEnvironment();
                ServiceLocator.Instance.GetService<IDebugMediator>().LogL("Start intro");
            })
            .Wait(() => _mediator.GetAudioIntro().HasAudioFinished(), 0.1f)
            .Add(() =>
            {
                ServiceLocator.Instance.GetService<IDebugMediator>().LogL("Start Car Custom");
                //Play sound the second audio
                _mediator.GetAudioIntro().StartOptionCarCustomization();
                //activate animation to show the icon
                _mediator.GetAudioIntro().StartAnimationCarCustomization();
                //first icon
            })
            .Wait(() => _mediator.GetAudioIntro().HasAudioFinished(), 0.1f)
            .Add(() =>
            {
                ServiceLocator.Instance.GetService<IDebugMediator>().LogL("Start Driver experience");
                //Play sound the third audio
                _mediator.GetAudioIntro().StartOptionDriverExperience();
                //activate animation to show the icon
                _mediator.GetAudioIntro().StartAnimationDriverExperience();
                //second icon
            })
            .Wait(() => _mediator.GetAudioIntro().HasAudioFinished(), 0.1f)
            .Add(() =>
            {
                ServiceLocator.Instance.GetService<IDebugMediator>().LogL("Start Doing mechanic");
                //Play sound the fourth audio
                _mediator.GetAudioIntro().StartOptionDoingMechanic();
                //activate animation to show the icon
                _mediator.GetAudioIntro().StartAnimationDoingMechanic();
                //third icon
            })
            .Wait(() => _mediator.GetAudioIntro().HasAudioFinished(), 0.1f);
    }
}