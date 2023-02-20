using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class PistolHidraulic : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable grabbable;
    [SerializeField] private CollisionWithGun collision;
    [SerializeField] private InputActionProperty _trigger;
    private bool _useImpulse;
    private XRBaseController control;

    private void Start()
    {
        grabbable.activated.AddListener(arg =>
        {
            if (arg.interactorObject is XRBaseControllerInteractor controllerInteractor)
            {
                control =controllerInteractor.xrController;
                //Drill Sound Start (Maybe hook with pitch)
                ServiceLocator.Instance.GetService<IDebugMediator>().LogR("RUUUUNNNN");
                
                _useImpulse = true;
                if (collision.StayInPosition())
                {
                    //IsAttachedToNut different sound
                    ServiceLocator.Instance.GetService<IDebugMediator>().LogR("RUUUUNNNN In Object");
                }    
            }
            
        });
        grabbable.deactivated.AddListener(arg =>
        {
            control = null;
            _useImpulse = false;
            //Drill Release
            ServiceLocator.Instance.GetService<IDebugMediator>().LogR("Disable RUN");
            if (collision.StayInPosition())
            {
            }
        });
    }

    private void Update()
    {
        ServiceLocator.Instance.GetService<IDebugMediator>().LogR(_trigger.action.ReadValue<float>().ToString());
        if (_useImpulse)
        {
            //Mientras esta presionado 
            control.SendHapticImpulse(0.7f, 0.1f);
        }
    }
}

