using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject player;
    Image deathScreen;
    public bool deathScreenUp = false;
    public PlayerController playerController;

    public GameObject health;
    HealthMeter healthMeter;


    // Start is called before the first frame update
    void Start()
    {
        deathScreen = transform.GetChild(0).GetComponent<Image>();
        playerController = player.GetComponent<PlayerController>();
        healthMeter = health.GetComponent<HealthMeter>();
        //Teleport();
    }


    public IEnumerator FadeDeathScreen()
    {
        playerController.enabled = false;
        // Transparent to Opaque
        for (float i = 0; i <= 1; i += Time.unscaledDeltaTime)
        {
            deathScreen.color = new Color(deathScreen.color.r, deathScreen.color.g, deathScreen.color.b, i);
            yield return null;
        }
        Teleport();
        healthMeter.healthVal = 100;
        yield return new WaitForSecondsRealtime(3f);
        // Opaque to Transparent
        for (float i = 1; i >= 0; i -= Time.unscaledDeltaTime)
        {
            deathScreen.color = new Color(deathScreen.color.r, deathScreen.color.g, deathScreen.color.b, i);
            yield return null;
        }
        healthMeter.playerDead = false;
        playerController.enabled = true;
    }

    public void Teleport()
    {
        player.transform.position = teleportTarget.transform.position;
    }
}
