using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    public Transform teleportTarget;
    public Animator deathScreen;
    public bool deathScreenUp = false;
    public PlayerController playerController;
    public TriggerDecompresionChamber triggerDecompresionChamber;

    public HealthMeter healthMeter;
    private void Awake()
    {
        deathScreen.SetTrigger("FadeIn");
    }

    public IEnumerator FadeDeathScreen()
    {
        playerController.enabled = false;
        // Transparent to Opaque
        deathScreen.SetTrigger("FadeOut");
        yield return new WaitForSecondsRealtime(3f);
        Teleport();
        healthMeter.healthVal = 100;
        triggerDecompresionChamber.BeginDecompression();
        yield return new WaitForSecondsRealtime(3f);
        // Opaque to Transparent
        deathScreen.SetTrigger("FadeIn");
        healthMeter.playerDead = false;
        playerController.enabled = true;
    }

    public void Teleport()
    {
        playerController.gameObject.transform.position = teleportTarget.transform.position;
    }
}
