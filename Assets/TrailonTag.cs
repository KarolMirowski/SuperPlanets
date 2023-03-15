using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailonTag : MonoBehaviour
{
    private     PlayerController control;
    private new Rigidbody rigidbody;


    private void Start()
    {
        transform.rotation = GetComponentInChildren<Transform>().transform.rotation;

        transform.position = Vector3.zero;
        
        //control = GetComponentInParent<PlayerController>();
        //rigidbody = GetComponentInParent<Rigidbody>();
    }
  




}
