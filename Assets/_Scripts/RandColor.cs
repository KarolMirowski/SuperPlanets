using UnityEngine;
using System.Collections.Generic;

public class RandColor : MonoBehaviour
{
    [SerializeField] private Color[] colors;
    private List<Color> assignedColors = new List<Color>();

    private void Start()
    {
        Color randomColor;
        do
        {
            int randomColorIndex = Random.Range(0, colors.Length);
            randomColor = colors[randomColorIndex];
        }
        while (assignedColors.Contains(randomColor));

        assignedColors.Add(randomColor);

        var meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.sharedMaterial.color = randomColor;
        GetComponentInChildren<TrailRenderer>().material.color = randomColor;
    }
}
