using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class JoinPlayer : MonoBehaviour
{
    [SerializeField]
    private PlayerInputManager inputManager;
    [SerializeField]
    private GameObject playerPrefab;
    void Awake()
    {

    }
    void SetTwoPlayersGameplay()
    {

        inputManager.playerPrefab = playerPrefab;
        //inputManager.playerPrefab.GetComponent<PlayerController>().turnLeftButton = CanvasManager.Instance.TurnLeftButton;
        //inputManager.playerPrefab.GetComponent<PlayerController>().turnRightButton = CanvasManager.Instance.TurnRightButton;
        inputManager.JoinPlayer();








    }


    void Start()
    {
        var gameManager = GameManager.Instance;

        if (gameManager.PlayerCountNumber == 2)
        {
            SetTwoPlayersGameplay();
        }
    }
}
