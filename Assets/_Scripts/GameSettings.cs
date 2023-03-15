using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Manager/GameSettings")]

public class GameSettings : ScriptableObject
{
    [SerializeField]
    private string _gameVersion = "0.0.0";

    public string GameVersion { get { return _gameVersion; } }

    [SerializeField]
    private string _nickName = "Karol";
    [SerializeField]
    public float pOneSpeed = 0.4f;
    [SerializeField]
    public float pTwoSpeed = 0.4f;
    [SerializeField]
    public float pOneFOV;
    [SerializeField]
    public float pTwoFOV;
    [SerializeField]
    public float RotationSpeed;

    public void ColorSet1()
    {

    }
    public void ColorSet()
    {

    }
    















    public string NickName
    {
        get
        {
            int value = Random.Range(0, 9999);
            return _nickName + " id: " + value.ToString();
        }
    }
}
