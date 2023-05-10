using UnityEngine;

public class Tower : MonoBehaviour
{
    private int _towerPoint => SettingsManager.GameSettings.towerPointSetting;
    [SerializeField] private int towerPoint;
    private float spawnInterval => SettingsManager.GameSettings.spawnIntervalForEnemy;
    private int enemyCount => SettingsManager.GameSettings.enemyCount;

    private void Awake()
    {
        towerPoint = _towerPoint;
        InvokeRepeating(nameof(EnemySpawnRoutine), spawnInterval, spawnInterval);
        GameManager.Instance.SetTowerDestination(transform.position);
        TowerPointChanger.Instance.ChangeTowerPoint(towerPoint);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var collisionName = collision.gameObject.tag;

        if (collisionName.Equals("Player") || collisionName.Equals("GiantPlayer"))
        {
            collision.gameObject.SetActive(false);
            collision.gameObject.transform.position = Vector3.zero;
            GameManager.Instance.increaseScore();
            if (collisionName.Equals("Player"))
            {
                towerPoint = GameManager.Instance.DecreaseTowerPoint("Player", 1, towerPoint);
            }
            else if (collisionName.Equals("GiantPlayer"))
            {
                towerPoint = GameManager.Instance.DecreaseTowerPoint("GiantPlayer", 1, towerPoint);
            }

            TowerPointChanger.Instance.ChangeTowerPoint(towerPoint);

            if (towerPoint >= -5 && towerPoint==0 )
            {
                TowerDestroy();
            }
        }
    }

    private void EnemySpawnRoutine()
    {
        GameManager.Instance.SpawnRequest("Enemy", transform.position, new Quaternion(0f, 180f, 0f, 0f), enemyCount);
    }

    private void TowerDestroy()
    {
            GameManager.Instance.Won();
    }
}