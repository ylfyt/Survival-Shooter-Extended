using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowGameOver : MonoBehaviour
{
    public Text nameText;
    public Text modeText;
    public Text scoreText;
    public Text levelText;
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

        nameText.text = username;
        modeText.text = mode.ToUpper() + " Mode";

        if (mode == "zen")
        {
            scoreText.text = "Score: " + score.ToString() + " s";
            levelText.enabled = false;
            return;
        }

        scoreText.text = "Score: " + score.ToString();
        levelText.enabled = true;
        levelText.text = "Level: " + (waveLevel-1).ToString();
    }

    public void GoToReplay()
    {
        PlayerPrefs.SetString("mode", mode);
        SceneManager.LoadScene(sceneName: "Level_01");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(sceneName: "Menu");
    }
}
