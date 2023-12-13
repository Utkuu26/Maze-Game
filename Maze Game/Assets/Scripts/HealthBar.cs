using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : PlayerHealth
{
    public Slider healthSlider; 
    public Slider easehealthSlider; 
    private float lerpSpeed = 0.05f;
    
    void Update()
    {
        if(healthSlider.value != currentHealth)
        {
            healthSlider.value = currentHealth;
            Debug.Log(currentHealth);
        }

        if(healthSlider.value != easehealthSlider.value)
        {
            easehealthSlider.value = Mathf.Lerp(easehealthSlider.value, currentHealth, lerpSpeed);
            Debug.Log(currentHealth);
        }

    }
}
