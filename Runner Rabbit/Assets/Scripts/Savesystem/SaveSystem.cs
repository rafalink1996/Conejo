using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class SaveSystem
{
    public static void SavePlayer (GameStats gamestats)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/stats.Magicbound";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(gamestats);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static PlayerData loadPlayer ()
    {
        string path = Application.persistentDataPath + "/stats.Magicbound";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("save file not found in" + path);
            return null;
        }
    }

    public static bool IsBinaryFilePresent()
    {
        string path = Application.persistentDataPath + "/stats.Magicbound";
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


