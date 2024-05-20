using static UnityEngine.Debug;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.OnScreen;

public class PlayerController : MonoBehaviour
{
    public float speed = 3f;
    public float rotationSpeed = 200f;
    public float horizontal = 0.3f;
    [SerializeField] private Camera camera;
    [SerializeField] private Joystick joystick;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private PlayerInput _playerInput;
    bool IsBonus1Active = false;
    int bonus1Reps = 0;
    public GameObject turnLeftButton;
    public GameObject turnRightButton;
    public InputAction turnAction;
    private float tempHorizontal;
    private TrailRenderer tr;
    
    void OnValidate()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

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

        //Rejestracja eventów starego systemu inpput
        turnLeftButton.GetComponent<Button>().onClick.AddListener(OnTurnLeftButtonPressed);
        turnRightButton.GetComponent<Button>().onClick.AddListener(OnTurnRightButtonPressed);
        //var gamepad = Game
        
    }

    void Update()
    {
        //tempHorizontal = _playerInput.actions["Move"].ReadValue<Vector2>().x;
        //Debug.Log($"Horizontal Input: {tempHorizontal}");
        if (turnAction.WasPressedThisFrame()){
            TurnLeft();
            print("TURN ACTION DZIAŁĄ");
        }
    }

    void FixedUpdate()
    {
        ConstantMoveForward();
        //JustTurn();
    }

    public void JustTurn()
    {
        float threshold = 0.1f;
        if (tempHorizontal < -threshold)
        {
            TurnLeft();
        }
        else if (tempHorizontal > threshold)
        {
            TurnRight();
        }
    }

    void ConstantMoveForward()
    {
        transform.Translate(Vector3.forward * speed);
    }

    public void TrailTactBonus()
    {
        Debug.Log("TrailTactBonus przed petla");
        if (!IsBonus1Active)
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

    public void OnTurnLeftButtonPressed()
    {
        TurnLeft();
        print("moved left!");
    }

    public void OnTurnRightButtonPressed()
    {
        TurnRight();
        print("A teraz nam poszło right");
    }

    private void TurnLeft()
    {
        transform.Rotate(Vector3.up * -90f);
        TurnCameraRight90();
        if (!IsTurning())
        {
        }
    }

    private void TurnRight()
    {
        if (!IsTurning())
        {
            transform.Rotate(Vector3.up * 90f);
            TurnCameraLeft90();
        }
    }
    public void OnTurnLeft(InputAction.CallbackContext context)
    {
        if (context.performed && context.control.name == "a")
        {
            TurnLeft();
        }
    }

    public void OnTurnRight(InputAction.CallbackContext context)
    {
        if (context.performed && context.control.name == "d")
        {
            TurnRight();
        }
    }
    private bool IsTurning()
    {
        return tempHorizontal != 0;
    }

    void TurnCameraLeft90()
    {
        camera.transform.Rotate(Vector3.forward * 90f);
    }

    void TurnCameraRight90()
    {
        camera.transform.Rotate(Vector3.forward * -90f);
    }
}
