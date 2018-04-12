using UnityEngine;

public class BulletFireScript : MonoBehaviour
{
    public float SecondsBetweenFiring = .1f;

    private ObjectPooler _bulletPooler;
    private bool _isFiring;
    private float _secondsSinceLastFired;

    private void Awake()
    {
        _bulletPooler = GetComponent<ObjectPooler>();
    }

    private void Update()
    {
        if (_isFiring && _secondsSinceLastFired >= SecondsBetweenFiring)
        {
            var angle = AngleBetweenTwoPoints(transform.position, Crosshair.Instance.transform.position);
            Fire(Quaternion.Euler(new Vector3(0f, 0f, angle + 90f)));

            CameraController.Instance.Shake();

            _secondsSinceLastFired = 0f;
        }
        else
        {
            _secondsSinceLastFired += Time.deltaTime;
        }
    }

    private static float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    private void Fire(Quaternion rotation)
    {
        var bullet = _bulletPooler.GetPooledObject();

        if (bullet == null) return;

        bullet.transform.position = transform.position;
        bullet.transform.rotation = rotation;
        bullet.SetActive(true);
    }

    public void SetFiring(bool isFiring)
    {
        this._isFiring = isFiring;
    }
}