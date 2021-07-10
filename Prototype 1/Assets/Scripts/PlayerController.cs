using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    private void Update()
    {
        // Move the vehicle forward
        transform.Translate(Vector3.forward * (Time.deltaTime * speed));
    }
}
