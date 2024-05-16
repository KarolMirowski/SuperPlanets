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
    private bool _shouldAddPoint;
    public bool ShouldAddPoint { get { return _shouldAddPoint; } set { _shouldAddPoint = value; } }


    public static ScoreCount Instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


    }

    public IEnumerator ScoreCounter()
    {
        if (GameManager.Instance != null)
        {

            GameManager.Instance.ScoreCount += 1;
            text.text = "Score: " + GameManager.Instance.ScoreCount.ToString();
            yield return new WaitForSecondsRealtime(1);

            if (ShouldAddPoint == false)
                StartCoroutine(ScoreCounter());

        }
    }

}
