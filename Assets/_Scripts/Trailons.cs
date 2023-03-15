using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Trailons : MonoBehaviour
{
    [SerializeField]
    private GameObject TrailonPrefab;

    //private Dictionary<int, Player> PlayerCount;
    //private InstantiateExample example;
    private GameObject playerTag;
    private GameObject trailonTag;

  

    public void Start()
    {
        //example = FindObjectOfType<InstantiateExample>();
        //PlayerCount = PhotonNetwork.CurrentRoom.Players;
        

        
    }
    public void OnClick_Reset()
    {
        //Niszczy dwa obiekty. Player i Trailon;
        //######### TUTAJ SPRAWDZIĆ !
        //example.PlayerInstantiate(randomPosition());
        
        FindObjectOfType<PlayerTag>().gameObject.SetActive(false);
        FindObjectOfType<TrailonTag>().gameObject.SetActive(false);
        
        
        //Tworzy od nowa isntancje obiektów Player i Trailon.
         
    }

    private protected Vector3 randomPosition()
    {
        return Random.onUnitSphere * 18;
    }
}
