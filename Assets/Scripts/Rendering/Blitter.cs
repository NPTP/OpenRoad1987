using UnityEngine;
 
[ExecuteInEditMode]
public class Blitter : MonoBehaviour
{
    [SerializeField] private RenderTexture sourceTexture;
    [SerializeField] private int targetFramerate = 16;

    private void Awake()
    {
        Application.targetFrameRate = targetFramerate;
    }

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(sourceTexture, dest);
    }
}
