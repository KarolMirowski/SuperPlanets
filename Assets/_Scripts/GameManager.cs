using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Update()
    {

    }

    public enum GameState
    {
        MainMenu,
        Settings,
        GamePlay,
        CreditsPanel
        
    }

    public enum BotsNumber{
        OneBot,
        TwoBots,
        ThreeBots,
        FourBots
    }


}
