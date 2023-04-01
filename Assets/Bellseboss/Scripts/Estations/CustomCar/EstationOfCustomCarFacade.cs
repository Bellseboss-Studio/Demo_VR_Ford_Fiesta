using UnityEngine;

public class EstationOfCustomCarFacade : MonoBehaviour
{
    [SerializeField] private CustomElement ring, color, aleron;
    public void NextRingOfCar()
    {
        ServiceLocator.Instance.GetService<IDebugMediator>().LogR($"before to next function");
        ring.Next();
    }
    public void PreviousRingOfCar()
    {
        ServiceLocator.Instance.GetService<IDebugMediator>().LogR($"before to previous function");
        ring.Previous();
    }
    public void NextColorOfCar()
    {
        color.Next();
    }
    public void PreviousColorOfCar()
    {
        color.Previous();
    }
    public void NextAleronOfCar()
    {
        aleron.Next();
    }
    public void PreviousAleronOfCar()
    {
        aleron.Previous();
    }
}