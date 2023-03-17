using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventsScripts : MonoBehaviour
{
    // Start is called before the first frame update
    public bool GenerateBonus   = true;
    public bool GenerateLetters = true;


    [SerializeField]
    private GameObject       playerOne;

    [SerializeField]
    private GameObject       playerTwo;
    [SerializeField]
    private GameObject       playerThree;
    [SerializeField]
    private GameObject       playerFour;

    [SerializeField]
    private TMPro.TMP_Text   text;

    [SerializeField]
    private GameSettings     gameSettings;

    [SerializeField]
    private GameObject       speedBonus;

    [SerializeField]
    private GameObject       letter;

    private ScoreCount[] scoreCounts;
    private int looper = 0;
    public int explosionForce = 100;
    public int explosionRadius = 10;

    void Start()
    {
        StartCoroutine(Wait());
        if(GenerateBonus)
            StartCoroutine(SpeedBonus());
        if(GenerateLetters)
            StartCoroutine(LettersGen());
        scoreCounts = FindObjectsOfType<ScoreCount>();

    }

    private void OnValidate()
    {
        if(speedBonus)
        StopCoroutine(SpeedBonus());



    }
    IEnumerator LettersGen()
    {
        Vector3 letterPosition = playerOne.transform.position - playerOne.transform.forward + new Vector3(0, 0.1f, 0);
        Quaternion letterRotation = playerOne.transform.rotation;
        Instantiate(letter, letterPosition, letterRotation);
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(LettersGen());

        /*
        looper += 1;
        while (looper < 1000)
        {

        }
        while (looper >= 1000)
        {
            StopCoroutine(LettersGen());
        }
        */

    }
    IEnumerator Wait()
    {


        playerOne.GetComponent<PlayerController>().speed = 0f;
        playerOne.GetComponent<Rigidbody>().Sleep();
        
        //playerTwo.GetComponent<Player2Controller>().speed = 0f;
        //playerTwo.GetComponent<Rigidbody>().Sleep();
//
        //playerThree.GetComponent<Player2Controller>().speed = 0f;
        //playerThree.GetComponent<Rigidbody>().Sleep();
        //
        //playerFour.GetComponent<Player2Controller>().speed = 0f;
        //playerFour.GetComponent<Rigidbody>().Sleep();


        text.text = "3";
        yield return new WaitForSeconds(0.7f);
        text.text = "2";
        yield return new WaitForSeconds(0.7f);
        text.text = "1";
        yield return new WaitForSeconds(0.7f);
        text.text = "Start";
        yield return new WaitForSeconds(0.3f);
        text.text = "";

        scoreCounts[0].StartCoroutine(scoreCounts[0].ScoreCounter());
        //scoreCounts[1].StartCoroutine(scoreCounts[1].ScoreCounter());

        playerOne.GetComponent<PlayerController>().speed = gameSettings.pOneSpeed;
       // playerTwo.GetComponent<Player2Controller>().speed = gameSettings.pTwoSpeed;
       // playerThree.GetComponent<Player2Controller>().speed = gameSettings.pTwoSpeed;
       // playerFour.GetComponent<Player2Controller>().speed = gameSettings.pTwoSpeed;
        //StartCoroutine(playerTwo.GetComponent<Player2Controller>().TurnTact(2f));
        
        StopCoroutine(Wait());
    }

    public IEnumerator SpeedBonus()
    {
        MeshRenderer instance = Instantiate(speedBonus, Random.onUnitSphere * 50, Quaternion.identity).GetComponentInChildren<MeshRenderer>();
        Color color = Random.ColorHSV();
        instance.material.color = color;
        yield return new WaitForSeconds(1);
        StartCoroutine(SpeedBonus());
    }
    public void ResetScene()
    {
        //Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("WorkingScene");
    }
    public void BackToMenu()
    {
        //Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("Menu");
    }
    public void GoToOptions()
    {
        //Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("Options");
    }
   
}
