public class WaitingForSelectOption : StateInDemo
{
    private readonly IWaitingForSelectionOfOption _mediator;

    public WaitingForSelectOption(IWaitingForSelectionOfOption mediator) : base(mediator)
    {
        _mediator = mediator;
    }

    protected override void CreateState()
    {
        _state.Pause()
            .Add(() =>
            {
                ServiceLocator.Instance.GetService<IDebugMediator>().LogL($"Start Waiting");
                _mediator.ShowButtonToUi();
            })
            .Wait(() => _mediator.GetWaitingMono().HasSelectedAnything(), 0.1f);
    }
    
    public int Selection()
    {
        return _mediator.GetWaitingMono().GetOption();
    }

    public void SetSelection(int newOption)
    {
        _mediator.GetWaitingMono().SetOption(newOption);
    }
}