using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGrav : MonoBehaviour
{
    [SerializeField]    private float gravity = -12;
    [SerializeField]    private float speed = 1;

    private Transform playerTransform;

    [HideInInspector] public Renderer mat;
    public float var1 ;
    public float var2 ;
    public float var3 ;
    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        playerTransform = transform;
        //mat = GetComponent<Renderer>();
        //mat.material.color = Random.ColorHSV();
}

    private void OnEnable()
    {
        var1 = Random.Range(1f, 5f);
        var2 = Random.Range(1f, 5f);
        var3 = Random.Range(1f, 5f);
        GetComponentInChildren<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        //GetComponent<Transform>().localScale = new Vector3(var1, var2 , var3);
    }
    void FixedUpdate()
    {
        Vector3 gravityUp = (transform.position).normalized;
        Vector3 localUp = playerTransform.up;

        playerTransform.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);
        playerTransform.GetComponent<Rigidbody>().AddForce(Vector3.forward * speed);

        Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * playerTransform.rotation;
        playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, 50f * Time.deltaTime);
    }
}
