using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using Event = Bellseboss.Audio.Scripts.Event;

public class PistolHidraulic : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable grabbable;
    [SerializeField] private CollisionWithGun collision;
    private bool _useImpulse;
    private XRBaseController control;

    [Header("Audio Elements")] 
    [SerializeField] private Event m_DrillStarted;
    [SerializeField] private Event m_DrillStopped;
    
    private void Start()
    {
        grabbable.activated.AddListener(arg =>
        {
            if (arg.interactorObject is XRBaseControllerInteractor controllerInteractor)
            {
                control = controllerInteractor.xrController;
                //Drill Sound Start (Maybe hook with pitch)
                ServiceLocator.Instance.GetService<IDebugMediator>().LogR("RUUUUNNNN");
                if (m_DrillStarted != null)
                {
                   m_DrillStarted.Occurred();
                }
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
            if (m_DrillStopped != null)
            {
                m_DrillStopped.Occurred();
                ServiceLocator.Instance.GetService<IDebugMediator>().LogR("Stop");
            }
            if (collision.StayInPosition())
            {
                ServiceLocator.Instance.GetService<IDebugMediator>().LogR("Stop_1");
            }
        });
    }

    private void FixedUpdate()
    {
        if (_useImpulse)
        {
            control.SendHapticImpulse(0.7f, 0.1f);
        }
    }
}

