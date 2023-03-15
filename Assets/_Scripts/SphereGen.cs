using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
public class SphereGen : MonoBehaviour 
{
    private GameObject p;
    public int SubDivisionNum = 2;

    public float factor = 0.5f;
    public float factor2 = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        //p = gameObject.AddComponent(typeof(Planet)) as Planet;
        p.InitAsIcosohedron();
        p.Subdivide(SubDivisionNum);
    }

    public void OnClickSin()
    {
        //Debug.Log(Mathf.Sin(SineWaveSec));
    }

    public void OnClickGen()
    {
        //if (this.gameObject.GetComponent<Planet>())
        try
        {
            Destroy(this.gameObject.GetComponent<Planet>());
            Destroy(FindObjectOfType<PlanetScript>().gameObject);
        
        }
        catch (Exception e)
        {
            print("error");
        }
        p = gameObject.AddComponent(typeof(Planet)) as Planet;
        p.InitAsIcosohedron();
        p.Subdivide(SubDivisionNum);
        p.GenerateMesh();
    }

    
}
*/