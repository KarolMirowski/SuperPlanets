using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{

    //Here script with longer naming convention to avoid commants. Just example
    [SerializeField] private GameObject _prefabToSpawn;
    [SerializeField] private int _numberOfSpawns;
    [SerializeField] private float _minSpawnDistance;
    [SerializeField] private float _maxSpawnDistance;
    [SerializeField] private float _minDistanceBetweenPoints;
    [SerializeField] private List<Vector3> _listForDistCheck;
    void Awake()
    {
        GenRandSpherePositions();
    }

    void GenRandSpherePositions()
    {
        _listForDistCheck = new List<Vector3>();
        var parentTransform = GameObject.Find("Bots").transform;
        for (int i = 0; i < _numberOfSpawns; i++)
        {
            Vector3 randomSpawnPosition = Random.onUnitSphere * Random.Range(_minSpawnDistance, _maxSpawnDistance);
            
            
            _listForDistCheck.Add(randomSpawnPosition);
            
            Instantiate(_prefabToSpawn, randomSpawnPosition, Quaternion.identity,parentTransform);
        }
    }


}