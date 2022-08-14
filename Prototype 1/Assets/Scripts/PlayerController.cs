using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject frontCamera;
    public GameObject backCamera;
    [Range(1, 2)] public int playerId = 1;
    public KeyCode cameraTypeKey = KeyCode.F;
    
    [SerializeField] private float horsePower = 20f;
    [SerializeField] private float turnSpeed = 25f;
    
    [SerializeField] private float horizontalInput;
    [SerializeField] private float forwardInput;

    [SerializeField] private string horizontal;
    [SerializeField] private string vertical;
    [SerializeField] private GameObject centerOfMass;
    [SerializeField] private TextMeshProUGUI speedometerText;
    [SerializeField] private float speed;
    [SerializeField] private TextMeshProUGUI rpmText;
    [SerializeField] private float rpm;
    [SerializeField] private List<WheelCollider> allWheels;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        horizontal = $"Horizontal{playerId}";
        vertical = $"Vertical{playerId}";
        _rb.centerOfMass = centerOfMass.transform.position;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(cameraTypeKey)) return;
        
        backCamera.SetActive(!backCamera.activeSelf);
        frontCamera.SetActive(!frontCamera.activeSelf);
    }

    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis(horizontal);
        forwardInput = Input.GetAxis(vertical);

        if (!IsOnGround()) return;
        
        // Move the vehicle forward
        _rb.AddRelativeForce(Vector3.forward * (horsePower * forwardInput));
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        speed = Mathf.Round(_rb.velocity.magnitude * 3.6f);
        speedometerText.SetText($"Speed: {speed}kmh");
        rpm = Mathf.Round(speed % 30 * 40);
        rpmText.SetText($"RPM: {rpm}");
    }

    private bool IsOnGround()
    {
        return allWheels.All(wheel => wheel.isGrounded);
    }
}
