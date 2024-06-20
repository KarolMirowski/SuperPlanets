using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMainMenu : MonoBehaviour
{
    GameManager _gameManager;
    private void OnEnable()
    {
        _gameManager = GameManager.Instance;
    }
    public void BackToMainMenuButton()
    {
        MySceneManager.Instance.LoadMainMenuScene();

        _gameManager.UpdateGameState(GameState.MainMenu);
        
    }
}
