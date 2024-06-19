using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;
    [SerializeField] private GameObject _gameOverSign;
    [SerializeField] private GameObject _yourScoreSign;
    [SerializeField] private GameObject _backToMenuButton;
    [SerializeField] private GameObject _resetSceneButton;
    [SerializeField] private GameObject _scoreCounter;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void OnGameOver()
    {
        if (_gameOverSign != null && !_gameOverSign.activeInHierarchy){

            _gameOverSign.SetActive(true);
        }

        if (_yourScoreSign != null && !_yourScoreSign.activeInHierarchy){
            _yourScoreSign.GetComponent<TMPro.TMP_Text>().text += GameManager.Instance.ScoreCount.ToString();
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
}
