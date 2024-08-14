using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;
    [SerializeField] private GameObject _gameOverSign;
    [SerializeField] private GameObject _yourScoreSign;
    [SerializeField] private GameObject _resetSceneButton;
    [SerializeField] private GameObject _scoreCounter;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private Button _pauseMenuButton;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _retryButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private bool Sprawdzenie;
    public Button TurnLeftButton;
    public Button TurnRightButton;
    private EventsScripts _eventsScript;
    [SerializeField] private TMP_Text _oneGameOverText;
    [SerializeField] private TMP_Text _twoGameOverText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            //Destroy(gameObject);
        }



    }
    void Start()
    {
        if (GameManager.Instance != null)
        {
            UpdateUi();
            GameManager.Instance.ValidateGameManager();
        }

        _eventsScript = EventsScripts.Instance;
        _pauseMenuButton.onClick.AddListener(PauseGamePlay);
        _resumeButton.onClick.AddListener(ResumeGamePlay);
        _retryButton.onClick.AddListener(RetryGamePlay);
        _exitButton.onClick.AddListener(ExitGameplay);


    }
    void PauseGamePlay()
    {
        //EVENTS PAUSE GAME
        _pausePanel.SetActive(true);
        _pauseMenuButton.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }
    void ResumeGamePlay()
    {
        _pausePanel.SetActive(false);
        _pauseMenuButton.gameObject.SetActive(true);
        Time.timeScale = 1f;
    }
    void RetryGamePlay()
    {
        _eventsScript.ResetScene();
        Time.timeScale = 1f;
    }
    void ExitGameplay()
    {
        _eventsScript.BackToMenu();
        Time.timeScale = 1f;
    }
    public void OnOneGameOver(int score)
    {
        if (_oneGameOverText != null && !_oneGameOverText.gameObject.activeInHierarchy)
        {
            _oneGameOverText.gameObject.SetActive(true);
            _oneGameOverText.text = $"twoj wynik to: {score}";
        }

        if (_yourScoreSign != null && !_yourScoreSign.activeInHierarchy)
        {
            //TUTAJ PILNE 
            //_yourScoreSign.GetComponent<TMPro.TMP_Text>().text += GameManager.Instance.PlayerOneScore.ToString();
            _yourScoreSign.SetActive(true);
        }
    }
    public void OnTwoGameOver(int score){
        if (_twoGameOverText != null && !_twoGameOverText.gameObject.activeInHierarchy)
        {
            _twoGameOverText.gameObject.SetActive(true);
            _twoGameOverText.text = $"twoj wynik to: {score}";
        }

        if (_yourScoreSign != null && !_yourScoreSign.activeInHierarchy)
        {
            //TUTAJ PILNE 
            //_yourScoreSign.GetComponent<TMPro.TMP_Text>().text += GameManager.Instance.PlayerOneScore.ToString();
            _yourScoreSign.SetActive(true);
        }
    }
    public void OnResetScene()
    {

    }

    public void BackToMainMenuButton()
    {
        MySceneManager.Instance.LoadMainMenuScene();

        GameManager.Instance.UpdateGameState(GameState.MainMenu);
    }
    void UpdateUi()
    {

        if (GameManager.Instance.PlayerCountNumber == 1)
        {

            TurnLeftButton.gameObject.SetActive(false);
            TurnRightButton.gameObject.SetActive(false);
        }
        if (GameManager.Instance.PlayerCountNumber == 2)
        {


            TurnLeftButton.gameObject.SetActive(true);
            TurnRightButton.gameObject.SetActive(true);

        }

    }

}
