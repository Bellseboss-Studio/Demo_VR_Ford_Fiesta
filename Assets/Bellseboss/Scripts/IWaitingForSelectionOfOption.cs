public interface IWaitingForSelectionOfOption : IStateOfDemo
{
    WaitingForSelectOptionMono GetWaitingMono();
    void ShowButtonToUi();
}