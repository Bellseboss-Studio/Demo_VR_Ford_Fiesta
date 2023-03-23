public class CarCustomization : StateInDemo
{
    private readonly ICarCustomization _mediator;

    public CarCustomization(ICarCustomization mediator) : base(mediator)
    {
        _mediator = mediator;
    }

    protected override void CreateState()
    {
        _state.Pause()
            .Add(() =>
            {
                _mediator.HideOptionsToDoing();
                _mediator.HideTeleportToGoToBegging();
                _mediator.GetCarCustomMono().ShowPointToTeleport();
            })
            .Add(() =>
            {
                _mediator.GetCarCustomMono().EnablePanelAndMechanics();
                _mediator.GetCarCustomMono().StartExplanationInAudio();
            }).Wait(()=>_mediator.GetCarCustomMono().WannaGoingToOtherPlace(), 0.1f)
            .Add(() =>
            {
                //Reset all position
                _mediator.GetCarCustomMono().HidePointToTeleport();
                _mediator.ShowTeleportToGoToBegging();
                _mediator.GetCarCustomMono().DisablePanelAndMechanics();
            });
    }
}