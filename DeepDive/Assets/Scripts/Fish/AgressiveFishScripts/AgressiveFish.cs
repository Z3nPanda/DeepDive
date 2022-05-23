using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgressiveFish : MonoBehaviour
{
    public Transform target;
    public float speed = 4f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        rb.MovePosition(pos);
        transform.LookAt(target);
    }
}
