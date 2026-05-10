using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SettingsController : MonoBehaviour
{
    public Slider PlayerSlider;
    public TextMeshProUGUI PlayerValueText;

    public Slider EnemySlider;
    public TextMeshProUGUI EnemyValueText;

    public float minSpeed = 1f;
    public float maxSpeed = 12f;

    void Start()
    {
        GameSettings.Load();

        PlayerSlider.minValue = minSpeed;
        PlayerSlider.maxValue = maxSpeed;
        PlayerSlider.value = GameSettings.PlayerSpeed;
        UpdatePlayerText(PlayerSlider.value);
        PlayerSlider.onValueChanged.AddListener(OnPlayerSpeedChanged);

        EnemySlider.minValue = minSpeed;
        EnemySlider.maxValue = maxSpeed;
        EnemySlider.value = GameSettings.EnemySpeed;
        UpdateEnemyText(EnemySlider.value);
        EnemySlider.onValueChanged.AddListener(OnEnemySpeedChanged);
    }

    public void OnPlayerSpeedChanged(float newSpeed)
    {
        GameSettings.PlayerSpeed = newSpeed;
        GameSettings.Save();
        UpdatePlayerText(newSpeed);
    }

    public void OnEnemySpeedChanged(float newSpeed)
    {
        GameSettings.EnemySpeed = newSpeed;
        GameSettings.Save();
        UpdateEnemyText(newSpeed);
    }

    void UpdatePlayerText(float value)
    {
        if (PlayerValueText != null)
            PlayerValueText.text = $"Princess Sakumi's Speed: {value:0.0}";
    }

    void UpdateEnemyText(float value)
    {
        if (EnemyValueText != null)
            EnemyValueText.text = $"Shadows' Speed: {value:0.0}";
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}