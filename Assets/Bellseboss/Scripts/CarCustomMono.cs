using UnityEngine;

public class CarCustomMono : MonoBehaviour
{
    [SerializeField] private GameObject panel, teleportPoint;
    [SerializeField] private AudioSource audioSource;

    private bool _wannaGoingToOtherPlace;

    public void ExitToCarCustomization()
    {
        _wannaGoingToOtherPlace = true;
    }
    private void Start()
    {
        panel.SetActive(false);
    }

    public void EnablePanelAndMechanics()
    {
        panel.SetActive(true);
        _wannaGoingToOtherPlace = false;
    }

    public void ShowPointToTeleport()
    {
        teleportPoint.SetActive(true);
    }

    public void StartExplanationInAudio()
    {
        audioSource.Play();        
    }

    public bool WannaGoingToOtherPlace()
    {
        return _wannaGoingToOtherPlace;
    }

    public void HidePointToTeleport()
    {
        teleportPoint.SetActive(false);
    }

    public void DisablePanelAndMechanics()
    {
        panel.SetActive(false);
    }
}