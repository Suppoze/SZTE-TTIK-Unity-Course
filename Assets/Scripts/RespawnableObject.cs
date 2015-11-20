using UnityEngine;
using System.Collections;

public class RespawnableObject : MonoBehaviour {

    public Transform respawnPoint;
    public float respawnDelay;

    public void Respawn() {
        gameObject.SetActive(false);
        Invoke("Reactivate", respawnDelay);
    }

    private void Reactivate() {
        gameObject.transform.position = respawnPoint.position;
        gameObject.SetActive(true);
    }
}
