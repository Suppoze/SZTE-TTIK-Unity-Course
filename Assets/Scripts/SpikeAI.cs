using UnityEngine;

public class SpikeAI : MonoBehaviour
{
    public float SearchInterval;

    private Mover _mover;
    private Rigidbody2D _myRigidbody;
    private Transform _player;

    private void Awake()
    {
        _myRigidbody = GetComponent<Rigidbody2D>();
        _mover = GetComponent<Mover>();
    }

    private void Start()
    {
        InvokeRepeating("FindPlayer", SearchInterval, SearchInterval);
    }

    private void FixedUpdate()
    {
        if (_player == null) return;

        Vector2 playerDirection = _player.position - transform.position;
        _mover.Move(playerDirection);
    }

    private void FindPlayer()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (_player != null) CancelInvoke("FindPlayer");
    }
}