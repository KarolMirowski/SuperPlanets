using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendPlayerData : MonoBehaviour
{
    public void SendData()
    {
        var playerDataHandler = PlayerDataHandler.Instance;

        if(playerDataHandler._isPlayerOneChoosing){
            playerDataHandler.PlayerOneData = GetComponent<PlayerElementData>();
            print(GetComponent<PlayerElementData>().PlayerName);
            playerDataHandler.PlayerOneText.text = GetComponent<PlayerElementData>().PlayerName;
            playerDataHandler._isPlayerOneChoosing = false;
            playerDataHandler._isPlayerTwoChoosing = false;
        }
        if(playerDataHandler._isPlayerTwoChoosing){
            playerDataHandler.PlayerTwoData = GetComponent<PlayerElementData>();
            print(GetComponent<PlayerElementData>().PlayerName);
            playerDataHandler.PlayerTwoText.text = GetComponent<PlayerElementData>().PlayerName;
            playerDataHandler._isPlayerOneChoosing = false;
            playerDataHandler._isPlayerTwoChoosing = false;
        }
    }


}
