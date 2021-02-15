using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    public BagItem myItem;
    public BagItem otherItem;
    public int curInvSlot = 0;

    private void Start()
    {
        Bag.InitInventory();
        Bag.AddItemToInventory(myItem);
        Bag.AddItemToInventory(myItem);
        otherItem = Resources.Load<BagItem>("Fertilizer");
        Bag.AddItemToInventory(otherItem);
        Bag.AddItemToInventory(otherItem);
        Bag.AddItemToInventory(otherItem);
        //Bag.AddItemToInventory(myItem);
        //Bag.AddItemToInventory(myItem);

        DrawSlots();
        InventorySelection();
    }

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

    public void InventorySelection()
    {
        Image slotBorder;

        for(int i = 0; i < Bag.slots.Length; i++)
        {
            if(i != curInvSlot)
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
