using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMainMenu : MonoBehaviour
{
    public void BackToMainMenuButton(){
        MySceneManager.Instance.LoadMainMenuScene();
    }
}
