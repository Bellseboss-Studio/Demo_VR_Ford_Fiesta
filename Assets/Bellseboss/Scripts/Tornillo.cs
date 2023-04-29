    using System;
using UnityEngine;

public class Tornillo : MonoBehaviour
{
    [SerializeField] private float timeToActivateToRemoveBolt;
    [SerializeField] private Transform positionToPistol;
    public Action onFinishedRemove;
    private float deltaTimeLocal;
    private bool isEnableRemoveBolt;
    private bool isRemoveBolt;

    public bool IsRemovedBolt => isRemoveBolt;

    public Transform PositionToPistol => positionToPistol;

    public void RemoveBolt(bool yesOrNot){
        isEnableRemoveBolt = yesOrNot;
    }

    private void Update() {
        if(isEnableRemoveBolt && !isRemoveBolt){
            if(deltaTimeLocal >= timeToActivateToRemoveBolt){
                isRemoveBolt = true;
                onFinishedRemove?.Invoke();
            }
            deltaTimeLocal += Time.deltaTime;
        }
    }
}