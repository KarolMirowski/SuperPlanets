using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
//using static UnityEngine.Debug;

public class OnCollision : MonoBehaviour
{
    private PlayerController _playerController;
    private PlayerController _playerTwoController;
    void Start()
    {
        _playerController = GetComponentInParent<PlayerController>();
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Add5Points") == true)
        {
            try
            {
                GameManager.Instance.PlayerOneScore += 5;
                Destroy(collision.collider);
            }
            catch (System.Exception e)
            {
                print($"OnCollision Enter wykonal catch w Add5Points bonus a error odnosi sie do {e}");
                throw;
            }

        }

        if (collision.collider.CompareTag("BonusOne") == true)
        {

            if (_playerController != null)
            {
                //GetComponentInParent<PlayerController>().TrailTactBonus();
                _ = _playerController.TrailTactBonusAsync(12);
                Destroy(collision.collider);
            }
            else if (GetComponentInParent<Player2Controller>() != null)
            {
                GetComponentInParent<Player2Controller>().TrailTactBonus();
                print($"ten gracz to {gameObject.tag}, a collision to {collision.collider.name}");
                Destroy(collision.collider);
            }
        }
        if (collision.collider.CompareTag("EnlargeBonus"))
        {
            var cameraTransform = _playerController.gameObject.GetComponentInChildren<Camera>().gameObject.transform.position;
            var playerTransform = _playerController.gameObject.transform.position;
            var position = Vector3.Lerp(cameraTransform, playerTransform, 0f);
            _playerController.transform.localScale += new Vector3(0.4f, 0.4f, 0.4f);
            _playerController.gameObject.GetComponentInChildren<TrailRenderer>().widthMultiplier += 0.4f;
            _playerController.gameObject.GetComponentInChildren<Camera>().gameObject.transform.position = position;
            print("Doszlo do zderzenia z enlarge");
            //collision.collider.gameObject.SetActive(false)
            Destroy(collision.gameObject);
        }
        if (collision.collider.CompareTag("ShrinkBonus"))
        {
            var cameraTransform = _playerController.gameObject.GetComponentInChildren<Camera>().gameObject.transform.position;
            var playerTransform = _playerController.gameObject.transform.position;
            var position = Vector3.Lerp(cameraTransform, playerTransform, 0f);
            if (_playerController.transform.localScale.x >= 0.2f)
            {
                _playerController.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
                _playerController.gameObject.GetComponentInChildren<TrailRenderer>().widthMultiplier -= 0.1f;
                print(_playerController.gameObject.GetComponentInChildren<TrailRenderer>().widthMultiplier.ToString());
            }

            _playerController.gameObject.GetComponentInChildren<Camera>().gameObject.transform.position = position;
            print("Doszlo do zderzenia z enlarge");
            //collision.collider.gameObject.SetActive(false)
            Destroy(collision.gameObject);
        }
        if (collision.collider.CompareTag("Trailon") == true || collision.collider.CompareTag("TrailonTwo") == true)
        {
            if (GetComponentInParent<PlayerController>() != null)
            {
                //Stop player movement.
                GetComponentInParent<PlayerController>().CollidedWithTrailon();
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
