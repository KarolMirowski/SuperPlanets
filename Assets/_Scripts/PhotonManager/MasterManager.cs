using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif
/*
[CreateAssetMenu(menuName = "Singletons/MasterManager")]

public class MasterManager : SingletonScriptableObject<MasterManager>
{

    //Inicjalizuje ustawienia gry.
    [SerializeField]
    private GameSettings _gameSettings;
    public static GameSettings GameSettings { get { return Instance._gameSettings; } }

    private List<NetworkedPrefab> networkedPrefabs;

    public static MasterManager Instance2;

    private void OnEnable()
    {
        Instance2 = this;
    }

    //networkedPrefab.Path != string.Empty
    public static GameObject NetworkInstantiate(GameObject obj, Vector3 position)
    {
        foreach (NetworkedPrefab networkedPrefab in Instance.networkedPrefabs)
        {
            if (networkedPrefab.Prefab == obj)
            {
                if (1 > 0)
                {
                    GameObject result = PhotonNetwork.Instantiate(networkedPrefab.Path, position, Quaternion.identity);
                    //GameObject trailObj = Instantiate(childrenPrefab, result.transform.position, result.transform.rotation);
                    //GameObject trailonObj = Instantiate(childrenPrefab2 ,result.transform.position, result.transform.rotation);
                    //trailObj.transform.parent = result.transform;
                    //trailonObj.GetComponent<TrailMesh>().tr = trailObj.GetComponent<TrailRenderer>();
                    return result;
                    Debug.Log("Udało się isntantianete");
                }

                else
                {
                    Debug.LogError("Ścieżka dla obiektu jest pusta " + networkedPrefab.Prefab);
                    return null;
                }
            }
        }
        return null;
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void PopulateNetworkedPrefabs()
    {
       

        Instance.networkedPrefabs.Clear();

        GameObject[] results = Resources.LoadAll<GameObject>("resources");

#if UNITY_EDITOR
        
        for (int i = 0; i < results.Length; i++)
        {
            if (results[i].GetComponent<PhotonView>() != null)
            {
                string path = UnityEditor.AssetDatabase.GetAssetPath(results[i]);
                Instance.networkedPrefabs.Add(new NetworkedPrefab(results[i], path));
                Debug.Log(path);
            }
        }
#endif


    }
*/


 