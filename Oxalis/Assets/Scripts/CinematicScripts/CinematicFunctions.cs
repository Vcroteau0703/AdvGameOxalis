using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicFunctions : MonoBehaviour
{
    public GameObject star1;
    public GameObject star2;
    public Animator animator;
    public AudioSource music;

    AudioSource[] audioSources;
    AudioSource crash;
    AudioSource beeps;
    public GameObject image;

    private void Awake()
    {
        audioSources = GetComponents<AudioSource>();
        crash = audioSources[1];
        beeps = audioSources[0];

    }



    public void EndHyperDrive()
    {
        star1.SetActive(false);
        star2.SetActive(false);
        animator.SetTrigger("StartShipMove");
    }

    public void ShipHitSFX()
    {
        crash.Play();
        music.Stop();
    }

    public void EmergencyBeepSFX()
    {
        beeps.Play();
    }

    public void EndScene()
    {
        image.SetActive(true);
        beeps.Stop();
    }
}
