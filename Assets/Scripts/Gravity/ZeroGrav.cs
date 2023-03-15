using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroGrav : MonoBehaviour
{
    [SerializeField]
    private int gravity = -20;

    public float speed;
    private Rigidbody rb;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(Vector3.forward * speed);
        rb.AddForce(-Vector3.up * gravity);


    }
}
