using UnityEngine;

public class Installer : MonoBehaviour
{
    [SerializeField] private SceneTransitionManager transitionManager;
    private void Awake()
    {
        if (FindObjectsOfType<Installer>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        ServiceLocator.Instance.RegisterService<ISceneTransition>(transitionManager);
        DontDestroyOnLoad(gameObject);
        Application.targetFrameRate = 60;
    }
}