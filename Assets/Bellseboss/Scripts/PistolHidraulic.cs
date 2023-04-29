using UnityEngine;
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
       
            if (m_DrillStopped != null)
            {
                m_DrillStopped.Occurred();
            }
            if (collision.StayInPosition())
            {
                ServiceLocator.Instance.GetService<IDebugMediator>().LogR("Stop_1");
            }
        });
    }
    private void Update() {
        if (collision.StayInPosition()){
            transform.position = collision.GetTornillo().PositionToPistol.position;
        }
    }
    private void FixedUpdate()
    {
        if (_useImpulse)
        {
            var amplitude = 0.7f;
            var logitud = 0.1f;
            if(collision.StayInPosition()){
                amplitude = 0.9f;
            }
            control.SendHapticImpulse(amplitude, logitud);
        }
    }
}

