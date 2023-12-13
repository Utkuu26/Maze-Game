using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider; 
    public Slider easehealthSlider; 
    private float lerpSpeed = 0.05f;
    private PlayerHealth playerHealth;

     void Start()
    {
        playerHealth = GetComponent<PlayerHealth>(); 
        healthSlider.value = playerHealth.currentHealth / 100f; 
    }
    
    void Update()
    {
        if(healthSlider.value != playerHealth.currentHealth)
        {
            healthSlider.value = playerHealth.currentHealth;
        }

        if(healthSlider.value != easehealthSlider.value)
        {
            easehealthSlider.value = Mathf.Lerp(easehealthSlider.value, playerHealth.currentHealth, lerpSpeed);
        }

    }
}
