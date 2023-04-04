using UnityEngine;

public class TestToColliderWithWheel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ServiceLocator.Instance.GetService<IDebugMediator>().LogR($"trigger {name} with {other.gameObject.name}");
    }

    private void OnCollisionEnter(Collision collision)
    {
        ServiceLocator.Instance.GetService<IDebugMediator>().LogR($"collision {name} with {collision.gameObject.name}");
    }
}