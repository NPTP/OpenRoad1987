using UnityEngine;

public class CamForwardBillboard : MonoBehaviour
{
    private Camera mainCameraRef;
    
    private void Awake()
    {
        mainCameraRef = Camera.main;
    }

    void Update()
    {
        transform.forward = -mainCameraRef.transform.forward;
    }
}
