using UnityEngine;

public class ObjectInAllTimeInFrontOfPlayer : MonoBehaviour
{
    [SerializeField] private Transform pointTarget, pointToFollow, player;

    public void ActivatePanel(bool active)
    {
        pointToFollow.gameObject.SetActive(active);
    }

    private void Update()
    {
        var position = pointTarget.position;
        var position2 = pointToFollow.position;
        position2 = new Vector3(position.x, position2.y, position.z);
        pointToFollow.position = position2;
        var position1 = player.position;
        pointToFollow.LookAt(new Vector3(position1.x, position2.y,position1.z));
        pointToFollow.forward *= -1;
    }
}
