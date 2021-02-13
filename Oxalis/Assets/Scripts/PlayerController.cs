 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Controls controls;

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

    private RaycastHit vision; // detecting raycast collision
    public float rayLength; //assigning length to the raycast


    private UI_Inventory uiInventory;
    public GameObject ui_Inventory;

    private void Awake()
    {
        controls = new Controls();
        characterController = GetComponent<CharacterController>();
        rayLength = 4.0f;

        uiInventory = ui_Inventory.GetComponent<UI_Inventory>();

        //Interact
        controls.Gameplay.Interact.performed += ctx => Interact();

        //Change Inventory Selection
        controls.Gameplay.ChangeSelection.performed += ctx => ChangeInventorySelection();

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

    void Interact()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * rayLength, Color.red, 0.5f);

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out vision, rayLength))
        {

            if (vision.collider.tag == "Plot")
            {
                Debug.Log(vision.collider.name);
                BagItem selectedItem = Bag.slots[uiInventory.curInvSlot].itemRef;
                vision.collider.GetComponent<GrowPlant>().FarmMechanic(selectedItem);
                uiInventory.DrawSlots();
                //Debug.Log("Interacting");
            }
        }
    }

    void ChangeInventorySelection()
    {

        if(uiInventory.curInvSlot < Bag.slots.Length - 1)
        {
            uiInventory.curInvSlot++;
            uiInventory.InventorySelection();
        }
        else
        {
            uiInventory.curInvSlot = 0;
            uiInventory.InventorySelection();
        }

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
