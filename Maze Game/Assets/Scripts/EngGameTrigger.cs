using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EngGameTrigger : MonoBehaviour
{
    public GameObject endGameScreen;
    private bool gameEnded = false;

    private void Start() 
    {
        endGameScreen.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
         if (other.CompareTag("Player") && !gameEnded)
        {
            EndGame();
        }
    }

     private void EndGame()
    {
        Time.timeScale = 0f;
        endGameScreen.SetActive(true);
        gameEnded = true;
    }

    private void Update()
    {
        if (gameEnded && Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToMainMenu();
        }
    }

    private void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}
