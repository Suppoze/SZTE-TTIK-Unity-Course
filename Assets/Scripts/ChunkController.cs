using UnityEngine;
using System.Collections;

public class ChunkController : MonoBehaviour {

    public float explodingLinearForce;
    public float explodingAngularForce;
    public float linearForceVariation;
    public float angularForceVariation;
    public float decay;
    public float fadingTime;
    public Sprite[] sprites;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D chunkRigidBody;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        chunkRigidBody = GetComponent<Rigidbody2D>();
    }
	
	public void RenderSprite(int spriteIndex) {
        spriteRenderer.sprite = sprites[spriteIndex];

        chunkRigidBody.AddRelativeForce(
            new Vector2(-1, 1) * Random.Range(
                explodingLinearForce - linearForceVariation, 
                explodingLinearForce + linearForceVariation), 
            ForceMode2D.Impulse);

        chunkRigidBody.AddTorque(
            Random.Range(
                -explodingAngularForce - angularForceVariation, 
                explodingAngularForce + angularForceVariation), 
            ForceMode2D.Impulse);

        Invoke("Fade", decay);
    }

    private void Fade() {
        animator.SetTrigger("Fade");
        gameObject.layer = LayerMask.NameToLayer("Background");
        Invoke("Despawn", fadingTime);
    }

    private void Despawn() {
        gameObject.SetActive(false);
    }

}
