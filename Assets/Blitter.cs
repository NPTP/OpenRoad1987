using System;
using UnityEngine;
 
[ExecuteInEditMode]
public class Blitter : MonoBehaviour
{
    [SerializeField] private RenderTexture sourceTexture;
    [SerializeField] private int targetFramerate = 30;

    private void Awake()
    {
        Application.targetFrameRate = targetFramerate;
    }

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(sourceTexture, dest);
    }
}
