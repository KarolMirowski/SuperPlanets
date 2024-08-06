using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SyncTrailColor : MonoBehaviour
{
    public Material PlayerMaterial;
    public Material TrailMaterial { get; set; }

    void OnValidate()
    {
        UpdateTrailMaterial();
    }
    void Awake()
    {
        //PlayerMaterial = GetComponent<MeshRenderer>().material;
        PlayerMaterial.EnableKeyword("_EMISSION");
        
    }
    void Start()
    {

    }
    public void UpdateTrailMaterial()
    {
        PlayerMaterial.SetColor("_EmissionColor", PlayerMaterial.color);


    }
}
