using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreCount : MonoBehaviour
{
    public TextMeshProUGUI text;
    private int score = 0;
    private float speedMultiplier = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(ScoreCounter());
        
    }

    public IEnumerator ScoreCounter()
    {
        GameManager.Instance.ScoreCount += 1 ;
        text.text = "Score: " + GameManager.Instance.ScoreCount.ToString();
        yield return new WaitForSecondsRealtime(1);
        StartCoroutine(ScoreCounter());
        
    }

}
