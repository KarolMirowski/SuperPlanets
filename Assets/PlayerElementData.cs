using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class PlayerElementData : MonoBehaviour
{
    public string PlayerName;
    public int HighestScore;
    public int ListIndex;

    private void Start()
    {
        if (CompareTag("PlayerOne"))
            UpdatePlayerOneData();
        if (CompareTag("PlayerTwo"))
            UpdatePlayerTwoData();
        //if(GetComponentIn)

    }
    private void UpdatePlayerOneData()
    {
        PlayerName = PlayerDataHandler.Instance.PlayerOneData.PlayerName;
        HighestScore = PlayerDataHandler.Instance.PlayerOneData.HighestScore;
        ListIndex = PlayerDataHandler.Instance.PlayerOneData.ListIndex;
    }
    private void UpdatePlayerTwoData()
    {
        PlayerName = PlayerDataHandler.Instance.PlayerTwoData.PlayerName;
        HighestScore = PlayerDataHandler.Instance.PlayerTwoData.HighestScore;
        ListIndex = PlayerDataHandler.Instance.PlayerTwoData.ListIndex;
    }
}
