using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    public Transform itemSlotContainer;
    public Transform itemSlotTemplate;
    public BagItem myItem;

    private void Start()
    {
        Bag.InitInventory();
        //Bag.AddItemToInventory(myItem);
        //Bag.AddItemToInventory(myItem);
        //Bag.AddItemToInventory(myItem);
        //Bag.AddItemToInventory(myItem);
        //Debug.Log(Bag.slots[0].itemRef.crop);
        //Debug.Log(Bag.slots[0].itemRef.growTime);
        //Debug.Log(Bag.slots[0].itemRef.supplyYield);
        //Debug.Log(Bag.slots[0].quantity);
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        //RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        int y = 0;
        int x = 0;
        float itemSlotCellSize = 30f;
        foreach(Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            x++;
            if(x > 2)
            {
                Debug.Log("Inventory Full!");
            }
        }
    }
}
