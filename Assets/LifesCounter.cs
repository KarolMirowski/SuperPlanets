using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifesCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _heartText;
    [SerializeField] private TMP_Text _countAfterLossText;
    private Coroutine _countAfterLoss;
    public int LifesLeft = 3;
    private PlayerController _playerController;
    //[SerializeField] private TextMeshProUGUI countdownText;
    void Start()
    {
        _playerController = GetComponent<PlayerController>();
    }
    public void ShowCountdown(int seconds)
    {
        _countAfterLossText.text = seconds.ToString();
        _countAfterLossText.gameObject.SetActive(true);
    }

    public void HideCountdown()
    {
        _countAfterLossText.gameObject.SetActive(false);
    }
    public void TakeOneLife()
    {
        LifesLeft -= 1;
        if(_heartText.text.Length >0)
            _heartText.text = _heartText.text.Remove(_heartText.text.Length - 1);
    }

}


