using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class GoToCredits : MonoBehaviour, IPointerDownHandler
{
      [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _creditsPanel;

    public void OnPointerDown(PointerEventData eventData)
    {
        _audioSource.PlayOneShot(_audioClip);
        
        if(_menuPanel.activeSelf == true)
            _menuPanel.SetActive(false);
        
        if(_creditsPanel.activeSelf == false)
            _creditsPanel.SetActive(true);
    
    }
}
