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
        score += 1 ;
        text.text = Convert.ToString(score);
        yield return new WaitForSecondsRealtime(1);
        StartCoroutine(ScoreCounter());
    }

}
