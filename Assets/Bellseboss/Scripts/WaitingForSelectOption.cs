public class WaitingForSelectOption : StateInDemo
{
    private readonly IWaitingForSelectionOfOption _mediator;

    public WaitingForSelectOption(IWaitingForSelectionOfOption mediator) : base(mediator)
    {
        _mediator = mediator;
    }

    protected override void CreateState()
    {
        
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