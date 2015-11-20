using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public static CameraController instance;

    public float fov = 0.5f;

    public Transform crosshair;
    public Transform player;

    private float shakeDuration;
    private float shakeAmount;
    private float shakeDecreaseFactor;

    private Vector3 originalPos;

    void Awake() {
        instance = this;
    }

    void OnEnable() {
        originalPos = transform.position;
    }

    private void Update() {
        transform.position = addShake(calculateCenterWithFov());
    }

    private Vector3 calculateCenterWithFov() {
        return new Vector3(
                    (fov * player.position.x + (1 - fov) * crosshair.position.x),
                    (fov * player.position.y + (1 - fov) * crosshair.position.y),
                    transform.position.z);
    }

    private Vector3 addShake(Vector3 centeredPosition) {
        if (shakeDuration > 0f) {
            shakeDuration -= Time.deltaTime * shakeDecreaseFactor;
            return centeredPosition + Random.insideUnitSphere * shakeAmount;
        } else {
            shakeDuration = 0f;
            return centeredPosition;
        }
    }

    public void shake(float shakeDuration = .1f, float shakeAmount = .1f, float shakeDecreaseFactor = 1f) {
        this.shakeDuration = shakeDuration;
        this.shakeAmount = shakeAmount;
        this.shakeDecreaseFactor = shakeDecreaseFactor;

        originalPos = transform.position;
    }
}
