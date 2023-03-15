using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors : MonoBehaviour
{
    public GameObject player;
    public GameObject planet;
    public GameObject trail;
    public GameObject sky;

    public Material playerMat;
    public Material planetMat;
    public Material trailMat;
    public Material skyMat; 

    void Awake()
    {
        
        
    }

    void mPalette()
    {
        player.GetComponent<Renderer>().material = playerMat;
        planet.GetComponent<Renderer>().material = planetMat;
        trail.GetComponent<Renderer>().material = trailMat;
        sky.GetComponent<Renderer>().material = skyMat;



    }
}
