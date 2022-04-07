using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ScoreManager : MonoBehaviour
{
    public static float score;
    public static int finalScore;
    int multiplier = 1;


    Text text;


    void Start ()
    {
        text = GetComponent <Text> ();
        score = 0;
    }

    void Update ()
    {
        score += Time.deltaTime * multiplier;
        finalScore = (int) score;
        text.text = "Score: " + String.Format("{0:0}",score);
    }


}
