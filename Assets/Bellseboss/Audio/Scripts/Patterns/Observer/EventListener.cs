using System;
using UnityEngine;
using UnityEngine.Events;

namespace Bellseboss.Audio.Scripts
{
    [Serializable]
    public class EventListener : MonoBehaviour
    {
        [SerializeField] private Event m_GameEvent;
        [SerializeField] private UnityEvent m_Response;

        private void OnEnable()
        {
            if (m_GameEvent != null)
            {
                m_GameEvent.Register(this);
            }
        }

        public void OnDisable()
        {
            if (m_GameEvent != null)
            {
                m_GameEvent.Unregister(this);
            }
        }
        public void OnEventOccurs()
        {
            m_Response.Invoke();
        }
    }
}
