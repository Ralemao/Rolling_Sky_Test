using UnityEngine;
using UnityEngine.UI;

public class UIGame : Singleton<UIGame>
{
    private bool _isPause;

    [SerializeField]
    private Text _diamondsText;
    [SerializeField]
    private Image _pause;
    [SerializeField]
    private Button _play;
    [SerializeField]
    private Button _return;
    [SerializeField]
    private GameObject _startTuto;
    [SerializeField]
    private GameObject _joystick;
    [SerializeField]
    private GameObject _endPanel;
    private Transform _diamondsLevel;

    void Start()
    {
        AudioBG.Instance.GameAudio();
        Time.timeScale = 1;
        _diamondsLevel = GameObject.Find("Diamonds").transform;
        UpdateDiamonds(GameManager.Instance.GetLevelDiamonds());
        SetDiamonds();
    }

    public void UpdateDiamonds(int value)
    {
        _diamondsText.text = "x " + value.ToString();
    }

    private void SetDiamonds()
    {
        if (!LevelManager.Instance.GetLevelStarted())
        {
            LevelManager.Instance.SetLevelStarted(true);
            GameManager.Instance.SetDiamondsChild(_diamondsLevel);
        }
        else
            _diamondsLevel.gameObject.SetActive(false);
    }

    public void TurnOffTuto()
    {
        _startTuto.SetActive(false);
        _pause.gameObject.SetActive(true);
    }

    public void SetPause()
    {
        _isPause = !_isPause;
        EndPanel(_isPause);
    }

    public void EndPanel(bool value)
    {
        PlayerController.Instance.SetDisable(value);
        _joystick.SetActive(!value);
        _endPanel.SetActive(value);
        _pause.gameObject.SetActive(!value);

        if (_isPause)
        {
            _play.gameObject.SetActive(!value);
            _return.gameObject.SetActive(value);
        }
        else
        {
            _play.gameObject.SetActive(value);
            _return.gameObject.SetActive(!value);
        }
    }

    public void ReloadScene()
    {
        LevelManager.Instance.ReloadScene();
    }

    public void MenuScene()
    {
        LevelManager.Instance.MenuScene();
    }

    public void LeaveLevel()
    {
        LevelManager.Instance.MenuLevelScene();
    }
}
