using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTraps : MonoBehaviour
{
    private bool isTrigger;
    private int damageAmount = 10; 
    public float damageInterval = 2f;
    private float lastDamageTime; 

     private void Start()
    {
        lastDamageTime = Time.time;  // Initialize lastDamageTime with the current time
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {

                playerHealth.TakeDamage(damageAmount);
                isTrigger = true;

               
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(isTrigger)
            {
                PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    if (Time.time - lastDamageTime >= damageInterval)
                    {
                        lastDamageTime = Time.time;
                        playerHealth.TakeDamage(damageAmount-5);
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           if(isTrigger)
           {
            isTrigger = false;
           }
        }
    }
}
