using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreboardManager : MonoBehaviour
{
    public void ExitScoreboard()
    {
        SceneManager.LoadScene(sceneName: "Menu");
    }
}
