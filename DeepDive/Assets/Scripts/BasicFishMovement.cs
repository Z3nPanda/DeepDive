using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFishMovement : MonoBehaviour
{
    
    [SerializeField] private float movementSpeed = 2f;
    [SerializeField] private float rotationSpeed = 100f;

    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isSwimming = false;
    private bool isSwimmingUp = false;
    private bool isSwimmingDown = false;
    private bool obstruction = false;

    public LayerMask Terrain;
    [SerializeField] private float yUpperLimit = 100f;
    [SerializeField] private float yLowerLimit = 10f;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        // Raycast for front facing collisions
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        obstruction = Physics.Raycast(ray, out hit, 5, Terrain);
        Debug.DrawRay(ray.origin, ray.direction * 5.0f, Color.red);

        // Enables our fish to wander
        if (isWandering == false)
        {
            StartCoroutine(Wander());
        }

        // Rotate fish either right or left if true
        if (isRotatingRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
        }

        if (isRotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotationSpeed);
        }

        if (isSwimming == true)
        {

            // Swim Forward if there is no obstruction, else turn away from obstruction
            if (obstruction)
            {
                int dir = Random.Range(1, 2);
                if (dir == 1)
                {
                    transform.Rotate(transform.up * Time.deltaTime * 160f);
                }
                else
                {
                    transform.Rotate(transform.up * Time.deltaTime * -160f);
                }
            }
            else
            {
                // Swim forward
                rb.AddForce(transform.forward * movementSpeed);
            }

            // If the fish is swimming up check if its at its upper y-axis limit, if it is set its velocity to 0 so it can't breach its boundary
            // otherwise, allow the fish to move up
            if (isSwimmingUp == true)
            {
                if (transform.position.y <= yUpperLimit)
                {
                    // Swim up
                    rb.AddForce(transform.up * (movementSpeed / 2.0f));
                }
                else 
                {
                    rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
                }
            }
            // If the fish is swimming down check if its at its lower y-axis limit, if it is set its velocity to 0 so it can't breach its lower boundary
            // otherwise, allow the fish to move up
            else if (isSwimmingDown == true)
            {
                if (transform.position.y >= yLowerLimit)
                {
                    // Swim down
                    rb.AddForce(-transform.up * (movementSpeed / 2.0f));
                }
                else
                {
                    rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.x);
                }
            }
        }
    }

    IEnumerator Wander()
    {
        // Randomized variables to determine timing
        int rotationTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 3);
        int rotateDirection = Random.Range(1, 2);
        int swimWait = Random.Range(1, 3);
        float swimTime = Random.Range(.25f, .75f);

        int swimUp = Random.Range(1, 5);
        int swimDown = Random.Range(1, 5);

        isWandering = true;

        yield return new WaitForSeconds(swimWait);

        isSwimming = true;
        
        if (swimUp == 1)
        {
            isSwimmingUp = true;
        }
        else if (swimDown == 1)
        {
            isSwimmingDown = true;
        }

        yield return new WaitForSeconds(swimTime);

        isSwimming = false;
        isSwimmingUp = false;
        isSwimmingDown = false;

        yield return new WaitForSeconds(rotateWait);

        if (rotateDirection == 1)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingLeft = false;
        }

        if (rotateDirection == 2)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingRight = false;
        }

        isWandering = false;
    }
}
