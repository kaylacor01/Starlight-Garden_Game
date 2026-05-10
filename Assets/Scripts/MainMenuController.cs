using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    void Start()
    {
        GameSettings.Load();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void OpenGallery()
    {
        SceneManager.LoadScene("Gallery");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
