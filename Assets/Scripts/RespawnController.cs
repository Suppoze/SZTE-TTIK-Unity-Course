using UnityEngine;

public class RespawnController : MonoBehaviour
{
    public RespawnableObject[] RespawnableObjects;

    public void ResetGame()
    {
        foreach (var respawnableObject in RespawnableObjects) respawnableObject.Respawn();
    }
}