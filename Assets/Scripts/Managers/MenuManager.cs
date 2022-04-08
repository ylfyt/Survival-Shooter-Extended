using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    string username = "";
    public Text welcomeText;
    void Start()
    {
        username = PlayerPrefs.GetString("username");
        if (username == "")
        {
            Debug.Log("Username doesn't exist");
            SceneManager.LoadScene(sceneName: "Intro");
            return;
        }

        welcomeText.text = "Welcome " + username;
    }
}
