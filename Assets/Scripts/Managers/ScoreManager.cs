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


    Text text;


    void Start ()
    {
        text = GetComponent <Text> ();
        zenScore = 0;
        waveScore = 0;
        Debug.Log(text);
    }

    void Update ()
    {
        if (PlayerInfo.isZenMode)
        {
            if (!isScoreOver) {
                zenScore += Time.deltaTime * multiplier;
                finalScore = (int) zenScore;
                text.text = "Score: " + String.Format("{0:0}",zenScore);
            } else {
                text.text = "Score: " + String.Format("{0:0}",zenScore);
            }
        } else {
            text.text = "Score: " + waveScore;
        }
        
    }


}
