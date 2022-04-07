using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ScoreManager : MonoBehaviour
{
    public static float score;
    public static int finalScore;
    int multiplier = 1;
    public static bool isScoreOver = false;


    Text text;


    void Start ()
    {
        text = GetComponent <Text> ();
        score = 0;
        Debug.Log(text);
    }

    void Update ()
    {
        if (!isScoreOver) {
            score += Time.deltaTime * multiplier;
            finalScore = (int) score;
            text.text = "Score: " + String.Format("{0:0}",score);
        } else {
            text.text = "Score: " + String.Format("{0:0}",score);
        }
        
    }


}
