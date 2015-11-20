using UnityEngine;
using System.Collections;

public class BulletFireScript : MonoBehaviour {

    public float secondsBetweenFiring = .1f;

    private ObjectPooler bulletPooler;

    private bool isFiring;
    private float secondsSinceLastFired;

    private void Awake() {
        bulletPooler = GetComponent<ObjectPooler>();
    }

    private void Update() {
        if (isFiring && secondsSinceLastFired >= secondsBetweenFiring) {
            float angle = AngleBetweenTwoPoints(transform.position, Crosshair.instance.transform.position);
            Fire(Quaternion.Euler(new Vector3(0f, 0f, angle + 90f)));

            CameraController.instance.shake();

            secondsSinceLastFired = 0f;
        } else {
            secondsSinceLastFired += Time.deltaTime;
        }
    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    private void Fire(Quaternion rotation) {
        GameObject bullet = bulletPooler.GetPooledObject();
        
        if (bullet == null) {
            return;
        }

        bullet.transform.position = transform.position;
        bullet.transform.rotation = rotation;
        bullet.SetActive(true);
    }

    public void SetFiring(bool isFiring) {
        this.isFiring = isFiring;
    }
}
