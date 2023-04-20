using UnityEngine;

public class CubeLookDetection : MonoBehaviour
{
    public Transform playerCamera;
    public float maxDistance = 10f;
    public LayerMask detectionLayer;

    public bool isLookingAtCube;

    void Update()
    {
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance, detectionLayer))
        {
            if (hit.collider.gameObject == gameObject)
            {
                isLookingAtCube = true;
            }
            else
            {
                isLookingAtCube = false;
            }
        }
        else
        {
            isLookingAtCube = false;
        }

        // Do something with isLookingAtCube
        ServiceLocator.Instance.GetService<IDebugMediator>().LogR($"isLookingAtCube {isLookingAtCube}");
    }
}
