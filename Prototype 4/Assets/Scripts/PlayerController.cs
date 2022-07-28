using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private bool hasPowerUp;
    [SerializeField] private GameObject powerUpIndicator;

    private Rigidbody _rb;
    private GameObject _focalPoint;

    private const float PowerUpStrength = 15.0f;

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
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("PowerUp")) return;

        hasPowerUp = true;
        Destroy(other.gameObject);
        StartCoroutine(PowerUpCountdownRoutine());
        powerUpIndicator.SetActive(true);
    }

    private IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(7);

        hasPowerUp = false;
        powerUpIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Enemy") || !hasPowerUp) return;

        var enemyRb = collision.gameObject.GetComponent<Rigidbody>();
        var awayFromPlayer = (collision.gameObject.transform.position - transform.position);

        Debug.Log($"Player collided with {collision.gameObject.name} with powerUp set to {hasPowerUp}");
        enemyRb.AddForce(awayFromPlayer * PowerUpStrength, ForceMode.Impulse);
    }
}