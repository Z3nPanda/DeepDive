using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCast : MonoBehaviour
{
    private static Rigidbody rb;
    public CameraSwap rayCamActive;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rayCamActive.camActive)
        {
            if (Input.GetKeyDown("v"))
            {
                CastSphere();
            }
        }
    }

    public static void CastSphere()
    {
        RaycastHit hit;
        Vector3 start = rb.transform.position;
        // float objDist = 0f;

        // cast a sphere 10m forward
        // see if it hit something
        if (Physics.SphereCast(start, 0.5f, rb.transform.forward, out hit, 20))
        {
            // update the score
            Debug.Log("It works");
        }
    }
}
