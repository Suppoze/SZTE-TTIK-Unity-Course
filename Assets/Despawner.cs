using UnityEngine;
using System.Collections;

public class Despawner : MonoBehaviour {

    public float despawnDelay;

    void Start() {
        Destroy(gameObject, despawnDelay);
    }

}
