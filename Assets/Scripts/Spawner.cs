using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float firstTime;
    public float secondTime;
    public float thirfTime;
    


    [SerializeField]
    private GameObject obj;
    [SerializeField]
    private GameObject obj2;
    [SerializeField]
    private GameObject obj3;


    void Start()
    {
        StartCoroutine(ObjectOne());


    }
    IEnumerator ObjectOne()
    {
        yield return new WaitForSecondsRealtime(firstTime);
        Instantiate(obj, Random.onUnitSphere * 18f, Quaternion.identity);
        StartCoroutine(ObjectOne());
    }



}
