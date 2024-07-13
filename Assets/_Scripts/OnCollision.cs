using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEngine.Debug;

public class OnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //Test buga pauzy,
        
        
        if (collision.collider.CompareTag("Add5Points") == true && gameObject.transform.parent.name == "PlayerOne")
        {
            GameManager.Instance.ScoreCount += 5;
            Destroy(collision.collider.gameObject);
            
        }


        if (collision.collider.CompareTag("BonusOne") == true)
        {


            if (GetComponentInParent<PlayerController>() != null)
            {
                GetComponentInParent<PlayerController>().TrailTactBonus();
                Destroy(collision.collider.gameObject);
                
                

            }

            else if (GetComponentInParent<Player2Controller>() != null)
            {
                GetComponentInParent<Player2Controller>().TrailTactBonus();
                Destroy(collision.collider.gameObject);
                

            }
        }

        if (collision.collider.CompareTag("Trailon") == true || collision.collider.CompareTag("TrailonTwo") == true)
        {
            if (GetComponentInParent<PlayerController>() != null)
            {
                //Stop player movement.
                GetComponentInParent<PlayerController>().speed = 0;
                
                //Show Game Over Sign, score number, and disable player canvas     
                if (CanvasManager.Instance.isActiveAndEnabled)
                {
                    CanvasManager.Instance.OnGameOver();
                    
                }
                
                //Stop score counter
                ScoreCount.Instance.ShouldAddPoint = false;
                StopCoroutine(ScoreCount.Instance.ScoreCounter());
                ScoreCount.Instance.gameObject.SetActive(false);
            
            
            }
            else if (GetComponentInParent<Player2Controller>() != null)
            {
                GetComponentInParent<Player2Controller>().speed = 0;
                GetComponentInParent<Player2Controller>().CanTurn = false;
            }
            GetComponentInParent<Rigidbody>().Sleep();
            

            
            return;
        }
    }
}
