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
            Vector3 p1 = (transform.position + new Vector3 (0, 0, 3.5f)) + Vector3.forward * .5f;
            Vector3 p2 = p1 + Vector3.forward;
            RaycastHit hit;

            if(Physics.CapsuleCast(p1, p2, 1.0f, direction, out hit, 10))
            {
                if(hit.collider.transform.tag == "Player")
                {
                    Debug.Log("Hit player at distance = " + hit.distance);
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
