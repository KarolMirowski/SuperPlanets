using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField]
    private TMP_Text ScoreText;
    public int Score = 0;
    public bool IsCounting = false;
    private bool Counting;
    private PlayerData _playerData;
    private Coroutine _scoreCounterRoutine;
    void Start()
    {
        //StartCoroutine(ScoreCounterRoutine());
        _playerData = GetComponent<PlayerElementData>().SinglePlayerData;
    }

    public IEnumerator ScoreCounterRoutine()
    {
        while (IsCounting)
        {
            Score += 1;
            ScoreText.text = Score.ToString();
            yield return new WaitForSeconds(1f);
            _playerData.CurrentScore = Score;
            if (_playerData.CurrentScore > _playerData.HighestScore)
                _playerData.HighestScore = _playerData.CurrentScore;
        }
        _playerData.CurrentScore = Score;
            if (_playerData.CurrentScore > _playerData.HighestScore)
                _playerData.HighestScore = _playerData.CurrentScore;
    }
    public void StopCounter()
    {
        if (_scoreCounterRoutine != null)
        {
            StopCoroutine(_scoreCounterRoutine);
            _scoreCounterRoutine = null;
            IsCounting = false;
            //print($"Obiekt to {gameObject.name} IsCounting = {IsCounting}");

        }
    }
    public void StartCounter()
    {

        if (IsCounting == false)
        {
            IsCounting = true;
            _scoreCounterRoutine = StartCoroutine(ScoreCounterRoutine());
        }
    }
}
