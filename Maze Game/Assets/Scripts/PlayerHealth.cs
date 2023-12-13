using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;  
    public int currentHealth;    

    private void Start()
    {
        currentHealth = maxHealth;  
    }

    // Trap'e çarpıldığında çağrılır
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;  
        Debug.Log("AHH");

        if (currentHealth <= 0)
        {
            Die(); 
        }
    }

    void Die()
    {
        // Buraya karakterin ölmeyle ilgili işlemleri ekleyebilirsiniz
        Debug.Log("Game Over");
        // Örneğin, oyunu yeniden başlatma veya ana menüye dönme işlemleri buraya eklenir
    }
}
