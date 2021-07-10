using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float Speed = 20f;
    private const float TurnSpeed = 25f;
    
    private float _horizontalInput;
    private float _forwardInput;

    private void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _forwardInput = Input.GetAxis("Vertical");
        
        // Move the vehicle forward
        transform.Translate(Vector3.forward * (Time.deltaTime * Speed * _forwardInput));
        transform.Rotate(Vector3.up, Time.deltaTime * TurnSpeed * _horizontalInput);
    }
}
