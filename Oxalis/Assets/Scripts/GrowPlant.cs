using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrowPlant : MonoBehaviour
{
    public Material unTilledGround;
    public Material wateredGround;
    public Material dryGround;
    public GameObject plant;
    Renderer rend;

    public int plantState = 0;
    public BagItem crop;
    public string plantedCropName;
    public int cropYield;

    //get ui_tutorial
    public GameObject ui_Tutorial;
    private UI_Tutorial uiTutorial;

    //SFX
    AudioSource audioSource;

    public TextMeshProUGUI updates;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        uiTutorial = ui_Tutorial.GetComponent<UI_Tutorial>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(plant != null)
        {
            if (plant.GetComponent<FinishGrowing>().grown)
            {
                plant.GetComponent<FinishGrowing>().grown = false;
                plantState++;
                if (uiTutorial.firstWater && ui_Tutorial.activeInHierarchy)
                {
                    uiTutorial.firstWater = false;
                    uiTutorial.firstHarvest = true;
                    uiTutorial.NextTutorial();
                }
            }
        }
    }
    public void FarmMechanic(BagItem selectedItem)
    {
        switch (plantState)
        {
            case 0:
                Till(selectedItem);
                break;
            case 1:
                Plant(selectedItem);
                break;
            case 2:
                Water();
                audioSource.clip = Resources.Load<AudioClip>("WaterSFX");
                audioSource.Play();
                break;
            case 3:
                Harvest();
                break;
            default:
                Debug.Log("there was a problem :/");
                break;
        }
    }

    private void Till(BagItem selectedItem)
    {
        if(selectedItem != null)
        {
            //till the soil for planting
            if (selectedItem.isFertilizer)
            {
                Bag.RemoveItemFromInventory(selectedItem);
                rend.material = dryGround;
                plantState++;
                audioSource.clip = Resources.Load<AudioClip>("PlantingSFX");
                audioSource.Play();
                if (uiTutorial.firstTill && ui_Tutorial.activeInHierarchy)
                {
                    uiTutorial.firstTill = false;
                    uiTutorial.firstPlant = true;
                    uiTutorial.NextTutorial();
                }
            }
            else
            {
                updates.gameObject.SetActive(true);
                updates.text = "Selected item is not fertilizer";
            }
        }
    }

    private void Plant(BagItem selectedItem)
    {
        //check if selected item is a seed
        if(selectedItem != null)
        {
            if (selectedItem.isSeed)
            {
                //plant the selected seed
                plantedCropName = selectedItem.crop; //storing the name of the crop that needs to grow
                crop = Resources.Load<BagItem>(plantedCropName); //getting the reference to that crop from the resources folder
                cropYield = crop.cropYield; //storing the number of crops to give the player upon harvest
                Bag.RemoveItemFromInventory(selectedItem);
                Vector3 plantTransform = new Vector3(0, 0.495f, 0);

                plant = Instantiate(crop.plant, transform, false) as GameObject;

                plantState++;

                audioSource.Play();
                if (uiTutorial.firstPlant && ui_Tutorial.activeInHierarchy)
                {
                    uiTutorial.firstPlant = false;
                    uiTutorial.firstWater = true;
                    uiTutorial.NextTutorial();
                }
            }
            else
            {
                updates.gameObject.SetActive(true);
                updates.text = "Selected item is not a seed";
            }
        }

    }

    private void Water()
    {
        //Water the plant
        rend.material = wateredGround;
        Grow();
    }

    private void Grow()
    {
        plant.GetComponent<Animator>().SetTrigger("Planted");

    }

    private void Harvest()
    {
        //harvest the plant when fully grown
        Bag.IsInvFull();
        if (!Bag.invFull)
        {
            for (int i = 0; i < cropYield; i++)
            {
                Bag.AddItemToInventory(crop);
            }
            Destroy(plant);
            rend.material = unTilledGround;
            plantState = 0;
            audioSource.clip = Resources.Load<AudioClip>("PickupSFX");
            audioSource.Play();
            if (uiTutorial.firstHarvest && ui_Tutorial.activeInHierarchy)
            {
                uiTutorial.firstHarvest = false;
                uiTutorial.firstGermination = true;
                uiTutorial.NextTutorial();
            }
        }
        else
        {
            updates.gameObject.SetActive(true);
            updates.text = "Inventory is full";
        }
    }
}
