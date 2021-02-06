using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowPlant : MonoBehaviour
{
    public Material WateredGround;
    public GameObject plant;
    Renderer rend;

    private void Awake()
    {
         rend = GetComponent<Renderer>();
    }

    public void Grow()
    {
        rend.material = WateredGround;
        plant.GetComponent<Animator>().SetTrigger("Planted");
    }
}
