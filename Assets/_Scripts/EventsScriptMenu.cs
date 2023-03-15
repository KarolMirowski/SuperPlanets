using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventsScriptMenu : MonoBehaviour
{
   

    

   

    public void ResetScene()
    {
        //Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("WorkingScene");
    }
    public void BackToMenu()
    {
        //Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("Menu");
    }
    public void GoToOptions()
    {
        //Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("Options");
    }
}
