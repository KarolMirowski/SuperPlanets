using static UnityEngine.Debug;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGhostCollision : MonoBehaviour
{
    [SerializeField] private float _rescueTurnValue;
    [SerializeField] private float _rescueTurnDuration = 1f;

    private Player2Controller _playerController;

    void Awake()
    {
        if (GetComponentInParent<Player2Controller>() != null)
            _playerController = GetComponentInParent<Player2Controller>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Trailon") == true )
        {
            _playerController.CanTurnRight = false;
            Log($"Right collision. Parent name: {transform.parent.name}");
            
        }
        if (collision.collider.CompareTag("Trailon") == true && this.gameObject.name == "TurnColliderLeft")
        {
            Log($"Left collision. Parent name: {transform.parent.name}");
            _playerController.CanTurnLeft = false;
        }

        

    }
    
    
    
    
}
