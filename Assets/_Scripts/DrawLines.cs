using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[ExecuteInEditMode]
public class DrawLines : MonoBehaviour
{
    // Start is called before the first frame update
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position, transform.forward * 100f);
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position, Vector3.zero * 1f);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(Vector3.zero, 10f);

    }





}
