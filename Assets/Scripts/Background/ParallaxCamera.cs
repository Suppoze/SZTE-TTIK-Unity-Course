using UnityEngine;

public class ParallaxCamera : MonoBehaviour
{
    public delegate void ParallaxCameraDelegate(Vector2 deltaMovement);

    public ParallaxCameraDelegate OnCameraTranslate;

    private Vector2 _oldPosition;

    private void Start()
    {
        _oldPosition = transform.position;
    }

    private void Update()
    {
        if ((Vector2) transform.position != _oldPosition)
        {
            if (OnCameraTranslate != null)
            {
                var delta = _oldPosition - (Vector2) transform.position;
                OnCameraTranslate(delta);
            }
            _oldPosition = transform.position;
        }
    }
}