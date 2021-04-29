using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathingSFX : MonoBehaviour
{
    private PlayerController playerController;

    public AudioClip[] audioClips;
    AudioSource audioSource;

    private int randomClip;

    float timer = 0.0f;
    public float breathingSpeed;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (timer > breathingSpeed)
        {
            PlaySFX();
            timer = 0.0f;
        }
        timer += Time.deltaTime;
    }

    public void PlaySFX()
    {
        randomClip = Random.Range(0, audioClips.Length);
        audioSource.clip = audioClips[randomClip];
        audioSource.Play();
    }
}
