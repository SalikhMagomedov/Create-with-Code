using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private const float TopBound = 30f;
    private const float LowerBound = -10f;

    private void Update()
    {
        if (transform.position.z > TopBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < LowerBound)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}