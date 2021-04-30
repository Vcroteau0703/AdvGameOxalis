 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerController : MonoBehaviour
{
    private Controls controls;

    //movement
    public float movementSpeed = 4.5f;
    private Vector2 move;
    public bool isMoving;

    private CharacterController characterController;
    public Vector3 velocity;
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
    public bool jetpackActive;
    public TextMeshProUGUI updates;

    //Hunger ref
    public GameObject hunger;
    HungerMeter hungerMeter;

    //get ui_tutorial
    public GameObject ui_Tutorial;
    private UI_Tutorial uiTutorial;
    public GameObject tutorialTrigger2;

    //SFX
    AudioSource audioSource;

    //ref health
    public GameObject health;
    HealthMeter healthMeter;

    //ref pause menu
    public PauseMenu pauseMenu;

    //Crosshairs
    public Transform crosshairs;
    Animator leftAnim;
    Animator rightAnim;
    Animator upAnim;
    Animator downAnim;

    //Interact indicator
    public Image mouseIndicator;

    //hit sfx
    public bool hardImpact = false;
    public bool softImpact = false;
    AudioCycle audioCycle;



    private void Awake()
    {
        controls = new Controls();
        characterController = GetComponent<CharacterController>();
        rayLength = 6.0f;

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

        //footsteps ref
        audioCycle = transform.GetChild(2).GetComponent<AudioCycle>();
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (velocity.y <= -20)
        {
            if (velocity.y <= -30)
            {
                //hardest hit
                hardImpact = true;
                softImpact = false;
            }
            else
            {
                //hard hit
                hardImpact = true;
                softImpact = false;
            }
        }
        else if (velocity.y <= -5)
        {
            softImpact = true;
        }
        else
        {
            softImpact = false;
            hardImpact = false;
        }

        //checking to see if player is on the ground
        if (isGrounded && velocity.y < 0)
        {
            if (velocity.y <= -20)
            {
                if (velocity.y <= -30)
                {
                    //hardest hit
                    audioCycle.PlayAudio();
                    audioSource.clip = Resources.Load<AudioClip>("dieimpactSFX");
                    audioSource.volume = 1f;
                    audioSource.Play();
                    healthMeter.DecreaseHealth(110);
                    velocity.y = -2f;
                }
                else
                {
                    //hard hit
                    audioCycle.PlayAudio();
                    audioSource.clip = Resources.Load<AudioClip>("dieimpactSFX");
                    audioSource.volume = 1f;
                    audioSource.Play();
                    healthMeter.DecreaseHealth(15);
                    velocity.y = -2f;
                }
            }
            else if(velocity.y <= -5)
            {
                audioCycle.PlayAudio();
            }
            velocity.y = -2f;
            fuelMeter.IncreaseFuel();
        }

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        //movement
        if (transform.hasChanged)
        {
            isMoving = true;
            transform.hasChanged = false;
        }
        else
        {
            isMoving = false;
        }

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
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out vision, rayLength) && !uiInventory.supplyMenuActive && !pauseMenu.pauseMenu.activeInHierarchy)
        {
            if(vision.collider.tag == "Plot" || vision.collider.tag == "Germinator" || vision.collider.tag == "Storage" || vision.collider.tag == "Compost" || vision.collider.tag == "Decompression" || vision.collider.tag == "AlienFruit" || vision.collider.tag == "RockPlant" || vision.collider.tag == "FloatFruit")
            {
                leftAnim.SetBool("interactable", true);
                rightAnim.SetBool("interactable", true);
                upAnim.SetBool("interactable", true);
                downAnim.SetBool("interactable", true);
                //mouseIndicator.gameObject.SetActive(true);
            }
        }
        else
        {
            leftAnim.SetBool("interactable", false);
            rightAnim.SetBool("interactable", false);
            upAnim.SetBool("interactable", false);
            downAnim.SetBool("interactable", false);
            //mouseIndicator.gameObject.SetActive(false);
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
                    Bag.IsInvFull();
                    if (!Bag.invFull || Bag.IsItemInBag(selectedItem))
                    {
                        supplySlider.value -= selectedItem.supplyYield;
                        Bag.AddItemToInventory(selectedItem);
                        Bag.RemoveItemFromStorage(selectedItem);
                        uiInventory.DrawSlots();
                        uiInventory.DrawSupplySlots();
                    }
                    else
                    {
                        updates.gameObject.SetActive(true);
                        updates.text = "Inventory is full";
                    }

                }
                else
                {
                    updates.gameObject.SetActive(true);
                    updates.text = "You don't have enough supply points to buy this item";
                }
            }
            else
            {
                selectedItem = Bag.slots[uiInventory.curInvSlot].itemRef;
                if (selectedItem != null)
                {
                    supplySlider.value += selectedItem.supplyYield;
                    //checking if item player is adding is in storage menu and adding them if not
                    //if (!Bag.IsItemInStorage(selectedItem))
                    //{
                    //    Debug.Log("item is not in storage, adding item now");
                    //    uiInventory.curStorageSlots++;
                    //}
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
        else if(!pauseMenu.pauseMenu.activeInHierarchy)
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
                if(vision.collider.tag == "Decompression")
                {
                    vision.collider.GetComponent<TriggerDecompresionChamber>().BeginDecompression();
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
                            Bag.IsInvFull();
                            if (!Bag.invFull || Bag.IsItemInBag(seed))
                            {
                                // cycling through how many seeds to add based on crops seed yield
                                for (int i = 0; i < selectedItem.seedYield; i++)
                                {
                                    Bag.AddItemToInventory(seed);
                                }
                                audioSource.clip = Resources.Load<AudioClip>("PickupSFX");
                                audioSource.Play();
                                Bag.RemoveItemFromInventory(selectedItem);
                            }
                            else
                            {
                                updates.gameObject.SetActive(true);
                                updates.text = "Inventory is full";
                            }
                            // refreshing inventory
                            uiInventory.DrawSlots();

                            // checking if tutorial is needed
                            if (uiTutorial.firstGermination && ui_Tutorial.activeInHierarchy)
                            {
                                uiTutorial.firstGermination = false;
                                uiTutorial.firstCompost = true;
                                uiTutorial.NextTutorial();
                            }
                        }
                        else
                        {
                            updates.gameObject.SetActive(true);
                            updates.text = "Item is not a crop";
                        }
                    }
                }
                if (vision.collider.tag == "Storage")
                {
                    uiInventory.ActivateStorageMenu();
                    //mouseIndicator.gameObject.SetActive(false);
                    uiInventory.DrawSupplySlots();
                    leftAnim.gameObject.GetComponent<Image>().color = new Color(leftAnim.gameObject.GetComponent<Image>().color.r, leftAnim.gameObject.GetComponent<Image>().color.b, leftAnim.gameObject.GetComponent<Image>().color.g, 0f);
                    rightAnim.gameObject.GetComponent<Image>().color = new Color(rightAnim.gameObject.GetComponent<Image>().color.r, rightAnim.gameObject.GetComponent<Image>().color.b, rightAnim.gameObject.GetComponent<Image>().color.g, 0f);
                    upAnim.gameObject.GetComponent<Image>().color = new Color(upAnim.gameObject.GetComponent<Image>().color.r, upAnim.gameObject.GetComponent<Image>().color.b, upAnim.gameObject.GetComponent<Image>().color.g, 0f);
                    downAnim.gameObject.GetComponent<Image>().color = new Color(downAnim.gameObject.GetComponent<Image>().color.r, downAnim.gameObject.GetComponent<Image>().color.b, downAnim.gameObject.GetComponent<Image>().color.g, 0f);
                }
                if (vision.collider.tag == "Compost")
                {
                    if (selectedItem != null)
                    {
                        if (selectedItem.isCrop)
                        {
                            // storing how much fertilizer to add to inventory
                            int fertilizerCnt = selectedItem.fertilizerYield;
                            // getting fertilizer ref
                            BagItem fertilizer = Resources.Load<BagItem>("Fertilizer");
                            Bag.IsInvFull();
                            if (!Bag.invFull || Bag.IsItemInBag(fertilizer))
                            {
                                // cycling through how much fertilizer to add
                                for (int i = 0; i < fertilizerCnt; i++)
                                {
                                    Bag.AddItemToInventory(fertilizer);
                                }
                                audioSource.clip = Resources.Load<AudioClip>("PickupSFX");
                                audioSource.Play();
                                Bag.RemoveItemFromInventory(selectedItem);
                            }
                            else
                            {
                                updates.gameObject.SetActive(true);
                                updates.text = "Inventory is full";
                            }

                            // refreshing inventory
                            uiInventory.DrawSlots();

                            // checking if tutorial is needed
                            if (uiTutorial.firstCompost && ui_Tutorial.activeInHierarchy)
                            {
                                uiTutorial.firstCompost = false;
                                uiTutorial.firstConsume = true;
                                uiTutorial.NextTutorial();
                            }
                        }
                        else
                        {
                            updates.gameObject.SetActive(true);
                            updates.text = "Item is not a crop";
                        }
                    }
                }
                if (vision.collider.tag == "AlienFruit")
                {
                    Bag.IsInvFull();
                    BagItem AlienFruit = Resources.Load<BagItem>("AlienFruit");
                    if (!Bag.invFull || Bag.IsItemInBag(AlienFruit))
                    {
                        vision.collider.gameObject.SetActive(false);
                        
                        for (int i = 0; i < AlienFruit.cropYield; i++)
                        {
                            Bag.AddItemToInventory(AlienFruit);
                        }
                        audioSource.clip = Resources.Load<AudioClip>("PickupSFX");
                        audioSource.Play();
                        // refreshing inventory
                        uiInventory.DrawSlots();
                    }
                    else
                    {
                        updates.gameObject.SetActive(true);
                        updates.text = "Inventory is full";
                    }
                }
                if(vision.collider.tag == "RockPlant")
                {
                    BagItem rockFruit = Resources.Load<BagItem>("RockFruit");
                    Bag.IsInvFull();
                    if (!Bag.invFull || Bag.IsItemInBag(rockFruit))
                    {
                        vision.collider.gameObject.SetActive(false);
                        
                        for (int i = 0; i < rockFruit.cropYield; i++)
                        {
                            Bag.AddItemToInventory(rockFruit);
                        }
                        audioSource.clip = Resources.Load<AudioClip>("PickupSFX");
                        audioSource.Play();
                        // refreshing inventory
                        uiInventory.DrawSlots();
                    }
                    else
                    {
                        updates.gameObject.SetActive(true);
                        updates.text = "Inventory is full";
                    }
                }
                if(vision.collider.tag == "FloatFruit")
                {
                    BagItem floatFruit = Resources.Load<BagItem>("FloatFruit");
                    Bag.IsInvFull();
                    if (!Bag.invFull || Bag.IsItemInBag(floatFruit))
                    {
                        vision.collider.gameObject.SetActive(false);
                        
                        for (int i = 0; i < floatFruit.cropYield; i++)
                        {
                            Bag.AddItemToInventory(floatFruit);
                        }
                        audioSource.clip = Resources.Load<AudioClip>("PickupSFX");
                        audioSource.Play();
                        // refreshing inventory
                        uiInventory.DrawSlots();
                    }
                    else
                    {
                        updates.gameObject.SetActive(true);
                        updates.text = "Inventory is full";
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
                if (uiTutorial.firstSelectionChange && ui_Tutorial.activeInHierarchy)
                {
                    selectedItem = Bag.slots[uiInventory.curInvSlot].itemRef;
                    if (selectedItem.isFertilizer)
                    {
                        uiTutorial.firstSelectionChange = false;
                        uiTutorial.firstTill = true;
                        uiTutorial.NextTutorial();
                    }
                }
            }
            else
            {
                uiInventory.curInvSlot = 0;
                uiInventory.InventorySelection();
                if (uiTutorial.firstSelectionChange && ui_Tutorial.activeInHierarchy)
                {
                    selectedItem = Bag.slots[uiInventory.curInvSlot].itemRef;
                    if (selectedItem.isFertilizer)
                    {
                        uiTutorial.firstSelectionChange = false;
                        uiTutorial.firstTill = true;
                        uiTutorial.NextTutorial();
                    }
                }
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
                if (uiTutorial.firstSelectionChange && ui_Tutorial.activeInHierarchy)
                {
                    selectedItem = Bag.slots[uiInventory.curInvSlot].itemRef;
                    if (selectedItem.isFertilizer)
                    {
                        uiTutorial.firstSelectionChange = false;
                        uiTutorial.firstTill = true;
                        uiTutorial.NextTutorial();
                    }
                }
            }
            else
            {
                uiInventory.curInvSlot = Bag.slots.Length - 1;
                uiInventory.InventorySelection();
                if (uiTutorial.firstSelectionChange && ui_Tutorial.activeInHierarchy)
                {
                    selectedItem = Bag.slots[uiInventory.curInvSlot].itemRef;
                    if (selectedItem.isFertilizer)
                    {
                        uiTutorial.firstSelectionChange = false;
                        uiTutorial.firstTill = true;
                        uiTutorial.NextTutorial();

                    }
                }
            }
        }

    }

    //sprint functions
    void Sprint()
    {
        movementSpeed = 14;
    }

    void SprintReleased()
    {
        movementSpeed = 7;
        if (uiTutorial.firstOxygen && ui_Tutorial.activeInHierarchy)
        {
            uiTutorial.firstOxygen = false;
            uiTutorial.firstOxygenPlant = true;
            uiTutorial.NextTutorial();
        }
    }


    //jetpacking functions
    void Jetpack()
    {
        if (jetpackActive)
        {
            jump = true;
            audioSource.clip = Resources.Load<AudioClip>("JetpackSFX");
            audioSource.volume = 0.47f;
            audioSource.loop = true;
            audioSource.Play();
        }
        else
        {
            updates.gameObject.SetActive(true);
            updates.text = "Jetpack is not active while inside";
        }
    }
    
    void JetpackReleased()
    {
        jump = false;
        audioSource.loop = false;
        audioSource.Pause();
        if (uiTutorial.firstSprint)
        {
            uiTutorial.firstSprint = false;
            uiTutorial.firstOxygen = true;
            uiTutorial.NextTutorial();
        }
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
                audioSource.clip = Resources.Load<AudioClip>("eatSFX");
                audioSource.volume = 1;
                audioSource.Play();
                if (uiTutorial.firstConsume && ui_Tutorial.activeInHierarchy)
                {
                    uiTutorial.firstConsume = false;
                    uiTutorial.firstStorage = true;
                    uiTutorial.NextTutorial();
                }
            }
            else
            {
                updates.gameObject.SetActive(true);
                updates.text = "You aren't hungry right now";
            }


        }
        else
        {
            updates.gameObject.SetActive(true);
            updates.text = "Item is not a crop";
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

    public void ExitMenu()
    {
        if (uiInventory.supplyMenuActive)
        {
            uiInventory.DeactivateStorageMenu();
            uiInventory.inSupplyMenu = false;
            uiInventory.curInvSlot = 0;
            uiInventory.InventorySelection();
            leftAnim.gameObject.GetComponent<Image>().color = new Color(leftAnim.gameObject.GetComponent<Image>().color.r, leftAnim.gameObject.GetComponent<Image>().color.b, leftAnim.gameObject.GetComponent<Image>().color.g, 1f);
            rightAnim.gameObject.GetComponent<Image>().color = new Color(rightAnim.gameObject.GetComponent<Image>().color.r, rightAnim.gameObject.GetComponent<Image>().color.b, rightAnim.gameObject.GetComponent<Image>().color.g, 1f);
            upAnim.gameObject.GetComponent<Image>().color = new Color(upAnim.gameObject.GetComponent<Image>().color.r, upAnim.gameObject.GetComponent<Image>().color.b, upAnim.gameObject.GetComponent<Image>().color.g, 1f);
            downAnim.gameObject.GetComponent<Image>().color = new Color(downAnim.gameObject.GetComponent<Image>().color.r, downAnim.gameObject.GetComponent<Image>().color.b, downAnim.gameObject.GetComponent<Image>().color.g, 1f);
            if (uiTutorial.firstStorage || uiTutorial.firstStoragePickup)
            {
                tutorialTrigger2.SetActive(true);
            }
        }
        else
        {
            if (pauseMenu.playerHud.activeInHierarchy)
            {
                pauseMenu.PauseGame();
                leftAnim.gameObject.GetComponent<Image>().color = new Color(leftAnim.gameObject.GetComponent<Image>().color.r, leftAnim.gameObject.GetComponent<Image>().color.b, leftAnim.gameObject.GetComponent<Image>().color.g, 0f);
                rightAnim.gameObject.GetComponent<Image>().color = new Color(rightAnim.gameObject.GetComponent<Image>().color.r, rightAnim.gameObject.GetComponent<Image>().color.b, rightAnim.gameObject.GetComponent<Image>().color.g, 0f);
                upAnim.gameObject.GetComponent<Image>().color = new Color(upAnim.gameObject.GetComponent<Image>().color.r, upAnim.gameObject.GetComponent<Image>().color.b, upAnim.gameObject.GetComponent<Image>().color.g, 0f);
                downAnim.gameObject.GetComponent<Image>().color = new Color(downAnim.gameObject.GetComponent<Image>().color.r, downAnim.gameObject.GetComponent<Image>().color.b, downAnim.gameObject.GetComponent<Image>().color.g, 0f);
            }
            else
            {
                pauseMenu.ResumeGame();
                leftAnim.gameObject.GetComponent<Image>().color = new Color(leftAnim.gameObject.GetComponent<Image>().color.r, leftAnim.gameObject.GetComponent<Image>().color.b, leftAnim.gameObject.GetComponent<Image>().color.g, 1f);
                rightAnim.gameObject.GetComponent<Image>().color = new Color(rightAnim.gameObject.GetComponent<Image>().color.r, rightAnim.gameObject.GetComponent<Image>().color.b, rightAnim.gameObject.GetComponent<Image>().color.g, 1f);
                upAnim.gameObject.GetComponent<Image>().color = new Color(upAnim.gameObject.GetComponent<Image>().color.r, upAnim.gameObject.GetComponent<Image>().color.b, upAnim.gameObject.GetComponent<Image>().color.g, 1f);
                downAnim.gameObject.GetComponent<Image>().color = new Color(downAnim.gameObject.GetComponent<Image>().color.r, downAnim.gameObject.GetComponent<Image>().color.b, downAnim.gameObject.GetComponent<Image>().color.g, 1f);
            }
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
