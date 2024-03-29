using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    string username = "";
    public Toggle fpsToggle;
    public Text welcomeText;
    void Start()
    {
        username = PlayerPrefs.GetString("username");
        if (username == "")
        {
            SceneManager.LoadScene(sceneName: "Intro");
            return;
        }

        welcomeText.text = "Welcome " + username;
    }

    public void GoToZenScoreboard()
    {
        SceneManager.LoadScene(sceneName: "ZenScoreboard");
    }

    public void GoToWaveScoreboard()
    {
        SceneManager.LoadScene(sceneName: "WaveScoreboard");
    }

    public void ExitMenu()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void GoToZenMode()
    {
        PlayerPrefs.SetString("view", fpsToggle.isOn ? "first" : "third");
        PlayerPrefs.SetString("mode", "zen");
        SceneManager.LoadScene(sceneName: "Level_01");
    }

    public void GoToWaveMode()
    {
        PlayerPrefs.SetString("view", fpsToggle.isOn ? "first" : "third");
        PlayerPrefs.SetString("mode", "wave");
        SceneManager.LoadScene(sceneName: "Level_01");
    }

    public void GoToRename()
    {
        PlayerPrefs.DeleteKey("username");
        SceneManager.LoadScene(sceneName: "Intro");
    }
}
