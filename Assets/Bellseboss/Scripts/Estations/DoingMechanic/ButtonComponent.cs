using UnityEngine;
using UnityEngine.Events;

public class ButtonComponent : MonoBehaviour
{
    [SerializeField] private ButtonComponentColliderCustom _collider;
    [SerializeField] private GameObject button;
    [SerializeField] private float positionA, positionB;
    public UnityEvent onButtonPress, onButtonRelease;
    private bool isPressed;

    private void Start() {
        var buttonTranformLocalPosition = button.transform.localPosition;
        buttonTranformLocalPosition.y = positionA;
        button.transform.localPosition = buttonTranformLocalPosition;
        //ServiceLocator.Instance.GetService<IDebugMediator>().LogL("config button");
        _collider.onTouchButton += (isTouch)=>{
            isPressed = isTouch;
            var buttonTranformLocalPosition = button.transform.localPosition;
            if(isTouch){
                buttonTranformLocalPosition.y = positionB;
                onButtonPress?.Invoke();
            }else{
                buttonTranformLocalPosition.y = positionA;
                onButtonRelease?.Invoke();
            }

            button.transform.localPosition = buttonTranformLocalPosition;
        };
    }

    public bool IsPressed => isPressed;
}
