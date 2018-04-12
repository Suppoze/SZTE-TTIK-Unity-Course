using UnityEngine;

public class ChunkController : MonoBehaviour
{
    public Sprite[] Sprites;
    public float AngularForceVariation;
    public float Decay;
    public float ExplodingAngularForce;
    public float ExplodingLinearForce;
    public float FadingTime;
    public float LinearForceVariation;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Rigidbody2D _chunkRigidBody;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _chunkRigidBody = GetComponent<Rigidbody2D>();
    }

    public void RenderSprite(int spriteIndex)
    {
        _spriteRenderer.sprite = Sprites[spriteIndex];

        _chunkRigidBody.AddRelativeForce(
            new Vector2(-1, 1) * Random.Range(
                ExplodingLinearForce - LinearForceVariation,
                ExplodingLinearForce + LinearForceVariation),
            ForceMode2D.Impulse);

        _chunkRigidBody.AddTorque(
            Random.Range(
                -ExplodingAngularForce - AngularForceVariation,
                ExplodingAngularForce + AngularForceVariation),
            ForceMode2D.Impulse);

        Invoke("Fade", Decay);
    }

    private void Fade()
    {
        _animator.SetTrigger("Fade");
        gameObject.layer = LayerMask.NameToLayer("Background");
        Invoke("Despawn", FadingTime);
    }

    private void Despawn()
    {
        gameObject.SetActive(false);
    }
}