using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private bool _shouldSpawn = true;
    public float firstTime;
    
    [SerializeField]
    private GameObject TrailTactBonusObject;
    


    void Start()
    {
        if(_shouldSpawn) StartCoroutine(ObjectOne());
        

    }
    IEnumerator ObjectOne()
    {
        yield return new WaitForSecondsRealtime(firstTime);
        Instantiate(TrailTactBonusObject, Random.onUnitSphere * 18f, Quaternion.identity);
        StartCoroutine(ObjectOne());
    }
    IEnumerator ObjectTwo()
    {
        yield return new WaitForSecondsRealtime(firstTime);
        Instantiate(TrailTactBonusObject, Random.onUnitSphere * 18f, Quaternion.identity);
        StartCoroutine(ObjectTwo());
    }



}
