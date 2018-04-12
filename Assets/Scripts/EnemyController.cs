using System;
using Assets.Scripts.Achievements;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public SpikeAudioClips AudioClips;
    public GameObject DeathParticleEmitter;
    public ChunkController EnemyChunk;
    public float Health;

    private Animator _animator;
    private AudioSource _audioSource;
    private PolygonCollider2D _enemyCollider;
    private Rigidbody2D _enemyRigidbody;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _enemyRigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _enemyCollider = GetComponent<PolygonCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Damaging"))
            Hurt(collision.gameObject.GetComponent<Damager>());
    }

    public void Hurt(Damager damager)
    {
        Health -= damager.Damage;

        if (Health > 0f)
        {
            _animator.SetTrigger("Hurt");
            _audioSource.PlayOneShot(AudioClips.Hurtclip);
        }
        else
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
        PlayClipAt(AudioClips.DeadClip, (Vector2) transform.position, _audioSource.volume);
        Instantiate(DeathParticleEmitter, transform.position, transform.rotation);

        AchievementManager.Instance.AddKill();

        for (var i = 0; i < EnemyChunk.Sprites.Length; i++)
        {
            var chunk = Instantiate(EnemyChunk, transform.position, Quaternion.identity);
            chunk.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -(i * 90f)));
            chunk.RenderSprite(i);
        }
    }

    private void PlayClipAt(AudioClip clip, Vector3 pos, float volume)
    {
        var tempGo = new GameObject("TempAudio");
        tempGo.transform.position = pos;
        var aSource = tempGo.AddComponent<AudioSource>();
        aSource.clip = clip;
        aSource.volume = volume;
        aSource.Play();
        Destroy(tempGo, clip.length);
    }

    [Serializable]
    public class SpikeAudioClips
    {
        public AudioClip DeadClip;
        public AudioClip Hurtclip;
    }
}