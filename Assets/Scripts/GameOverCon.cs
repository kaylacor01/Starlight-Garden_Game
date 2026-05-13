using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCon : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("Level1");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
