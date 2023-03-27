using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    public GameObject spawnObject; // prefab to spawn
    public int numSpawns; // number of times for prefab to spawn    
    public float minDistance; // minimalna odległość między spawnami
    public float maxDistance; // maksymalna odległość między spawnami

    void Start()
    {
        for (int i = 0; i < numSpawns; i++)
        {
            Vector3 spawnPos = Random.onUnitSphere * Random.Range(minDistance, maxDistance); // losowa pozycja na powierzchni sfery
            Instantiate(spawnObject, spawnPos, Quaternion.identity); // tworzenie obiektu na wylosowanej pozycji
        }
    }
}