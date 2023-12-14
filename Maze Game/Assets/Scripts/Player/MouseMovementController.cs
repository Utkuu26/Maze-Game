using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovementController : MonoBehaviour
{
    public float mouseSensitivity = 50f;

    float xRotation = 0f;
    float yRotation = 0f;

    void Start()
    {
        // Locking the cursor to the middle of the screen and making it invisible
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Control rotation around x axis (Look up and down)
        xRotation -= mouseY;

        // Clamp the rotation to avoid over-rotation
        xRotation = Mathf.Clamp(xRotation, -30f, 2f);

        // Control rotation around y axis (Look left and right)
        yRotation += mouseX;

        // Applying both rotations
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
