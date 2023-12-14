using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTraps : MonoBehaviour
{
    public int damageAmount = 10; 
    public float damageInterval = 1.5f;
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
                // Check if enough time has passed since the last damage
                if (Time.time - lastDamageTime >= damageInterval)
                {
                    playerHealth.TakeDamage(damageAmount);

                    // Update lastDamageTime to the current time
                    lastDamageTime = Time.time;
                }
            }
        }
    }
}
