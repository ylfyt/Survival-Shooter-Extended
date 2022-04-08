using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserSetup : MonoBehaviour
{
    // Start is called before the first frame update

    public Text nameText;

    void Start()
    {
        string name = PlayerPrefs.GetString("username", "");
        if (name == "")
        {
            return;
        }
        SceneManager.LoadScene(sceneName: "Menu");
    }

    public void EnterButton()
    {
        if (nameText.text == "")
        {
            Debug.Log("Name is empty");
            return;
        }

        PlayerPrefs.SetString("username", nameText.text);
        SceneManager.LoadScene(sceneName: "Menu");
    }

    public void ExitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
