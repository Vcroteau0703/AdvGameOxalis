using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                audioSource.clip = Resources.Load<AudioClip>("PlantingSFX");
                audioSource.Play();
                if (uiTutorial.firstTill && ui_Tutorial.activeInHierarchy)
                {
                    uiTutorial.firstTill = false;
                    uiTutorial.NextTutorial();
                }
                break;
            case 1:
                Plant(selectedItem);
                audioSource.Play();
                if (uiTutorial.firstPlant && ui_Tutorial.activeInHierarchy)
                {
                    uiTutorial.firstPlant = false;
                    uiTutorial.NextTutorial();
                }
                break;
            case 2:
                Water();
                audioSource.clip = Resources.Load<AudioClip>("WaterSFX");
                audioSource.Play();
                break;
            case 3:
                Harvest();
                audioSource.clip = Resources.Load<AudioClip>("PickupSFX");
                audioSource.Play();
                if (uiTutorial.firstHarvest && ui_Tutorial.activeInHierarchy)
                {
                    uiTutorial.firstHarvest = false;
                    uiTutorial.NextTutorial();
                }
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
            }
            else
            {
                Debug.Log("Item is not fertilizer!");
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
            }
            else
            {
                Debug.Log("Selected Item is not a seed!!");
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
        for(int i = 0; i < cropYield; i++)
        {
            Bag.AddItemToInventory(crop);
        }
        Destroy(plant);
        rend.material = unTilledGround;
        plantState = 0;
    }
}
