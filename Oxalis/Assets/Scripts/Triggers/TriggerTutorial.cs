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
            if(uiTutorial.firstTutorial && ui_Tutorial.activeInHierarchy)
            {
                uiTutorial.firstSelectionChange = true;
                uiTutorial.firstTutorial = false;
                uiTutorial.NextTutorial();
                Destroy(gameObject);
            }
            else if(uiTutorial.firstStorage && ui_Tutorial.activeInHierarchy)
            {
                uiTutorial.firstStoragePickup = true;
                uiTutorial.firstStorage = false;
                uiTutorial.NextTutorial();
                gameObject.SetActive(false);
            }
            else if(uiTutorial.firstStoragePickup && ui_Tutorial.activeInHierarchy)
            {
                uiTutorial.firstDecompression = true;
                uiTutorial.firstStoragePickup = false;
                uiTutorial.NextTutorial();
                Destroy(gameObject);
            }
            else if(uiTutorial.firstDecompression && ui_Tutorial.activeInHierarchy)
            {
                uiTutorial.firstDecompression = false;
                uiTutorial.firstJetpack = true;
                uiTutorial.NextTutorial();
                Destroy(gameObject);
            }
            else if(uiTutorial.firstJetpack && ui_Tutorial.activeInHierarchy)
            {
                uiTutorial.firstJetpack = false;
                uiTutorial.firstSprint = true;
                uiTutorial.NextTutorial();
                Destroy(gameObject);
            }
        }
    }
}
