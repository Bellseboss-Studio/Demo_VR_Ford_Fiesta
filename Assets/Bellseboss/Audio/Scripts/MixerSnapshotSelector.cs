using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

namespace Audio.Scripts
{
	public class MixerSnapshotSelector : MonoBehaviour
	{
		[SerializeField] private AudioMixerSnapshot m_Snapshot = null;
		[SerializeField] private float m_CrossfadeTime = 0;
		[SerializeField] private float m_DelayTimeBeforeFade = 0;
		[SerializeField] private float m_DelayTimeBeforeDisable = 0;

		public void SetMixerSnapshot(bool makeActive)
		{
			StartCoroutine(makeActive ? TriggerSnapshot() : DisableSnapshot());
		}

		private IEnumerator TriggerSnapshot()
		{
			yield return new WaitForSeconds(m_DelayTimeBeforeFade);
			m_Snapshot.TransitionTo(m_CrossfadeTime);
		}

		private IEnumerator DisableSnapshot()
		{
			yield return new WaitForSeconds(m_DelayTimeBeforeDisable);
			gameObject.SetActive(false);
		}
	}
}
