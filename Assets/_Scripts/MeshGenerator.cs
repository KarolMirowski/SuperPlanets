//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//[RequireComponent(typeof(MeshFilter))]
//public class MeshGenerator : MonoBehaviour
//{
//    // Deklaracja zmiennej mesh.
//    Mesh mesh;
//    public TrailRenderer line;
//    // Wierzchołki i trójkąty.
//    Vector3[] vertices;
//    int[] triangles;
//
//    // Rozmiar siatki.
//    public int xSize = 40;
//    public int zSize = 40;
//
//    [SerializeField] private float var1 = .2f;
//    [SerializeField] private float var2 = .2f;
//    [SerializeField] private float var3 = 2f;
//    //[SerializeField] private float var4 ;
//
//    public GameObject obj;
//    private void OnValidate()
//    {
//        Mesher();
//        GetComponent<MeshFilter>().mesh = mesh;
//        GetComponent<MeshCollider>().sharedMesh = mesh;
//    }
//    void Start()
//    {
//        //mesh = new Mesh();
//        //Mesher();
//        GetComponent<MeshFilter>().mesh = mesh;
//        GetComponent<MeshCollider>().sharedMesh = mesh;
//   
//    }
//    public void Mesher()
//    {
//        CreateMesh();
//        UpdateMesh();
//        //Instantiate(obj, Random.onUnitSphere * 44, Quaternion.identity);
//    }
//
//    // Tworzy nowy mesh.
//    void CreateMesh()
//    {
//        vertices = new Vector3[(xSize + 1) * (zSize + 1)];
//
//      
//        for (int i = 0, z = 0; z <= zSize; z++)
//        {
//            for (int x = 0; x < xSize; x++)
//            {
//                float by = Mathf.PerlinNoise(x * var1, z * var2) * var3;
//                vertices[i] = new Vector3(x, by, z);
//                i++;
//            }
//        }
//
//        int verts = 0;
//        int tris = 0;
//
//        triangles = new int[xSize * zSize * 6];
//
//        for (int v = 0; v < zSize; v++)
//        {
//            for (int i = 0; i < xSize; i++)
//            {
//
//                triangles[tris] = verts;
//                triangles[tris + 1] = verts + xSize + 1;
//                triangles[tris + 2] = verts + 1;
//                triangles[tris + 3] = verts + 1;
//                triangles[tris + 4] = verts + xSize + 1;
//                triangles[tris + 5] = verts + xSize + 2;
//
//                verts++;
//                tris += 6;
//              
//
//            }
//
//        }
//
//      
//    }
//
//       // Podmienia meshe.
//    void UpdateMesh()
//    {
//        mesh.Clear();
//      
//        mesh.vertices = vertices;
//        mesh.triangles = triangles;
//
//        mesh.RecalculateBounds();
//    }
//
//
//    void CavityShape()
//    {
//      
//  
//    }
//}
//  