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
    private PlayerData dummyData;
    [SerializeField] public PlayerData PlayerOneData;
    [SerializeField] public PlayerData PlayerTwoData;
    public bool _isPlayerOneChoosing = false;
    public bool _isPlayerTwoChoosing = false;
    public TMP_Text PlayerOneText;
    public TMP_Text PlayerTwoText;
    public IDataService DataService = new JsonDataService();
    public event Action OnPlayerDataDeserialized;
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
        MySceneManager.Instance.OnMainMenuSceneLoad += DeserializePlayerDataList;
        MySceneManager.Instance.OnMainMenuSceneLoad += PrintOn;
    }
    public void PrintOn()
    {
        print("Wczytanie sceny wywolalo metode print poprzez event ze scene manager");
    }
    public void SerializeJson()
    {
        Debug.Log(Application.persistentDataPath);
        if (DataService.SaveData<List<PlayerData>>("/player-data.json", _playersDataList, false))
        {

        }
        else
        {
            Debug.Log("Z jakiegos powodu json nie serializuje.");
        }

    }

    void OnMenuSceneLoaded()
    {
        DeserializePlayerDataList();
        Debug.Log("Udalo sie zdeserializowac ze wzgledu na powrot do menu");
    }
    void OnValidate()
    {
        //SerializeJson(_playersDataList);
        //_playersDataList = DeserializePlayerDataList();
    }

    public void DeserializePlayerDataList()
    {
        _playersDataList = DataService.LoadData<List<PlayerData>>("/player-data.json", false);
        OnPlayerDataDeserialized?.Invoke();
    }

}

