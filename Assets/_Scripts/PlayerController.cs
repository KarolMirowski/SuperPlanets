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
    bool _shouldMove = true;
    int bonus1Reps = 0;
    public Button turnLeftButton;
    public Button turnRightButton;
    public InputAction turnAction;
    private float tempHorizontal;
    private TrailRenderer tr;
    public bool StopTrailon = false;
    void OnValidate()
    {
        _playerInput = GetComponent<PlayerInput>();

    }

    private void Start()
    {
        //Calling empty function to Validate GameManager so that it can see second player. 
        GameManager.Instance.ValidateGameManager();

        if (GetComponentInChildren<Camera>() != null)
        {
            camera = GetComponentInChildren<Camera>();
            camera.fieldOfView = gameSettings.playerFOV;
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
        if (this.gameObject.CompareTag("PlayerTwo"))
        {
            transform.rotation = Quaternion.identity;
            turnLeftButton = CanvasManager.Instance.TurnLeftButton.GetComponent<Button>();
            turnRightButton = CanvasManager.Instance.TurnRightButton.GetComponent<Button>();
            //CanvasManager.Instance.trailMesh.tr = tr;
            //GameObject.FindGameObjectWithTag("TrailonTwo").GetComponent<TrailMesh>().tr = tr;
            //GameObject.Find("TrailonTwo").GetComponent<TrailMesh>().Trail = tr;
            //print(gameObject.name + ": " + camera.tag);
            //print(gameObject.name + ": " + camera.tag);

        }

        turnLeftButton.GetComponent<Button>().onClick.AddListener(OnTurnLeftButtonPressed);
        turnRightButton.GetComponent<Button>().onClick.AddListener(OnTurnRightButtonPressed);

        //var gamepad = Game
        //var gamepad = Game

    }

    void Update()
    {
        //tempHorizontal = _playerInput.actions["Move"].ReadValue<Vector2>().x;
        //Debug.Log($"Horizontal Input: {tempHorizontal}");
        if (turnAction.WasPressedThisFrame())
        {
            TurnLeft();

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
        //Debug.Log("TrailTactBonus przed petla");
        if (!IsBonus1Active)
        {
            StartCoroutine(TrailTact());
            IsBonus1Active = true;
            //Debug.Log("Trailtactbonus petla");
        }
    }
    public void CollidedWithTrailon()
    {
        //Show Game Over Sign, score number, and disable player canvas     
        if (CanvasManager.Instance.isActiveAndEnabled)
        {
            CanvasManager.Instance.OnGameOver();

        }
        
        //Stop score counter
        ScoreCount.Instance.ShouldAddPoint = false;
        StopCoroutine(ScoreCount.Instance.ScoreCounter());
        ScoreCount.Instance.gameObject.SetActive(false);
        speed = 0;
        StopTrailon = true;
        _shouldMove = false;
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
        //print("moved left!");
    }

    public void OnTurnRightButtonPressed()
    {
        TurnRight();
        //print("A teraz nam poszło right");
    }

    private void TurnLeft()
    {
        if (!_shouldMove) return;
        transform.Rotate(Vector3.up * -90f);
        TurnCameraRight90();


    }

    private void TurnRight()
    {
        if (!_shouldMove) return;
        
        transform.Rotate(Vector3.up * 90f);
        TurnCameraLeft90();

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
        //camera.transform.LookAt(Vector3.zero, Vector3.up);
    }

    void TurnCameraRight90()
    {
        //Lookat as a method to stop camera from slight jitter
        //camera.transform.LookAt(Vector3.zero, Vector3.up);
        camera.transform.Rotate(Vector3.forward * -90f);
    }
}
