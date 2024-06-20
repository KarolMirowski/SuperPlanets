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
    [SerializeField] private List<MeshRenderer> _listOfRenderers;

    void Awake()
    {
        if (GameManager.Instance.isActiveAndEnabled)
            _numberOfSpawns = GameManager.Instance.BotCountNumber;
        GenRandSpherePositions();
    }

    void GenRandSpherePositions()
    {
        _listForDistCheck = new List<Vector3>();
        var parentTransform = GameObject.Find("Bots").transform;
        int safetyCount = 0;
        for (int i = 0; i < _numberOfSpawns; i++)
        {
            Vector3 randomSpawnPosition = Random.onUnitSphere * Random.Range(_minSpawnDistance, _maxSpawnDistance);

            // Sprawdzanie odległości między nowo wylosowanym punktem a już wylosowanymi
            bool isTooClose = true;
            while (isTooClose)
            {
                isTooClose = false;
                foreach (Vector3 position in _listForDistCheck)
                {
                    safetyCount++;
                    if (safetyCount > 5000)
                        break;
                    if (Vector3.Distance(position, randomSpawnPosition) < _minDistanceBetweenPoints)
                    {
                        isTooClose = true;
                        randomSpawnPosition = Random.onUnitSphere * Random.Range(_minSpawnDistance, _maxSpawnDistance);
                        break;
                    }
                }
            }
            print(safetyCount);
            _listForDistCheck.Add(randomSpawnPosition);
            var nextPlayer = Instantiate(_prefabToSpawn, randomSpawnPosition, Quaternion.identity, parentTransform);
            var newMeshRenderer = new MeshRenderer();
            //nextPlayer.GetComponent<MeshRenderer>() = newMeshRenderer;
            _listOfRenderers.Add(nextPlayer.GetComponent<MeshRenderer>());

        }
        
    }



}