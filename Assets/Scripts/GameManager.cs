using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public enum GameState { MainMenu, Playing, Paused, GameOver, Win}

    public GameState CurrentState { get; private set; }

    public static event Action<GameState> OnGameStateChanged;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            PlayerDeath.OnPlayerDied += HandlePlayerDied;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        if (Instance == this)
        {
            PlayerDeath.OnPlayerDied -= HandlePlayerDied;
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu")
            SetState(GameState.MainMenu);
        else if (scene.name == "Level1")
            SetState(GameState.Playing);
        else if (scene.name == "GameOver")
            SetState(GameState.GameOver);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Level1")
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (CurrentState == GameState.Playing) PauseGame();
            else if (CurrentState == GameState.Paused) ResumeGame();
        }
    }

    void HandlePlayerDied()
    {
        Debug.Log("Player Died -> loading to GameOver");
        SetState(GameState.GameOver);
        SceneManager.LoadScene("GameOver");
    }

    public void SetState(GameState newState)
    {
        CurrentState = newState;

        Time.timeScale = (newState == GameState.Paused) ? 0f : 1f;

        Debug.Log("State changed to: " + newState);

        OnGameStateChanged?.Invoke(newState);
    }

    public void PauseGame() => SetState(GameState.Paused);
    public void ResumeGame() => SetState(GameState.Playing);

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");
    }

    public void WinGame()
    {
        SetState(GameState.Win);
        Time.timeScale = 0f;
    }
}