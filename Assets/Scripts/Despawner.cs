using UnityEngine;

public class Despawner : MonoBehaviour
{
    public float DespawnDelay;

    private void Start()
    {
        Destroy(gameObject, DespawnDelay);
    }
}