using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    [SerializeField] private bool _dontDestroyOnLoad;
    
    private void Awake() {
        if(_dontDestroyOnLoad == true)
            DontDestroyOnLoad(gameObject);
    }
}
