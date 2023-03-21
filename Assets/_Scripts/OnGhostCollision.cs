using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGhostCollision : MonoBehaviour
{
    [SerializeField] private float _rescueTurnValue;
    [SerializeField] private float _rescueTurnDuration = 1f;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Trailon") == true && this.gameObject.name == "TurnColliderLeft")
        {
            var duration = Time.time + _rescueTurnDuration;
            while (Time.time < duration)
            {
                GetComponentInParent<Transform>().Rotate(Vector3.up * _rescueTurnValue /** Time.deltaTime*/);
            }
        }
        if (collision.collider.CompareTag("Trailon") == true && this.gameObject.name == "TurnColliderRight")
        {
            var duration = Time.time + _rescueTurnDuration;
            while (Time.time < duration)
            {
                GetComponentInParent<Transform>().Rotate(Vector3.up * -_rescueTurnValue /** Time.deltaTime*/);
            }
        }
    }
}
