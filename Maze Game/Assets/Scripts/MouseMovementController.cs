using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovementController : MonoBehaviour
{
    private float mouseSensitivity = 100f;
    private float maxVerticalRotation = 15f;
 
    float xRotation = 0f;
    float YRotation = 0f;
 
    void Start()
    {
      Cursor.lockState = CursorLockMode.Locked;
    }
 
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -maxVerticalRotation, maxVerticalRotation);
        YRotation += mouseX;

        transform.localRotation = Quaternion.Euler(xRotation, YRotation, 0f);
    }

}
