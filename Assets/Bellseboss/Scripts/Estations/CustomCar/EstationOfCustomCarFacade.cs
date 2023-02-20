using UnityEngine;

public class EstationOfCustomCarFacade : MonoBehaviour
{
    [SerializeField] private CustomElement ring, color, aleron;
    public void NextRingOfCar()
    {
        ring.Next();
    }
    public void PreviousRingOfCar()
    {
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