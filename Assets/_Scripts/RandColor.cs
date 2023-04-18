using UnityEngine;
using System.Collections.Generic;

public class RandColor : MonoBehaviour
{
    [SerializeField] private Color[] colors;
    private List<Color> assignedColors = new List<Color>();

    private void Start()
    {
        //Nowy materiał.
        Material newMaterial = new Material(Shader.Find("Standard"));

        //Pętla. Dla unikalności każdego z kolorów pobranych z listy.
        Color randomColor;
        do
        {
            int randomColorIndex = Random.Range(0, colors.Length);
            randomColor = colors[randomColorIndex];
        }
        while (assignedColors.Contains(randomColor));
        assignedColors.Add(randomColor);

        //Przypisanie koloru do materiału, materiału do Renderera i TrailRenderera.
        newMaterial.color = randomColor;
        var meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = newMaterial;

        var trailRenderer = GetComponentInChildren<TrailRenderer>();
        if (trailRenderer != null)
        {
            trailRenderer.material = new Material(Shader.Find("Standard"));
            trailRenderer.material.color = randomColor;
            trailRenderer.materials = new Material[] { trailRenderer.material };
        }
    }
}
