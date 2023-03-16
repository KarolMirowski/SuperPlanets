using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class BackToMenu : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _creditsPanel;

    public void OnPointerDown(PointerEventData eventData)
    {
        _audioSource.PlayOneShot(_audioClip);
        
        if(_menuPanel.activeSelf == false)
            _menuPanel.SetActive(true);
        
        if(_settingsPanel.activeSelf == true)
            _settingsPanel.SetActive(false);
        
        if(_creditsPanel.activeSelf == true)
            _creditsPanel.SetActive(false);
    
    }
}
