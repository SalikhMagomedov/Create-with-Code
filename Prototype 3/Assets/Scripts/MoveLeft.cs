using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private const float Speed = 30f;

    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * Speed);
    }
}