using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthMeter : MonoBehaviour
{
    Slider healthSlider;
    public float curHealth;
    public float healthVal;
    float fillSpeed = 2f;
    public bool playerDead = false;
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
        if(curHealth <= 0 && !playerDead)
        {
            playerDead = true;
            //player dies
            StartCoroutine(playerDeath.FadeDeathScreen());

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
