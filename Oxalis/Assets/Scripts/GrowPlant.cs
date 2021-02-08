using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowPlant : MonoBehaviour
{
    public Material wateredGround;
    public Material dryGround;
    public GameObject plant;
    Renderer rend;

    public int plantState = 2;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    public void FarmMechanic()
    {
        switch (plantState)
        {
            case 0:
                Till();
                break;
            case 1:
                Plant();
                break;
            case 2:
                Water();
                break;
            case 3:
                Harvest();
                break;
            default:
                Debug.Log("there was a problem :/");
                break;
        }
    }

    private void Till()
    {
        //till the soil for planting
    }

    private void Plant()
    {
        //plant the selected seed
    }

    private void Water()
    {
        rend.material = wateredGround;
        plantState++;
        Grow();
    }

    private void Grow()
    {
        plant.GetComponent<Animator>().SetTrigger("Planted");
    }

    private void Harvest()
    {
        //harvest the plant when fully grown
        Destroy(plant);
        rend.material = dryGround;
        plantState = 2;
    }
}
