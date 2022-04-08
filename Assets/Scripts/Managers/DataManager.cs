using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class DataManager
{

    public static void SaveData(string name_, int score_)
    {
        string path;

        DateTime timestamp = DateTime.Now;
        string unixTime = ((DateTimeOffset)timestamp).ToUnixTimeSeconds().ToString();

        BinaryFormatter formatter = new BinaryFormatter();
        if (EnemyManager.isZenMode)
        {
            path = Application.persistentDataPath + "/zen_" + unixTime;
        }
        else
        {
            path = Application.persistentDataPath + "/wave_" + unixTime;
        }
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(name_, score_);

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log(path);
    }

    public static PlayerData[] LoadPlayer(string gameMode)
    {

        string patern = gameMode == "zen" ? "zen_" : "wave_";

        var playerData = new List<PlayerData>();

        string[] filenames = Directory.GetFiles(Application.persistentDataPath);

        foreach (var filename in filenames)
        {
            if (filename.Contains(patern))
            {
                if (File.Exists(filename))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    FileStream stream = new FileStream(filename, FileMode.Open);

                    PlayerData data = formatter.Deserialize(stream) as PlayerData;
                    stream.Close();

                    playerData.Add(data);
                }
                else
                {
                    Debug.LogError("Save file not found in " + filename);
                }
            }
        }

        return playerData.ToArray();
    }
}
