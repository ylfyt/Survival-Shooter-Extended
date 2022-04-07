using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class DataManager
{
    
    public static void SaveData (string name_, int score_, string GAMEMODE) {
        string path;

        DateTime timestamp = DateTime.Now;
        string unixTime = ((DateTimeOffset)timestamp).ToUnixTimeSeconds().ToString();

        BinaryFormatter formatter = new BinaryFormatter();
        if (GAMEMODE == "ZEN") {
            path = Application.persistentDataPath + "/zen_" + unixTime;
        } else {
            path = Application.persistentDataPath + "/wave_" + unixTime;
        }
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(name_, score_);

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log(path);
    }

    public static PlayerData LoadPlayer(string GAMEMODE) {
        string path;

        DateTime timestamp = DateTime.Now;
        string unixTime = ((DateTimeOffset)timestamp).ToUnixTimeSeconds().ToString();

        if (GAMEMODE == "ZEN") {
            path = Application.persistentDataPath + "/zen_" + unixTime;
        } else {
            path = Application.persistentDataPath + "/wave_" + unixTime;
        }

        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        } else {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
    
}
