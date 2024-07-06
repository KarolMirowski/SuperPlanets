using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem.Interactions;
using static UnityEngine.Debug;

[CreateAssetMenu(menuName = "Manager/GameSettings")]
[ExecuteInEditMode]
public class GameSettings : ScriptableObject
{
    [Serializable]
    public class ColorSet
    {
        public Color PlanetColor;
        public Color BackgroundColor;
        public Color PlayerOneColor;
        public Color PlayerTwoColor;


        public ColorSet() { }
        public ColorSet(Color _planetColor, Color _backgroundColor, Color _playerOneColor, Color _playerTwoColor)
        {
            PlanetColor = _planetColor;
            BackgroundColor = _backgroundColor;
            PlayerOneColor = _playerOneColor;
            PlayerTwoColor = _playerTwoColor;
            
            
        }
    }
    public class MaterialSet
    {
        public Material PlanetMat;
        public Material BackgroundMat;
        public Material PlayerOneMat;
        public Material PlayerTwoMat;

        public MaterialSet() { }
        public MaterialSet(Material planet, Material background, Material playerOne, Material playerTwo)
        {
            PlanetMat = planet;
            BackgroundMat = background;
            PlayerOneMat = playerOne;
            PlayerTwoMat = playerTwo;
        }
    }

    [SerializeField] private Material PlanetMat;
    [SerializeField] private Material BackgroundMat;
    [SerializeField] private Material PlayerOneMat;
    [SerializeField] private Material PlayerTwoMat;

    [SerializeField] private string _gameVersion = "0.0.0";
    public string GameVersion => _gameVersion;


    private string _nickName = "Karol";
    public string NickName => $"{_nickName} id: {UnityEngine.Random.Range(0, 9999)}";

    [SerializeField] public float pOneSpeed = 0.4f;
    [SerializeField] public float pTwoSpeed = 0.4f;
    public float playerFOV = 45f;
    [SerializeField] private List<ColorSet> colorSets = new List<ColorSet>();
    public IReadOnlyList<ColorSet> ColorSets => colorSets;
    [SerializeField] private int currentColorSetIndex = 0;

    public int CurrentColorSetIndex
    {
        get { return currentColorSetIndex; }
        set
        {
            currentColorSetIndex = Math.Clamp(value, 0, colorSets.Count - 1);
            UpdateColors();
        }
    }

    void OnValidate()
    {
        UpdateColors();
        CurrentColorSetIndex = currentColorSetIndex;
    }
    void UpdateColors()
    {
        if (PlanetMat != null) PlanetMat.color = ColorSets[currentColorSetIndex].PlanetColor;
        if (PlayerOneMat != null) PlayerOneMat.color = ColorSets[currentColorSetIndex].PlayerOneColor;
        if (PlayerTwoMat != null) PlayerTwoMat.color = ColorSets[currentColorSetIndex].PlayerTwoColor;
        if (BackgroundMat != null) BackgroundMat.color = ColorSets[currentColorSetIndex].BackgroundColor;
        
        

    }


}