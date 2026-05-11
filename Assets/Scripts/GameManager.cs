using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public enum GameState { MainMenu, Playing, Paused, GameOver }

    public GameState CurrentState { get; private set; }

    public static event Action<GameState> OnGameStateChanged;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
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
            SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayerDeath.OnPlayerDied -= HandlePlayerDied;
        PlayerDeath.OnPlayerDied += HandlePlayerDied;
        
        if (scene.name == "MainMenu")
            SetState(GameState.MainMenu);
        else if (scene.name == "Level1")
            SetState(GameState.Playing);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (CurrentState == GameState.Playing) PauseGame();
            else if (CurrentState == GameState.Paused) ResumeGame();
        }
    }

    void HandlePlayerDied()
    {
        Debug.Log("GameManager received PlayerDied -> switching to GameOver");
        SetState(GameState.GameOver);
    }

    public void SetState(GameState newState)
    {
        CurrentState = newState;

        Time.timeScale = (newState == GameState.Paused || newState == GameState.GameOver) ? 0f : 1f;

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
        SceneManager.LoadScene("Game");
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }
}