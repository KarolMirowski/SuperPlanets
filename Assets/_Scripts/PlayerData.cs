using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public string PlayerName;
    public int CurrentScore = 0;
    public int HighestScore = 0;
    public int ListIndex;
    
    public PlayerData(string playerName, int currentScore, int highestScore, int listIndex){
        PlayerName = playerName;   
        HighestScore = highestScore;
        CurrentScore = currentScore;
        ListIndex = listIndex;
    } 
    
    public PlayerData(){}

}
