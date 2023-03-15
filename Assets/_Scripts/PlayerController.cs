using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
//using System;

using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PlayerController : MonoBehaviour
{
    //private InputManager inputManager;

    // Szybkość ruchu i rotacja
    public float         speed = 3f;
    public float         rotationSpeed = 200f;
    public float         horizontal = 0.3f;
    private Camera cam;
    
    [SerializeField]
    private Joystick joystick;    
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private GameObject trailon;
    //public static PlayerController playerController;
    //public static PlayerController playerController;
    private GameObject planet;
    private TrailRenderer tr;
    private GameObject col;
    [SerializeField]
    private GameSettings gameSettings;



    bool IsBonus1Active = false;
    int bonus1Reps = 0;

    public int i = 0;



    private void Start()
    {
        cam = GetComponentInChildren<Camera>();
        tr = GetComponentInChildren<TrailRenderer>();
        cam.fieldOfView = gameSettings.pOneFOV;

        if (this.gameObject.tag == "PlayerOne")
            speed = gameSettings.pOneSpeed;
        else
            speed = gameSettings.pTwoSpeed;

        
    }
    
    public void FixedUpdate()
    {
        horizontal = -joystick.Vertical;
        transform.Translate(Vector3.forward * speed);
        transform.Rotate(Vector3.up * horizontal * rotationSpeed);

        if(cam != null)
            cam.transform.Rotate(Vector3.forward * horizontal * rotationSpeed); 
        
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


    






    /*
     * 
    private void OnCollisionEnter(Collision collision)
    {

        rb.Sleep();
        Destroy(controller);
        rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;

        // Destroy(FindObjectOfType());
        Debug.Log("Miało być STOP." + collision.collider.name);

    }

    */




    public void OnClick_AddSpeed()
    {
        
        speed = 0.15f;
        TextSpeed();

        
    }
    public void OnClick_LowSpeed()
    {
        speed--;
        TextSpeed();

    }
    public void OnClick_AddSpeed10()
    {
        speed += 10f;
        TextSpeed();


    }
    public void OnClick_LowSpeed10()
    {
        speed -= 10f;
        TextSpeed();

    }
    public void TextSpeed()
    {
        text.text = speed.ToString();
    }
    


    
}
        
