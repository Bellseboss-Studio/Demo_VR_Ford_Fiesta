using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportIntoCar : MonoBehaviour
{
    [SerializeField] private GameObject player, parentTarget;
    [SerializeField] private GameObject[] objectsToActivate, objectsToDisable;
    public void OnTeleport(TeleportingEventArgs arg)
    {
        foreach (var o in objectsToActivate)
        {
            o.SetActive(true);
        }
        foreach (var o in objectsToDisable)
        {
            o.SetActive(false);
        }
        player.transform.SetParent(parentTarget.transform);
    }
    
    public void OnTeleportOut(TeleportingEventArgs arg)
    {
        
        foreach (var o in objectsToActivate)
        {
            o.SetActive(false);
        }
        foreach (var o in objectsToDisable)
        {
            o.SetActive(true);
        }
        player.transform.SetParent(null);
    }
    public void OnActivate(ActivateEventArgs arg)
    {
        
    }
    
}
