using System;
using UnityEngine;

public class CollisionWithGun : MonoBehaviour
{
    [SerializeField] private GameObject[] parts;
    private bool isPosition;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tornillo"))
        {
            other.transform.parent.gameObject.GetComponent<Tornillo>().HideGun();
            foreach (var part in parts)
            {
                part.SetActive(true);
            }
            isPosition = false;   
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Tornillo"))
        {
            ServiceLocator.Instance.GetService<IDebugMediator>().LogL(
                $"Distance {Vector3.Distance(other.transform.position, transform.position)} - " +
                $"Magnitude {(other.transform.forward - transform.forward).magnitude}");
            if (Vector3.Distance(other.transform.position, transform.position) < 0.1f && (other.transform.forward - transform.forward).magnitude <= 0.1f)
            {
                other.transform.parent.gameObject.GetComponent<Tornillo>().ShowGun();
                foreach (var part in parts)
                {
                    part.SetActive(false);
                }
                isPosition = true;   
            }else
            {
                other.transform.parent.gameObject.GetComponent<Tornillo>().HideGun();
                foreach (var part in parts)
                {
                    part.SetActive(true);
                }
                isPosition = false;
            }
        }
        
    }

    public bool StayInPosition()
    {
        return isPosition;
    }
}