using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Try : MonoBehaviour
{

    Mesh mesh;
    Vector3[] vertices;
    int[] triagles;


    public struct Triangles
    {
        public List<int> wierzcholki;

        public Triangles(int a, int b, int c)
        {
            wierzcholki = new List<int>() { a, b, c };
        }
    }
    public struct Polygon
    {
        public List<int> m_Vertices;

        public Polygon(int a, int b, int c)
        {
            m_Vertices = new List<int>() { a, b, c };
        }
    }
    Mesh TriangleMesh()
    {
        Mesh mesh = new Mesh();
        return mesh;
    }



    void Awake()
    {
        mesh = GetComponent<MeshFilter>().sharedMesh;
    }

    private void OnEnable()
    {
        Mesh mesh = new Mesh();
        mesh = GetComponent<MeshFilter>().sharedMesh;

        for (int i = 0; i < mesh.vertexCount; i++)
        {
            
        }


        
        
    }

}
