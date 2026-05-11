using UnityEngine;

public class PauseMenu : MonoBehaviour{
  public GameObject PausePanel;

  void Awake(){
    if(PausePanel != null){
      PausePanel.SetActive(false);
    }
  }

  void OnEnable(){
    GameManager.OnGameStateChanged += HandleGameStateChanged;
  }

  void OnDisable(){
    GameManager.OnGameStateChanged -= HandleGameStateChanged;
  }

  void HandleGameStateChanged(GameManager.GameState state){
    if (PausePanel != null)
      PausePanel.SetActive(state == GameManager.GameState.Paused);
  }

  public void Resume(){
    GameManager.Instance.ResumeGame();
  }

  public void GoToMainMenu(){
    GameManager.Instance.GoToMainMenu();
  }
}
