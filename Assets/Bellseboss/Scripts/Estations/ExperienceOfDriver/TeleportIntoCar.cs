using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportIntoCar : MonoBehaviour
{
    [SerializeField] private GameObject player, parentTarget;
    public void OnTeleport(TeleportingEventArgs arg)
    {
        
        player.transform.SetParent(parentTarget.transform);
    }
    
    public void OnTeleportOut(TeleportingEventArgs arg)
    {
        
        player.transform.SetParent(null);
    }
    public void OnActivate(ActivateEventArgs arg)
    {
        
    }
    
}
