using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;
    [SerializeField] private GameObject _gameOverSign;
    [SerializeField] private GameObject _yourScoreSign;
    [SerializeField] private GameObject _backToMenuButton;
    [SerializeField] private GameObject _resetSceneButton;
    [SerializeField] private GameObject _scoreCounter;
    [SerializeField] private bool Sprawdzenie;
    public Button TurnLeftButton;
    public Button TurnRightButton;

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

    }
    public void OnGameOver()
    {
        if (_gameOverSign != null && !_gameOverSign.activeInHierarchy)
        {

            _gameOverSign.SetActive(true);
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
