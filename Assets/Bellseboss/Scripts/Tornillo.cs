using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Tornillo : MonoBehaviour
{
    [SerializeField] private float timeToActivateToRemoveBolt;
    [SerializeField] private Transform positionToPistol;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float xRange = 5f;
    [SerializeField] private float yRange = 5f;
    public Action onFinishedRemove;
    private Rigidbody rb;
    private float deltaTimeLocal;
    private bool isEnableRemoveBolt;
    private bool isRemoveBolt;

    public bool IsRemovedBolt => isRemoveBolt;

    public Transform PositionToPistol => positionToPistol;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    public void RemoveBolt(bool yesOrNot){
        isEnableRemoveBolt = yesOrNot;
        //ServiceLocator.Instance.GetService<IDebugMediator>().LogL($"Remove Bolt {yesOrNot}");
    }

    private void Update() {
        if(isEnableRemoveBolt && !isRemoveBolt){
            if(deltaTimeLocal >= timeToActivateToRemoveBolt){
                isRemoveBolt = true;
                //ServiceLocator.Instance.GetService<IDebugMediator>().LogL("Remove Bolt");
                onFinishedRemove?.Invoke();
                Jump();
            }
            deltaTimeLocal += Time.deltaTime;
        }
    }
    void Jump()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
        Vector3 jumpDirection = (transform.forward * -1) * Random.Range(-1f, 1f) + transform.up * Random.Range(0f, yRange);
        rb.AddForce(jumpDirection.normalized * jumpForce, ForceMode.Impulse);
    }
}