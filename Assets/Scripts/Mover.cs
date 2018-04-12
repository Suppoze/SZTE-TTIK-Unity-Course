using UnityEngine;

public class Mover : MonoBehaviour
{
    public float Acceleration;
    public float MaxSpeed;

    private Rigidbody2D _myRigidBody;
    private Vector2 _direction;
    private bool _moving;

    private void Awake()
    {
        _myRigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!_moving) return;

        var requiredAcceleration = _direction.normalized * GetRequiredAcceleraton(MaxSpeed, _myRigidBody.drag);
        _myRigidBody.AddRelativeForce(requiredAcceleration * _myRigidBody.mass);

        _moving = false;
    }

    public void Move(Vector2 direction)
    {
        this._direction = direction;
        _moving = true;
    }

    private static float GetRequiredAcceleraton(float aFinalSpeed, float aDrag)
    {
        return GetRequiredVelocityChange(aFinalSpeed, aDrag) / Time.fixedDeltaTime;
    }

    private static float GetRequiredVelocityChange(float aFinalSpeed, float aDrag)
    {
        var m = Mathf.Clamp01(aDrag * Time.fixedDeltaTime);
        return aFinalSpeed * m / (1 - m);
    }

    private static float GetDrag(float aVelocityChange, float aFinalVelocity)
    {
        return aVelocityChange / ((aFinalVelocity + aVelocityChange) * Time.fixedDeltaTime);
    }

    private float GetDragFromAcceleration(float aAcceleration, float aFinalVelocity)
    {
        return GetDrag(aAcceleration * Time.fixedDeltaTime, aFinalVelocity);
    }
}