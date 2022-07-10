using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;

    private Rigidbody _rb;
    private GameObject _focalPoint;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _focalPoint = GameObject.Find("Focal Point");
    }

    private void Update()
    {
        var forwardInput = Input.GetAxis("Vertical");
        _rb.AddForce(_focalPoint.transform.forward * (speed * forwardInput));
    }
}