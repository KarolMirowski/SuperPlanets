using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Unity.Burst;



public class TrailMesh : MonoBehaviour
{




    public TrailRenderer tr;

    private Mesh mesh;
    private Camera camera;


    private bool collisionBool;
    public void trInit()
    {

        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        //cos


    }
    public void Awake()
    {
        mesh = new Mesh();
        mesh.MarkDynamic();
        mesh.Optimize();
        
    }

    void Start()
    {
        if (gameObject.name == "TrailonOne")
            camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        if (gameObject.name == "TrailonTwo")
            camera = GameObject.FindGameObjectWithTag("MainCamera2").GetComponent<Camera>();
        print(camera.gameObject.GetComponentInParent<PlayerController>().gameObject.name);
        
    }

    public void OnValidate()
    {

    }

    void FixedUpdate()
    {
        tr.BakeMesh(mesh, camera, useTransform: true);

        GetComponent<MeshFilter>().mesh = mesh;
        if (mesh.vertexCount > 5)
            GetComponent<MeshCollider>().sharedMesh = mesh;

    }









}
