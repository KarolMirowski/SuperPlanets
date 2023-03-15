using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassGen : MonoBehaviour
{
    public GameObject grass;

    public ObjectPooler objectPooler;
    public int density;
    public int height;

    void Awake()
    {
        objectPooler = ObjectPooler.Instance;

    }


    void Start()
    {
        GameObject looperObj = new GameObject();
        
        for (int i = 0; i < density; i++)
        {
            Vector3 pos = Random.onUnitSphere * 17.57f;
            for (int x = 0; x < height; x++)
            {
                
               looperObj = Instantiate(grass, pos, Quaternion.identity);
               looperObj.transform.localPosition += new Vector3(0, x, 0);     


            }


            //looperObj = Instantiate(grass, Random.onUnitSphere * 17.57f, Quaternion.identity);
            //looperObj.transform.LookAt(Vector3.zero);
            //random = Random.Range(0.3f, 2.5f);
            //looperObj.transform.localScale = new Vector3(random, random, random);
        }    
    }

    

}
