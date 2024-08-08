using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class PlayerElementData : MonoBehaviour
{
    public PlayerData SinglePlayerData = new PlayerData{
        PlayerName = "Gracz",
        HighestScore = 0,
        ListIndex = 0
    };
    private void Start()
    {
        if (CompareTag("PlayerOne"))
            UpdatePlayerOneData();
        if (CompareTag("PlayerTwo"))
            UpdatePlayerTwoData();
        
    }
    private void UpdatePlayerOneData()
    {
        SinglePlayerData.PlayerName = PlayerDataHandler.Instance.PlayerOneData.PlayerName;
        SinglePlayerData.HighestScore = PlayerDataHandler.Instance.PlayerOneData.HighestScore;
        SinglePlayerData.ListIndex = PlayerDataHandler.Instance.PlayerOneData.ListIndex;
    }
    private void UpdatePlayerTwoData()
    {
        SinglePlayerData.PlayerName = PlayerDataHandler.Instance.PlayerTwoData.PlayerName;
        SinglePlayerData.HighestScore = PlayerDataHandler.Instance.PlayerTwoData.HighestScore;
        SinglePlayerData.ListIndex = PlayerDataHandler.Instance.PlayerTwoData.ListIndex;
    }
}
