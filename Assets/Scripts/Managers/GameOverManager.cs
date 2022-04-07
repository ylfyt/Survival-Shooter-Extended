﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float restartDelay = 5f;


    public Animator canvasAnimator;
    float restartTimer;

    bool isGameOver = false;

    void Update()
    {
        if (playerHealth.isDead)
        {
            canvasAnimator.SetBool("GameOver", true);
            isGameOver = true;

            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void ShowWarning()
    {
        if (isGameOver)
        {
            return;
        }
        canvasAnimator.SetTrigger("Warning");
    }
}