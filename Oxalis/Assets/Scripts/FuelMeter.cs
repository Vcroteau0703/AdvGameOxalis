using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelMeter : MonoBehaviour
{
    Slider fuelSlider;
    float fillSpeed = 1f;
    public float curFuel;
    public float fuelVal;
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        fuelSlider = GetComponent<Slider>();

        curFuel = fuelVal = fuelSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        curFuel = Mathf.Lerp(curFuel, fuelVal, Time.deltaTime * fillSpeed);

        fuelSlider.value = curFuel;
    }

    public void DepleteFuel()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            timer = 1f;
            fuelVal -= 10;
        }
    }
    public void IncreaseFuel()
    {
        fuelVal = 100;
    }
}
