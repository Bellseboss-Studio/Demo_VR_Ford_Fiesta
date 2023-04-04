using System;
using UnityEngine;

namespace Audio.Scripts
{
    public class PlatformBasedPlayerController : MonoBehaviour
    {
        [SerializeField] private GameObject m_EditorObject;
        [SerializeField] private GameObject m_AndroidObject;
        [SerializeField] private bool m_UseThisCrap;


        private void Awake()
        {
            if (m_UseThisCrap)
            {
                m_AndroidObject.SetActive(false);
                m_EditorObject.SetActive(false);
            }
        }

        void Start()
        {
            if (m_UseThisCrap)
            {
#if UNITY_EDITOR
                m_EditorObject.SetActive(true);
#else
                m_AndroidObject.SetActive(true);
#endif
            }

        }
    }
}
