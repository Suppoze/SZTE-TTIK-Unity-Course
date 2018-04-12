using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    public float ParallaxFactor;

    public void Move(Vector2 delta)
    {
        Vector2 newPosition = transform.localPosition;
        newPosition -= delta * ParallaxFactor;
        transform.localPosition = newPosition;
    }
}