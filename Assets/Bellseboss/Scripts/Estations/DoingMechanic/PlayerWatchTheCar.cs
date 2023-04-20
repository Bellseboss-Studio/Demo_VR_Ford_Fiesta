using System;
using UnityEngine;

public class PlayerWatchTheCar : MonoBehaviour
{
    [SerializeField] private CubeLookDetection look;
    internal bool IsWaching()
    {
        return look.isLookingAtCube;
    }

    internal void ShowCubeLookAt()
    {
        look.gameObject.SetActive(true);
    }
    private void Start() {
        look.gameObject.SetActive(false);
    }
}