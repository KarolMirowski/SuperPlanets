using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class DontDestroyOnLoad : MonoBehaviour
{
    [SerializeField] private bool _dontDestroyOnLoad;

    private void Awake()
    {
        if (_dontDestroyOnLoad == true)
            DontDestroyOnLoad(gameObject);

        GameObject[] managersObjectArray = GameObject.FindGameObjectsWithTag("Managers");
        managersObjectArray = managersObjectArray.Reverse().ToArray();

        if (managersObjectArray.Length > 1)
        {
            for(int i = 0; i < managersObjectArray.Length - 1 ;i++){
                Destroy(managersObjectArray[i]);
            }
        }
    }
}
