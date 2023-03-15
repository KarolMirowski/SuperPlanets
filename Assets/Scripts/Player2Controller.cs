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

    // Szybkoœæ ruchu i rotacja
    public float speed = 3f;
    public float rotationSpeed = 200f;
    public float horizontal = 0.3f;

    [Header("Czynnik alfa. xD")]
    public float czynnik = 1f;
    public PlanetScript2 mg;

    public float camOffset;
    public Camera cam;
    // Obiekt; Prefab do testów
    public GameObject obj;

    [SerializeField]
    private Joystick joystick;
    //Photon View.


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



    public int i = 0;
    bool IsBonus1Active = false;
    int bonus1Reps = 0;


    private void Start()
    {
        tr = GetComponentInChildren<TrailRenderer>();
        cam.fieldOfView = gameSettings.pOneFOV;
    }

    public void FixedUpdate()
    {
        horizontal = joystick.Vertical;
        transform.Translate(Vector3.forward * speed /** Time.deltaTime*/);
        transform.Rotate(Vector3.up * horizontal * rotationSpeed /** Time.deltaTime*/);

        if (cam != null)
            cam.transform.Rotate(Vector3.forward * horizontal * rotationSpeed /** Time.deltaTime*/);
    }

    public void TrailTactBonus()
    {
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
        Debug.Log("Mia³o byæ STOP." + collision.collider.name);

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

//float movementInput = inputManager.Newactionmap.Movement.ReadValue<float>();
//Debug.Log(Convert.ToBoolean(movementInput));

//cam.transform.rotation = transform.rotation;
//cam.transform.Rotate(cam.transform.forward * movementInput * rotationSpeed * Time.deltaTime);
//cam.transform.Rotate(90, 0, 0);
//cam.transform.position = transform.position * camOffset;
//cam.transform.LookAt(Vector3.zero, cam.transform.position);
//transform.localScale *= (czynnik * Time.deltaTime);
//bool meshi = inputManager.Newactionmap.Mesh.triggered;
