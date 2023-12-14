using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController1 : MonoBehaviour
{
    public AudioSource btnSFX;
    public GameObject controlPanel;

    private void Start() 
    {
        controlPanel.SetActive(false);
        btnSFX.Play();
    }

     public void StartButton()
    {
        SceneManager.LoadScene(1);
        PlayButtonClickSound();
    }

    public void ControlsButton()
    {
        controlPanel.SetActive(true);
        PlayButtonClickSound();
    }

    public void ExitControlsButton()
    {
        controlPanel.SetActive(false);
        PlayButtonClickSound();
    }

    public void ExitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void PlayButtonClickSound()
    {
        if (btnSFX != null && btnSFX.clip != null)
        {
            btnSFX.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip not assigned.");
        }
    }
}
