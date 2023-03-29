using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
//using System;

using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class PlayerController : MonoBehaviour
{



    public float speed = 3f;
    public float rotationSpeed = 200f;
    public float horizontal = 0.3f;
    [SerializeField] private Camera camera;
    [SerializeField] private Joystick joystick;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameSettings gameSettings;
    private TrailRenderer tr;
    bool IsBonus1Active = false;
    int bonus1Reps = 0;

    private void Start()
    {
        if (GetComponentInChildren<Camera>() != null)
        {
            camera = GetComponentInChildren<Camera>();
            camera.fieldOfView = gameSettings.pOneFOV;
        }
        if (GetComponentInChildren<TrailRenderer>() != null)
        {
            tr = GetComponentInChildren<TrailRenderer>();
        }

        if (this.gameObject.tag == "PlayerOne")
            speed = gameSettings.pOneSpeed;
        else
            speed = gameSettings.pTwoSpeed;


    }
    void Update()
    {
        Rotate90Degrees();

    }

    void FixedUpdate()
    {
        ConstantMoveForward();
        //JoystickMovement();
        //Rotate90Degrees();
    }
    void LateUpdate()
    {

    }

    private void Rotate90Degrees()
    {

        //Constant move forward function call here to check eficancy.


        //Turn left 90 degrees
        if (Input.GetKeyDown(KeyCode.A))
        {

            transform.Rotate(Vector3.up * -90f);
            if (camera != null) camera.transform.Rotate(Vector3.forward * -90f);
            transform.position += transform.forward * 0.5f;
            // tutaj umieść swoje instrukcje, które mają być wykonane po wciśnięciu klawisza "A"
        }
        //Turn right 90 degrees
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(Vector3.up * 90f);
            if (camera != null) camera.transform.Rotate(Vector3.forward * 90f);
            transform.position += transform.forward * 0.5f;

            // tutaj umieść swoje instrukcje, które mają być wykonane po wciśnięciu klawisza "A"
        }
    }

    private void JoystickMovement()
    {
        horizontal = -joystick.Vertical;
        transform.Rotate(Vector3.up * horizontal * rotationSpeed);

        if (camera != null)
            camera.transform.Rotate(Vector3.forward * horizontal * rotationSpeed);
    }

    private void ConstantMoveForward()
    {
        transform.Translate(Vector3.forward * speed);

    }

    public void TrailTactBonus()
    {
        Debug.Log("TrailTactBonus przed petla");
        if (IsBonus1Active == false)
        {
            StartCoroutine(TrailTact());
            IsBonus1Active = true;
            Debug.Log("Trailtactbonus petla");

        }


    }
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
    public void TextSpeed()
    {
        text.text = speed.ToString();
    }

}

