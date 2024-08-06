using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventsScripts : MonoBehaviour
{
    public PlayerController _playerOneController;
    public PlayerController _playerTwoController;
    [SerializeField] private GameObject playerThree;
    [SerializeField] private GameObject playerFour;
    [SerializeField] private TMPro.TMP_Text text;
    [SerializeField] private GameSettings gameSettings;
    private ScoreCount[] scoreCounts;
    private int looper = 0;
    private Camera _playerOneCamera;
    private Camera _playerTwoCamera;
    private GameManager _gameManager;
    void Start()
    {
        _gameManager = GameManager.Instance;
        
        scoreCounts = FindObjectsOfType<ScoreCount>();
        _playerOneCamera = _playerOneController.GetComponentInChildren<Camera>();
        _playerTwoCamera = _playerTwoController.GetComponentInChildren<Camera>();
        
        SetNumberOfPlayers();
    
    
    }

    IEnumerator Wait()
    {
        _playerOneController.speed = 0f;
        _playerOneController.GetComponent<Rigidbody>().Sleep();

        //playerTwo.GetComponent<Player2Controller>().speed = 0f;
        //playerTwo.GetComponent<Rigidbody>().Sleep();
        //
        //playerThree.GetComponent<Player2Controller>().speed = 0f;
        //playerThree.GetComponent<Rigidbody>().Sleep();
        //
        //playerFour.GetComponent<Player2Controller>().speed = 0f;
        //playerFour.GetComponent<Rigidbody>().Sleep();


        text.text = "3";
        yield return new WaitForSeconds(0.5f);
        text.text = "2";
        yield return new WaitForSeconds(0.5f);
        text.text = "1";
        yield return new WaitForSeconds(0.5f);
        text.text = "Start";
        yield return new WaitForSeconds(0.3f);
        text.text = "";

        scoreCounts[0].StartCoroutine(scoreCounts[0].ScoreCounter());
        //scoreCounts[1].StartCoroutine(scoreCounts[1].ScoreCounter());

        // playerTwo.GetComponent<Player2Controller>().speed = gameSettings.pTwoSpeed;
        // playerThree.GetComponent<Player2Controller>().speed = gameSettings.pTwoSpeed;
        // playerFour.GetComponent<Player2Controller>().speed = gameSettings.pTwoSpeed;
        //StartCoroutine(playerTwo.GetComponent<Player2Controller>().TurnTact(2f));

        StopCoroutine(Wait());
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
            
            _playerOneCamera.rect = new Rect(0f,0f,1f,1f);
            _playerTwoController.gameObject.SetActive(false);
        }
        if (_gameManager.PlayerCountNumber == 2)
        {
            _playerOneCamera.rect = new Rect(0f,0f,0.5f,1f);
            _playerTwoCamera.rect = new Rect(0.5f,0f,0.5f,1f);
            _playerTwoController.gameObject.SetActive(true);
        }

    }

    public void ResetScene()
    {
        //Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("WorkingScene");
        _gameManager.PlayerOneScore = 0;
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
