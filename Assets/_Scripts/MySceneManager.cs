using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    //[SerializeField] private GameManager gameManager;
    public static MySceneManager Instance;
    
    public string checkDontDestroy;
    public string checkDontDestroyGetSet{get;set;}
    void Awake()
    {
        //GameManager.OnGameStateChange += Sprawdzam;
        //GameManager.OnGameStateChange += LoadStage;
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

   


    //Tu były testy, usunąć niepotrzebne
    public void LoadScene(){
        SceneManager.LoadScene("WorkingScene");
        GameManager.Instance.UpdateGameState(GameManager.GameState.GamePlay);
        
        //Zatrzymanie sceny np dla loading screenu.
        //scene.allowSceneActivation = true; // It is set true by default. Written for future applications.

    }
    
}
