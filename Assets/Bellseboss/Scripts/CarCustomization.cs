public class CarCustomization : StateInDemo
{
    private readonly ICarCustomization _mediator;

    public CarCustomization(ICarCustomization mediator) : base(mediator)
    {
        _mediator = mediator;
    }

    protected override void CreateState()
    {
        
    }
}