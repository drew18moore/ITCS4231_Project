using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    [Header("Movement")]
    public float speed = 12f;
    public float walkSpeed;
    public float sprintSpeed;

    [Header("Jumping")]
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [Header("Sounds")]
    public AudioSource footstepSound;
    
    private Vector3 velocity;
    private bool isGrounded;

    public MovementState state;
    public enum MovementState
    {
        walking,
        sprinting,
        air
    }

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

        if (isGrounded && (x != 0 || z != 0) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && !footstepSound.isPlaying)
        {
            footstepSound.volume = Random.Range(0.8f, 1);
            footstepSound.pitch = Random.Range(0.8f, 1.1f);
            footstepSound.Play();
        }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKey(jumpKey) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        StateHandler();
    }

    void StateHandler()
    {
        if (isGrounded && Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting;
            speed = sprintSpeed;
        }
        else if (isGrounded)
        {
            state = MovementState.walking;
            speed = walkSpeed;
        }
        else
        {
            state = MovementState.air;
        }
    }
}
