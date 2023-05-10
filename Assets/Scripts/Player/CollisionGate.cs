using UnityEngine;

public class CollisionGate : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("2xGate"))
        {
            gameObject.SetActive(false);
            GameManager.Instance.SpawnRequest(gameObject.tag, transform.position, transform.rotation, 2);
            gameObject.transform.position=Vector3.zero;
        }
        else if (other.gameObject.CompareTag("3xGate"))
        {
            gameObject.SetActive(false);
            GameManager.Instance.SpawnRequest(gameObject.tag, transform.position, transform.rotation, 3);
            gameObject.transform.position=Vector3.zero;
        }
        else if (other.gameObject.CompareTag("4xGate"))
        {
            gameObject.SetActive(false);
            GameManager.Instance.SpawnRequest(gameObject.tag, transform.position, transform.rotation, 4);
            gameObject.transform.position=Vector3.zero;
        }
        else if (other.gameObject.CompareTag("DeadZone"))
        {
            gameObject.SetActive(false);
            transform.position = Vector3.zero;
            
        }
    }
}