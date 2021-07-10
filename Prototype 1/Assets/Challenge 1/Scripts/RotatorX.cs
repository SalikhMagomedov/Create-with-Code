using UnityEngine;

namespace Challenge_1.Scripts
{
    public class RotatorX : MonoBehaviour
    {
        public float turnSpeed;

        private void Update()
        {
            transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
        }
    }
}