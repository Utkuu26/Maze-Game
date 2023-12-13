using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth = 100;  
    private bool isDead = false;
    public GameObject gameOverArea;


    private void Start()
    {
        gameOverArea.SetActive(false);
    }

    public void TakeDamage(int damageAmount)
    {
        if (!isDead)
        {
            currentHealth -= damageAmount;

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
         if (!isDead)
        {
            isDead = true;
            Debug.Log("Game Over");
            GetComponent<Animator>().SetTrigger("Die");

            ShowGameOverScreen();
            StartCoroutine(RestartScene());
        }
    }

    void ShowGameOverScreen()
    {
        gameOverArea.SetActive(true);
    }

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
