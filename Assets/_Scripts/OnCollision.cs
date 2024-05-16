using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEngine.Debug;

public class OnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Add5Points") == true && gameObject.transform.parent.name == "PlayerOne")
        {
            GameManager.Instance.ScoreCount += 5;
            Destroy(collision.collider.gameObject);
            print("5 points should be added");
        }


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
        }

        if (collision.collider.CompareTag("Trailon") == true)
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
