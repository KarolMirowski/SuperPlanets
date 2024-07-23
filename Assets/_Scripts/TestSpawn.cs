using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TestSpawn : MonoBehaviour
{
    //Rename list to an array.
    [SerializeField] private GameObject[] _botList;
    [SerializeField] private float _sphereRadius;
    [SerializeField] private GameObject _trailonPrefab;
    [SerializeField] private GameObject _trailonsParent;
    
    private List<GameObject> _bots = new List<GameObject>();
    private List<GameObject> _botTrailons = new List<GameObject>();

    
    void Start()
    {
        InstantiateBots();
    }
    void InstantiateBots()
    {
        foreach (var bot in _botList)
        {
            var newBot = Instantiate(bot, Random.onUnitSphere * _sphereRadius, Quaternion.identity);
            var newTrailon = Instantiate(_trailonPrefab, Vector3.zero, Quaternion.identity,parent:_trailonsParent.transform);
            newTrailon.GetComponent<TrailMesh>().Trail = newBot.GetComponentInChildren<TrailRenderer>();
            _bots.Add(newBot);
            _botTrailons.Add(newTrailon);
        }
    }
    void OnDestroy()
    {
        //Destroy bots and trailons onExit/OnDestroy.
        foreach (var bot in _bots)
        {
            Destroy(bot);
        }
        foreach (var botTrailon in _botTrailons)
        {
            Destroy(botTrailon);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
