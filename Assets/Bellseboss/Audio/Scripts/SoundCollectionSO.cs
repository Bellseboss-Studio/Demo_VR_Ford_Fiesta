using UnityEngine;

namespace Bellseboss.Audio.Scripts
{
    [CreateAssetMenu(fileName = "Sound Collection", menuName = "ScriptableObjects/SoundCollection")]
    public class SoundCollectionSO : ScriptableObject
    {
        [SerializeField] private AudioClip[] m_SoundCollection;

        public AudioClip[] SoundCollection => m_SoundCollection;
    }
}
