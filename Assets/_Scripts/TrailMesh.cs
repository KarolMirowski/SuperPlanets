using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Unity.Burst;

using UnityEngine;
using TMPro.Examples;

public class TrailMesh : MonoBehaviour
{
    public TrailRenderer tr;
    private Mesh mesh;
    public Camera camera;
    public float collisionThreshold = 0.1f; // Próg odległości dla kolizji
    [SerializeField] private GameObject thisObject;
    private int counter = 0;

    void Start()
    {
        mesh = new Mesh();
        mesh.MarkDynamic();
        if (tr == null)
        {
            tr = GameObject.FindGameObjectWithTag("PlayerTwo").GetComponentInChildren<TrailRenderer>();
            
        }

    }

    void Update()
    {
        UpdateMesh();
        

    }

    void UpdateMesh()
    {

        tr.BakeMesh(mesh, useTransform: true);
        if (mesh.vertexCount > 5)
        {
            var meshCollider = GetComponent<MeshCollider>();
            meshCollider.sharedMesh = null;
            meshCollider.sharedMesh = mesh;
        }
        counter++;
        if (counter == 50)
        {
            var newTrailon = Instantiate(thisObject, transform, false);
            newTrailon.GetComponent<TrailMesh>().tr = tr;
            newTrailon.GetComponent<TrailMesh>().thisObject = thisObject;
            Destroy(this);
            print("Osiągnęło 50");
            
            

        }




    }


}
/*
public class TrailMesh : MonoBehaviour
{




    public TrailRenderer tr;

    private Mesh mesh;
    public Camera camera;

    private bool collisionBool;
    public void trInit()
    {

        //GameObject player = GameObject.FindGameObjectWithTag("Player");



    }
    public void Awake()
    {
    }

    void Start()
    {
        mesh = new Mesh();
        //mesh.MarkDynamic();
        //mesh.Optimize();
        
        
        if (gameObject.name == "TrailonOne")
            camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        if (gameObject.name == "TrailonTwo" )
            camera = GameObject.FindGameObjectWithTag("MainCamera2").GetComponent<Camera>();
        
        //print(this.name + ": " +camera.gameObject.tag);
    }


    void FixedUpdate()
    {
        tr.BakeMesh(mesh, camera, useTransform: true);

        //GetComponent<MeshFilter>().mesh = mesh;
        
        if (mesh.vertexCount > 5)
            GetComponent<MeshCollider>().sharedMesh = mesh;
        
    }









}

*/