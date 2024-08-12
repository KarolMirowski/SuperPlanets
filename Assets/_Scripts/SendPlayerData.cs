using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SendPlayerData : MonoBehaviour
{
    public static event Action SendDataEvent;
    private TMP_Text _playerOneText;
    private TMP_Text _playerTwoText;
    public void Start(){
        gameObject.name = GetComponent<PlayerElementData>().SinglePlayerData.PlayerName;
    }
    public void SendData()
    {
        //Odwlanie do instancji PlayerDataHandler(GameManager)
        var playerDataHandler = PlayerDataHandler.Instance;

        //Przycisk z listy, sprawdza ktory gracz jest aktualnie wybierany.
        //Nadpisuje PlayerData w PlayerDataHandler oraz napis z nazwa gracza na przycisku.
        if(playerDataHandler._isPlayerOneChoosing){
            playerDataHandler.PlayerOneData = GetComponent<PlayerElementData>().SinglePlayerData;
            //playerDataHandler.PlayerOneText.text = GetComponent<PlayerElementData>().SinglePlayerData.PlayerName;
            //_playerOneText.text = GetComponent<PlayerElementData>().SinglePlayerData.PlayerName;
            playerDataHandler._isPlayerOneChoosing = false;
            playerDataHandler._isPlayerTwoChoosing = false;
            playerDataHandler.ValidateNames();
        }
        if(playerDataHandler._isPlayerTwoChoosing){
            playerDataHandler.PlayerTwoData = GetComponent<PlayerElementData>().SinglePlayerData;
            //playerDataHandler.PlayerTwoText.text = GetComponent<PlayerElementData>().SinglePlayerData.PlayerName;
            //_playerTwoText.text = GetComponent<PlayerElementData>().SinglePlayerData.PlayerName;
            playerDataHandler._isPlayerOneChoosing = false;
            playerDataHandler._isPlayerTwoChoosing = false;
            playerDataHandler.ValidateNames();
        }
        
    }


}
