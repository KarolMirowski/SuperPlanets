using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Scripting;
using System.Collections.Generic;
using UnityEditor;

public class TrailMesh : MonoBehaviour
{
    public TrailRenderer Trail;

    private Mesh mesh;
    private int meshCounter = 0;
    private GameObject _trailons;
    [SerializeField] bool needsColliderUpdate = true;
    [SerializeField] private GameObject _trailonPrefab;
    [SerializeField] private GameObject _trailPrefab;
    [SerializeField] private GameObject _cube;
    

    void Awake()
    {
        mesh = new Mesh();
        mesh.MarkDynamic();
        
        if (Trail == null && GameObject.FindGameObjectWithTag("PlayerTwo") != null)
        {
            var obj = GameObject.FindGameObjectWithTag("PlayerTwo");
            var trail = obj.GetComponentInChildren<TrailRenderer>();
            Trail = trail;
        }
        //Find Trailons obj as parent object.
        _trailons = GameObject.Find("Trailons");
        


    }
    

    void Update()
    {
        BakeMeshFromTrail();
        //TrailonDivider();
    }

    void BakeMeshFromTrail()
    {
        Trail.BakeMesh(mesh, useTransform: true);
        GetComponent<MeshFilter>().mesh = mesh;

        // Checking if there are more than 5 vertices to avoid collison between sphere(player) and trailon.
        if (mesh.vertexCount > 5)
            GetComponent<MeshCollider>().sharedMesh = mesh;
       meshCounter++;
    }
    void TrailonDivider()
    {
        //Przerwanie metody kiedy gracz uderzyl w trailon;
        if(Trail.GetComponentInParent<PlayerController>().StopTrailon) return;
        if (meshCounter >= 20)
        {
            int index = mesh.vertexCount - 1;
            
            //zmienin dekrementacje i do srodka petli
            for (int i = index; i >= 0; i -= 2)
            {
                if (i - 1 < 0 || i - 2 < 0 ) break;
                float distanceBetweenPoints = Vector3.Distance(a: mesh.vertices[0], b: mesh.vertices[1]);
                var c = Instantiate(_cube);
                
                Vector3 pointBetween = Vector3.Lerp(mesh.vertices[i], mesh.vertices[i - 1], 0.5f);
                Vector3 forwardPointToLookAt = Vector3.Lerp(mesh.vertices[i - 2], mesh.vertices[i - 3], 0.5f);
                
                c.transform.position = pointBetween;
                c.transform.LookAt(forwardPointToLookAt);
            }
            
            Trail.emitting = false;
            GameObject newTrail = Instantiate(_trailPrefab, Trail.gameObject.transform);
            newTrail.GetComponent<Renderer>().material = Trail.gameObject.GetComponent<Renderer>().material;
            var newTrailon = Instantiate(_trailonPrefab);
            newTrailon.name = $"{gameObject.name}";
            newTrailon.GetComponent<TrailMesh>().Trail = newTrail.GetComponent<TrailRenderer>();
            newTrailon.GetComponent<TrailMesh>()._cube = _cube;
            newTrailon.transform.SetParent(_trailons.transform);
            newTrailon.tag = gameObject.tag;
            newTrailon.layer = gameObject.layer;

            Destroy(this);
        }
    }
    void MeshThicker()
    {

    }




}