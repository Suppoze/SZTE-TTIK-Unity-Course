using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour {

    [Serializable]
    public class PlayerAudioClips {
        public AudioClip spawnClip;
        public AudioClip hurtClip;
        public AudioClip deadClip;
    }

    public float maxSpeed;
    public float health;
    public float invincibilityTime;

    public GameController gameController;
    public PlayerAudioClips audioClips;

    private AudioSource audioSource;
    private Rigidbody2D myRigidBody;
    private Mover mover;

    private float currentHealth;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
        myRigidBody = GetComponent<Rigidbody2D>();
        mover = GetComponent<Mover>();
    }

    private void OnEnable() {
        currentHealth = health;
    }

    private void Start() {
        audioSource.PlayOneShot(audioClips.spawnClip);
    }

    private void FixedUpdate() {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector2 movementDirection = new Vector2(moveHorizontal, moveVertical);
        mover.Move(movementDirection);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        GameObject other = collision.gameObject;
        if (other.layer == LayerMask.NameToLayer("Enemy")) {
            float damage = other.GetComponent<Damager>().damage;
            OnEnemyCollision(damage);
        }
    }

    private void OnEnemyCollision(float damage) {
        currentHealth -= damage;
        if (currentHealth > 0f) {
            Hurt();
        } else {
            Die();
        }
    }

    private void Hurt() {
        CameraController.instance.shake(0.2f, 0.2f, 1f);
        audioSource.PlayOneShot(audioClips.hurtClip);
        gameController.OnPlayerHurt();
    }

    private void Die() {
        CameraController.instance.shake(0.3f, 0.3f, 1f);
        AudioSource.PlayClipAtPoint(audioClips.deadClip, transform.position, audioSource.volume);
        AchievementManager.instance.AddDeath();
        gameController.OnPlayerDead();
    }
}
