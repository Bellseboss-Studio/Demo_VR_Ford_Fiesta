using UnityEngine;
using System;

public class ButtonComponentColliderCustom : MonoBehaviour {

    public Action<bool> onTouchButton;
    private void OnTriggerEnter(Collider other) {
        ServiceLocator.Instance.GetService<IDebugMediator>().LogL("Collider enter in button");
        onTouchButton?.Invoke(other.CompareTag("Hand"));
    }
    private void OnTriggerExit(Collider other) {
        ServiceLocator.Instance.GetService<IDebugMediator>().LogL("Collider exit in button");
        onTouchButton?.Invoke(!other.CompareTag("Hand"));
    }
}