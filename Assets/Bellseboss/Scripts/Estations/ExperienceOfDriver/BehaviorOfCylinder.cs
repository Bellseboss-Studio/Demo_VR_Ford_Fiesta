using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorOfCylinder : MonoBehaviour
{
    [SerializeField] private GameObject cylinder;

    // Update is called once per frame
    void Update()
    {
        cylinder.transform.eulerAngles = new Vector3(cylinder.transform.eulerAngles.x,cylinder.transform.eulerAngles.y + 0.1f, cylinder.transform.eulerAngles.z);
    }
}
