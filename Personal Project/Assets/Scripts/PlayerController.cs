using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;

    [SerializeField] private float speed = 10.0f;
    private const float ZBound = 6.0f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ConstrainPlayerPosition();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        var input = new Vector3(horizontalInput, 0, verticalInput);
        var direction = input.normalized;

        _rb.AddForce(direction * (input.magnitude * speed));
    }

    private void ConstrainPlayerPosition()
    {
        var position = transform.position;
        position = new Vector3(position.x, position.y, Mathf.Clamp(position.z, -ZBound, ZBound));
        transform.position = position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player collided with enemy");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
        }
    }
}