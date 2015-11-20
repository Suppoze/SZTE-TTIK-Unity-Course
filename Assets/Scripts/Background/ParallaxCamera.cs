using UnityEngine;
using System.Collections;

public class ParallaxCamera : MonoBehaviour {

    public delegate void ParallaxCameraDelegate(Vector2 deltaMovement);
    public ParallaxCameraDelegate onCameraTranslate;

    private Vector2 oldPosition;

    void Start() {
        oldPosition = transform.position;
    }

    void Update() {
        if ((Vector2) transform.position != oldPosition) {
            if (onCameraTranslate != null) {
                Vector2 delta = oldPosition - (Vector2) transform.position;
                onCameraTranslate(delta);
            }
            oldPosition = transform.position;
        }
    }
}
