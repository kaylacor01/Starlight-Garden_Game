using UnityEngine;

public class PauseMenu : MonoBehaviour{
  public GameObject PausePanel;
  public GameObject CongratPanel;

  void Awake(){
    if(PausePanel != null)
    {
      PausePanel.SetActive(false);
    }

    if (CongratPanel != null)
    {
      CongratPanel.SetActive(false);
    }
  }

  void OnEnable(){
    GameManager.OnGameStateChanged += HandleGameStateChanged;
    ScoreManager.OnAllCollected += HandleAllCollected;
  }

  void OnDisable(){
    GameManager.OnGameStateChanged -= HandleGameStateChanged;
    ScoreManager.OnAllCollected += HandleAllCollected;
  }

  void HandleGameStateChanged(GameManager.GameState state){
    if (PausePanel != null)
    {
      PausePanel.SetActive(state == GameManager.GameState.Paused);
    }

    if (CongratPanel != null)
    {
      CongratPanel.SetActive(state == GameManager.GameState.Win);
    }
  }

  void HandleAllCollected(){
    CongratPanel.SetActive(true);
    GameManager.Instance.PauseGame();
  }

  public void Resume(){
    GameManager.Instance.ResumeGame();
  }

  public void GoToMainMenu(){
    GameManager.Instance.GoToMainMenu();
  }
}