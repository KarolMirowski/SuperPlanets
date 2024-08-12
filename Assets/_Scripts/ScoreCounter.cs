using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField]
    private TMP_Text ScoreText;
    public int Score = 0;
    public bool IsCounting {get; private set;} = true;
    private PlayerData _playerData;
    void Start()
    {
        StartCoroutine(ScoreCounterRoutine());
        _playerData = GetComponent<PlayerElementData>().SinglePlayerData;
    }

    public IEnumerator ScoreCounterRoutine()
    {
        
        while (IsCounting)
        {
            Score += 1;
            ScoreText.text = Score.ToString();
            yield return new WaitForSeconds(1f);
        }
        _playerData.CurrentScore = Score;
        if(_playerData.CurrentScore > _playerData.HighestScore) 
            _playerData.HighestScore = _playerData.CurrentScore;

    }
    public void StopCounter(){
        IsCounting = false;
    }

}
