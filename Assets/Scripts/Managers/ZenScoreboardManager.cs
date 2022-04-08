using UnityEngine;
using UnityEngine.SceneManagement;

public class ZenScoreboardManager : MonoBehaviour
{
    public void ExitScoreboard()
    {
        SceneManager.LoadScene(sceneName: "Menu");
    }
}
