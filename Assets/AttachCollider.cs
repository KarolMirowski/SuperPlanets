using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void OnValidate()
    {
        AttachMeshCollider();
    }
    void AttachMeshCollider(){
        if (GetComponent<MeshCollider>() == null){
            var meshCollider = gameObject.AddComponent<MeshCollider>();
            meshCollider.sharedMesh = GetComponent<MeshFilter>().mesh;
            print("Obiekt traioltact dodal komponent bo go nie bylo ");
            transform.localScale *= 10;
        }
    }

    
}
