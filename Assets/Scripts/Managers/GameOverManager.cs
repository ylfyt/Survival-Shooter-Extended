using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Text warningText;
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
                DataManager.SaveData(PlayerInfo.name, ScoreManager.finalScore);
                isSaved = true;
            }

            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                GoToGameOverScene();
            }
        }
    }

    public void ShowWarning(float distance)
    {
        if (isGameOver)
        {
            return;
        }
        var text = $"! {Mathf.RoundToInt(distance)}m";
        warningText.text = text;
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