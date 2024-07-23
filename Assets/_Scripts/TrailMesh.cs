using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Scripting;
using System.Collections.Generic;

public class TrailMesh : MonoBehaviour
{
    public TrailRenderer Trail;

    public GameObject thisObject;
    private Mesh mesh;
    private int counter = 0;
    private GameObject _trailons;
    [SerializeField] bool needsColliderUpdate = true;
    [SerializeField] private GameObject _trailonPrefab;
    [SerializeField] private GameObject _trailPrefab;

    void Awake()
    {
        mesh = new Mesh();
        mesh.MarkDynamic();
        //mesh.SetVertices(new List<Vector3> { Vector3.zero, Vector3.forward, Vector3.back });
        if (Trail == null)
        {
            var obj = GameObject.FindGameObjectWithTag("PlayerTwo");
            //print(this.name + $": {obj.name}");
            var trail = obj.GetComponentInChildren<TrailRenderer>();
            //print(this.name + $": {trail.name}");
            Trail = trail;
        }

        //Find Trailons obj as parent object.
        _trailons = GameObject.Find("Trailons");
        //Sprawdzenie szukania trailon
        
        
    }





    void LateUpdate()
    {
        Trail.BakeMesh(mesh, useTransform: true);
        GetComponent<MeshFilter>().mesh = mesh;

        // Checking if there are more than 5 vertices to avoid collison between sphere(player) and trailon.
        if (mesh.vertexCount > 5)
            GetComponent<MeshCollider>().sharedMesh = mesh;
        // Checkinh if there are more than 100 vertices to destroy old trailrendewrer
        // and create new one along with new trailon to avoid updating the whole trailon every frame 
        // and potentially fix collision issues.
        counter++;
        if (counter > 100)
        {
            
            //Vector3 oldPosition = new();
            //Quaternion oldRotation = new();
            //Trail.transform.GetPositionAndRotation(out oldPosition, out oldRotation);
            //GameObject trailParent  = Trail.gameObject;
            Trail.emitting = false;
            
            GameObject newTrail = Instantiate(_trailPrefab, Trail.gameObject.transform);
            newTrail.GetComponent<Renderer>().material = Trail.gameObject.GetComponent<Renderer>().material;
            //Trail = newTrail.GetComponent<TrailRenderer>();
            var newTrailon = Instantiate(_trailonPrefab);
            newTrailon.name = $"{gameObject.name}";
            newTrailon.GetComponent<TrailMesh>().Trail = Trail.GetComponent<TrailRenderer>();
            newTrailon.transform.SetParent(_trailons.transform);
            newTrailon.tag = gameObject.tag;
            newTrailon.layer = gameObject.layer;
            Destroy(this);
            
            
        }



    }
}