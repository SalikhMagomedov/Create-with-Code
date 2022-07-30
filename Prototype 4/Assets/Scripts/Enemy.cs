using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;

    private Rigidbody _rb;
    private GameObject _player;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _player = GameObject.Find("Player");
    }

    private void Update()
    {
        var lookDirection = (_player.transform.position - transform.position).normalized;
        _rb.AddForce(lookDirection * speed);
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}