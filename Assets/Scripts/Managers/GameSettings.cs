using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Game Settings")]
public class GameSettings : ScriptableObject
{
    //----------------- Player -------------
    public float spawnIntervalForPlayer = 0.5f;
    public float playerSpeedChangeTime = 0.5f;
    public float playerSingleStepSpeedAtTowerArea = 1f;

    //----------------- Enemy -------------
    public float spawnIntervalForEnemy = 5f;
    public float enemySpeed = 6f;
    public int enemyCount = 20;

    //----------------- Giant -------------
    public int numberOfPlayerThrownForSpawnGiant = 20;
    public int giantHp = 5;

    //----------------- Tower -------------
    public int towerPointSetting = 50;
    
    //----------------- Cannon -------------
    public float sideMovementSensitivity = 20f;
    public float sideMovementLerpSpeed = 5f;
}