using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float Speed;

    private Rigidbody2D _bullet;

    private void Awake()
    {
        _bullet = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }

    public void OnEnable()
    {
        _bullet.velocity = transform.up * Speed;
    }
}