using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;

    private const float Speed = 10.0f;
    private const float ZBound = 6.0f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();
    }

    private void MovePlayer()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        var input = new Vector3(horizontalInput, 0, verticalInput);
        var direction = input.normalized;

        _rb.AddForce(direction * (input.magnitude * Speed));
    }

    private void ConstrainPlayerPosition()
    {
        var position = transform.position;
        position = new Vector3(position.x, position.y, Math.Clamp(position.z, -ZBound, ZBound));
        transform.position = position;
    }
}