using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusInst : MonoBehaviour
{
    [SerializeField]
    private GameObject instance;
    private GameObject player;


    private GameObject EventSystem;
    void Start()
    {
        EventSystem = GameObject.Find("EventSystem");        
    }

       
}
