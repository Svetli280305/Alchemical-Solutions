using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class SaveLoad
{
    public static UnityAction OnSaveGame;
    public static UnityAction<SaveData> onLoadGame;

    public static string directory = "/SaveData/";
    public static string fileName = "SaveGame.sav";

    public static bool Save(SaveData data)
    {
        Debug.Log("Saving");
        OnSaveGame?.Invoke();

        string dir = Application.persistentDataPath + directory;
        Debug.Log(dir);
        GUIUtility.systemCopyBuffer = dir;

        if(!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(dir + fileName, json);
        Debug.Log("Saving game");

        return true;
    }

    public static SaveData Load()
    {
        Debug.Log("Loading");
        string fullPath = Application.persistentDataPath + directory + fileName;
        SaveData data = new SaveData();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            data = JsonUtility.FromJson<SaveData>(json);

            onLoadGame?.Invoke(data);
        }
        else
        {
            Debug.Log("Save file does not exist.");
        }

        return data;
    }

    public static void DeleteSaveData()
    {
        string fullpath = Application.persistentDataPath + directory + fileName;

        if (File.Exists(fullpath)) File.Delete(fullpath);
    }
}
