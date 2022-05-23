using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public PlayerController player;
    bool playerInRange;
    public float damage = .001f;

    // Update is called once per frame
    void Update()
    {
        // If the player is in range do damage to them
        if (playerInRange)
        {
            HealthBarOperator.SetHealthBarVal(HealthBarOperator.GetHealthBarVal() - damage);
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
