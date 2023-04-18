using UnityEngine;
using System.Collections.Generic;

public class RandColor : MonoBehaviour
{
    [SerializeField] private Color[] colors;
    private List<Color> assignedColors = new List<Color>();

    private void Start()
    {
        Material newMaterial = new Material(Shader.Find("Standard"));

        Color randomColor;
        do
        {
            int randomColorIndex = Random.Range(0, colors.Length);
            randomColor = colors[randomColorIndex];
        }
        while (assignedColors.Contains(randomColor));
        assignedColors.Add(randomColor);

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
