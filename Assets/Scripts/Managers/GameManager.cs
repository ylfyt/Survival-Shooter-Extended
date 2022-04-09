using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject thirdCamera;
    public GameObject firstCamera;
    public PlayerMovement playerMovement;
    public PlayerFPController playerFPController;
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

        string view = PlayerPrefs.GetString("view", "third");
        SwitchView(view == "third" ? true : false);
    }

    void SwitchView(bool third)
    {
        if (third)
        {
            firstCamera.SetActive(false);
            playerFPController.enabled = false;
            thirdCamera.SetActive(true);
            playerMovement.enabled = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            thirdCamera.SetActive(false);
            playerMovement.enabled = false;
            firstCamera.SetActive(true);
            playerFPController.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
