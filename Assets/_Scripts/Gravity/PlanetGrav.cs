using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGrav : MonoBehaviour {

    public float gravity = -10f;
    public Transform sphereTransform;
    private Transform _playerTransform;
    
    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        _playerTransform = transform;
    }

    void FixedUpdate()
    {
        Attract(_playerTransform);
    }

    public void Attract(Transform playerTransform)
    {
        Vector3 gravityUp = (playerTransform.position - sphereTransform.position).normalized;
        Vector3 localUp = playerTransform.up;

        playerTransform.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);

        Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * playerTransform.rotation;
        playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, 50f * Time.deltaTime);
    }
}
