using UnityEngine;
using System.Collections;
using System;

public class SpikeAI : MonoBehaviour {

    public float searchInterval;

    private Transform player;
    private Rigidbody2D myRigidbody;
    private Mover mover;

    private void Awake() {
        myRigidbody = GetComponent<Rigidbody2D>();
        mover = GetComponent<Mover>();
    }

    private void Start() {
        InvokeRepeating("FindPlayer", searchInterval, searchInterval);
    }

	void FixedUpdate () {
        if (player != null) {
            Vector2 playerDirection = player.position - transform.position;
            mover.Move(playerDirection);
        }
    }

    private void FindPlayer() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (player != null) {
            CancelInvoke("FindPlayer");
        }
    }
	
}
