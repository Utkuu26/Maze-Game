using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTraps : MonoBehaviour
{
    private bool isTrigger;
    private int damageAmount = 5; 
    public float damageInterval = 2f;
    private float lastDamageTime; 
    private AudioSource audioSource;
    public AudioClip takeDamageSFX;

     private void Start()
    {
        lastDamageTime = Time.time; 
         audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
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

                if (audioSource != null && takeDamageSFX != null && Time.time - lastDamageTime >= 1f)
                {
                    audioSource.PlayOneShot(takeDamageSFX);
                    lastDamageTime = Time.time; // Yeni çalma zamanını güncelle
                }
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

                        if (audioSource != null && takeDamageSFX != null)
                        {
                            audioSource.PlayOneShot(takeDamageSFX);
                        }
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
