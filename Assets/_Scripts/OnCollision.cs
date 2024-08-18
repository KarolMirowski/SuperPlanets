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
    private GameObject _pObj;
    private Coroutine _speedBonusCoroutine;
    private Coroutine _slowBonusCoroutine;
    void Start()
    {
        _playerController = GetComponentInParent<PlayerController>();
        if(_playerController != null)
            _pObj = _playerController.gameObject;
    
    
    
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("SpeedBonus") == true)
        {
            try
            {
                AddSpeedBonus();
                Destroy(collision.gameObject);
            }
            catch (System.Exception e)
            {
                throw;
            }

        }if (collision.collider.CompareTag("SlowBonus") == true)
        {
            try
            {
                AddSlowBonus();
                Destroy(collision.gameObject);
            }
            catch (System.Exception e)
            {
                throw;
            }

        }
        if (collision.collider.CompareTag("Add5Points") == true)
        {
            try
            {
                _pObj.GetComponent<ScoreCounter>().Score += 5;
                Destroy(collision.gameObject);
            }
            catch (System.Exception e)
            {
                throw;
            }

        }

        if (collision.collider.CompareTag("BonusOne") == true)
        {

            if (_playerController != null)
            {
                //GetComponentInParent<PlayerController>().TrailTactBonus();
                _ = _playerController.TrailTactBonusAsync(12);
                Destroy(collision.gameObject);
            }
            else if (GetComponentInParent<Player2Controller>() != null)
            {
                GetComponentInParent<Player2Controller>().TrailTactBonus();
                Destroy(collision.gameObject);
            }
        }
        if (collision.collider.CompareTag("EnlargeBonus"))
        {
            var cameraTransform = _playerController.GetComponentInChildren<Camera>().gameObject.transform.position;
            var playerTransform = _playerController.transform.position;
            var position = Vector3.Lerp(cameraTransform, playerTransform, 0f);
            _playerController.transform.localScale += new Vector3(0.4f, 0.4f, 0.4f);
            _pObj.GetComponentInChildren<TrailRenderer>().widthMultiplier += 0.4f;
            _pObj.GetComponentInChildren<Camera>().gameObject.transform.position = position;
            print("Doszlo do zderzenia z enlarge");
            //collision.collider.gameObject.SetActive(false)
            Destroy(collision.gameObject);
        }
        if (collision.collider.CompareTag("ShrinkBonus"))
        {
            
            
            var cameraTransform = _playerController.GetComponentInChildren<Camera>().gameObject.transform.position;
            var playerTransform = _playerController.transform.position;
            var position = Vector3.Lerp(cameraTransform, playerTransform, 0f);
            if (_playerController.transform.localScale.x >= 0.2f)
            {
                _playerController.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
                _pObj.GetComponentInChildren<TrailRenderer>().widthMultiplier -= 0.1f;
                
            }

            _pObj.GetComponentInChildren<Camera>().gameObject.transform.position = position;
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
    private IEnumerator SpeedBonusCoroutine(){
        _pObj.GetComponent<PlayerController>().speed *= 2;
        yield return new WaitForSeconds(5);
        _pObj.GetComponent<PlayerController>().speed /= 2;
        
        StopCoroutine(SpeedBonusCoroutine());
        _speedBonusCoroutine = null;
    }
    private void AddSpeedBonus(){
        if(_speedBonusCoroutine != null) return;
        _speedBonusCoroutine = StartCoroutine(SpeedBonusCoroutine());
    }
    private IEnumerator SlowBonusCoroutine(){
        _pObj.GetComponent<PlayerController>().speed /= 2;
        yield return new WaitForSeconds(5);
        _pObj.GetComponent<PlayerController>().speed *= 2;
        
        StopCoroutine(SlowBonusCoroutine());
        _speedBonusCoroutine = null;
    }
    private void AddSlowBonus(){
        if(_slowBonusCoroutine != null) return;
        _slowBonusCoroutine = StartCoroutine(SlowBonusCoroutine());
    }

}
