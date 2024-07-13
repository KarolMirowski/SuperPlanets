using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Scripting;

public class TrailMesh : MonoBehaviour
{
    public TrailRenderer tr;
    public GameObject thisObject;
    private Mesh mesh;
    private int counter = 0;

    void Awake()
    {
        mesh = new();
    }
    void Update()
    {
        UpdateMesh();
    }

    private void UpdateMesh()
    {
        bool needsColliderUpdate = false;
        GameObject newTrailon = null;



        needsColliderUpdate = mesh.vertexCount > 5;

        if (needsColliderUpdate)
        {
            tr.BakeMesh(mesh, useTransform: true);
            //counter++;
            var meshCollider = GetComponent<MeshCollider>();
            meshCollider.sharedMesh = mesh;
        }
        /*
        if (counter == 50)
        {
            newTrailon = await CreateNewTrailAsync();
        }

        if (newTrailon != null)
        {
            newTrailon.GetComponent<TrailMesh>().tr = tr;
            newTrailon.GetComponent<TrailMesh>().thisObject = thisObject;
            Destroy(this);
        }
        */
    }

    private async Task<GameObject> CreateNewTrailAsync()
    {
        return await Task.Run(() => Instantiate(thisObject, transform, false));
    }
}