using System;
using UnityEngine;

public class CollisionWithGun : MonoBehaviour
{
    [SerializeField] private GameObject[] parts;
    [SerializeField] private float tolerance;
    private bool isPosition;

    private Tornillo tornilloInTouch;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tornillo"))
        {
            other.gameObject.GetComponent<Tornillo>().RemoveBolt(false);
            isPosition = false;   
            tornilloInTouch = null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Tornillo"))
        {
            tornilloInTouch = other.gameObject.GetComponent<Tornillo>();
            // Calculate the dot product between the two vectors
            float dotProduct = Vector3.Dot(other.transform.forward, transform.forward);
            // Check if the dot product is close to 1 (within a tolerance)
            var isAligned = Mathf.Abs(dotProduct) < tolerance;
            ServiceLocator.Instance.GetService<IDebugMediator>().LogL(
                $"Distance {Vector3.Distance(other.transform.position, transform.position)} - " + 
                $"isAligned {isAligned} - " +
                $"dotProduct {dotProduct}");
            if (Vector3.Distance(other.transform.position, transform.position) < 0.1f && isAligned)
            {
                isPosition = true;   
            }else
            {
                isPosition = false;
            }
        }
        
    }

    public bool StayInPosition()
    {
        return isPosition;
    }

    internal Tornillo GetTornillo()
    {
        return tornilloInTouch;
    }
}