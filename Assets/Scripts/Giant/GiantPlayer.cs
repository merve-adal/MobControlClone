using UnityEngine;

public class GiantPlayer : MonoBehaviour
{
    [SerializeField] private int _giantHp => SettingsManager.GameSettings.giantHp;
    [SerializeField]private int giantHp;
    private Vector3 firstScale;

    private void Awake()
    {
        giantHp = _giantHp;
        firstScale = gameObject.transform.localScale;
    }

    private void ScaleChanger()
    {
        var localScale = gameObject.transform.localScale;
        localScale.x -= 0.2f;
        localScale.y -= 0.2f;
        localScale.z -= 0.2f;
        gameObject.transform.localScale = localScale;
    }

    private void DecreaseGiantHp(int count)
    {
        for (int i = 0; i < count; i++)
        {
            giantHp--;
            ScaleChanger();
            if (giantHp <= 0)
            {
                gameObject.SetActive(false);
                giantHp = _giantHp;
                gameObject.transform.localScale = firstScale;
                break;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DecreaseGiantHp(1);
        }
        else if (collision.gameObject.CompareTag("Tower"))
        {
            GameManager.Instance.PlayerGiantHitTower(giantHp);
            gameObject.transform.localScale = firstScale;
            giantHp = _giantHp;
        }
        else if (collision.gameObject.CompareTag("GiantEnemy"))
        {
            GameManager.Instance.SetPlayerGiantHitEnemyGiant(giantHp);
            var currentEnemyGiantHp = GameManager.Instance.GetEnemyGiantHp();
            DecreaseGiantHp(currentEnemyGiantHp);
        }
    }
}