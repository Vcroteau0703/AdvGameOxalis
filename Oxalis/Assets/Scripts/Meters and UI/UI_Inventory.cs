using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    public BagItem myItem;
    public BagItem otherItem;
    public int curInvSlot;
    public int numOfSlots;
    public int curStorageSlots;
    // supply inventory 
    Transform supplyInv;

    public bool inSupplyMenu = false;
    public bool supplyMenuActive = false;

    //accessing supply canvas in worldspace
    public GameObject localSupplyCanvas;
    Slider localSupplySlider;
    // supply goals script
    public SupplyGoals supplyGoals;

    private void Start()
    {
        Bag.InitInventory();
        otherItem = Resources.Load<BagItem>("Fertilizer");
        Bag.AddItemToInventory(otherItem);
        Bag.AddItemToInventory(otherItem);
        Bag.AddItemToInventory(otherItem);
        Bag.AddItemToInventory(myItem);
        Bag.AddItemToInventory(myItem);
        numOfSlots = Bag.slots.Length;
        supplyInv = transform.GetChild(5).GetComponent<Transform>();
        curStorageSlots = Bag.supplySlots.Length;
        //otherItem = Resources.Load<BagItem>("Orange");
        //Bag.AddItemToStorage(otherItem);
        //curStorageSlots++;

        DrawSlots();
        DrawSupplySlots();
        InventorySelection();
    }

    // Draws the inventory slots with the correct items and number of items
    public void DrawSlots()
    {
        for(int i = 0; i < Bag.slots.Length; i++)
        {
            Image slotImage;
            Text slotNumber;
            slotImage = transform.GetChild(i).GetChild(0).GetComponent<Image>();
            slotNumber = transform.GetChild(i).GetChild(1).GetComponent<Text>();
            if (Bag.slots[i].quantity != 0)
            {
                slotImage.gameObject.SetActive(true);
                slotNumber.gameObject.SetActive(true);
                slotImage.sprite = Bag.slots[i].itemRef.Image;
                slotNumber.text = Bag.slots[i].quantity.ToString();
            }
            else
            {
                slotImage.gameObject.SetActive(false);
                slotNumber.gameObject.SetActive(false);
            }
        }
    }

    // drawing slots on the supply purchase menu
    public void DrawSupplySlots()
    {
        for(int i = 0; i < Bag.supplySlots.Length; i++)
        {
            Image slotImage;
            Text slotNumberQuantity;
            Text slotNumberPrice;
            slotImage = supplyInv.GetChild(i).GetChild(0).GetComponent<Image>();
            slotNumberQuantity = supplyInv.GetChild(i).GetChild(2).GetComponent<Text>();
            slotNumberPrice = supplyInv.GetChild(i).GetChild(1).GetComponent<Text>();
            if (Bag.supplySlots[i].quantity != 0)
            {
                slotImage.gameObject.SetActive(true);
                slotNumberQuantity.gameObject.SetActive(true);
                slotNumberPrice.gameObject.SetActive(true);
                slotImage.sprite = Bag.supplySlots[i].itemRef.Image;
                slotNumberQuantity.text = Bag.supplySlots[i].quantity.ToString();
                slotNumberPrice.text = Bag.supplySlots[i].worth.ToString();
            }
            else
            {
                slotImage.gameObject.SetActive(false);
                slotNumberQuantity.gameObject.SetActive(false);
                slotNumberPrice.gameObject.SetActive(false);
            }
        }
    }

    // called when changing which inventory item is selected
    public void InventorySelection()
    {
        Image slotBorder;
        if (inSupplyMenu)
        {
            for (int i = 0; i < Bag.slots.Length; i++)
            {
                slotBorder = transform.GetChild(i).GetComponent<Image>();
                slotBorder.color = new Color(slotBorder.color.r, slotBorder.color.g, slotBorder.color.b, 0.5f);
            }

            for (int i = 0; i < curStorageSlots; i++)
            {
                if (i != curInvSlot)
                {
                    slotBorder = supplyInv.GetChild(i).GetComponent<Image>();
                    slotBorder.color = new Color(slotBorder.color.r, slotBorder.color.g, slotBorder.color.b, 0.5f);
                }
                else
                {
                    slotBorder = supplyInv.GetChild(curInvSlot).GetComponent<Image>();
                    slotBorder.color = new Color(slotBorder.color.r, slotBorder.color.g, slotBorder.color.b, 1f);
                }
            }
        }
        else
        {
            if (supplyMenuActive)
            {
                for (int i = 0; i < curStorageSlots; i++)
                {
                    slotBorder = supplyInv.GetChild(i).GetComponent<Image>();
                    slotBorder.color = new Color(slotBorder.color.r, slotBorder.color.g, slotBorder.color.b, 0.5f);
                }

            }
            for (int i = 0; i < Bag.slots.Length; i++)
            {
                if (i != curInvSlot)
                {
                    slotBorder = transform.GetChild(i).GetComponent<Image>();
                    slotBorder.color = new Color(1, 1, 1, 0.5f);
                }
                else
                {
                    slotBorder = transform.GetChild(curInvSlot).GetComponent<Image>();
                    slotBorder.color = new Color(1, 1, 1, 1f);
                }
            }
        }
    }

    // activating storage menu and turning off local storage canvas and pausing the game
    public void ActivateStorageMenu()
    {
        supplyMenuActive = true;
        supplyInv.gameObject.SetActive(true);
        localSupplyCanvas.SetActive(false);
        Time.timeScale = 0;
        InventorySelection();
    }

    // deactivating storage menu, turning on local storage canvas and unpausing the game
    public void DeactivateStorageMenu()
    {
        float curStorageVal = supplyGoals.supplySlider.value;
        supplyMenuActive = false;
        supplyInv.gameObject.SetActive(false);
        localSupplyCanvas.SetActive(true);
        Time.timeScale = 1;
        localSupplySlider = localSupplyCanvas.transform.GetChild(0).GetComponent<Slider>();
        localSupplySlider.value = curStorageVal;
    }
}
