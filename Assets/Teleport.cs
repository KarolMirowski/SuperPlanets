using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    private Button _teleportButton;
    // Start is called before the first frame update
    void Start()
    {
        _teleportButton.onClick.AddListener(OnTeleportButtonPressed);

    }
    void OnTeleportButtonPressed()
    {
        var transform = GetComponent<Transform>().transform;
        transform.position = Random.onUnitSphere * 18.2f;
        transform.LookAt(Vector3.zero);
        transform.Rotate(new Vector3(0, 0, 90f));

    }
    // Update is called once per frame
    void Update()
    {

    }
}
