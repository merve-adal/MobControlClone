using UnityEngine;

public class PlayerMovement : MonoBehaviour, IPooledObject
{
    private float speed = 3f;
    private float playerSpeedChangeTime => SettingsManager.GameSettings.playerSpeedChangeTime;
    private bool isPlayerCome = false;

    private void Update()
    {
        if (isPlayerCome)
        {
            OnObjectSpawn();
            isPlayerCome = false;
        }
        else
        {
            OnObjectSpawn();
        }
    }

    public void OnObjectSpawn()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    private void playerSpeedChanger()
    {
        speed = 3f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerRusher"))
        {
            isPlayerCome = true;
            speed = 5f;
            Invoke(nameof(playerSpeedChanger), playerSpeedChangeTime);
        }
    }
}