using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDataHandler : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField]
    TextAsset _playersDataTextFile;
    public List<PlayerData> _playersDataList;
    public static PlayerDataHandler Instance;
    public PlayerElementData PlayerOneData = new();
    public PlayerElementData PlayerTwoData = new();
    public bool _isPlayerOneChoosing = false;
    public bool _isPlayerTwoChoosing = false;
    public TMP_Text PlayerOneText;
    public TMP_Text PlayerTwoText;
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
        if(_playersDataList == null) _playersDataList = new List<PlayerData>();
    }

}

