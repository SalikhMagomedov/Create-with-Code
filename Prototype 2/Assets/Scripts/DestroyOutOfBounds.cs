using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private const float TopBound = 30f;
    private const float LowerBound = -10f;

    private void Update()
    {
        if (transform.position.z > TopBound || transform.position.z < LowerBound)
        {
            Destroy(gameObject);
        }
    }
}