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

    public void ShowMessageInLogR(string message){
        ServiceLocator.Instance.GetService<IDebugMediator>().LogR(message);
    }

    public void ShowMessageInLogL(string message){
        ServiceLocator.Instance.GetService<IDebugMediator>().LogL(message);
    }
}