using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript2 : MonoBehaviour {

    public float        gravity = -13;
    public GameObject   obj;
    private GameObject  trailon;

    public void Instantiate(TrailRenderer tr, Quaternion rotation)
    {
        trailon = Instantiate(obj, Vector3.zero, rotation);
        TrailMesh trailMesh = trailon.GetComponent<TrailMesh>();
        trailMesh.trInit();
    }





}
