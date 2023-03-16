using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;


public class ThreeBots: MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private Image _oneBot;
    [SerializeField] private Image _twoBots;

    public void OnPointerDown(PointerEventData eventData)
    {
        _audioSource.PlayOneShot(_audioClip);
        GetComponent<Image>().color = Color.gray;
        _oneBot.color = Color.white;
        _twoBots.color = Color.white;
    
    }
}
