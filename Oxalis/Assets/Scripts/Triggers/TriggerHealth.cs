using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerHealth : MonoBehaviour
{
    public HealthMeter healthSlider;
    public bool sound = false;
    AudioSource audioSource;

    float timer = 0.0f;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (sound)
        {
            timer += Time.deltaTime;
            if(timer > 4f)
            {
                sound = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        healthSlider.DecreaseHealth(10);
        if (!sound)
        {
            sound = true;
            audioSource.Play();
        }
    }
}
