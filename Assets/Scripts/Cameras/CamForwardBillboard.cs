using UnityEngine;

namespace Cameras
{
    public class CamForwardBillboard : MonoBehaviour
    {
        private void Awake()
        {
            CameraFollow.OnCameraTransformUpdated += HandleCameraTransformUpdated;
        }

        private void OnDestroy()
        {
            CameraFollow.OnCameraTransformUpdated -= HandleCameraTransformUpdated;
        }

        private void HandleCameraTransformUpdated(Transform cameraTransform)
        {
            transform.forward = -cameraTransform.forward;
        }
    }
}
