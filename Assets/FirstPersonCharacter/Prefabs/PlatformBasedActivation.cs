using System;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public class PlatformBasedActivation : MonoBehaviour
    {
        [SerializeField] private GameObject[] m_PlayerControllerObjects;       
        private Dictionary<string, GameObject> m_PlayerObjects = new Dictionary<string, GameObject>();
        
        private void Awake()
        {
            foreach (GameObject controllerObject in m_PlayerControllerObjects)
            {
                m_PlayerObjects.Add(controllerObject.name,controllerObject);
                controllerObject.SetActive(false);
            }

           
        }

        void Start()
        {
#if UNITY_EDITOR
            m_PlayerObjects["FPSController"].SetActive(true);
#else
            m_PlayerObjects["XR Origin"].SetActive(true);
#endif
        }
    }
}
