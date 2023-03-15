using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NetworkedPrefab : MonoBehaviour
{
    public GameObject Prefab;
    public string Path;

    public NetworkedPrefab(GameObject obj, string path)
    {
        Prefab = obj;
        Path = path;
    }
    
    private string ReturnPath(string path)
    {
        int extenstionLength = System.IO.Path.GetExtension(path).Length;
        int additionalLength = 10; 
        int startIndex = path.ToLower().IndexOf("resources");

        if (startIndex == -1)
        {
            return string.Empty;
        }

        else
        {
            return path.Substring(startIndex, path.Length - (startIndex + extenstionLength) + additionalLength);
        }
    }

}
