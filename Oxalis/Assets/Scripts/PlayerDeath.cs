using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject player;
    Image deathScreen;

    // Start is called before the first frame update
    void Start()
    {
        deathScreen = transform.GetChild(0).GetComponent<Image>();
    }

    public IEnumerator FadeInDeathScreen()
    {
        // Transparent to Opaque
        for (float i = 0; i <= 1; i += Time.unscaledDeltaTime)
        {
            deathScreen.color = new Color(deathScreen.color.r, deathScreen.color.g, deathScreen.color.b, i);
            yield return null;
        }
        //teleporting player back to base
        Debug.Log(teleportTarget.transform.position);
        player.transform.position = teleportTarget.transform.position;
        Debug.Log(player.transform.position);
        yield return new WaitForSecondsRealtime(1f);
        //remove stuff from inventory here? and reset any pickups?

        // Opaque to Transparent
        for (float i = 1; i >= 0; i -= Time.unscaledDeltaTime)
        {
            deathScreen.color = new Color(deathScreen.color.r, deathScreen.color.g, deathScreen.color.b, i);
            yield return null;
        }
        StopCoroutine(FadeInDeathScreen());
    }
}
