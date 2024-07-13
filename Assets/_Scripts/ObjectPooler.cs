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

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    [SerializeField]

    async void Awake()
    {
        //Wzor na singleton
        Instance = this;

        //Wywolanie asynchroniczne metody do spawnu bonusow;
        try
        {
            await SpawnRoutineAsync();
        }
        catch (OperationCanceledException)
        {
            print(this.name + ": Destroy Token zostal anulowany");
        }
    }
    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }


    }
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
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

    private async Task SpawnRoutineAsync()
    {
        if (!_shouldSpawn) return;
        //Przerwij jesli nie jest zaznaczone _shouldSpawnGameObject.
        //Losowe polozenie wokol kuli jednak z dala od powierzchni(18f), dlatego mnozenie razy 25f.
        while (!destroyCancellationToken.IsCancellationRequested)
        {
            var position = UnityEngine.Random.onUnitSphere * 25f;
            GameObject gameObjectToSpawn = SpawnFromPool("grass", position, Quaternion.identity);
            Instantiate(gameObjectToSpawn);
            await Task.Delay(1000);
        }



    }



}
