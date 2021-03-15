using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerHealth : MonoBehaviour
{
    public HealthMeter healthSlider;

    private void OnTriggerStay(Collider other)
    {
        healthSlider.DecreaseHealth(10);
    }
}
