using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject frontCamera;
    public GameObject backCamera;
    [Range(1, 2)] public int playerId = 1;
    public KeyCode cameraTypeKey = KeyCode.F;
    
    private const float Speed = 20f;
    private const float TurnSpeed = 25f;
    
    private float _horizontalInput;
    private float _forwardInput;

    private string _horizontal;
    private string _vertical;

    private void Start()
    {
        _horizontal = $"Horizontal{playerId}";
        _vertical = $"Vertical{playerId}";
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxis(_horizontal);
        _forwardInput = Input.GetAxis(_vertical);

        if (Input.GetKeyDown(cameraTypeKey))
        {
            backCamera.SetActive(!backCamera.activeSelf);
            frontCamera.SetActive(!frontCamera.activeSelf);
        }
        
        // Move the vehicle forward
        transform.Translate(Vector3.forward * (Time.deltaTime * Speed * _forwardInput));
        transform.Rotate(Vector3.up, Time.deltaTime * TurnSpeed * _horizontalInput);
    }
}
