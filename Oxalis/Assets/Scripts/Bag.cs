using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Bag 
{
    public static BagItemSlot[] slots;
    public static BagItemSlot[] supplySlots;
    public static bool invFull;
    
    public static void InitInventory()
    {
        //initializing item slots
        slots = new BagItemSlot[5];
        supplySlots = new BagItemSlot[10];
    }

    public static void AddItemToInventory(BagItem itemToAdd)
    {
        //Check if item is already in the inventory
        bool itemIn = false;
        bool itemAdded = false;
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
            invFull = false;
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
                    itemAdded = true;
                    break;
                }
            }
        }
    }

    public static void RemoveItemFromInventory(BagItem itemToRemove)
    {
        //Check if item is in the invetory
        bool itemIn = false;
        int itemPos = 0;
        for(int i = 0; i < slots.Length; i++)
        {
            if(itemToRemove == slots[i].itemRef)
            {
                itemIn = true;
                itemPos = i;
                break;
            }
        }
        //lower the item quantity if the item is in the inventory or remove the item if it is the last one
        if (itemIn)
        {
            if (slots[itemPos].quantity > 1)
            {
                slots[itemPos].quantity--;
            }
            else
            {
                if (invFull)
                {
                    invFull = false;
                }
                slots[itemPos].itemRef = default;
                slots[itemPos].quantity = 0;
            }

        }
    }

    public static void AddItemToStorage(BagItem itemToAdd)
    {
        // check if item already in
        bool itemIn = false;
        int itemPos = 0;
        for(int i = 0; i < supplySlots.Length; i++)
        {
            if(itemToAdd == supplySlots[i].itemRef)
            {
                itemIn = true;
                itemPos = i;
                break;
            }
        }
        if (itemIn)
        {
            supplySlots[itemPos].quantity++;
        }
        else
        {
            for (int i = 0; i < supplySlots.Length; i++)
            {
                if (supplySlots[i].itemRef == null)
                {
                    supplySlots[i].itemRef = itemToAdd;
                    supplySlots[i].quantity = 1;
                    supplySlots[i].worth = itemToAdd.supplyYield;
                    break;
                }
            }
        }
    }

    public static void RemoveItemFromStorage(BagItem itemToRemove)
    {
        //Check if item is in the invetory
        bool itemIn = false;
        int itemPos = 0;
        for (int i = 0; i < supplySlots.Length; i++)
        {
            if (itemToRemove == supplySlots[i].itemRef)
            {
                itemIn = true;
                itemPos = i;
                break;
            }
        }
        //lower the item quantity if the item is in the inventory or remove the item if it is the last one
        if (itemIn)
        {
            if (supplySlots[itemPos].quantity > 1)
            {
                supplySlots[itemPos].quantity--;
            }
            else
            {
                supplySlots[itemPos].itemRef = default;
                supplySlots[itemPos].quantity = 0;
            }

        }
    }

    public static bool IsItemInStorage(BagItem itemToCheck)
    {
        bool itemIn = false;
        for (int i = 0; i < supplySlots.Length; i++)
        {
            if (itemToCheck == supplySlots[i].itemRef)
            {
                itemIn = true;
                break;
            }
        }
        if (itemIn)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void IsInvFull()
    {
        int counter = 0;
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].itemRef != null)
            {
                counter++;
            }

        }
        if (counter == 5)
        {
            invFull = true;
        }
        else
        {
            invFull = false;
        }
    }
}
