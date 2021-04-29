using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFunctions : MonoBehaviour
{
    private AudioSource audioSource;
    public TriggerDecompresionChamber triggerDecompresionChamber;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        audioSource.clip = triggerDecompresionChamber.gameMusic;
        audioSource.Play();
    }

    public void TransitionOff()
    {
        triggerDecompresionChamber.gameMusicTransitions.SetBool("FadeOut", false);
    }
}
