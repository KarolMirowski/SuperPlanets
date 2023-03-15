using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGravBody : MonoBehaviour
{
    public PlanetGrav planet;
    public float gravity = -12;
    

    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        planet = FindObjectOfType<PlanetGrav>();

    }

    void FixedUpdate()
    {
        planet.Attract(transform.transform);
        
    }
}
