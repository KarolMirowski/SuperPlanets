using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataHandler : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField]
    TextAsset _playersDataTextFile;
    public List<PlayerData> _playersDataList;
    public PlayerData[] _playersDataList2;
    public static PlayerDataHandler Instance;
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

        
    }
   

    
}
