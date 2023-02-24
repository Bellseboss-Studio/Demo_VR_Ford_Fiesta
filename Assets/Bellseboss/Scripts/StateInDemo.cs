public abstract class StateInDemo
{
    protected readonly IStateOfDemo _mediator;
    protected TeaTime _state;

    public StateInDemo(IStateOfDemo mediator)
    {
        _mediator = mediator;
        _state = _mediator.GetTeaTime();
        CreateState();
    }

    protected abstract void CreateState();

    public TeaTime GetTeaTime()
    {
        return _state;
    }
}