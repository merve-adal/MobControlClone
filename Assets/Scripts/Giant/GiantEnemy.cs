using System;
using UnityEngine;

public class GiantEnemy : MonoBehaviour
{
    private float speed => SettingsManager.GameSettings.enemySpeed;
    [SerializeField] private int _giantHp => SettingsManager.GameSettings.giantHp;
    [SerializeField] private int giantHp;
    private Vector3 firstScale;

    private void Awake()
    {
        giantHp = _giantHp;
        firstScale = gameObject.transform.localScale;
    }

    private void Update()
    {
        GoForward();
    }

    private void ScaleChanger()
    {
        var localScale = gameObject.transform.localScale;
        localScale.x -= 0.2f;
        localScale.y -= 0.2f;
        localScale.z -= 0.2f;
        gameObject.transform.localScale = localScale;
    }

    private void GoForward()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
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
        if (collision.gameObject.CompareTag("Player"))
        {
            DecreaseGiantHp(1);
            collision.gameObject.SetActive(false);
            collision.gameObject.transform.position = Vector3.zero;
            GameManager.Instance.increaseScore();
        }
        else if (collision.gameObject.CompareTag("GiantPlayer"))
        {
            GameManager.Instance.SetEnemyGiantHitPlayerGiant(giantHp);
            var currentPlayerGiantHp = GameManager.Instance.GetPlayerGiantHp();
            DecreaseGiantHp(currentPlayerGiantHp);
            GameManager.Instance.increaseScore();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerRusher"))
        {
            GameManager.Instance.GameOver();
            gameObject.transform.localScale = firstScale;
            giantHp = _giantHp;
        }
    }
}