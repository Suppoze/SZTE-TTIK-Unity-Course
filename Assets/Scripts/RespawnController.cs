using UnityEngine;
using System.Collections;

public class RespawnController : MonoBehaviour {

    public RespawnableObject[] respawnableObjects;

    public void ResetGame() {
        foreach (RespawnableObject respawnableObject in respawnableObjects) {
            respawnableObject.Respawn();
        }
    }
}
