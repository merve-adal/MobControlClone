using UnityEngine;

public class SettingsManager : MonoSingleton<SettingsManager>
{
    [SerializeField] private GameSettings settings;
    public static GameSettings GameSettings=> Instance.settings;
}
