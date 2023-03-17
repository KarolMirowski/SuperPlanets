using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("BonusOne") == true)
        {
            

            if (GetComponentInParent<PlayerController>() != null)
            {
                GetComponentInParent<PlayerController>().TrailTactBonus();
                Destroy(collision.collider.gameObject);
                Debug.Log("player one bonus hit");
            }
                
            else if (GetComponentInParent<Player2Controller>() != null)
            {
                GetComponentInParent<Player2Controller>().TrailTactBonus();
                Destroy(collision.collider.gameObject);
                Debug.Log("player two bonus hit");

            }
                    





               // Debug.Log("Oj bonusa  Kolizja czyta taga ");
            
        }
        
        if (collision.collider.CompareTag("Trailon") == true)
        {
            if(GetComponentInParent<PlayerController>() != null)
                GetComponentInParent<PlayerController>().speed = 0;
            else if (GetComponentInParent<Player2Controller>() != null)
                GetComponentInParent<Player2Controller>().speed = 0;
            GetComponentInParent<Rigidbody>().Sleep();
            Debug.Log($"{this.name} - Pauza {collision.collider.name}");
            return;
        }
    }
}
