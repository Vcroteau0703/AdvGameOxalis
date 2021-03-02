using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SupplyGoals : MonoBehaviour
{
    Slider supplySlider;
    int goalCompletionCount = 0;
    private UI_Inventory uiInventory;
    public GameObject ui_Inventory;

    private void Awake()
    {
        supplySlider = GetComponent<Slider>();
        // getting ui invetory script ref
        uiInventory = ui_Inventory.GetComponent<UI_Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if(supplySlider.maxValue == supplySlider.value)
        {
            //give reward and hint!!
            Reward();
            //Make new goal harder
            ChangeGoal();
        }
    }

    public void ChangeGoal()
    {
        goalCompletionCount++;
        supplySlider.maxValue = supplySlider.maxValue * 1.5f;
        supplySlider.value = 0;
    }

    public void GameCompletion()
    {
        //call when final goal is reached and complete the game!!
    }

    public void Reward()
    {
        switch (goalCompletionCount)
        {
            case 0:
                BagItem orangeSeeds = Resources.Load<BagItem>("Orange Seeds");
                Bag.AddItemToInventory(orangeSeeds);
                Bag.AddItemToInventory(orangeSeeds);
                Bag.AddItemToInventory(orangeSeeds);
                uiInventory.DrawSlots();
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }

    }
}
