using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerMeter : MonoBehaviour
{
    Slider hungerSlider;
    public float curHunger;
    public float hungerVal;
    float fillSpeed = 1f;
    public float timer = 20f;
    float timerVal = 20f;

    //ref health
    public GameObject health;
    HealthMeter healthMeter;
    public GameObject warning;

    // Start is called before the first frame update
    void Start()
    {
        hungerSlider = GetComponent<Slider>();
        curHunger = hungerVal = hungerSlider.value;
        healthMeter = health.GetComponent<HealthMeter>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            timer = timerVal;
            DecreaseHunger(5);
        }

        curHunger = Mathf.Lerp(curHunger, hungerVal, Time.deltaTime * fillSpeed);

        hungerSlider.value = curHunger;
    }

    public void DecreaseHunger(int amount)
    {
        if(hungerVal > 0)
        {
            hungerVal -= amount;
            if (hungerVal == 0)
            {
                timerVal = 1f;
                timer = timerVal;
            }
            else if(timerVal == 1f)
            {
                timerVal = 20f;
                timer = timerVal;
            }
            else if (hungerVal < 25)
            {
                warning.SetActive(true);
            }
        }
        else if (!healthMeter.playerDead)
        {
            healthMeter.DecreaseHealth(10);
            //put starving sfx or smthin?
        }

    }
    
    public void IncreaseHunger(int amount)
    {
        hungerVal += amount;
        if(hungerVal > 25)
        {
            warning.SetActive(false);
        }
    }
}
