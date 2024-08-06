using static UnityEngine.Debug;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.OnScreen;
using System.Threading.Tasks;
using UnityEditor;
//using UnityEngine.UIElements;


public class PlayerController : MonoBehaviour
{
    public float speed = 3f;
    public float rotationSpeed = 200f;
    public float horizontal = 0.3f;
    private Camera camera;
    [SerializeField] private TextMeshProUGUI text; //Change it to getcomponent.
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private PlayerInput _playerInput;
    bool IsBonus1Active = false;
    bool _shouldMove = true;
    int bonus1Reps = 0;
    public Button turnLeftButton, turnRightButton;
    private TrailRenderer tr;
    public bool StopTrailon = false;
    void OnValidate()
    {
        _playerInput = GetComponent<PlayerInput>();
    }
    void Start()
    {
        //await Task.Delay(3000);
        //Calling empty function to Validate GameManager so that it can see second player.CHECK IF NECESSARY.

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
        if (CompareTag("PlayerOne"))
            speed = gameSettings.pOneSpeed;
        else
            speed = gameSettings.pTwoSpeed;

        //Rejestracja eventów starego systemu inpput
        if (CompareTag("PlayerTwo"))
        {
            transform.rotation = Quaternion.identity;
            turnLeftButton = CanvasManager.Instance.TurnLeftButton.GetComponent<Button>();
            turnRightButton = CanvasManager.Instance.TurnRightButton.GetComponent<Button>();
        }

        turnLeftButton.GetComponent<Button>().onClick.AddListener(OnTurnLeftButtonPressed);
        turnRightButton.GetComponent<Button>().onClick.AddListener(OnTurnRightButtonPressed);
        
    }
    void FixedUpdate()
    {
        ConstantMoveForward();
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
    public async Task TrailTactBonusAsync(int maxReps)
    {
        var repsCounter = 0;
        while (repsCounter < maxReps)
        {
            print("TrailTactBonusAsync ruszylo");
            tr.emitting = false;
            await Task.Delay(500);
            tr.emitting = true;
            await Task.Delay(500);
            repsCounter++;
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

    
    public void TextSpeed() => text.text = speed.ToString();
    public void OnTurnLeftButtonPressed() => Turn(-90f);
    public void OnTurnRightButtonPressed() => Turn(90f);
    private void Turn(float turnAngle)
    {
        if (!_shouldMove) return;
        TurnCamera(turnAngle);
        transform.Rotate(Vector3.up * turnAngle);
    }
    void TurnCamera(float turnAngle)
    {
        camera.transform.Rotate(Vector3.forward * turnAngle);
    }
}
