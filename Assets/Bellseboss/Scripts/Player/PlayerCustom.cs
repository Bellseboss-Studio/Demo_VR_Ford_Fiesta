using UnityEngine;

public class PlayerCustom : MonoBehaviour
{
    [SerializeField] private DebugMediator debug;
    [SerializeField] private FadeAnimation fade;
    private void Start()
    {
        ServiceLocator.Instance.RemoveService(typeof(IDebugMediator));
        ServiceLocator.Instance.RegisterService<IDebugMediator>(debug);
        ServiceLocator.Instance.GetService<ISceneTransition>().SetFade(fade);
    }
}
