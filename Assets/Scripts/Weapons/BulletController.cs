using UnityEngine;
using System.Collections;
using System;

public class BulletController : MonoBehaviour {

    public float speed;

    private Rigidbody2D bullet;

    private void Awake() {
        bullet = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) { 
        gameObject.SetActive(false);
    }

	public void OnEnable() {
        bullet.velocity = transform.up * speed;
    }
}
