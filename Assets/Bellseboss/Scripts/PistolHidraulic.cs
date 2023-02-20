using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PistolHidraulic : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable grabbable;
    [SerializeField] private CollisionWithGun collision;
    private bool _useImpulse;
    private XRBaseController control;

    private void Start()
    {
        grabbable.activated.AddListener(arg =>
        {
            if (arg.interactorObject is XRBaseControllerInteractor controllerInteractor)
            {
                control =controllerInteractor.xrController;
                ServiceLocator.Instance.GetService<IDebugMediator>().LogR("RUUUUNNNN");
                _useImpulse = true;
                if (collision.StayInPosition())
                {
                    ServiceLocator.Instance.GetService<IDebugMediator>().LogR("RUUUUNNNN In Object");
                }    
            }
            
        });
        grabbable.deactivated.AddListener(arg =>
        {
            control = null;
            _useImpulse = false;
            ServiceLocator.Instance.GetService<IDebugMediator>().LogR("Disable RUN");
            if (collision.StayInPosition())
            {
            }
        });
    }

    private void Update()
    {
        if (_useImpulse)
        {
            control.SendHapticImpulse(0.7f, 0.1f);
        }
    }
}