using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

using UnityEngine.Rendering;

[ExecuteInEditMode]
public class SphereVerts : MonoBehaviour
{
    [Range(0,10)]
    public int VertsMultiplier = 1; 
    public int Count = 1;

    
    public Mesh mesh;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //Mesh mesh = new Mesh();
        //mesh.indexFormat = IndexFormat.UInt32;
        //mesh = Planet.GenerateMesh(VertsMultiplier);
        //GetComponent<MeshFilter>().mesh = mesh;
        //UVSet();
        //AssetDatabase.CreateAsset(this.GetComponent<MeshFilter>().mesh, "Assets/Prefabs/KulaDajeFulaUVs.mesh");
        //GetComponent<MeshFilter>().sharedMesh.RecalculateNormals();
        //.Log("Normalsy zrekalkulowano.");
        //GetComponent<MeshFilter>().mesh.Optimize();
        //GetComponent<MeshFilter>().mesh.MarkDynamic();
        // GetComponent<MeshFilter>().mesh.MarkDynamic();

        //GetComponent<MeshCollider>().sharedMesh.indexFormat = IndexFormat.UInt32;
        //GetComponent<MeshCollider>().sharedMesh = GetComponent<MeshFilter>().sharedMesh;
        //GetComponent<MeshFilter>().mesh = Planet.GenerateMesh(VertsMultiplier);

        //GetComponent<MeshFilter>().mesh = ss;
    }

    void UVSet()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        Vector3[] vertices = mesh.vertices;
        Vector2[] uvs = new Vector2[vertices.Length];

        for (int i = 0; i < uvs.Length; i++)
        {
            uvs[i] = new Vector2(vertices[i].x, vertices[i].z);
        }
        mesh.uv = uvs;
    }
    
}
