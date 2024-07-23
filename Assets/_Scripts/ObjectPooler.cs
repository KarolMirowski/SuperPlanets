using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;


public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    public static ObjectPooler Instance;

    [SerializeField]
    private bool _shouldSpawn = true;

    public List<Pool> Pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    public GameObject RootObjectForPools;
    private CancellationTokenSource _cts;

    void Awake()
    {
        //Wzor na singleton
        Instance = this;
        _cts = new CancellationTokenSource();
        InitializePools();


        //Wywolanie asynchroniczne metody do spawnu bonusow;

    }
    void Start()
    {
        if (_shouldSpawn)
        {
            try
            {
                _ = SpawnRoutineAsync();
                print(this.name + ": blok try w Awake, pod await SpawnRoutineAsync()");

            }
            catch (OperationCanceledException)
            {
                print(this.name + ": Destroy Token zostal anulowany");
            }
        }


    }
    
    
    void InitializePools()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in Pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            GameObject poolRootObject = new GameObject(name: pool.tag + "Pool");
            poolRootObject.transform.SetParent(RootObjectForPools.transform, false);
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab, parent: poolRootObject.transform);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        //tutaj sprawwdzic
        if (poolDictionary == null) return new();
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Nie znajduje poola o tym tagu.");
            return null;
        }

        

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }

    async Task SpawnRoutineAsync()
    {

        //Przerwij jesli nie jest zaznaczone _shouldSpawnGameObject.
        //Losowe polozenie wokol kuli jednak z dala od powierzchni(18f), dlatego mnozenie razy 25f.
        while (!destroyCancellationToken.IsCancellationRequested)
        {
            foreach (var pool in Pools)
            {
                var position = UnityEngine.Random.onUnitSphere * 25f;
                GameObject gameObjectToSpawn = SpawnFromPool(pool.tag, position, Quaternion.identity);
    
            }
            
            //Instantiate(gameObjectToSpawn);
            await Task.Delay(1000, _cts.Token);
        }



    }



}
