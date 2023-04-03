using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


namespace Audio.Scripts
{
	public class SceneBasedObjectActivator : Singleton <SceneBasedObjectActivator>
	{
		[SerializeField] private int m_CurrentSceneIndex;
		public int CurrentSceneIndex
		{
			get => CurrentSceneIndex;
			set => m_CurrentSceneIndex = value;
		}

		public UnityEvent m_LobbySceneEvents;
		public UnityEvent m_WorkshopRoomEvents;

		private void Start()
		{
			DontDestroyOnLoad(gameObject);
			m_CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
			SceneManager.sceneLoaded += OnSceneLoaded;
			TriggerEvents(m_CurrentSceneIndex);
		}

		private void OnDestroy()
		{
			SceneManager.sceneLoaded -= OnSceneLoaded;
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			m_CurrentSceneIndex = scene.buildIndex;
			TriggerEvents(m_CurrentSceneIndex);
		}

		private void TriggerEvents(int currentSceneIndex)
		{
			switch (currentSceneIndex)
			{
				case 0:
					m_LobbySceneEvents.Invoke();
					break;
				case 1:
					m_WorkshopRoomEvents.Invoke();
					break;
			}
		}
	}
}
