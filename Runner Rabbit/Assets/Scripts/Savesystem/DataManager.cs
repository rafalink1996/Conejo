using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public PlayerData2 data;
    private string file = "player.text";

    public void SaveJson()
    {
        data.SaveData();
        string json = JsonUtility.ToJson(data);
        writeToFile(file, json);
    }
    public void LoadJson()
    {
        data = new PlayerData2();
        string json = ReadFromFile(file);
        JsonUtility.FromJsonOverwrite(json, data);
    }

    private void writeToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);
        FileStream fileStream = new FileStream(path, FileMode.Create);
        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }

    private string ReadFromFile(string fileName)
    {
        string path = GetFilePath(fileName);
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        }
        else
        {
            Debug.LogWarning("fileNotFound");
            return "";
        }
    }

    private string GetFilePath(string filename)
    {
        return Application.persistentDataPath + "/" + filename;
    }

    public bool IsFilePresent()
    {
        string path = GetFilePath(file);
        if (File.Exists(path))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
