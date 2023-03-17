using UnityEngine;
using UnityEngine.Events;

[ExecuteInEditMode]
public class ColorPerpend : MonoBehaviour
{
    public Renderer renderer;

    public ColorChangeEvent onColorChange;

    private Color previousColor;

    private void OnEnable()
    {
        // Sprawdź, czy renderer jest przypisany do obiektu
        if (renderer == null)
            renderer = GetComponent<Renderer>();

        // Zapisz poprzedni kolor
        previousColor = renderer.sharedMaterial.GetColor("_EmissionColor");
    }

    private void Update()
    {
        // Sprawdź, czy kolor emitting materiału uległ zmianie
        if (renderer != null && renderer.sharedMaterial != null && renderer.sharedMaterial.GetColor("_EmissionColor") != previousColor)
        {
            // Przekaż nowy kolor do zdarzenia
            onColorChange.Invoke(renderer.sharedMaterial.GetColor("_EmissionColor"));

            // Zapisz nowy kolor jako poprzedni kolor
            previousColor = renderer.sharedMaterial.GetColor("_EmissionColor");
        }
    }
}

[System.Serializable]
public class ColorChangeEvent : UnityEvent<Color> { }
