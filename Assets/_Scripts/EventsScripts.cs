using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventsScripts : MonoBehaviour
{
    public static EventsScripts Instance;

    public PlayerController _playerOneController;
    public PlayerController _playerTwoController;
    private ScoreCounter _playerOneCounter;
    private ScoreCounter _playerTwoCounter;
    [SerializeField] TMP_Text _playerOneText;
    [SerializeField] TMP_Text _playerTwoText;
    [SerializeField] TMP_Text _oneStartLabel;
    [SerializeField] TMP_Text _twoStartLabel;
    [SerializeField] private TMPro.TMP_Text text;
    [SerializeField] private GameSettings gameSettings;
    private int looper = 0;
    private Camera _playerOneCamera;
    private Camera _playerTwoCamera;
    private GameManager _gameManager;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {

            Destroy(Instance);
        }

    }
    void Start()
    {
        _gameManager = GameManager.Instance;

        //scoreCounts = FindObjectsOfType<ScoreCount>();
        _playerOneCamera = _playerOneController.GetComponentInChildren<Camera>();
        _playerTwoCamera = _playerTwoController.GetComponentInChildren<Camera>();
        _playerOneCounter = _playerOneController.GetComponentInChildren<ScoreCounter>();
        _playerTwoCounter = _playerTwoController.GetComponentInChildren<ScoreCounter>();
        SetNumberOfPlayers();
        StartCoroutine(WatForStart());

    }

    public IEnumerator WatForStart()
    {
        //Zatrzymanie graczy w miejscu, do sprawdzenia czy konieczne.
        _playerOneController.speed = 0f;
        _playerOneController.GetComponent<Rigidbody>().Sleep();
        _playerTwoController.speed = 0f;
        _playerTwoController.GetComponent<Rigidbody>().Sleep();

        //Odliczanie
        _playerOneText.text = "3";
        _playerTwoText.text = "3";
        yield return new WaitForSeconds(1f);
        _playerOneText.text = "2";
        _playerTwoText.text = "2";
        yield return new WaitForSeconds(1f);
        _playerOneText.text = "1";
        _playerTwoText.text = "1";
        yield return new WaitForSeconds(1f);

        //Puste po odliczeniu zeby nie bylo widac napisu.
        _playerOneText.text = "";
        _playerTwoText.text = "";
        //Aktywacja znakow start
        _oneStartLabel.gameObject.SetActive(true);
        _twoStartLabel.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.6f);
        //Dezaktywacja znakow start
        _oneStartLabel.gameObject.transform.parent.gameObject.SetActive(false);
        _twoStartLabel.gameObject.transform.parent.gameObject.SetActive(false);

        StartGamePlay();
        //scoreCounts[0].StartCoroutine(scoreCounts[0].ScoreCounter());
        //scoreCounts[1].StartCoroutine(scoreCounts[1].ScoreCounter());

        // playerTwo.GetComponent<Player2Controller>().speed = gameSettings.pTwoSpeed;
        // playerThree.GetComponent<Player2Controller>().speed = gameSettings.pTwoSpeed;
        // playerFour.GetComponent<Player2Controller>().speed = gameSettings.pTwoSpeed;
        //StartCoroutine(playerTwo.GetComponent<Player2Controller>().TurnTact(2f));

        StopCoroutine(WatForStart());
    }
    void StartGamePlay()
    {
        //Aktywacja graczy
        _playerOneController.speed = 0.1f;
        _playerTwoController.speed = 0.1f;
        _playerOneCounter.StartCounter();
        _playerTwoCounter.StartCounter();
    }
    /*
    public IEnumerator SpeedBonus()
    {
        MeshRenderer instance = Instantiate(speedBonus, Random.onUnitSphere * 50, Quaternion.identity).GetComponentInChildren<MeshRenderer>();
        Color color = Random.ColorHSV();
        instance.material.color = color;
        yield return new WaitForSeconds(2f);
        StartCoroutine(SpeedBonus());
    }

    public IEnumerator addPointsBonusRoutine()
    {
        MeshRenderer instance = Instantiate(addPointsBonus, Random.onUnitSphere * 50, Quaternion.identity).GetComponentInChildren<MeshRenderer>();
        Color color = Random.ColorHSV();
        instance.material.color = color;
        yield return new WaitForSeconds(2f);
        StartCoroutine(addPointsBonusRoutine());
    }
    */
    public void SetNumberOfPlayers()
    {
        if (_gameManager.PlayerCountNumber == 1)
        {

            _playerOneCamera.rect = new Rect(0f, 0f, 1f, 1f);
            _playerTwoController.gameObject.SetActive(false);
        }
        if (_gameManager.PlayerCountNumber == 2)
        {
            _playerOneCamera.rect = new Rect(0f, 0f, 0.5f, 1f);
            _playerTwoCamera.rect = new Rect(0.5f, 0f, 0.5f, 1f);
            _playerTwoController.gameObject.SetActive(true);
        }

    }

    public void ResetScene()
    {
        //Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("WorkingScene");
        //TUTAJ WROCIC
        //_gameManager.PlayerOneScore = 0;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void GoToOptions()
    {
        SceneManager.LoadScene("Options");
    }

}
