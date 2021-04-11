using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDecompresionChamber : MonoBehaviour
{
    public Animator insideDoor;
    public Animator outsideDoor;
    public GameObject decompressionTrigger;
    public bool inside = true;

    public void BeginDecompression()
    {
        if (inside)
        {
            gameObject.tag = "Untagged";
            StartCoroutine(CloseChamberFromInside());
            inside = false;
        }
        else
        {
            gameObject.tag = "Untagged";
            StartCoroutine(CloseChamberFromOutside());
            inside = true;
        }
    }

    IEnumerator CloseChamberFromInside()
    {
        insideDoor.SetTrigger("DoorClose");
        yield return new WaitForSeconds(2f);
        //decompressionTrigger.SetActive(false);
        OpenChamberOutside();
    }
    IEnumerator CloseChamberFromOutside()
    {
        outsideDoor.SetTrigger("CloseDoor");
        yield return new WaitForSeconds(2f);
        //decompressionTrigger.SetActive(true);
        OpenChamberInside();
    }


    void OpenChamberOutside()
    {
        outsideDoor.SetTrigger("OpenDoor");
        gameObject.tag = "Decompression";
    }

    void OpenChamberInside()
    {
        insideDoor.SetTrigger("DoorOpen");
        gameObject.tag = "Decompression";
    }
}
