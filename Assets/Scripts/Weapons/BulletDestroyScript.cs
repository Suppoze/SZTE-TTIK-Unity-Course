using UnityEngine;
using System.Collections;

public class BulletDestroyScript : MonoBehaviour {

    public float lifeSpanInSeconds;

    private void OnEnable() {
        Invoke("Destroy", lifeSpanInSeconds);
    }

    private void Destroy() {
        gameObject.SetActive(false);
    }

    private void OnDisable() {
        CancelInvoke();
    }
}
