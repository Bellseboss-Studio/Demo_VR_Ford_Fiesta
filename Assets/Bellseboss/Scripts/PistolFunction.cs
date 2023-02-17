using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PistolFunction : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    [SerializeField] private Transform spawn;

    [SerializeField] private float speed = 20;
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(arg =>
        {
            var bulletSpawn = Instantiate(bullet);
            var position = spawn.position;
            bulletSpawn.transform.position = position;
            bulletSpawn.GetComponent<Rigidbody>().velocity = spawn.forward * speed;
            Destroy(bulletSpawn, 10);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
