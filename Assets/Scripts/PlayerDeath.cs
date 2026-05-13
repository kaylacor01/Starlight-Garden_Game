using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerDeath : MonoBehaviour
{
    public static event Action OnPlayerDied;
    public int maxhealth = 100;
    public int currenthealth;

    public Image fill;

    void Start()
    {
        currenthealth = maxhealth;
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        currenthealth -= damage;
        currenthealth = Mathf.Clamp(currenthealth, 0, maxhealth);
        UpdateHealthBar();

        if (currenthealth <= 0)
        {
            PlayerDeath.OnPlayerDied?.Invoke();
            Destroy(gameObject);
        }
    }

    void UpdateHealthBar()
    {
        float r = (float)currenthealth / maxhealth;
        fill.fillAmount = r;
    }
}