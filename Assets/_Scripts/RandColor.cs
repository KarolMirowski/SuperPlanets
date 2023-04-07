using UnityEngine;

[CreateAssetMenu(fileName = "ColorList", menuName = "Custom/Color List")]
public class RandColor : MonoBehaviour
{
    [SerializeField] private Color[] colors;

    private void OnEnable()
    {
        var randomColorIndex = Random.Range(0,colors.Length);
        GetComponent<Renderer>().material.color = colors[randomColorIndex];
        GetComponentInChildren<TrailRenderer>().material.color = colors[randomColorIndex];
    }
}
