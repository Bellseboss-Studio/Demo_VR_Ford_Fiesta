using System.Collections;
using UnityEngine;

public class BaseCanvas : MonoBehaviour
{
    [SerializeField]
    private bool configurateOnAwake;
    [SerializeField]
    private float distanceFromPlayer;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    [Range(0f, 10f)]
    private float rotationTolerance;
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private Vector3 customScale;
    private Transform mainCameraTransform;
    private Camera mainCameraComponent;
    private bool follow;
    private float negativeXAxisTolerance, possitiveXAxisTolerane;
    private bool isVR = false;

    public float DistanceFromPlayer { get => distanceFromPlayer; set => distanceFromPlayer = value; }

    private void Awake()
    {
        if (canvas)
        {
            switch (canvas.renderMode)
            {
                case RenderMode.ScreenSpaceOverlay:
                    canvas.transform.localScale = new Vector3(1, 1, 1);
                    isVR = false;
                    break;
                case RenderMode.ScreenSpaceCamera:
                    break;
                case RenderMode.WorldSpace:
                    canvas.transform.localScale = customScale;
                    isVR = true;
                    break;
                default:
                    break;
            }
        }
        if (Camera.main)
        {
            mainCameraTransform = Camera.main.transform;
            mainCameraComponent = mainCameraTransform.GetComponent<Camera>();
        }
        StartCoroutine(UpdateTransformEndOfFrame());
   
    }
    private void Start()
    {
        negativeXAxisTolerance = 0.5f - rotationTolerance;
        possitiveXAxisTolerane = 0.5f + rotationTolerance;
    }
    private void Update()
    {
      
        if(mainCameraTransform == null && Camera.main != null)
        {
            mainCameraTransform = Camera.main.transform;
            mainCameraComponent = mainCameraTransform.GetComponent<Camera>();
        }

        if (mainCameraTransform != null)
        {
            SetRotation();
            if (!configurateOnAwake)
                SetPosition();
        }

    }

    private IEnumerator UpdateTransformEndOfFrame()
    {
        // Wait until the camera has finished the current frame.
        yield return new WaitForEndOfFrame();

        if (configurateOnAwake)
            UpdateMenuTransform(Camera.main);
    }

    private void SetRotation()
    {
        Vector3 targetDir = mainCameraTransform.position - transform.position;
        float step = rotationSpeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
    private void SetPosition()
    {
        Vector3 screenPos = mainCameraComponent.WorldToViewportPoint(transform.position);
        float distance = Vector3.Distance(transform.position, mainCameraComponent.transform.position);

        if (screenPos.x > possitiveXAxisTolerane || screenPos.x < negativeXAxisTolerance || distance < DistanceFromPlayer * .95f || distance > DistanceFromPlayer * 1.05)
            follow = true;
        else
            follow = false;


        if (follow)
        {
            Vector3 cameraDirection = mainCameraTransform.forward;
            cameraDirection.y = 0;
            if (configurateOnAwake)
                transform.position = mainCameraTransform.position + offset + cameraDirection;
            else
                transform.position = Vector3.Lerp(transform.position, mainCameraTransform.position + offset + cameraDirection * DistanceFromPlayer, Time.deltaTime * 2f);

        }
    }

    public void UpdateMenuTransform(Camera camera)
    {
        // Move the object in front of the camera with specified offsets.

        if (!isVR)
            return;

        Vector3 cameraForward = camera.transform.forward;
        if (cameraForward.z > 0)
            cameraForward.z = 1;
        else
            cameraForward.z = -1;

        Vector3 targetPosition = camera.transform.position + offset + (cameraForward * distanceFromPlayer);
        targetPosition.Set(targetPosition.x, camera.transform.position.y - 0, targetPosition.z);
        transform.position = targetPosition;

    }


}