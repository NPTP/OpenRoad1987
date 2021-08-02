using UnityEngine;

namespace Cameras
{
    [RequireComponent(typeof(UnityEngine.Camera))]
    public class CameraFollow : MonoBehaviour
    {
        public static event System.Action<Transform> OnCameraTransformUpdated;

        [SerializeField] private Transform transformToFollow;
        [SerializeField] private float zOffset = -3.0f;
        [SerializeField] private float yOffset = 0.5f;

        private Transform cameraTransform;

        private Vector3 OffsetPosition => transformToFollow.position +
                                          transformToFollow.forward * zOffset +
                                          Vector3.up * yOffset;
        
        private void Awake()
        {
            cameraTransform = GetComponent<Transform>();
        }

        private void Start()
        {
            transform.position = OffsetPosition;
        }

        private void LateUpdate()
        {
            transform.position = OffsetPosition;
            transform.forward = transformToFollow.forward;
            OnCameraTransformUpdated?.Invoke(transform);
        }
    }
}
