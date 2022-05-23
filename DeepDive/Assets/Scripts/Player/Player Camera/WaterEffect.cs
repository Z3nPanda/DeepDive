using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEffect : MonoBehaviour
{
    public Material effect_material;
    void OnRenderImage(RenderTexture source, RenderTexture destination) 
    {
        Graphics.Blit(source, destination, effect_material);
    }
}
