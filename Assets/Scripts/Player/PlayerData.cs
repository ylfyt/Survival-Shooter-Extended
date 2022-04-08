using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string name;
    public int score;

    public PlayerData(string name_, int score_)
    {
        name = name_;
        score = score_;
    }

}
