using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTutorial : MonoBehaviour
{
    private UI_Tutorial uiTutorial;
    public GameObject ui_Tutorial;

    private void Awake()
    {
        uiTutorial = ui_Tutorial.GetComponent<UI_Tutorial>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            uiTutorial.NextTutorial();
            Destroy(gameObject);
        }
    }
}
