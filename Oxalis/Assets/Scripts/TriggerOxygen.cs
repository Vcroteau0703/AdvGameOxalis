using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOxygen : MonoBehaviour
{
    public GameObject oxygen;
    OxygenMeter oxygenMeter;
    // Start is called before the first frame update
    void Start()
    {
        oxygenMeter = oxygen.GetComponent<OxygenMeter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        oxygenMeter.depleteOxygen = false;
    }
    private void OnTriggerExit(Collider other)
    {
        oxygenMeter.depleteOxygen = true;
    }
}
