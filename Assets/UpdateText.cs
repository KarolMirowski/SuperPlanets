using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateText : MonoBehaviour
{
    public TMP_Text _playerNameText;
    private PlayerDataHandler _dataHandler;
    void Start()
    {
        PlayerDataHandler.Instance.OnPlayerDataHandlerValidate += TextUpdate;
        _playerNameText = GetComponent<TMP_Text>();
        _dataHandler = PlayerDataHandler.Instance;
        _dataHandler.OnPlayerDataHandlerValidate += TextUpdate;
        TextUpdate();
    }
    void TextUpdate()
    {
        if(_dataHandler.PlayerOneData.PlayerName == "") return;
        if (CompareTag("PlayerOne") && !string.IsNullOrEmpty(_dataHandler.PlayerOneData.PlayerName))
        {
            _playerNameText.text = _dataHandler.PlayerOneData.PlayerName;
            
        }
        if(_dataHandler.PlayerTwoData.PlayerName == "") return;
        if (CompareTag("PlayerTwo"))
        {
            _playerNameText.text = _dataHandler.PlayerTwoData.PlayerName;
            
        }



    }
}
