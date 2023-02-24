using UnityEngine;

public class WaitingForSelectOptionMono : MonoBehaviour
{
    private int _option;
    public bool HasSelectedAnything()
    {
        return _option != 0;
    }

    public void SetOption(int option)
    {
        _option = option;
    }

    public int GetOption()
    {
        return _option;
    }
}