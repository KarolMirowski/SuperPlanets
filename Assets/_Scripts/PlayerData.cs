using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public string PlayerName;
    public int HighestScore;
    public int ListIndex;

    public PlayerData(string playerName, int highestScore, int listIndex){
        PlayerName = playerName;   
        HighestScore = highestScore;
        ListIndex = listIndex;
    } 
    
    public PlayerData(){}

}
