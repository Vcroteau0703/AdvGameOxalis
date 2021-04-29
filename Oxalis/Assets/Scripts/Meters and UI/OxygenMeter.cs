using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OxygenMeter : MonoBehaviour
{
    public float timer = 5;
    public Slider oxygenSlider;
    public float fillSpeed = 1f;
    public float curOxygen;
    public float oxygenVal;
    public bool depleteOxygen = false;
    float timerVal = 5f;
    // ref health
    public GameObject health;
    HealthMeter healthMeter;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        oxygenSlider = GetComponent<Slider>();
        healthMeter = health.GetComponent<HealthMeter>();
        curOxygen = oxygenVal = oxygenSlider.value;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.0f && depleteOxygen)
        {
            timer = timerVal;
            OxygenDeplete();
        }
        else if(!depleteOxygen && oxygenSlider.value < 100)
        {
            OxygenRegen();
        }

        curOxygen = Mathf.Lerp(curOxygen, oxygenVal, Time.deltaTime * fillSpeed);

        oxygenSlider.value = curOxygen;
        if(curOxygen >= 99)
        {
            audioSource.Stop();
        }
    }

    public void OxygenDeplete()
    {
        if(oxygenVal > 0)
        {
            oxygenVal -= 5f;
            if(oxygenVal == 0)
            {
                timerVal = 1f;
                timer = timerVal;
            }
        }
        else if(!healthMeter.playerDead)
        {
            healthMeter.DecreaseHealth(10);
            //put hit/choking sfx here
        }
    }

    public void OxygenRegen()
    {
        if(oxygenVal < 100f)
        {
            audioSource.Play();
        }
        oxygenVal = 100f;
        timerVal = 5f;
        timer = timerVal;
    }
}
