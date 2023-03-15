using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrav : MonoBehaviour {

    public PlanetGrav attractorPlanet;
    private Transform playerTransform;

    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        playerTransform = transform;
        
    }

    void FixedUpdate()
    {
        Attract(playerTransform);
      
    }

    public float gravity = -12;

    public void Attract(Transform playerTransform)
    {
        Vector3 gravityUp = transform.position.normalized;
        Vector3 localUp = playerTransform.up;

        GetComponent<Rigidbody>().AddForce(gravityUp * gravity);

        Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * playerTransform.rotation;
        playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, 50f * Time.deltaTime);
    }




}
