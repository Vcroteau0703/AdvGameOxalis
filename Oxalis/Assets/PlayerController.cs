 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerControls controls;

    float movementSpeed = 4.5f;
    private Vector2 move;

    private CharacterController characterController;
    Vector3 velocity;
    public float gravity = -9.81f;

    //checks for grounded
    //public Transform groundCheck;
    //public float groundDistance = 0.4f;
    //public LayerMask groundMask;

    //public bool isGrounded;
    //public bool isRunning;

    //private RaycastHit vision; // detecting raycast collision
    //public float rayLength; //assigning length to the raycast


    private void Awake()
    {
        controls = new PlayerControls();
        characterController = GetComponent<CharacterController>();


    }

    private void FixedUpdate()
    {
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //checking to see if player is on the ground
        //if(isGrounded && velocity.y < 0)
        //{
        //    velocity.y = -2f;
        //}

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        //movement
        move = controls.Gameplay.Move.ReadValue<Vector2>();

        Vector3 movement = move.y * transform.forward + (move.x * transform.right);

        characterController.Move(movement * movementSpeed * Time.deltaTime);

        //gravity
        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
