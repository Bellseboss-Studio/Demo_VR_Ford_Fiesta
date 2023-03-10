using UnityEngine;

public class StatesOfDemo : MonoBehaviour, IStateOfDemo, IBeggingState, IWaitingForSelectionOfOption, ICarCustomization
{
    [SerializeField] private AudioIntro audioIntro;

    [SerializeField] private WaitingForSelectOptionMono waiting;

    [SerializeField] private CarCustomMono carCustom;

    [SerializeField] private GameObject teleportToGoToBegging;
    
    private TeaTime _firstPart, _secondPart, _optionCustom;
    private AudioIntroAndShowIcons _audio;
    private WaitingForSelectOption _waiting;
    private CarCustomization _customCar;
    // Start is called before the first frame update
    void Start()
    {
        _audio = new AudioIntroAndShowIcons(this);
        _waiting = new WaitingForSelectOption(this);
        _customCar = new CarCustomization(this);

        _audio.GetTeaTime().Add(_waiting.GetTeaTime().Play());
        _waiting.GetTeaTime().Add(() =>
        {
            switch (_waiting.Selection())
            {
                case 1:
                    _customCar.GetTeaTime().Play();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        });
        
        
        
        _audio.GetTeaTime().Play();

    }

    public TeaTime GetTeaTime()
    {
        return this.tt();
    }

    public void HideOptionsToDoing()
    {
        audioIntro.HideAllIcons();
    }

    public CarCustomMono GetCarCustomMono()
    {
        return carCustom;
    }

    public void ShowTeleportToGoToBegging()
    {
        teleportToGoToBegging.SetActive(true);
    }

    public void HideTeleportToGoToBegging()
    {
        teleportToGoToBegging.SetActive(false);
    }

    public AudioIntro GetAudioIntro()
    {
        return audioIntro;
    }

    public WaitingForSelectOptionMono GetWaitingMono()
    {
        return waiting;
    }

    public void ShowOptionsInBegging()
    {
        audioIntro.ShowAllIcons();
    }
}