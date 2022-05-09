using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour
{
    public GameObject rayCamera;
    public GameObject mainCamera;
    public bool camActive;

    private bool cameraOn = false;

    // Start is called before the first frame update
    // necessary to set the main and ray cameras at the start
    // otherwise it'll start with ray
    void Start()
    {
        mainCamera.SetActive(true);
        rayCamera.SetActive(false);
        camActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if the positive button in the Camera Switch section
        // of the input manager is pressed,
        // switch cameras
        if (Input.GetKeyDown("c"))
        {
            if (cameraOn == false) 
            {
                mainCamera.SetActive(false);
                rayCamera.SetActive(true);
                camActive = true;
                cameraOn = true;
            }
            else {
                mainCamera.SetActive(true);
                rayCamera.SetActive(false);
                camActive = false;
                cameraOn = false;
            }
        }
    }
}
