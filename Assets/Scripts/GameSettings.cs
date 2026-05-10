using UnityEngine;

public class GameSettings
{
    public static float PlayerSpeed = 5f;
    public static float EnemySpeed = 3f;
    private const string PlayerSpeedKey = "PlayerSpeed";
    private const string EnemySpeedKey = "EnemySpeed";

    public static void Load()
    {
        PlayerSpeed = PlayerPrefs.GetFloat(PlayerSpeedKey, PlayerSpeed);
        EnemySpeed = PlayerPrefs.GetFloat(EnemySpeedKey, EnemySpeed);
    }

    public static void Save()
    {
        PlayerPrefs.SetFloat(PlayerSpeedKey, PlayerSpeed);
        PlayerPrefs.SetFloat(EnemySpeedKey, EnemySpeed);
        PlayerPrefs.Save();
    }
}