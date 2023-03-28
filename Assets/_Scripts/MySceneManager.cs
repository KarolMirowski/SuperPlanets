using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public static MySceneManager Instance;
    public string checkDontDestroy;
    public string checkDontDestroyGetSet{get;set;}
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    public void LoadStage(string sceneName){
        var scene = SceneManager.LoadSceneAsync("WorkingScene");
        scene.allowSceneActivation = true; // It is set true by default. Written for future applications.


    }
}
