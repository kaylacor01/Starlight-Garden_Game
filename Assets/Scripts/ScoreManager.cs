using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour{
  public static ScoreManager instance;
  public TextMeshProUGUI scoreText;
  private int score = 0;

  void Awake(){
    if(instance == null)
      instance this;
    else 
      Destroy(gameObject);
  }

  void Start(){
    UpdateScore();
  }

  public void AddPoint(int amount){
    score += amount;
    UpdateScore();
  }

  void UpdateScore(){
    scoreText.text = "Score: " + score;
  }
}
