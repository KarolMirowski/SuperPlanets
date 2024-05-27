using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum ShareState { ShareStateOne, ShareStateTwo }

public enum GameState { MainMenu, Settings, GamePlay, SplitScreenGameplay, CreditsPanel }
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;
    public static event Action<GameState> OnGameStateChange;
    //public static event Action<BotsNumber> OnBotCountChange;

    [SerializeField] private int _scoreCount;
    public int ScoreCount { get { return _scoreCount; } set { _scoreCount = value; } }

    [SerializeField] private int _botCountNumber;
    [SerializeField] private int _playCountNumber;
    public int BotCountNumber
    {
        get { return _botCountNumber; }
        set { _botCountNumber = Mathf.Clamp(value, 0, 20); }
    }
    public int PlayerCountNumber
    {
        get { return _playCountNumber; }
        set { _playCountNumber = Mathf.Clamp(value, 1, 4); }
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


    }


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
            case GameState.SplitScreenGameplay:
                break;
            case GameState.CreditsPanel:
                break;
        }

        OnGameStateChange?.Invoke(nextState);
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
