using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.InputSystem.Interactions;
using Newtonsoft.Json;
using System;
using UnityEngine.Purchasing.MiniJSON;

public class JsonDataService : IDataService
{


    public bool SaveData<T>(string relativePath, T data, bool encrypted)
    {
        string path = Application.persistentDataPath + relativePath;

        try
        {
            if (File.Exists(path))
            {
                Debug.Log("Data exists, deleting old file and adding a new one ");
                File.Delete(path);

            }
            else
            {
                Debug.Log("Creating new file with json");

            }
            using FileStream stream = File.Create(path); //Dlaczego FileStream?
            stream.Close();
            File.WriteAllText(path, JsonConvert.SerializeObject(data));
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError($"There is Exception {e.Message} and {e.StackTrace}");
            return false;
        }
    }

    public T LoadData<T>(string relativePath, bool encrypted)
    {
        var path = Application.persistentDataPath + relativePath;

        if (!File.Exists(path))
        {
            Debug.Log("Plik nie istnieje");
            throw new FileNotFoundException();
        }
        
        try
        {
            T data = JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
            return data;
        }
        catch(Exception e){
            Debug.Log($"Wystapil blas podczas deserializacji {e.Message}, : {e.StackTrace}");
            throw new NullReferenceException();
        }
    }



}
