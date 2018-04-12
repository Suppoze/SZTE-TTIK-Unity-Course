using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;
    public Transform Crosshair;
    public Transform Player;
    public float Fov = 0.5f;

    private Vector3 _originalPos;
    private float _shakeAmount;
    private float _shakeDecreaseFactor;
    private float _shakeDuration;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        _originalPos = transform.position;
    }

    private void Update()
    {
        transform.position = AddShake(CalculateCenterWithFov());
    }

    private Vector3 CalculateCenterWithFov()
    {
        return new Vector3(
            Fov * Player.position.x + (1 - Fov) * Crosshair.position.x,
            Fov * Player.position.y + (1 - Fov) * Crosshair.position.y,
            transform.position.z);
    }

    private Vector3 AddShake(Vector3 centeredPosition)
    {
        if (_shakeDuration > 0f)
        {
            _shakeDuration -= Time.deltaTime * _shakeDecreaseFactor;
            return centeredPosition + Random.insideUnitSphere * _shakeAmount;
        }
        _shakeDuration = 0f;
        return centeredPosition;
    }

    public void Shake(float shakeDuration = .1f, float shakeAmount = .1f, float shakeDecreaseFactor = 1f)
    {
        this._shakeDuration = shakeDuration;
        this._shakeAmount = shakeAmount;
        this._shakeDecreaseFactor = shakeDecreaseFactor;

        _originalPos = transform.position;
    }
}