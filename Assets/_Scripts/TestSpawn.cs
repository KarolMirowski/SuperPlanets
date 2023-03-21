using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TestSpawn : MonoBehaviour
{
    //Rename list to an array.
    [SerializeField] private GameObject[] _botList;
    [SerializeField] private float _sphereRadius;
    
    private List<GameObject> _bots = new List<GameObject>();

    
    void Start()
    {
        InstantiateBots();
    }
    void InstantiateBots()
    {
        foreach (var bot in _botList)
        {
            var newBot = Instantiate(bot, Random.onUnitSphere * _sphereRadius, Quaternion.identity);
            _bots.Add(newBot);
        }
    }
    void OnDestroy()
    {
        foreach (var bot in _bots)
        {
            Destroy(bot);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
