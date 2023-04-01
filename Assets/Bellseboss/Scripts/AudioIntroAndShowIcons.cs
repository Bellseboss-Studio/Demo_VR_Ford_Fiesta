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
        
    }
}