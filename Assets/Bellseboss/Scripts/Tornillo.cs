using System;
using UnityEngine;

public class Tornillo : MonoBehaviour
{
    [SerializeField] private Transform gunPosition;
    [SerializeField] private GameObject[] parts;

    private void Start()
    {
        HideGun();
    }

    public Vector3 GetGunPosition()
    {
        return gunPosition.position;
    }

    public void HideGun()
    {
        ManagerOfGameObject(false);
    }

    public void ShowGun()
    {
        ManagerOfGameObject(true);
    }

    private void ManagerOfGameObject(bool show)
    {
        foreach (var part in parts)
        {
            part.SetActive(show);
        }
    }
}