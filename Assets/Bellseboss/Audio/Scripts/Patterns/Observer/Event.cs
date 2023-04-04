using System.Collections.Generic;
using UnityEngine;

namespace Bellseboss.Audio.Scripts
{
    [CreateAssetMenu(fileName = "New Event", menuName = "ScriptableObjects/Game Event")]
    public class Event : ScriptableObject
    {
        private List<EventListener> m_EListeners = new List<EventListener>();

        public void Register(EventListener listener)
        {
            m_EListeners.Add(listener);
        }
        
        public void Unregister(EventListener listener)
        {
            m_EListeners.Remove(listener);
        }

        public void Occurred()
        {
            for (int i = 0; i < m_EListeners.Count; i++)
            {
                m_EListeners[i].OnEventOccurs();
            }
        }
    }
}


