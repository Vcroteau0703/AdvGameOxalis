 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public BagItem selectedItem;

    public Slider supplySlider;

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
            selectedItem = Bag.slots[uiInventory.curInvSlot].itemRef;
            if (vision.collider.tag == "Plot")
            {
                vision.collider.GetComponent<GrowPlant>().FarmMechanic(selectedItem);
                uiInventory.DrawSlots();

                //Debug.Log("Interacting");
            }
            if (vision.collider.tag == "Germinator")
            {
                if(selectedItem != null)
                {
                    //check if selected item is a crop
                    if (selectedItem.isSeed || selectedItem == null)
                    {
                        Debug.Log("Item is not a crop!");

                    }
                    else
                    {
                        BagItem seed = Resources.Load<BagItem>(selectedItem.seeds);
                        for (int i = 0; i < selectedItem.seedYield; i++)
                        {
                            Bag.AddItemToInventory(seed);
                        }
                        Bag.RemoveItemFromInventory(selectedItem);
                        uiInventory.DrawSlots();
                    }
                }
            }
            if(vision.collider.tag == "Storage")
            {
                if(selectedItem != null)
                {
                    if (selectedItem.isSeed)
                    {
                        Debug.Log("Item is not a crop!");

                    }
                    else
                    {
                        supplySlider.value += selectedItem.supplyYield;
                        Bag.RemoveItemFromInventory(selectedItem);
                        uiInventory.DrawSlots();
                    }
                }
            }
        }
    }

    void ChangeInventorySelection()
    {
        if (uiInventory.curInvSlot < Bag.slots.Length - 1)
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
