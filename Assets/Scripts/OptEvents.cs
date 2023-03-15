using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class OptEvents : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject playerOne;
    [SerializeField]
    private GameObject playerTwo;
    [SerializeField]
    private TMPro.TMP_Text p1speed;
    [SerializeField]
    private TMPro.TMP_Text p2speed;
    [SerializeField]
    private GameSettings gameSettings;
   


    void Start()
    {
        p1speed.text = Convert.ToString(gameSettings.pOneSpeed);
        p2speed.text = Convert.ToString(gameSettings.pTwoSpeed);
        gameSettings.RotationSpeed = 5f;
        
        

    }

    public void AddSpeedOne()
    {
        gameSettings.pOneSpeed += 0.10f;
        
        p1speed.text = gameSettings.pOneSpeed.ToString();
    }
    public void LowSpeedOne()
    {
        gameSettings.pOneSpeed -= 0.10f;
        
        p1speed.text = Convert.ToString(gameSettings.pOneSpeed);
    }
    public void AddSpeedTwo()
    {
        gameSettings.pTwoSpeed += 0.1f;
        
        p2speed.text = gameSettings.pTwoSpeed.ToString();
    }
    public void LowSpeedTwo()
    {
        gameSettings.pTwoSpeed -= 0.1f;
        
        p2speed.text = gameSettings.pTwoSpeed.ToString();
    }
    public void BackToMenu()
    {
        //Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("Menu");
        
    }

    /*
    public void AddFov()
    {
        gameSettings.pOneFOV += 1f;
        p1fov.text = Convert.ToString(gameSettings.pOneFOV);
    }
    public void LowFov()
    {
        gameSettings.pOneFOV += 1f;
        p1fov.text = Convert.ToString(gameSettings.pOneFOV);
    }
    public void AddFov2()
    {
        gameSettings.pOneFOV += 1f;
        p2fov.text = Convert.ToString(gameSettings.pTwoFOV);
    }
    public void LowFov2()
    {
        gameSettings.pOneFOV += 1f;
        p2fov.text = Convert.ToString(gameSettings.pTwoFOV);
    }
    */












   
}
