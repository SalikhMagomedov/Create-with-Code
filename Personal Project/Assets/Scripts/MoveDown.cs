using UnityEngine;

public class MoveDown : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;

    private Rigidbody _rb;
    private const float ZDestroy = -10.0f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (transform.position.z < ZDestroy)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        _rb.AddForce(Vector3.forward * -speed);
    }
}