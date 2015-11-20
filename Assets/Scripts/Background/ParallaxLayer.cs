using UnityEngine;
using System.Collections;

public class ParallaxLayer : MonoBehaviour {

    public float parallaxFactor;

    public void Move(Vector2 delta) {
        Vector2 newPosition = transform.localPosition;
        newPosition -= delta * parallaxFactor;
        transform.localPosition = newPosition;
    }
}
