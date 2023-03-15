using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravityBody2 : MonoBehaviour {

    
    public Transform playerTransform;
    public int gravity;
    public Vector3 gravityUp;
    public Vector3 localUp; 

    private void Start()
    {
        playerTransform = GetComponent<Transform>();
    }


    void FixedUpdate()
    {
        Vector3 gravityUp = playerTransform.position.normalized;
        Vector3 localUp = playerTransform.up.normalized;

        GetComponent<Rigidbody>().AddForce(-transform.up * gravity);

        Quaternion targetRotation = Quaternion.FromToRotation(localUp, Vector3.zero) * playerTransform.rotation;
        playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, 50f * Time.deltaTime);
    }
}
