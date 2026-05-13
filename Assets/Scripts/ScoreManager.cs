using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour{
  public static ScoreManager instance;
  public TextMeshProUGUI starText;
  public TextMeshProUGUI sakuraText;

  public int starscore = 0;
  public int sakurascore = 0;

  public int starend = 10;
  public int sakuraend = 14;

  public static event Action OnAllCollected;

  void Awake(){
    if(instance == null)
      instance = this;
    else 
      Destroy(gameObject);
  }

  void Start(){
    UpdateUI();
  }

  public void AddStar(){
    starscore++;
    UpdateUI();
    CheckComplete();
  }

  public void AddSakura(){
    sakurascore++;
    UpdateUI();
    CheckComplete();
  }

  void UpdateUI(){
    starText.text = starscore + "/" + starend;
    sakuraText.text = sakurascore + "/" + sakuraend;
  }

  void CheckComplete(){
    if (starscore >= starend && sakurascore >= sakuraend){
      GameManager.Instance.WinGame();
    }
  }
}