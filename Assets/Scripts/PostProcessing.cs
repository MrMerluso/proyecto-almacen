using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProcessing : MonoBehaviour
{
    public Shader shader;
    private Material _material;

    public bool grayscale = false;

    // Start is called before the first frame update
    void Start()
    {
        _material = new Material(shader);
    }

    void OnRenderImage(RenderTexture source, RenderTexture desitnation)
    {
        if (grayscale)
        {
            Graphics.Blit(source, desitnation, _material);
        }
        else
        {
            Graphics.Blit(source, desitnation);
        }
    }
}
