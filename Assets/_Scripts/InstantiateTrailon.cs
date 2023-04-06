using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateTrailon : MonoBehaviour
{
    [SerializeField] private GameObject _trailonPrefab;
    [SerializeField] private GameObject _trailonGroup;
    void Awake()
    {
        var trailonGroupTransform = GameObject.Find("Trailons").transform;
        var trailon = Instantiate(_trailonPrefab, trailonGroupTransform);
        trailon.GetComponent<TrailMesh>().tr = this.GetComponentInChildren<TrailRenderer>();
        trailon.tag = "Trailon";
        trailon.layer = 9; //Trailon layer
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
