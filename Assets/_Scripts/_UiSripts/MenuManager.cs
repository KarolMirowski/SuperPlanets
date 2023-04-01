using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{
    private static MenuManager instance;
    public static MenuManager Instance { get {return instance;} }
    
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _goToSettingsButton;
    [SerializeField] private Button _goToCreditsButton;
    [SerializeField] private Button[] _backToMenuButton;
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _creditsPanel;




    private void Awake() {
        if (instance == null) {instance = this;}
        else {Destroy(gameObject);}
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
