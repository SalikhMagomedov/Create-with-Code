using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float gravityModifier;
    public bool isOnGround = true;

    private Rigidbody _playerRb;

    private void Start()
    {
        _playerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space) || !isOnGround) return;

        _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        isOnGround = true;
    }
}