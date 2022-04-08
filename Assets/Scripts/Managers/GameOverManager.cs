using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float restartDelay = 5f;


    public Animator canvasAnimator;
    float restartTimer;

    bool isGameOver = false;
    bool isSaved = false;

    void Update()
    {
        if (playerHealth.isDead)
        {
            canvasAnimator.SetBool("GameOver", true);
            isGameOver = true;
            ScoreManager.isScoreOver = true;

            if (!isSaved)
            {
                DataManager.SaveData(PlayerInfo.name, ScoreManager.finalScore, "ZEN");
                isSaved = true;
            }

            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                GoToGameOverScene();
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

    public void GoToGameOverScene()
    {
        PlayerPrefs.SetString("username", PlayerInfo.name);
        string mode = PlayerInfo.isZenMode ? "zen" : "wave";
        PlayerPrefs.SetString("mode", mode);
        PlayerPrefs.SetInt("score", ScoreManager.finalScore);
        PlayerPrefs.SetInt("wave-level", EnemyManager.waveLevel);

        SceneManager.LoadScene(sceneName: "GameOverScene");
    }
}