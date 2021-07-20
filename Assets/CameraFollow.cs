using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform transformToFollow;
    [SerializeField] private float offset = 3.0f;
    [SerializeField] private float dampingFactor = 15.0f;

    private void Start()
    {
        transform.position = transformToFollow.position - transformToFollow.forward * offset + Vector3.up * offset;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, transformToFollow.position - transformToFollow.forward * offset + Vector3.up * offset, Time.deltaTime * dampingFactor);
        transform.LookAt(transformToFollow, Vector3.up);
    }
}
