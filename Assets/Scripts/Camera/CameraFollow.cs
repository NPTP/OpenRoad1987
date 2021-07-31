using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform transformToFollow;
    [SerializeField] private float offset = 3.0f;

    private void Start()
    {
        transform.position = transformToFollow.position - transformToFollow.forward * offset + Vector3.up * offset;
    }

    private void LateUpdate()
    {
        transform.position = transformToFollow.position - transformToFollow.forward * offset + Vector3.up * offset / 2;
        transform.LookAt(transformToFollow, Vector3.up);
    }
}
