using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ColorCanvasManager : MonoBehaviour
{
    public List<GameSettings.ColorSet> _colorSetsList ;
    [SerializeField] private GameObject _listContent;
    [SerializeField] private GameSettings _gameSettings;

    void Start(){
        _colorSetsList = _gameSettings.ColorSets;
        
    }





}
