using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerListManager : MonoBehaviour
{
    public Button AddNewPlayerButton;
    public Button NewPlayerNameButton;
    public TMP_Text NewPlayerText;
    public GameObject ScrollViewContent;
    public GameObject PlayerListElementPrefab;
    private List<PlayerData> _listOfPlayers;
    private PlayerData _newPlayerData;
    private bool _isKeyboardActive;
    void Start()
    {
        _listOfPlayers = PlayerDataHandler.Instance._playersDataList;
        AddNewPlayerButton.onClick.AddListener(AddNewPlayer);
        NewPlayerNameButton.onClick.AddListener(ToggleKeyboard);
    }
    void Update()
    {
        // Sprawdź, czy klawiatura jest aktywna i czy został wprowadzony tekst
        
    }

    void AddNewPlayer()
    {
        //_listOfPlayers.Contains()
        if (string.IsNullOrEmpty(NewPlayerText.text)) return;
        if (_listOfPlayers.Exists(x => x.PlayerName == NewPlayerText.text))
        {
            _newPlayerData = new PlayerData
            {
                PlayerName = NewPlayerText.text,
                HighestScore = 0
            };
            _listOfPlayers.Add(_newPlayerData);
            UpdatePlayerList();
        }

    }

    void UpdatePlayerList()
    {
        foreach (var item in _listOfPlayers)
        {
            var player = Instantiate(PlayerListElementPrefab);
            player.transform.SetParent(ScrollViewContent.transform);
            var highestScoreObj = player.GetComponentInChildren<HighestScore>();
            var listPlayerNameObj = player.GetComponentInChildren<ListPlayerName>();
            highestScoreObj.GetComponentInChildren<TMP_Text>().text = item.HighestScore.ToString();
            listPlayerNameObj.GetComponentInChildren<TMP_Text>().text = item.PlayerName;

        }
    }
    void ToggleKeyboard()
    {
        _isKeyboardActive = !_isKeyboardActive;
        
        if (_isKeyboardActive)
        {
            //NewPlayerNameButton.GetComponent<Image>().color = ActiveButtonColor;
            TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        }
        else
        {
            //NewPlayerNameButton.GetComponent<Image>().color = _originalButtonColor;
            SaveNewPlayerName();
        }
    }
    void SaveNewPlayerName()
    {

    }

}
