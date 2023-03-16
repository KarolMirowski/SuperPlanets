using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;


public class OneBot: MonoBehaviour, IPointerDownHandler
{
      [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private Image _twoBots;
    [SerializeField] private Image _threeBots;

    public void OnPointerDown(PointerEventData eventData)
    {
        _audioSource.PlayOneShot(_audioClip);
        GetComponent<Image>().color = Color.gray;
        _twoBots.color = Color.white;
        _threeBots.color = Color.white;
    
    }
}
