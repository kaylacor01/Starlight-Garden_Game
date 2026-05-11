using UnityEngine;
using UnityEngine.SceneManagement;

public class GalleryController : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}