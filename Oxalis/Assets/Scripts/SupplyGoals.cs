using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SupplyGoals : MonoBehaviour
{
    public Slider supplySlider;

    int goalCompletionCount = 0;
    private UI_Inventory uiInventory;
    public GameObject ui_Inventory;
    Image rewardImage;
    public Sprite plotImage;
    public Transform farm;
    GameObject unlockPlot;
    int plotNum = 5;
    BagItem seedReward;
    public TextMeshProUGUI updates;
    float timer = 5f;

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
        rewardImage.sprite = seedReward.Image;
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

        if(updates.gameObject.activeInHierarchy)
        {
            timer -= Time.unscaledDeltaTime;
            if (timer < 0)
            {
                updates.gameObject.SetActive(false);
                timer = 5f;
            }
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
                updates.gameObject.SetActive(true);
                updates.text = "Orange seeds unlocked!";
                Bag.AddItemToInventory(seedReward);
                Bag.AddItemToInventory(seedReward);
                Bag.AddItemToInventory(seedReward);
                uiInventory.DrawSlots();
                rewardImage.sprite = plotImage;
                audioSource.Play();
                break;
            case 1:
                updates.gameObject.SetActive(true);
                updates.text = "New planter unlocked!";
                unlockPlot.SetActive(true);
                plotNum++;
                break;
            case 2:
                break;
            case 3:
                break;
        }

    }
}
