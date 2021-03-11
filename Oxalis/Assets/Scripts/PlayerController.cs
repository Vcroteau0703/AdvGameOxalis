 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    private Controls controls;

    public float movementSpeed = 4.5f;
    private Vector2 move;

    private CharacterController characterController;
    Vector3 velocity;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    //mouse scroll
    Vector2 scroll;

    //checks for grounded
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public bool isGrounded;
    public bool isRunning;

    private RaycastHit vision; // detecting raycast collision
    public float rayLength; //assigning length to the raycast

    //inventory
    private UI_Inventory uiInventory;
    public GameObject ui_Inventory;

    public BagItem selectedItem;

    //Slider refs
    public Slider supplySlider;

    //jetpack
    bool jump = false;
    public float jetpackStrength;
    private FuelMeter fuelMeter;
    public GameObject fuel;

    //Hunger ref
    public GameObject hunger;
    HungerMeter hungerMeter;

    //get ui_tutorial
    public GameObject ui_Tutorial;
    private UI_Tutorial uiTutorial;

    //SFX
    AudioSource audioSource;

    //ref health
    public GameObject health;
    HealthMeter healthMeter;

    //Crosshairs
    public Transform crosshairs;
    Animator leftAnim;
    Animator rightAnim;
    Animator upAnim;
    Animator downAnim;

    private void Awake()
    {
        controls = new Controls();
        characterController = GetComponent<CharacterController>();
        rayLength = 5.0f;

        // getting ui invetory script ref
        uiInventory = ui_Inventory.GetComponent<UI_Inventory>();

        // getting fuel meter script ref
        fuelMeter = fuel.GetComponent<FuelMeter>();

        // getting hunger meter script ref
        hungerMeter = hunger.GetComponent<HungerMeter>();

        // getting health meter script ref
        healthMeter = health.GetComponent<HealthMeter>();

        // getting ui tutorial script ref
        uiTutorial = ui_Tutorial.GetComponent<UI_Tutorial>();

        //Interact
        controls.Gameplay.Interact.performed += ctx => Interact();

        //Change Inventory Selection right
        controls.Gameplay.ChangeSelectionRight.performed += ctx => ChangeInventorySelectionRight();

        //Change Inventory Selection left
        controls.Gameplay.ChangeSelectionLeft.performed += ctx => ChangeInventorySelectionLeft();

        //Sprint
        controls.Gameplay.Sprint.performed += ctv => Sprint();
        controls.Gameplay.Sprint.canceled += ctx => SprintReleased();

        //Jetpack
        controls.Gameplay.Jump.performed += ctv => Jetpack();
        controls.Gameplay.Jump.canceled += ctx => JetpackReleased();

        //Consume
        controls.Gameplay.Consume.performed += ctx => Consume();

        //Change between inventory and supplies purchase menu
        controls.Gameplay.ChangeMenu.performed += ctx => SwitchMenus();

        //Exit menus
        controls.Gameplay.ExitMenu.performed += ctx => ExitMenu();

        //Getting SFX
        audioSource = GetComponent<AudioSource>();

        //getting crosshairs
        leftAnim = crosshairs.GetChild(0).GetComponent<Animator>();
        rightAnim = crosshairs.GetChild(1).GetComponent<Animator>();
        upAnim = crosshairs.GetChild(2).GetComponent<Animator>();
        downAnim = crosshairs.GetChild(3).GetComponent<Animator>();
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //checking to see if player is on the ground
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            fuelMeter.IncreaseFuel();
        }

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        //movement
        move = controls.Gameplay.Move.ReadValue<Vector2>();

        Vector3 movement = move.y * transform.forward + (move.x * transform.right);

        characterController.Move(movement * movementSpeed * Time.deltaTime);

        //gravity
        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

        //Jetpacking Logic
        if (jump && fuelMeter.fuelVal > 0)
        {
            jumpHeight = Mathf.Lerp(0, jumpHeight, jetpackStrength);
            velocity.y = jumpHeight;
            fuelMeter.DepleteFuel();
        }

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * rayLength, Color.red, 0.5f);


        // activating and deactivating animated crosshair
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out vision, rayLength))
        {
            if(vision.collider.tag == "Plot" || vision.collider.tag == "Germinator" || vision.collider.tag == "Storage" || vision.collider.tag == "Compost")
            {
                leftAnim.SetBool("interactable", true);
                rightAnim.SetBool("interactable", true);
                upAnim.SetBool("interactable", true);
                downAnim.SetBool("interactable", true);
            }
        }
        else
        {
            leftAnim.SetBool("interactable", false);
            rightAnim.SetBool("interactable", false);
            upAnim.SetBool("interactable", false);
            downAnim.SetBool("interactable", false);
        }


        // mouse scroll
        scroll = controls.Gameplay.Scroll.ReadValue<Vector2>();
        //Debug.Log(scroll.y);
        if(scroll.y > 0f)
        {
            ChangeInventorySelectionLeft();
        }
        if(scroll.y < 0f)
        {
            ChangeInventorySelectionRight();
        }


    }

    // interaction function
    void Interact()
    {
        if (uiInventory.supplyMenuActive)
        {
            if (uiInventory.inSupplyMenu)
            {
                selectedItem = Bag.supplySlots[uiInventory.curInvSlot].itemRef;
                if(supplySlider.value >= selectedItem.supplyYield)
                {
                    supplySlider.value -= selectedItem.supplyYield;
                    Bag.AddItemToInventory(selectedItem);
                    uiInventory.DrawSlots();
                }
                else
                {
                    Debug.Log("you don't have enough supply points to buy this item!");
                }
            }
            else
            {
                selectedItem = Bag.slots[uiInventory.curInvSlot].itemRef;
                if (selectedItem != null)
                {
                    supplySlider.value += selectedItem.supplyYield;
                    //checking if item player is adding is in storage menu and adding them if not
                    if (!Bag.IsItemInStorage(selectedItem))
                    {
                        Debug.Log("item is not in storage, adding item now");
                        uiInventory.curStorageSlots++;
                    }
                    Bag.AddItemToStorage(selectedItem);
                    uiInventory.DrawSupplySlots();
                    Bag.RemoveItemFromInventory(selectedItem);
                    uiInventory.DrawSlots();

                    //if (selectedItem.isCrop)
                    //{

                    //}
                    //else
                    //{
                    //    Debug.Log("Item is not a crop!");
                    //}
                }
            }
        }
        else
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
                    if (selectedItem != null)
                    {
                        //check if selected item is a crop
                        if (selectedItem.isCrop)
                        {
                            // getting seed ref
                            BagItem seed = Resources.Load<BagItem>(selectedItem.seeds);
                            // cycling through how many seeds to add based on crops seed yield
                            for (int i = 0; i < selectedItem.seedYield; i++)
                            {
                                Bag.AddItemToInventory(seed);
                            }
                            audioSource.clip = Resources.Load<AudioClip>("PickupSFX");
                            audioSource.Play();
                            Bag.RemoveItemFromInventory(selectedItem);
                            // refreshing inventory
                            uiInventory.DrawSlots();

                            // checking if tutorial is needed
                            if (uiTutorial.firstGermination && ui_Tutorial.activeInHierarchy)
                            {
                                uiTutorial.firstGermination = false;
                                uiTutorial.NextTutorial();
                            }
                        }
                        else
                        {
                            Debug.Log("Item is not a crop!");
                        }
                    }
                }
                if (vision.collider.tag == "Storage")
                {
                    uiInventory.ActivateStorageMenu();
                    uiInventory.DrawSupplySlots();
                }
                if (vision.collider.tag == "Compost")
                {
                    if (selectedItem != null)
                    {
                        if (selectedItem.isCrop)
                        {
                            // storing how much fertilizer to add to inventory
                            int fertilizerCnt = selectedItem.fertilizerYield;
                            Bag.RemoveItemFromInventory(selectedItem);
                            // getting fertilizer ref
                            BagItem fertilizer = Resources.Load<BagItem>("Fertilizer");
                            // cycling through how much fertilizer to add
                            for (int i = 0; i < fertilizerCnt; i++)
                            {
                                Bag.AddItemToInventory(fertilizer);
                            }
                            audioSource.clip = Resources.Load<AudioClip>("PickupSFX");
                            audioSource.Play();
                            // refreshing inventory
                            uiInventory.DrawSlots();

                            // checking if tutorial is needed
                            if (uiTutorial.firstCompost && ui_Tutorial.activeInHierarchy)
                            {
                                uiTutorial.firstCompost = false;
                                uiTutorial.NextTutorial();
                            }
                        }
                        else
                        {
                            Debug.Log("Item is not a crop!");
                        }
                    }
                }
            }
        }
    }


    // selection change functions
    void ChangeInventorySelectionRight()
    {
        if (uiInventory.inSupplyMenu)
        {
            if (uiInventory.curInvSlot < uiInventory.curStorageSlots - 1)
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
        else
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
    }
    
    void ChangeInventorySelectionLeft()
    {
        if (uiInventory.inSupplyMenu)
        {
            if (uiInventory.curInvSlot > 0)
            {
                uiInventory.curInvSlot--;
                uiInventory.InventorySelection();
            }
            else
            {
                uiInventory.curInvSlot = uiInventory.curStorageSlots - 1;
                uiInventory.InventorySelection();
            }
        }
        else
        {
            if (uiInventory.curInvSlot > 0)
            {
                uiInventory.curInvSlot--;
                uiInventory.InventorySelection();
            }
            else
            {
                uiInventory.curInvSlot = Bag.slots.Length - 1;
                uiInventory.InventorySelection();
            }
        }

    }

    //sprint functions
    void Sprint()
    {
        movementSpeed = movementSpeed * 2;
    }

    void SprintReleased()
    {
        movementSpeed = movementSpeed / 2;
    }


    //jetpacking functions
    void Jetpack()
    {
        jump = true;
        audioSource.clip = Resources.Load<AudioClip>("JetpackSFX");
        audioSource.loop = true;
        audioSource.Play();
    }
    
    void JetpackReleased()
    {
        jump = false;
        audioSource.clip = Resources.Load<AudioClip>("JetpackSFX");
        audioSource.loop = false;
        audioSource.Pause();
    }

    //Consume function
    void Consume()
    {
        selectedItem = Bag.slots[uiInventory.curInvSlot].itemRef;
        if (selectedItem.isCrop)
        {
            if(hungerMeter.hungerVal < 100)
            {
                hungerMeter.IncreaseHunger(selectedItem.hungerWorth);
                if(healthMeter.healthVal < 100)
                {
                    healthMeter.IncreaseHealth(selectedItem.healthWorth);
                }
                Bag.RemoveItemFromInventory(selectedItem);
                uiInventory.DrawSlots();

                if (uiTutorial.firstConsume && ui_Tutorial.activeInHierarchy)
                {
                    uiTutorial.firstConsume = false;
                    uiTutorial.NextTutorial();
                }
            }
            else
            {
                Debug.Log("You aren't hungry right now");
            }


        }
        else
        {
            Debug.Log("Item is not a crop!");
        }
    }

    void SwitchMenus()
    {
        if (uiInventory.inSupplyMenu)
        {
            uiInventory.inSupplyMenu = false;
            uiInventory.curInvSlot = 0;
            uiInventory.InventorySelection();
        }
        else
        {
            uiInventory.inSupplyMenu = true;
            uiInventory.curInvSlot = 0;
            uiInventory.InventorySelection();
        }
    }

    void ExitMenu()
    {
        if (uiInventory.supplyMenuActive)
        {
            uiInventory.DeactivateStorageMenu();
            uiInventory.inSupplyMenu = false;
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
