using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private const float Speed = 30f;

    private PlayerController _playerController;
    
    private const float LeftBound = -15f;

    private void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (!_playerController.gameOver) transform.Translate(Vector3.left * (Time.deltaTime * Speed));
        if (transform.position.x < LeftBound && gameObject.CompareTag("Obstacle")) Destroy(gameObject);
    }
}