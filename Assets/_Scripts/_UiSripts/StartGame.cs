using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private TextMeshProUGUI _menuPanel;
    [SerializeField] private TextMeshProUGUI _settingsPanel;


    public void OnPointerDown(PointerEventData eventData)
    {
        _audioSource.PlayOneShot(_audioClip);
        SceneManager.LoadScene("WorkingScene");
    
    }


}
