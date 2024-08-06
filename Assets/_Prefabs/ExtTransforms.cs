using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Transforms
{
    public static void DestroyChildren(this Transform t, bool destroyImmedietaly = false)
    {
        foreach (Transform child in t)
        {
            if (destroyImmedietaly)
                MonoBehaviour.DestroyImmediate(child.gameObject);
            else
                MonoBehaviour.Destroy(child.gameObject);
            

            

        }
    }
}
