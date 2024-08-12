using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDataHandler : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField]
    public List<PlayerData> _playersDataList;
    public static PlayerDataHandler Instance;
    //PlayerData ore PlayewrElementData;
    public PlayerData PlayerOneData;
    public PlayerData PlayerTwoData;
    public bool _isPlayerOneChoosing = false;
    public bool _isPlayerTwoChoosing = false;
    [SerializeField] public TMP_Text PlayerOneText;
    [SerializeField] public TMP_Text PlayerTwoText;
    public IDataService DataService = new JsonDataService();
    public event Action OnPlayerDataDeserialized;
    public event Action OnPlayerDataHandlerValidate;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        if (_playersDataList == null) _playersDataList = new List<PlayerData>();
    }
    void Start()
    {
        DeserializePlayerDataList();
        
    }
    
    public void SerializeJson()
    {
        
        if (DataService.SaveData<List<PlayerData>>("player-data.json", _playersDataList, false))
        {

        }
        else
        {
            Debug.Log("Z jakiegos powodu json nie serializuje.");
        }

    }
    public void ValidateNames(){
        OnPlayerDataHandlerValidate?.Invoke();
    }
    void OnApplicationQuit(){
        SerializeJson();
    }

    public void DeserializePlayerDataList()
    {
        _playersDataList.Clear();
        _playersDataList = new();
        _playersDataList = DataService.LoadData<List<PlayerData>>("player-data.json", false);
        OnPlayerDataDeserialized?.Invoke();
    }

    public void UpdateHighestScore()
    {
        
        print("UPDATE LAYER DATA LIST POSZLO : " + _playersDataList[0].ToString());
        if (PlayerOneData.HighestScore < PlayerOneData.CurrentScore)
        {
            PlayerData existingPlayer = _playersDataList.Find(p => p.PlayerName == PlayerOneData.PlayerName);
            if (existingPlayer != null)
            {
                // Aktualizujemy pola istniejącego obiektu
                existingPlayer.CurrentScore = PlayerOneData.CurrentScore;
                existingPlayer.HighestScore = PlayerOneData.HighestScore;
                existingPlayer.ListIndex = PlayerOneData.ListIndex;
                // ... aktualizuj inne pola według potrzeb
                
            }
            else
            {
                // Gracz nie istnieje, dodajemy nowy obiekt do listy
                _playersDataList.Add(PlayerOneData);
            }

        }

        if (PlayerTwoData.HighestScore < PlayerTwoData.CurrentScore)
        {
            PlayerData existingPlayer = _playersDataList.Find(p => p.PlayerName == PlayerTwoData.PlayerName);
            if (existingPlayer != null)
            {
                // Aktualizujemy pola istniejącego obiektu
                existingPlayer.CurrentScore = PlayerTwoData.CurrentScore;
                existingPlayer.HighestScore = PlayerTwoData.HighestScore;
                existingPlayer.ListIndex = PlayerTwoData.ListIndex;
                // ... aktualizuj inne pola według potrzeb
            }
            else
            {
                // Gracz nie istnieje, dodajemy nowy obiekt do listy
                _playersDataList.Add(PlayerTwoData);
            }
        }
        SerializeJson();
        


    }

}

