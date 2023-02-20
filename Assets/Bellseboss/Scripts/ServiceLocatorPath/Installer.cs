using UnityEngine;

public class Installer : MonoBehaviour
{
    [SerializeField] private DebugMediator debugMediator;
    private void Awake()
    {
        if (FindObjectsOfType<Installer>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        ServiceLocator.Instance.RegisterService<IDebugMediator>(debugMediator);
        DontDestroyOnLoad(gameObject);
        Application.targetFrameRate = 30;
    }
}