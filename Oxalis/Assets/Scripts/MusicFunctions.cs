using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFunctions : MonoBehaviour
{
    private AudioSource audio;
    public TriggerDecompresionChamber triggerDecompresionChamber;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        audio.clip = triggerDecompresionChamber.gameMusic;
        audio.Play();
    }

    public void TransitionOff()
    {
        triggerDecompresionChamber.gameMusicTransitions.SetBool("FadeOut", false);
    }
}
