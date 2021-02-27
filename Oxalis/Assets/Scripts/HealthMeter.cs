using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthMeter : MonoBehaviour
{
    Slider healthSlider;
    float curHealth;
    float healthVal;
    float fillSpeed = 1f;

    public GameObject deathScreen;
    PlayerDeath playerDeath;

    // Start is called before the first frame update
    void Start()
    {
        healthSlider = GetComponent<Slider>();
        curHealth = healthVal = healthSlider.value;
        playerDeath = deathScreen.GetComponent<PlayerDeath>();
    }

    // Update is called once per frame
    void Update()
    {
        if(healthVal == 0)
        {
            //player dies
            StartCoroutine(playerDeath.FadeInDeathScreen());
            //reset health
            healthVal = 100;
        }

        curHealth = Mathf.Lerp(curHealth, healthVal, Time.deltaTime * fillSpeed);

        healthSlider.value = curHealth;
    }

    public void DecreaseHealth(int amount)
    {
        healthVal -= amount;
    }

    public void IncreaseHealth(int amount)
    {
        healthVal += amount;
    }
}
