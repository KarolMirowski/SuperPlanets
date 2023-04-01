using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    
    [Header("GENERAL SETTINGS")] public GameState State ;//= //GameManager.GameState;
    public static event Action<GameState> OnGameStateChange;
   
    public string JakisNapis;


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
            case GameState.CreditsPanel:
                break;
        }

        OnGameStateChange?.Invoke(nextState);
    }
    public void UpdateBotNumber(BotsNumber nextState)
    {
        switch (nextState)
        {
            case BotsNumber.OneBot:
                // ...
                break;
            case BotsNumber.TwoBots:
                // ...
                break;
            case BotsNumber.ThreeBots:
                // ...
                break;
            case BotsNumber.FourBots:
                // ...
                break;
        }
    }



    public enum GameState
    {
        MainMenu,
        Settings,
        GamePlay,
        CreditsPanel

    }

    public enum BotsNumber
    {
        OneBot,
        TwoBots,
        ThreeBots,
        FourBots
    }


}
public enum ShareState {ShareStateOne, ShareStateTwo}
