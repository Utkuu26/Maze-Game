using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHint : MonoBehaviour
{
    public GameObject hintObject;
    public GameObject pressedImg;
    private bool isButtonActive = true;
    private float cooldownDuration = 3f;
    private float cooldownTimer = 0f;

    private void Start()
    {
        hintObject.SetActive(false);
        pressedImg.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            PressedButton();
        }

        if (!isButtonActive)
        {
            cooldownTimer += Time.deltaTime;

            if (cooldownTimer >= cooldownDuration)
            {
                ActivateButton();
            }
        }
    }

    private void PressedButton()
    {
        if (!isButtonActive)
            return;

        hintObject.SetActive(true);
        pressedImg.SetActive(true);
        isButtonActive = false;
        StartCoroutine(WaitAndActivateButton());
    }

    private void ActivateButton()
    {
        isButtonActive = true;
        hintObject.SetActive(false);
        pressedImg.SetActive(false);
        cooldownTimer = 0f;
    }

    private IEnumerator WaitAndActivateButton()
    {
        yield return new WaitForSeconds(cooldownDuration);
        ActivateButton();
    }
}
