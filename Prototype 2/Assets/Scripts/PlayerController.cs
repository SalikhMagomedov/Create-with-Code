using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10f;
    public float xRange = 10;
    public GameObject projectilePrefab;

    private void Update()
    {
        var position = transform.position;
        if (Mathf.Abs(position.x) > xRange)
        {
            transform.position = new Vector3(Mathf.Sign(position.x) * xRange, position.y, position.z);
        }
        
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * (horizontalInput * speed * Time.deltaTime));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        }
    }
}