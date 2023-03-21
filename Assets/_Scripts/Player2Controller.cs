using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
//using System;

using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Player2Controller : MonoBehaviour
{
    //private InputManager inputManager;

    // Szybko�� ruchu i rotacja
    public float speed = 3f;
    public float rotationSpeed = 200f;
    public float horizontal = 0.3f;



    public float camOffset;

    public GameObject obj;





    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private GameObject trailon;
    //public static PlayerController playerController;
    //public static PlayerController playerController;
    private GameObject planet;
    private TrailRenderer tr;

    [SerializeField]
    private GameSettings gameSettings;


    [SerializeField] private float _duration = 1.2f;
    private bool _firstIterationPassed = false;

    public int i = 0;
    bool IsBonus1Active = false;
    int bonus1Reps = 0;


    private void Start()
    {
        tr = GetComponentInChildren<TrailRenderer>();
        //cam.fieldOfView = gameSettings.pOneFOV;
        StartCoroutine(TurnTact(_duration));
        StartCoroutine(Wait());
    }

    public void FixedUpdate()
    {
        //horizontal = joystick.Vertical;
        transform.Translate(Vector3.forward * speed /** Time.deltaTime*/);
        //transform.Rotate(Vector3.up * horizontal * rotationSpeed /** Time.deltaTime*/);


    }

    public void TrailTactBonus()
    {
        if (IsBonus1Active == false)
        {
            //StartCoroutine(TrailTact());
            IsBonus1Active = true;
            Debug.Log("Trailtactbonus petla");

        }


    }
    IEnumerator Wait()
    {


        GetComponent<Player2Controller>().speed = 0f;
        GetComponent<Rigidbody>().Sleep();





        yield return new WaitForSeconds(0.7f);
        //3
        yield return new WaitForSeconds(0.7f);
        //2
        yield return new WaitForSeconds(0.7f);
        //1
        yield return new WaitForSeconds(0.3f);
        //GO

        //scoreCounts[0].StartCoroutine(scoreCounts[0].ScoreCounter());
        //scoreCounts[1].StartCoroutine(scoreCounts[1].ScoreCounter());

        GetComponent<Player2Controller>().speed = 0.2f;

        //StartCoroutine(playerTwo.GetComponent<Player2Controller>().TurnTact(2f));

        StopCoroutine(Wait());
    }


    /*
    IEnumerator TrailTact()
    {
        if (bonus1Reps < 12)
        {
            tr.emitting = false;
            yield return new WaitForSeconds(0.5f);
            tr.emitting = true;
            yield return new WaitForSeconds(0.5f);
            bonus1Reps += 1;
            StartCoroutine(TrailTact());

        }
        else
        {
            bonus1Reps = 0;
            StopCoroutine(TrailTact());
            IsBonus1Active = false;
        }



    }
    */
    public IEnumerator TurnTact(float duration)
    {
        //First bool check; for bot to avoid false start.
        if (_firstIterationPassed == false)
        {

            var timeBeforeWake = Random.Range(4f,6f);
            yield return new WaitForSeconds(timeBeforeWake);
        }
        
        //Time for the turn duration.
        var end = Time.time + duration;
        
        //Randomized decision. Shall turn right or left.
        var leftRight = Random.Range(0, 1f);
        if (leftRight < 0.5f)
        {
            while (Time.time < end)
            {
                transform.Rotate(Vector3.up * -0.3f * rotationSpeed /** Time.deltaTime*/);
                yield return null;
            }
        }
        else
        {
            while (Time.time < end)
            {
                transform.Rotate(Vector3.up * 0.3f * rotationSpeed /** Time.deltaTime*/);
                yield return null;
            }
        }
        //Random idle duration before the next turn. No turning than, only moving forward.
        yield return new WaitForSeconds(Random.Range(0.3f, 0.9f));
        _firstIterationPassed = true;
        yield return StartCoroutine(TurnTact(_duration));

    }







    /*
     * 
    private void OnCollisionEnter(Collision collision)
    {

        rb.Sleep();
        Destroy(controller);
        rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;

        // Destroy(FindObjectOfType());
        Debug.Log("Mia�o by� STOP." + collision.collider.name);

    }

    */







}

