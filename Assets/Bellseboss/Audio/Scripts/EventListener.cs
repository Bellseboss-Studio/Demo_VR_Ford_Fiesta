using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace Bellseboss.Audio.Scripts
{
    [Serializable]
    public class EventListener : MonoBehaviour
    {
        public Event GameEvent;
        public UnityEvent response;

        private void OnEnable()
        {
            GameEvent.Register(this);
        }

        public void OnDisable()
        {
            GameEvent.Unregister(this);
        }
        public void OnEventOccurs()
        {
            response.Invoke();
        }
        
    }
}
