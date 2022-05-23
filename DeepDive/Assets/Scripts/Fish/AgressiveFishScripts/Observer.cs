using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public BehaviorController control;
    bool playerInRange;

    void Update()
    {
        if (playerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.forward;
            Ray ray = new Ray (transform.position, direction);
            RaycastHit raycastHit;
            Debug.DrawRay(ray.origin, ray.direction * 1000.0f, Color.red);

            if(Physics.Raycast(ray, out raycastHit, 1000))
            {
                if(raycastHit.collider.transform.tag == "Player")
                {
                    if (control.getFollow() == false)
                    {
                        control.setFollowTrue();
                    }
                    control.resetFollowTime(control.getMaxTime());
                }
            }
        }
        else
        {
            //Debug.Log("Player outta range");
            if (control.getFollow() == true)
                {
                    control.setFollowFalse();
                }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
