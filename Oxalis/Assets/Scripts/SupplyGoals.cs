using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SupplyGoals : MonoBehaviour
{
    Slider supplySlider;
    int goalCompletionCount = 0;

    private void Awake()
    {
        supplySlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(supplySlider.maxValue == supplySlider.value)
        {
            //give reward and hint!!

            //Make new goal harder
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
}
