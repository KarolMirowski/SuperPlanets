using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendPlayerData : MonoBehaviour
{
    public void SendData()
    {
        //Odwlanie do instancji PlayerDataHandler(GameManager)
        var playerDataHandler = PlayerDataHandler.Instance;

        //Przycisk z listy, sprawdza ktory gracz jest aktualnie wybierany.
        //Nadpisuje PlayerData w PlayerDataHandler oraz napis z nazwa gracza na przycisku.
        if(playerDataHandler._isPlayerOneChoosing){
            playerDataHandler.PlayerOneData = GetComponent<PlayerElementData>().SinglePlayerData;
            print(GetComponent<PlayerElementData>().SinglePlayerData.PlayerName);
            playerDataHandler.PlayerOneText.text = GetComponent<PlayerElementData>().SinglePlayerData.PlayerName;
            playerDataHandler._isPlayerOneChoosing = false;
            playerDataHandler._isPlayerTwoChoosing = false;
        }
        if(playerDataHandler._isPlayerTwoChoosing){
            playerDataHandler.PlayerTwoData = GetComponent<PlayerElementData>().SinglePlayerData;
            print(GetComponent<PlayerElementData>().SinglePlayerData.PlayerName);
            playerDataHandler.PlayerTwoText.text = GetComponent<PlayerElementData>().SinglePlayerData.PlayerName;
            playerDataHandler._isPlayerOneChoosing = false;
            playerDataHandler._isPlayerTwoChoosing = false;
        }
    }


}
