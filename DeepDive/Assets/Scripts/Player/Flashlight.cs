using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{

    public GameObject flashlight;
    public bool foundLight = false;
    bool flashOn = false;

    void Update()
    {
        if (foundLight)
        {
            if (Input.GetKeyDown("f"))
            {
                flashSwitch();
            }
            
            if (flashOn)
            {
                flashlight.SetActive(true);
            }
            else
            {
                flashlight.SetActive(false);
            }
        }
        
    }

    void flashSwitch()
    {
        if (flashOn)
        {
            flashOn = false;
        }
        else
        {
            flashOn = true;
        }
    }

    public void foundFlashLight()
    {
        foundLight = true;
    }
}
