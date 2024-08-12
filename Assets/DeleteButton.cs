using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteButton : MonoBehaviour
{
    private PlayerListManager _playerListManager;
    [SerializeField] private Button _thisButton;

    void Start(){
        _playerListManager = PlayerListManager.Instance;
        _thisButton.onClick.AddListener(RunDelete);
    }

    private void RunDelete()
    {
        _playerListManager.PlayerToDelete = gameObject.transform.parent.gameObject;
        _playerListManager.ActivateDeletePanel();
    }
}
