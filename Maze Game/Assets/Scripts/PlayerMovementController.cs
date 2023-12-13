using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private float moveSpeed = 0.3f;
    private float sprintSpeed = 1f;

    private Animator prisonerAnim;
    private Rigidbody rb;
    private Vector3 moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        prisonerAnim = GetComponent<Animator>();
        prisonerAnim.SetFloat("PlayerSpeed", 0f);
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Player hareketi
        moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Koşma kontrolü
        float currentSpeed = (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))) ? sprintSpeed : (Input.GetKey(KeyCode.W) ? moveSpeed : 0f);
        Vector3 moveVelocity = moveDirection * currentSpeed * 10;

        rb.velocity = new Vector3(moveVelocity.x, rb.velocity.y, moveVelocity.z);

        // Hareket etme kontrolü
        bool isMoving = moveDirection.magnitude > 0.1f;
        prisonerAnim.SetBool("move", isMoving);

        if (!isMoving)
        {
            prisonerAnim.SetBool("move", false);
        }

        // Hız parametresini güncelle
        prisonerAnim.SetFloat("playerSpeed", currentSpeed);
    }
}
