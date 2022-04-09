using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ScoreManager : MonoBehaviour
{
    public static float zenScore;
    public static float waveScore;
    public static int finalScore;
    int multiplier = 1;
    public static bool isScoreOver = false;


    public Text score;
    public Text level;


    void Start ()
    {
        zenScore = 0;
        waveScore = 0;
    }

    void Update ()
    {
        if (PlayerInfo.isZenMode)
        {
            if (!isScoreOver) {
                zenScore += Time.deltaTime * multiplier;
                finalScore = (int) zenScore;
                score.text = "Score: " + String.Format("{0:0}",zenScore);
            } else {
                score.text = "Score: " + String.Format("{0:0}",zenScore);
            }
            level.text = "";
        } else {
            score.text = "Score: " + waveScore;
            level.text = "Level: " + EnemyManager.waveLevel;
        }
        
    }


}
