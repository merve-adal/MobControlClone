using UnityEngine;

public class DestinationTracker : MonoBehaviour
{
    [SerializeField] private Vector3 destination;
    [SerializeField] private bool isPlayerAtTowerArea = false;
    private float speed => SettingsManager.GameSettings.playerSingleStepSpeedAtTowerArea;

    private void Awake()
    {
        destination = GameManager.Instance.GetTowerDestination();
    }

    private void Update()
    {
        if (isPlayerAtTowerArea)
        {
            GoForDestination();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("TowerArea"))
        {
            isPlayerAtTowerArea = true;
        }
        else
        {
            isPlayerAtTowerArea = false;
        }
    }

    private void GoForDestination()
    {
        Vector3 destinationDirection = destination - transform.position;
        float singleStep = speed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, destinationDirection, singleStep, 0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}