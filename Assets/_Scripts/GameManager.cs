using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;
    public static event Action<GameState> OnGameStateChange;
    public string JakisNapis;


    void Awake()
    {
        if (Instance == null) Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateGameState(GameState nextState)
    {
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
