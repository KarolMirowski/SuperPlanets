using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.UI;

public enum ShareState { ShareStateOne, ShareStateTwo }

public enum GameState { MainMenu, Settings, GamePlay, SplitScreenGameplay, CreditsPanel }
public enum NumberOfPlayers { OnePlayer, TwoPlayers }
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Button playerTurnLeftButton;
    public Button playerTutnRightButton;
    

    public GameState State;
    public static event Action<GameState> OnGameStateChange;
    //public static event Action<BotsNumber> OnBotCountChange;

    [SerializeField] private int _playerOneScore;
    public int PlayerOneScore { get { return _playerOneScore; } set { _playerOneScore = value; } }
    [SerializeField] private int _playerTwoScore;
    public int PlayerTwoScore { get { return _playerTwoScore; } set { _playerTwoScore = value; } }

    [SerializeField] private int _botCountNumber;
    [SerializeField] private int _numberOfPlayers = 2;
    [SerializeField] private int _fpsLocker = 60;

    public GameManager()
    {
    }

    public int BotCountNumber
    {
        get { return _botCountNumber; }
        set { _botCountNumber = Mathf.Clamp(value, 0, 20); }
    }
    public int PlayerCountNumber
    {
        get { return _numberOfPlayers; }
        set { _numberOfPlayers = Mathf.Clamp(value, 1, 2); }
    }


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
        Application.targetFrameRate = _fpsLocker;

        //Setting for a framerate to be checked later.
    }
    void OnValidate()
    {
        Application.targetFrameRate = _fpsLocker;

        
    }
    
    public void ValidateGameManager()
    {
        OnValidate();

    }
    //Switch for managing state of a game: mainmenu_scene, gameplay etc.
    public void UpdateGameState(GameState nextState)
    {
        State = nextState;

        switch (nextState)
        {
            case GameState.MainMenu:
                // ...
                var hi = 1;
                break;
            case GameState.Settings:
                break;
            case GameState.GamePlay:
                break;
            case GameState.CreditsPanel:
                break;
        }

        OnGameStateChange?.Invoke(nextState);
    }
    //Switch for maanaging number of players
    public void UpdateNumberOfPlayers(NumberOfPlayers numberOfPlayers)
    {
        switch (numberOfPlayers)
        {
            case NumberOfPlayers.OnePlayer:
                _numberOfPlayers = 1;
                
                break;
            case NumberOfPlayers.TwoPlayers:
                _numberOfPlayers = 2;
                break;
        }
    }
    

    public void UpdateBotCount(BotCount newBotCount)
    {
        switch (newBotCount)
        {
            case BotCount.OneBot:
                // ...
                break;
            case BotCount.TwoBots:
                // ...
                break;
            case BotCount.ThreeBots:
                // ...
                break;
            case BotCount.FourBots:
                // ...
                break;
        }
    }

    public enum BotCount
    {
        OneBot,
        TwoBots,
        ThreeBots,
        FourBots
    }


}
