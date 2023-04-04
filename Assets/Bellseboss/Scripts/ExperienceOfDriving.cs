using System;
using UnityEngine;

public class ExperienceOfDriving : MonoBehaviour
{
    [SerializeField] private GameObject teleportInDoor, teleportIntoCar, teleportOutOfCar, wheelFake, wheelTruth;
    private bool _stayInTeleportInDoor, _stayIntoCar;

    private void Start()
    {
        teleportIntoCar.SetActive(false);
        teleportInDoor.SetActive(false);
        wheelFake.SetActive(true);
        wheelTruth.SetActive(false);
        teleportOutOfCar.SetActive(false);
    }

    public void EnableTeleportInDoor()
    {
        teleportInDoor.SetActive(true);
    }

    public bool HasTeleportInDoor()
    {
        return _stayInTeleportInDoor;
    }

    public void SetIfStayInTeleportInDoor(bool stay)
    {
        _stayInTeleportInDoor = stay;
    }

    public void EnableTeleportIntoCar()
    {
        teleportIntoCar.SetActive(true);
    }

    public void TeleportIntoCar()
    {
        teleportIntoCar.SetActive(false);
        wheelFake.SetActive(false);
        wheelTruth.SetActive(true);
        _stayIntoCar = true;
    }

    public void GoOutOfCar()
    {
        wheelFake.SetActive(true);
        wheelTruth.SetActive(false);
        EnableTeleportIntoCar();
        _stayIntoCar = false;
    }

    public bool StayIntoCar()
    {
        return _stayIntoCar;
    }

    public void EnableTeleportOutCar()
    {
        teleportOutOfCar.SetActive(true);
    }
}