using UnityEngine;

public abstract class CustomElement : MonoBehaviour
{
    protected int internalIndex;

    protected virtual void Start()
    {
        ChangeElement();
    }

    public void Next()
    {
        ServiceLocator.Instance.GetService<IDebugMediator>().LogR($"press button to next");
        internalIndex++;
        if (internalIndex > GetLengthOfList() -1)
        {
            internalIndex = 0;
        }
        ChangeElement();
    }

    public void Previous()
    {
        ServiceLocator.Instance.GetService<IDebugMediator>().LogR($"press button to next");
        internalIndex--;
        if (internalIndex < 0)
        {
            internalIndex = GetLengthOfList() - 1;
        }
        ChangeElement();
    }

    protected abstract void ChangeElement();
    
    protected abstract int GetLengthOfList();
}