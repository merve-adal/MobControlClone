using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoSingleton<GameManager>
{
    private int playerGiantHpForTower;
    private int playerGiantHpForEnemyGiant;
    private int enemyGiantHp;
    private int numberOfPlayerThrownForSpawnGiant => SettingsManager.GameSettings.numberOfPlayerThrownForSpawnGiant;
    [SerializeField] private Vector3 towerDestination;
    public event Action<float> OnProgressChange;
    [SerializeField] private int currentLevel;
    [SerializeField] private int nextLevel;

    private int score;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        score = 0;
        LoadLevel(1);
    }

    private void LoadLevel(int index)
    {
        currentLevel = index;
        Camera camera = Camera.main;
        if (camera != null)
        {
            camera.cullingMask = 0;
        }

        Invoke(nameof(LoadScene), 1f);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(currentLevel);
    }

    private void AllScore()
    {
        PlayerPrefs.SetInt("Score", score);
    }

    public void increaseScore()
    {
        score += 5;
        AllScore();
    }

    public int DecreaseTowerPoint(string tag, int hit, int towerPoint)
    {
        if (tag.Equals("Player"))
        {
            towerPoint -= hit;
        }
        else if (tag.Equals("GiantPlayer"))
        {
            towerPoint -= playerGiantHpForTower;
        }

        return towerPoint;
    }

    public void SetTowerDestination(Vector3 playerDestination)
    {
        towerDestination = playerDestination;
    }

    public Vector3 GetTowerDestination()
    {
        return towerDestination;
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");
        LoadLevel(currentLevel);
    }

    public void Won()
    {
        nextLevel = currentLevel + 1;
        if (nextLevel < SceneManager.sceneCountInBuildSettings)
        {
            LoadLevel(nextLevel);
        }
        else
        {
            LoadLevel(1);
        }
    }

    public void SpawnRequest(string tag, Vector3 pos, Quaternion rot, int count)
    {
        SpawnManager.Instance.SpawnPeople(tag, pos, rot, count);
    }

    public void SetCurrentThrownPctOnBar(float numberOfPlayerThrown)
    {
        float currentThrownPct = numberOfPlayerThrown / numberOfPlayerThrownForSpawnGiant;
        OnProgressChange?.Invoke(currentThrownPct);
    }

    public void PlayerGiantHitTower(int giantHp)
    {
        this.playerGiantHpForTower = giantHp;
    }

    public void SetPlayerGiantHitEnemyGiant(int giantHp)
    {
        this.playerGiantHpForEnemyGiant = giantHp;
    }

    public int GetPlayerGiantHp()
    {
        return this.playerGiantHpForEnemyGiant;
    }

    public void SetEnemyGiantHitPlayerGiant(int giantHp)
    {
        this.enemyGiantHp = giantHp;
    }

    public int GetEnemyGiantHp()
    {
        return this.enemyGiantHp;
    }

}