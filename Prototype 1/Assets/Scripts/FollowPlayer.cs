using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    
    private readonly Vector3 _offset = new Vector3(0, 5, -7);

    private void LateUpdate()
    {
        transform.position = player.transform.position + _offset;
    }
}