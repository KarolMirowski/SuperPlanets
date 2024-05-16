using static UnityEngine.Debug;
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
    public GameObject turnLeftButton;
    public GameObject turnRightButton;
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

        turnLeftButton.GetComponent<Button>().onClick.AddListener(OnTurnLeftButtonPressed);
        turnRightButton.GetComponent<Button>().onClick.AddListener(OnTurnRightButtonPressed);
    
    }
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        ConstantMoveForward();                          
        //JoystickRotate();                 
        //Rotate90Degrees();                  
        //RotateCamera90Degrees();                    
    }
    void LateUpdate()
    {
        Rotate90Degrees();
        RotateCamera90Degrees();
    }

    void Rotate90Degrees()
    {

        //Constant move forward function call here to check eficancy.


        //Turn left 90 degrees
        if (Input.GetKeyDown(KeyCode.A) )
        {
            transform.Rotate(Vector3.up * -90f);
            transform.position += transform.forward * 0.5f;
        }

        //Turn right 90 degrees
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(Vector3.up * 90f);
            transform.position += transform.forward * 0.5f;
        }
    }
    void RotateCamera90Degrees()
    {
        //Turn left 90 degrees
        if (Input.GetKeyDown(KeyCode.A))
            camera.transform.Rotate(Vector3.forward * -90f); 
        
        //Turn right 90 degrees
        if (Input.GetKeyDown(KeyCode.D))
            camera.transform.Rotate(Vector3.forward * 90f);
        

    }
    void JoystickRotate()
    {
        horizontal = -joystick.Vertical;
        transform.Rotate(Vector3.up * horizontal * rotationSpeed);

        if (camera != null)
            camera.transform.Rotate(Vector3.forward * horizontal * rotationSpeed);
    }

    void ConstantMoveForward()
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
    // Metody obsługi przycisków
    public void OnTurnLeftButtonPressed()
    {
        TurnLeft();
    }

    public void OnTurnRightButtonPressed()
    {
        TurnRight();
    }

    private void TurnLeft()
    {
        transform.Rotate(Vector3.up * -90f);
        transform.position += transform.forward * 0.5f;
    }

    private void TurnRight()
    {
        transform.Rotate(Vector3.up * 90f);
        transform.position += transform.forward * 0.5f;
    }
}

