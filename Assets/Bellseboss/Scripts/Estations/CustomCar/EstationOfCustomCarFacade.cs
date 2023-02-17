using UnityEngine;

public class EstationOfCustomCarFacade : MonoBehaviour
{
    [SerializeField] private CustomElement ring, color, aleron;
    public void NextRingOfCar()
    {
        ring.Next();
        Debug.Log("NextRingOfCar");
    }
    public void PreviousRingOfCar()
    {
        ring.Previous();
        Debug.Log("PreviousRingOfCar");
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