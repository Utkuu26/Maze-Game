using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth = 100;   
    public bool isTakeDamage; 

    private void Start()
    {
    
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;  

        if (currentHealth <= 0)
        {
            Die(); 
        }
    }

    void Die()
    {
        // Buraya karakterin ölmeyle ilgili işlemleri ekleyebilirsiniz
        Debug.Log("Game Over");
    }
}
