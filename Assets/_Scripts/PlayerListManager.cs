using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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
    public GameObject PlayerToDelete;
    public GameObject DeletePanel;
    public GameObject MenuPanel;
    public Button YesDeleteButton;
    public Button NoDeleteButton;

    private List<GameObject> _listOfPlayersPrefabs = new List<GameObject>();
    public GameObject Keyboard;
    public Button EnterButton;
    public List<PlayerData> _listOfPlayers;
    private PlayerData _newPlayerData = new PlayerData();

    private bool _isKeyboardActive = false;
    private int i=1;
    public static PlayerListManager Instance;
    private void Awake()
{
    if (Instance == null)
    {
        Instance = this;
        //DontDestroyOnLoad(gameObject);
    }
    else if (Instance != this)
    {
        Destroy(gameObject);
    }
}
    void Start()
    {
        //PlayerDataHandler.Instance._playersDataList = _listOfPlayers;
        _listOfPlayers = PlayerDataHandler.Instance._playersDataList;
        AddNewPlayerButton.onClick.AddListener(AddNewPlayer);
        NewPlayerNameButton.onClick.AddListener(ToggleKeyboard);
        EnterButton.onClick.AddListener(EnterButtonPressed);
        ChoosePlayerOneButton.onClick.AddListener(ChoosingPlayerOne);
        ChoosePlayerTwoButton.onClick.AddListener(ChoosingPlayerTwo);
        YesDeleteButton.onClick.AddListener(DeletePlayer);
        NoDeleteButton.onClick.AddListener(CancelDeletePlayer);
        SendPlayerData.SendDataEvent += UpdatePlayerOneName;
        SendPlayerData.SendDataEvent += UpdatePlayerTwoName;

        PlayerDataHandler.Instance.OnPlayerDataDeserialized += UpdatePlayerList;
        UpdatePlayerList();
        
    }
    void OnDestroy(){
        PlayerDataHandler.Instance.OnPlayerDataDeserialized -= UpdatePlayerList;

    }
    private void ChoosingPlayerTwo()
    {
        PlayerDataHandler.Instance._isPlayerTwoChoosing = !PlayerDataHandler.Instance._isPlayerTwoChoosing;
        PlayerDataHandler.Instance._isPlayerOneChoosing = false;
    }

    private void ChoosingPlayerOne()
    {
        PlayerDataHandler.Instance._isPlayerOneChoosing = !PlayerDataHandler.Instance._isPlayerOneChoosing;
        PlayerDataHandler.Instance._isPlayerTwoChoosing = false;
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
            PlayerDataHandler.Instance.SerializeJson();
        }
        NewPlayerText.text = string.Empty;

    }
    public void ActivateDeletePanel(){
        DeletePanel.SetActive(true);
        MenuPanel.SetActive(false);
    }
    public void DeletePlayer(){
        _listOfPlayers.RemoveAll(p => p.PlayerName == PlayerToDelete.name);
        Destroy(PlayerToDelete.gameObject);
        Destroy(PlayerToDelete);
        DeletePanel.SetActive(false);
        MenuPanel.SetActive(true);
        UpdatePlayerList();
    }
    public void CancelDeletePlayer(){

        DeletePanel.SetActive(false);
        MenuPanel.SetActive(true);
    }
    public void UpdatePlayerList()
    {
        print("Update Player List() z PlayerListManager() urchomnione.");
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
            player.GetComponent<PlayerElementData>().SinglePlayerData.ListIndex = i;
            player.GetComponent<PlayerElementData>().SinglePlayerData.PlayerName = item.PlayerName;
            player.GetComponent<PlayerElementData>().SinglePlayerData.HighestScore = item.HighestScore;
            _listOfPlayersPrefabs.Add(player);
            //player.transform.SetParent(ScrollViewContent.transform);
            var highestScoreObj = player.GetComponentInChildren<HighestScore>();
            var listPlayerNameObj = player.GetComponentInChildren<ListPlayerName>();
            highestScoreObj.gameObject.GetComponentInChildren<TMP_Text>().text = item.HighestScore.ToString();
            print(item.HighestScore.ToString() + "UPDATEPLAYERLSIT");
            print(item.PlayerName+"UPDATEPLAYER LIST");
            print($"i w update player list prefaby wynosi {i}");
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
    void UpdatePlayerOneName(){ 
        if(PlayerDataHandler.Instance.PlayerOneData.PlayerName == null) return; 
        ChoosePlayerOneButton.GetComponentInChildren<TMP_Text>().text = PlayerDataHandler.Instance.PlayerOneData.PlayerName;

    } void UpdatePlayerTwoName(){
        if(PlayerDataHandler.Instance.PlayerTwoData.PlayerName == null) return; 
        ChoosePlayerOneButton.GetComponentInChildren<TMP_Text>().text = PlayerDataHandler.Instance.PlayerTwoData.PlayerName;

    }

}
