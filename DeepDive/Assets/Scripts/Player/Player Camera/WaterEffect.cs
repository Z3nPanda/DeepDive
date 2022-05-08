using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEffect : MonoBehaviour
{

    void Start()
    {
        RenderSettings.fog = true;
        RenderSettings.fogColor = new Color(0.13f, 0.62f, 0.91f, 0.25f);
        RenderSettings.fogDensity = 0.005f; 
    }
}
