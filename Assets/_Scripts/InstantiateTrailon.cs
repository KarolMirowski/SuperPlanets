using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateTrailon : MonoBehaviour
{
    [SerializeField] private GameObject _trailonPrefab;
    
    void Awake()
    {
       
        GameObject trailon = Instantiate(_trailonPrefab, Vector3.zero, Quaternion.identity);
        trailon.GetComponent<TrailMesh>().Trail = GetComponentInChildren<TrailRenderer>();
        trailon.tag = "Trailon";
        trailon.layer = 10; //Trailon layer
        GameObject trailonRootObject = GameObject.Find("Trailons");
        trailon.transform.SetParent(trailonRootObject.transform);
        trailon.gameObject.name = "TrailonTwo";
        if(GetComponent<PlayerController>() == null)
            trailon.gameObject.name = "TrailonBot";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
