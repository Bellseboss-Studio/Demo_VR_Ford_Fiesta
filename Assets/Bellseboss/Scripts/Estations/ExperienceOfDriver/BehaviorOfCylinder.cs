using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorOfCylinder : MonoBehaviour
{
    [SerializeField] private GameObject cylinder;
    private bool canRotate = true;
    public void ResetRotation(){
        //transform.eulerAngles = Vector3.zero;
        canRotate = false;
        StartCoroutine(ResetRotationCorrutine(gameObject));
    }
    // Define the duration of the transition
    public float transitionDuration = 1.0f;

    // Coroutine to reset the rotation of a game object
    private IEnumerator ResetRotationCorrutine(GameObject obj)
    {
        // Get the transform component of the game object
        Transform transform = obj.GetComponent<Transform>();

        // Get the current rotation of the game object
        Quaternion startRotation = transform.rotation;

        // Define the end rotation as zero
        Quaternion endRotation = Quaternion.identity;

        // Define the elapsed time variable
        float elapsedTime = 0.0f;

        // Loop until the transition is complete
        while (elapsedTime < transitionDuration)
        {
            // Interpolate between the start and end rotations
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, elapsedTime / transitionDuration);

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }

        // Set the final rotation to zero
        transform.rotation = endRotation;
    }


    // Update is called once per frame
    void Update()
    {
        if(!canRotate) return;
        cylinder.transform.eulerAngles = new Vector3(cylinder.transform.eulerAngles.x,cylinder.transform.eulerAngles.y + 0.1f, cylinder.transform.eulerAngles.z);
    }
}
