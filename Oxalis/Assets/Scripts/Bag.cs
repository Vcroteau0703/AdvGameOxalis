using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Bag 
{
    public static BagItemSlot[] slots;
    
    public static void InitInventory()
    {
        //initializing item slots
        slots = new BagItemSlot[4];
    }

    public static void AddItemToInventory(BagItem itemToAdd)
    {
        //Check if item is already in the inventory
        bool itemIn = false;
        int itemPos = 0;
        for(int i = 0; i < slots.Length; i++)
        {
            if(itemToAdd == slots[i].itemRef)
            {
                itemIn = true;
                itemPos = i;
                break;
            }
        }
        //add to the item quantity if the item in already in the inventory
        if (itemIn)
        {
            slots[itemPos].quantity++;
        }
        //add item to inventory if the item is not already in the inventory
        else
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if(slots[i].itemRef == null)
                {
                    slots[i].itemRef = itemToAdd;
                    slots[i].quantity = 1;
                    break;
                }
            }
        }

    }
}
