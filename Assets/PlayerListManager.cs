using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;


public class PlayerListManager : MonoBehaviour
{
    public Button AddNewPlayerButton;
    public Button NewPlayerNameButton;
    public Button ChoosePlayerOneButton;
    public Button ChoosePlayerTwoButton;
    private bool _isPlayerOneChoosing = false;
    private bool _isPlayerTwoChoosing = false;
    public TMP_Text NewPlayerText;
    public GameObject ScrollViewContent;
    public GameObject PlayerListElementPrefab;
    private List<GameObject> _listOfPlayersPrefabs = new List<GameObject>();
    public GameObject Keyboard;
    public Button EnterButton;
    public List<PlayerData> _listOfPlayers;
    private PlayerData _newPlayerData = new PlayerData();

    private bool _isKeyboardActive = false;
    private int i=1;
    void Start()
    {
        //PlayerDataHandler.Instance._playersDataList = _listOfPlayers;
        _listOfPlayers = PlayerDataHandler.Instance._playersDataList;
        AddNewPlayerButton.onClick.AddListener(AddNewPlayer);
        NewPlayerNameButton.onClick.AddListener(ToggleKeyboard);
        EnterButton.onClick.AddListener(EnterButtonPressed);
        ChoosePlayerOneButton.onClick.AddListener(ChoosingPlayerOne);
        ChoosePlayerTwoButton.onClick.AddListener(ChoosingPlayerTwo);

        UpdatePlayerList();
        print($"Start metody Start() w PlayerListManager mial miejsce{i++}");
    }

    private void ChoosingPlayerTwo()
    {
        PlayerDataHandler.Instance._isPlayerTwoChoosing = !PlayerDataHandler.Instance._isPlayerTwoChoosing;
    }

    private void ChoosingPlayerOne()
    {
        PlayerDataHandler.Instance._isPlayerOneChoosing = !PlayerDataHandler.Instance._isPlayerOneChoosing;
    }

    void OnSceneLoad()
    {
        UpdatePlayerList();
    }
    private void EnterButtonPressed()
    {
        Keyboard.SetActive(false);
        _isKeyboardActive = false;
        //AddNewPlayer();
    }

    void Update()
    {
        // Sprawdź, czy klawiatura jest aktywna i czy został wprowadzony tekst

    }

    void AddNewPlayer()
    {
        //_listOfPlayers.Contains()
        if (string.IsNullOrEmpty(NewPlayerText.text)) return;

        print("NewPlayerText.text to : " + NewPlayerText.text);
        print(_listOfPlayers.Exists(x => x.PlayerName == NewPlayerText.text));
        if (!_listOfPlayers.Exists(x => x.PlayerName == NewPlayerText.text))
        {
            _newPlayerData = new PlayerData
            {
                PlayerName = NewPlayerText.text,
                HighestScore = 0
            };
            _listOfPlayers.Add(_newPlayerData);
            UpdatePlayerList();
        }
        NewPlayerText.text = string.Empty;

    }

    public void UpdatePlayerList()
    {

        foreach (var prefab in _listOfPlayersPrefabs)
        {
            Destroy(prefab);
        }
        _listOfPlayersPrefabs.Clear();
        _listOfPlayers = PlayerDataHandler.Instance._playersDataList;
        var i = 0;
        foreach (var item in _listOfPlayers)
        {
            var player = Instantiate(PlayerListElementPrefab, parent: ScrollViewContent.transform);
            player.GetComponent<PlayerElementData>().ListIndex = i;
            player.GetComponent<PlayerElementData>().PlayerName = item.PlayerName;
            player.GetComponent<PlayerElementData>().HighestScore = item.HighestScore;
            _listOfPlayersPrefabs.Add(player);
            //player.transform.SetParent(ScrollViewContent.transform);
            var highestScoreObj = player.GetComponentInChildren<HighestScore>();
            var listPlayerNameObj = player.GetComponentInChildren<ListPlayerName>();
            highestScoreObj.gameObject.GetComponentInChildren<TMP_Text>().text = item.HighestScore.ToString();
            listPlayerNameObj.gameObject.GetComponentInChildren<TMP_Text>().text = item.PlayerName;
            i++;
        }
    }
    void ToggleKeyboard()
    {
        _isKeyboardActive = !_isKeyboardActive;

        if (_isKeyboardActive)
        {
            Keyboard.SetActive(true);
            //TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        }
        else
        {
            //NewPlayerNameButton.GetComponent<Image>().color = _originalButtonColor;
            return;
        }
    }

}
