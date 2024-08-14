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
using System.Collections.Generic;
using System.Linq;
//using UnityEngine.UIElements;


public class PlayerController : MonoBehaviour
{
    public float speed = 3f;
    public float rotationSpeed = 200f;
    public float horizontal = 0.3f;
    private Camera camera;
    private ScoreCounter _scoreCounter;
    private PlayerData _playerData;
    private PlayerDataHandler _dataHandler;
    private List<PlayerData> _playerDataList;
    private PlayerDataHandler _playerDataHandler;
    private LifesCounter _lifesCounter;
    [SerializeField] private TextMeshProUGUI text; //Change it to getcomponent.
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private PlayerInput _playerInput;
    bool IsBonus1Active = false;
    bool _shouldMove = true;
    bool _canDie = true;
    int bonus1Reps = 0;
    public Button turnLeftButton, turnRightButton;
    private TrailRenderer tr;
    public bool StopTrailon = false;
    private bool _collideWithTrailon = false;
    public bool _isLeftClicked = false;
    public bool _isRightClicked = false;
    public bool _shouldTurn90 = false;
    private bool _isInvulnerable = false;
    private Coroutine _invulnerabilityCoroutine;
    void OnValidate()
    {
        //_playerInput = GetComponent<PlayerInput>();
    }
    void Start()
    {
        //Calling empty function to Validate GameManager so that it can see second player.CHECK IF NECESSARY.
        GameManager.Instance.ValidateGameManager();
        _scoreCounter = GetComponent<ScoreCounter>();
        _playerData = GetComponent<PlayerElementData>().SinglePlayerData;
        _playerDataHandler = PlayerDataHandler.Instance;
        _playerDataList = _playerDataHandler._playersDataList;
        _lifesCounter = GetComponent<LifesCounter>();
        //Poczatek rutyn, dotyczy cyklu rund i calego meczu.
        //StartCoroutine(RoundRoutine());


        if (GetComponentInChildren<Camera>() != null)
        {
            camera = GetComponentInChildren<Camera>();
            camera.fieldOfView = gameSettings.playerFOV;
        }
        if (GetComponentInChildren<TrailRenderer>() != null)
        {
            tr = GetComponentInChildren<TrailRenderer>();
        }
        //Rejestracja eventów starego systemu inpput
        if (CompareTag("PlayerTwo"))
        {
            //transform.rotation = Quaternion.identity;
            turnLeftButton = CanvasManager.Instance.TurnLeftButton.GetComponent<Button>();
            turnRightButton = CanvasManager.Instance.TurnRightButton.GetComponent<Button>();
        }
        turnLeftButton.GetComponent<Button>().onClick.AddListener(OnTurnLeftButtonPressed);
        turnRightButton.GetComponent<Button>().onClick.AddListener(OnTurnRightButtonPressed);
    }
    void FixedUpdate()
    {
        ConstantMoveForward();
        TurnSmoothly(rotationSpeed);
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
        if (_isInvulnerable) return;

        if (_lifesCounter.LifesLeft > 1)
        {
            _lifesCounter.TakeOneLife();
            StartInvulnerabilityPeriod();
        }
        else
        {
            StopPlayer();
            if (CompareTag("PlayerOne")) CanvasManager.Instance.OnOneGameOver(_scoreCounter.Score);
            if (CompareTag("PlayerTwo")) CanvasManager.Instance.OnTwoGameOver(_scoreCounter.Score);
        }
    }
    private void StartInvulnerabilityPeriod()
    {
        if (_invulnerabilityCoroutine != null)
        {
            StopCoroutine(_invulnerabilityCoroutine);
        }
        _invulnerabilityCoroutine = StartCoroutine(InvulnerabilityRoutine());
    }

    private IEnumerator InvulnerabilityRoutine()
    {
        _isInvulnerable = true;
        StopTrailon = true;
        tr.emitting = false;

        for (int i = 4; i > 0; i--)
        {
            _lifesCounter.ShowCountdown(i);
            yield return new WaitForSeconds(1f);
        }

        _isInvulnerable = false;
        StopTrailon = false;
        tr.emitting = true;
        _lifesCounter.HideCountdown();
    }


    public async Task TrailTactBonusAsync(int maxReps)
    {
        var repsCounter = 0;
        while (repsCounter < maxReps)
        {
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

    private IEnumerator Immortal()
    {

        yield return new WaitForSeconds(5);
    }

    private void StopPlayer()
    {
        _scoreCounter.StopCounter();
        //_scoreCounter.SetActive(false);
        speed = 0;
        StopTrailon = true;
        _shouldMove = false;

        if (CompareTag("PlayerOne"))
        {
            _playerDataHandler.PlayerOneData = _playerData;
            SendPlayerDataToList(_playerData);
        }
        if (CompareTag("PlayerTwo"))
        {
            _playerDataHandler.PlayerTwoData = _playerData;
            SendPlayerDataToList(_playerData);
            print(_playerData.ToString());
        }

    }
    public void TextSpeed() => text.text = speed.ToString();
    void SendPlayerDataToList(PlayerData playerData)
    {
        int index = _playerDataList.FindIndex(p => p.PlayerName == playerData.PlayerName);
        _playerDataList[index] = playerData;

        print("listelement.playername to:" + _playerDataList[index].PlayerName);
        print("listelement.playername to:" + _playerDataList[index].HighestScore);
        print("higest score  to:" + _playerDataList.Find(p => p.PlayerName == playerData.PlayerName).HighestScore);


        _playerDataHandler.SerializeJson();
    }
    public void TurnSmoothly(float rotationSpeed)
    {
        if (_isLeftClicked)
        {
            transform.Rotate(Vector3.up * -rotationSpeed);
            camera.transform.Rotate(Vector3.forward * -rotationSpeed);
        }
        if (_isRightClicked)
        {
            transform.Rotate(Vector3.up * rotationSpeed);
            camera.transform.Rotate(Vector3.forward * rotationSpeed);
        }
    }
    public void OnTurnLeftButtonPressed()
    {
        //Turn(-90f);

    }
    public void OnTurnRightButtonPressed()
    {
        //Turn(90f);
    }
    public void OnTurnLeftButtonReleased()
    {
        _isLeftClicked = false;
    }
    public void OnTurnRightButtonReleased()
    {
        _isRightClicked = false;
    }
    public void OnTurnLeftButtonDown()
    {
        _isLeftClicked = true;
    }
    public void OnTurnRightButtonDown()
    {
        _isRightClicked = true;
    }
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
