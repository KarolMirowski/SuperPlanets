using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Unity.Burst;



public class TrailMesh : MonoBehaviour
{
    

    
    
    public TrailRenderer tr;

    private Mesh mesh;
    

    private bool collisionBool;
    public void trInit()
    {

        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        
        
    }
    public void Start()
    {
        mesh = new Mesh();
        mesh.MarkDynamic();
        mesh.Optimize();
    }

    void FixedUpdate()
    {
        tr.BakeMesh(mesh, useTransform: true);

        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshCollider>().sharedMesh = mesh;
    }
        



    
    
  


}
