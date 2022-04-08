using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGameOver : MonoBehaviour
{
    string username = "";
    string mode = "zen";
    int score = 0;
    int waveLevel = 0;
    void Start()
    {
        username = PlayerPrefs.GetString("username", "null");
        mode = PlayerPrefs.GetString("mode", "zen");
        score = PlayerPrefs.GetInt("score", 0);
        waveLevel = PlayerPrefs.GetInt("wave-level", 0);

        Debug.Log(username);
        Debug.Log(mode);
        Debug.Log(score);
        Debug.Log(waveLevel);
    }
}
