using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed => SettingsManager.GameSettings.enemySpeed;

    private void Update()
    {
        GoForward();
    }

    private void GoForward()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            transform.position = Vector3.zero;

            collision.gameObject.SetActive(false);
            collision.gameObject.transform.position = Vector3.zero;
            GameManager.Instance.increaseScore();
        }
        else if (collision.gameObject.CompareTag("GiantPlayer"))
        {
            gameObject.SetActive(false);
            transform.position = Vector3.zero;
            GameManager.Instance.increaseScore();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerRusher"))
        {
            GameManager.Instance.GameOver();
        }
    }
}