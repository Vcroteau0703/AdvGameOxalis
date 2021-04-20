using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SupplyGoals : MonoBehaviour
{
    public Slider supplySlider;
    public Slider localSupplySlider;
    int goalCompletionCount = 0;
    private UI_Inventory uiInventory;
    public GameObject ui_Inventory;
    Image rewardImage;
    Image localRewardImage;
    public Sprite plotImage;
    public Transform farm;
    GameObject unlockPlot;
    int plotNum = 1;
    BagItem seedReward;
    public TextMeshProUGUI updates;

    //audio
    AudioSource audioSource;
    AudioClip currentSFX;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        currentSFX = Resources.Load<AudioClip>("PickupSFX");
        audioSource.clip = currentSFX;

        supplySlider = GetComponent<Slider>();

        // getting ui invetory script ref
        uiInventory = ui_Inventory.GetComponent<UI_Inventory>();

        // accessing farm plots
        unlockPlot = farm.GetChild(plotNum).gameObject;

        // getting image and first reward ref
        seedReward = Resources.Load<BagItem>("Orange Seeds");

        rewardImage = transform.GetChild(3).GetComponent<Image>();
        rewardImage.sprite = plotImage;
        localRewardImage = localSupplySlider.transform.GetChild(3).GetComponent<Image>();
        localRewardImage.sprite = plotImage;
    }

    // Update is called once per frame
    void Update()
    {

        if(supplySlider.maxValue <= supplySlider.value)
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
        localSupplySlider.maxValue = supplySlider.maxValue;
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
                updates.gameObject.SetActive(true);
                updates.text = "New planters unlocked!";
                unlockPlot.SetActive(true);
                plotNum++;
                rewardImage.sprite = seedReward.Image;
                localRewardImage.sprite = seedReward.Image;
                break;
            case 1:
                updates.gameObject.SetActive(true);
                updates.text = "Orange seeds unlocked!";
                Bag.AddItemToInventory(seedReward);
                Bag.AddItemToInventory(seedReward);
                Bag.AddItemToInventory(seedReward);
                uiInventory.DrawSlots();
                audioSource.Play();
                rewardImage.sprite = plotImage;
                localRewardImage.sprite = plotImage;
                break;
            case 2:
                unlockPlot = farm.GetChild(plotNum).gameObject;
                updates.gameObject.SetActive(true);
                updates.text = "New planters unlocked!";
                unlockPlot.SetActive(true);
                plotNum++;
                break;
            case 3:
                unlockPlot = farm.GetChild(plotNum).gameObject;
                updates.gameObject.SetActive(true);
                updates.text = "New planters unlocked!";
                unlockPlot.SetActive(true);
                plotNum++;
                break;
            case 4:
                Debug.Log("Game completion!");
                break;
        }

    }
}
