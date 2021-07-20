using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    [SerializeField] private float speed = 15.0f;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation *= Quaternion.Euler(0, -15 * Time.deltaTime * speed, 0);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation *= Quaternion.Euler(0, 15 * Time.deltaTime * speed, 0);
        }
    }
}
