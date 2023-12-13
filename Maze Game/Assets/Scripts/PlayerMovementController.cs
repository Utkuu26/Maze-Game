using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;

    public float speed = 12f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;

    float currentSpeed; // Güncellenen hız değeri
    float targetSpeed; // Hedef hız değeri

    // Hız değişim hızı
    public float speedChangeRate = 2f;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        Vector3 move = (isRunning ? transform.right * x + transform.forward * z : transform.right * x + transform.forward * z * 0.5f);

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        float playerSpeed = new Vector2(controller.velocity.x, controller.velocity.z).magnitude;
        bool isMoving = (x != 0f || z != 0f);
        animator.SetBool("move", isMoving);

        // Hedef hızı ayarla
        targetSpeed = isRunning ? 1f : 0.5f;

        // Güncellenen hızı yavaşça artır veya azalt
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, Time.deltaTime * speedChangeRate);

        // Set playerSpeed parameter for Blend Tree
        float modifiedPlayerSpeed = currentSpeed;
        animator.SetFloat("playerSpeed", modifiedPlayerSpeed);
    }
}
