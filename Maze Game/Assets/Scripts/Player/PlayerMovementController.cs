using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;

    public float speed = 2f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 1f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;
    bool isJumping;

    float currentSpeed;
    float targetSpeed;
    public float speedChangeRate = 2f;

    public AudioSource[] audioSource;
    public AudioClip jumpSFX;
    public AudioClip footstepSFX;
    public float runPitch = 1.5f;
     public float walkPitch = 1.0f;
    private float originalPitch;
    public AudioClip takeDamageSFX;

     void Start()
    {
        audioSource = GetComponents<AudioSource>();
        originalPitch = audioSource[0].pitch; 
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;

            if (isJumping)
            {
                isJumping = false;
                animator.SetBool("isJump", false);
            }
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        Vector3 move = (isRunning ? transform.right * x + transform.forward * z : transform.right * x + transform.forward * z * 0.5f);

        controller.Move(move * speed * Time.deltaTime);

        // Space tuşuna basıldığında ve karakter zemindeyken Jump animasyonu devreye girmeli
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            PlayJumpSound();
            isJumping = true;
            animator.SetBool("isJump", true);
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        float playerSpeed = new Vector2(controller.velocity.x, controller.velocity.z).magnitude;
        bool isMoving = (x != 0f || z != 0f);
        animator.SetBool("move", isMoving);

        targetSpeed = isRunning ? 1f : 0.5f;
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, Time.deltaTime * speedChangeRate);

        float modifiedPlayerSpeed = currentSpeed;
        animator.SetFloat("playerSpeed", modifiedPlayerSpeed);

        if (isGrounded && isMoving)
        {
            AudioClip footstepClip = footstepSFX;

            if (isRunning)
            {
                footstepClip = footstepSFX;
                foreach (var audioSource in audioSource)
                {
                    audioSource.pitch = runPitch;
                }
            }
            else 
            {
                foreach (var audioSource in audioSource)
                {
                    audioSource.pitch = walkPitch;
                }
            }

            PlaySound(footstepClip);
        }

        if (!isRunning)
        {
            foreach (var audioSource in audioSource)
            {
                audioSource.pitch = originalPitch;
            }
        }

        void PlayJumpSound()
        {
            foreach (var audioSource in audioSource)
            {
                audioSource.Stop(); 
                audioSource.pitch = 1.0f; 
                audioSource.clip = jumpSFX;
                audioSource.Play();
            }
        }

        void PlaySound(AudioClip clip)
        {
            // Boş bir AudioSource bul ve belirtilen sesi çal
            foreach (var audioSource in audioSource)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.clip = clip;
                    audioSource.Play();
                    break;
                }
            }
        }
    }
}
