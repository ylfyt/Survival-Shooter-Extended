using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Awake()
    {
        PlayerInfo.name = PlayerPrefs.GetString("username", "");
        if (PlayerInfo.name == "")
        {
            PlayerInfo.name = "Default";
        }

        string mode = PlayerPrefs.GetString("mode", "zen");
        if (mode == "wave")
        {
            PlayerInfo.isZenMode = false;
        }
    }
}
