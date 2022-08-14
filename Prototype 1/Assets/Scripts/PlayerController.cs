using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject frontCamera;
    public GameObject backCamera;
    [Range(1, 2)] public int playerId = 1;
    public KeyCode cameraTypeKey = KeyCode.F;
    
    [SerializeField] private float speed = 20f;
    [SerializeField] private float turnSpeed = 25f;
    
    [SerializeField] private float horizontalInput;
    [SerializeField] private float forwardInput;

    [SerializeField] private string horizontal;
    [SerializeField] private string vertical;

    private void Start()
    {
        horizontal = $"Horizontal{playerId}";
        vertical = $"Vertical{playerId}";
    }

    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis(horizontal);
        forwardInput = Input.GetAxis(vertical);

        if (Input.GetKeyDown(cameraTypeKey))
        {
            backCamera.SetActive(!backCamera.activeSelf);
            frontCamera.SetActive(!frontCamera.activeSelf);
        }
        
        // Move the vehicle forward
        transform.Translate(Vector3.forward * (Time.deltaTime * speed * forwardInput));
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
