using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLog : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private PlayerController controller;


    public void Start()
    {
         //controller = GetComponentInParent<PlayerController>();
         //rb = GetComponentInParent<Rigidbody>();
    
    }

    private void OnCollisionEnter(Collision collision)
    {


        
        Debug.Log("COLLIDER sie uruchomi");
        controller.speed = 0;
        rb.Sleep();


    }
    private void OnCollisionStay(Collision collision)
    {
        rb.Sleep();
        
    }

    


    








}
