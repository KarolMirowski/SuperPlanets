using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour, IPointerDownHandler
{
    private static MenuManager instance;
    public static MenuManager Instance { get { return instance; } }

    #region UI_Elements    
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _goToSettingsButton;
    [SerializeField] private Button _goToCreditsButton;
    [SerializeField] private Button[] _backToMenuButton;
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _creditsPanel;
    #endregion
    #region Audio
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    #endregion


    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
        DontDestroyOnLoad(gameObject);

        _startButton.onClick.AddListener(StartGame);
        _goToSettingsButton.onClick.AddListener(GoToSettings);
        for (int i = 0; i < _backToMenuButton.Length; i++)
        {
            int buttonIndex = i; // utworzenie lokalnej zmiennej przechowującej aktualny indeks przycisku
            _backToMenuButton[buttonIndex].onClick.AddListener(GoBackToMenu);
        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        string pressedButton = eventData.pointerClick.gameObject.name;

        switch (pressedButton)
        {
            case "_backToMenuButton":
                GoBackToMenu();
                break;
            case "Settings Button":
                GoToSettings();
                break;
            case "_goToCreditsButton":
                GoToCredits();
                break;
            default:
                break;
        }
    }



    public void StartGame()
    {
        _audioSource.PlayOneShot(_audioClip);
        MySceneManager.Instance.LoadScene("WorkingScene");
        GameManager.Instance.UpdateGameState(GameManager.GameState.GamePlay);
    }

    
    void GoBackToMenu()
    {
        _audioSource.PlayOneShot(_audioClip);

        if (_menuPanel.activeSelf == false)
            _menuPanel.SetActive(true);

        if (_settingsPanel.activeSelf == true)
            _settingsPanel.SetActive(false);

        if (_creditsPanel.activeSelf == true)
            _creditsPanel.SetActive(false);

    }

    void GoToSettings()
    {
        print("Gotosettings poszlo");
        _audioSource.PlayOneShot(_audioClip);

        if (_menuPanel.activeSelf == true)
            _menuPanel.SetActive(false);

        if (_settingsPanel.activeSelf == false)
            _settingsPanel.SetActive(true);

        if (_creditsPanel.activeSelf == true)
            _creditsPanel.SetActive(false);
    }

    void GoToCredits()
    {
        _audioSource.PlayOneShot(_audioClip);

        if (_menuPanel.activeSelf == true)
            _menuPanel.SetActive(false);

        if (_settingsPanel.activeSelf == true)
            _settingsPanel.SetActive(false);

        if (_creditsPanel.activeSelf == false)
            _creditsPanel.SetActive(true);
    }
}
