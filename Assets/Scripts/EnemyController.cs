using UnityEngine;
using System.Collections;
using System;

public class EnemyController : MonoBehaviour {

    [Serializable]
    public class SpikeAudioClips {
        public AudioClip hurtclip;
        public AudioClip deadClip;
    }

    public SpikeAudioClips audioClips;

    public GameObject deathParticleEmitter;
    public ChunkController enemyChunk;
    public float health;

    private Animator animator;
    private AudioSource audioSource;
    private Rigidbody2D enemyRigidbody;
    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D enemyCollider;

    private void Awake() {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyCollider = GetComponent<PolygonCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Damaging")) {
            Hurt(collision.gameObject.GetComponent<Damager>());
        }
    }

    public void Hurt(Damager damager) {
        health -= damager.damage;

        if (health > 0f) {
            animator.SetTrigger("Hurt");
            audioSource.PlayOneShot(audioClips.hurtclip);
        } else {
            Die();
        }
    }

    private void Die() {
        gameObject.SetActive(false);
        PlayClipAt(audioClips.deadClip, (Vector2) transform.position, audioSource.volume);
        Instantiate(deathParticleEmitter, transform.position, transform.rotation);

        AchievementManager.instance.AddKill();

        for (int i = 0; i < enemyChunk.sprites.Length; i++) {
            ChunkController chunk = (ChunkController) Instantiate(enemyChunk, transform.position, Quaternion.identity);
            chunk.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -(i * 90f)));
            chunk.RenderSprite(i);
        }
    }

    private void PlayClipAt(AudioClip clip, Vector3 pos, float volume) {
        GameObject tempGO = new GameObject("TempAudio");
        tempGO.transform.position = pos;
        AudioSource aSource = tempGO.AddComponent<AudioSource>();
        aSource.clip = clip;
        aSource.volume = volume;
        aSource.Play();
        Destroy(tempGO, clip.length);
    }
}
