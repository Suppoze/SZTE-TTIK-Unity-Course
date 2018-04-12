using System;
using Assets.Scripts.Achievements;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerAudioClips AudioClips;
    public GameController GameController;
    public float Health;
    public float InvincibilityTime;
    public float MaxSpeed;

    private AudioSource _audioSource;
    private Mover _mover;
    private Rigidbody2D _myRigidBody;
    private float _currentHealth;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _myRigidBody = GetComponent<Rigidbody2D>();
        _mover = GetComponent<Mover>();
    }

    private void OnEnable()
    {
        _currentHealth = Health;
    }

    private void Start()
    {
        _audioSource.PlayOneShot(AudioClips.spawnClip);
    }

    private void FixedUpdate()
    {
        var moveHorizontal = Input.GetAxisRaw("Horizontal");
        var moveVertical = Input.GetAxisRaw("Vertical");
        var movementDirection = new Vector2(moveHorizontal, moveVertical);
        _mover.Move(movementDirection);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var other = collision.gameObject;
        if (other.layer == LayerMask.NameToLayer("Enemy"))
        {
            var damage = other.GetComponent<Damager>().Damage;
            OnEnemyCollision(damage);
        }
    }

    private void OnEnemyCollision(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth > 0f) Hurt();
        else Die();
    }

    private void Hurt()
    {
        CameraController.Instance.Shake(0.2f, 0.2f, 1f);
        _audioSource.PlayOneShot(AudioClips.hurtClip);
        GameController.OnPlayerHurt();
    }

    private void Die()
    {
        CameraController.Instance.Shake(0.3f, 0.3f, 1f);
        AudioSource.PlayClipAtPoint(AudioClips.deadClip, transform.position, _audioSource.volume);
        AchievementManager.Instance.AddDeath();
        GameController.OnPlayerDead();
    }

    [Serializable]
    public class PlayerAudioClips
    {
        public AudioClip deadClip;
        public AudioClip hurtClip;
        public AudioClip spawnClip;
    }
}