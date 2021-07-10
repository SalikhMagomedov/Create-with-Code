using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private const float Speed = 5f;

    private void Update()
    {
        // Move the vehicle forward
        transform.Translate(Vector3.forward * (Time.deltaTime * Speed));
    }
}