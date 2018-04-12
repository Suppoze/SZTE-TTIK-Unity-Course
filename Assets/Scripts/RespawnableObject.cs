using UnityEngine;

public class RespawnableObject : MonoBehaviour
{
    public Transform RespawnPoint;
    public float RespawnDelay;

    public void Respawn()
    {
        gameObject.SetActive(false);
        Invoke("Reactivate", RespawnDelay);
    }

    private void Reactivate()
    {
        gameObject.transform.position = RespawnPoint.position;
        gameObject.SetActive(true);
    }
}