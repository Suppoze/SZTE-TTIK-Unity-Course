using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    public float maxSpeed;
    public float acceleration;

    private Rigidbody2D myRigidBody;

    private Vector2 direction;
    private bool moving;

    private void Awake() {
        myRigidBody = GetComponent<Rigidbody2D>();
    }
	
	private void FixedUpdate () {
	    if (moving) {
            Vector2 requiredAcceleration = direction.normalized * GetRequiredAcceleraton(maxSpeed, myRigidBody.drag);
            myRigidBody.AddRelativeForce(requiredAcceleration * myRigidBody.mass);

            moving = false;
        }
	}

    public void Move(Vector2 direction) {
        this.direction = direction;
        moving = true;
    }

    private float GetRequiredAcceleraton(float aFinalSpeed, float aDrag) {
        return GetRequiredVelocityChange(aFinalSpeed, aDrag) / Time.fixedDeltaTime;
    }

    private float GetRequiredVelocityChange(float aFinalSpeed, float aDrag) {
        float m = Mathf.Clamp01(aDrag * Time.fixedDeltaTime);
        return aFinalSpeed * m / (1 - m);
    }

    float GetDrag(float aVelocityChange, float aFinalVelocity) {
        return aVelocityChange / ((aFinalVelocity + aVelocityChange) * Time.fixedDeltaTime);
    }
    float GetDragFromAcceleration(float aAcceleration, float aFinalVelocity) {
        return GetDrag(aAcceleration * Time.fixedDeltaTime, aFinalVelocity);
    }
}
