using System.Collections;
using UnityEngine;

public class DebugMediator : MonoBehaviour, IDebugMediator
{
    [SerializeField] private DebugAdapter debugLeft, debugRight;

    private void Start()
    {
        debugLeft.DisableLog();
        debugRight.DisableLog();
    }

    public void LogL(string message)
    {
        if (!debugLeft.IsEnable())
        {
            debugLeft.EnableLog();
        }
        debugLeft.Log(message);
    }
    
    public void LogR(string message)
    {
        if (!debugRight.IsEnable())
        {
            debugRight.EnableLog();
        }
        debugRight.Log(message);
    }

    IEnumerator DisableLog(GameObject go)
    {
        yield return new WaitForSeconds(10);
        
    }
}