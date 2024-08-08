using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdatePlayerName : MonoBehaviour
{
    [SerializeField] TMP_Text _playerNameText;
    void Start()
    {
        _playerNameText.text = GetComponent<PlayerElementData>().PlayerName;
    }

    
}
