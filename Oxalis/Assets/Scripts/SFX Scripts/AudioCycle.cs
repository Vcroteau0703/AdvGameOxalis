using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCycle : MonoBehaviour
{
    private PlayerController playerController;

    public AudioClip[] mushAudioClips;
    public AudioClip[] dirtAudioClips;
    public AudioClip[] domeAudioClips;
    public AudioClip[] mushImpact;
    public AudioClip[] sandImpact;

    AudioSource audioSource;

    private int randomClip;

    float timer = 0.0f;
    public float walkingSpeed;
    public float sprintingSpeed;
    float footstepSpeed;

    private Controls controls;

    private void Awake()
    {
        controls = new Controls();
        playerController = transform.parent.GetComponent<PlayerController>();
        audioSource = GetComponent<AudioSource>();
        footstepSpeed = walkingSpeed;
        controls.Gameplay.Sprint.performed += ctv => Sprint();
        controls.Gameplay.Sprint.canceled += ctx => SprintReleased();
    }

    private void Update()
    {
        if(playerController.isGrounded && playerController.isMoving && !playerController.hardImpact && !playerController.softImpact)
        {
            if(timer > footstepSpeed)
            {
                PlayAudio();
                timer = 0.0f;
            }
            timer += Time.deltaTime;
        }
    }

    public void PlayAudio()
    {
        DetermineMaterial();
        audioSource.Play();
    }

    void Sprint()
    {
        footstepSpeed = sprintingSpeed;
    }

    void SprintReleased()
    {
        footstepSpeed = walkingSpeed;
    }

    public void DetermineMaterial()
    {
        RaycastHit[] hit;

        hit = Physics.RaycastAll(transform.position, Vector3.down, 3.5f);
        Debug.DrawRay(transform.position, Vector3.down * 3.5f , Color.red, 0.5f);

        foreach (RaycastHit rayfloorhit in hit)
        {
            if(rayfloorhit.transform.tag == "Mushroom Top")
            {
                if (playerController.hardImpact)
                {
                    playerController.hardImpact = false;
                    audioSource.clip = mushImpact[0];
                    timer = 0.0f;
                }
                else if (playerController.softImpact)
                {
                    playerController.softImpact = false;
                    audioSource.clip = mushImpact[1];
                    timer = 0.0f;
                }
                else
                {
                    randomClip = Random.Range(0, mushAudioClips.Length);
                    audioSource.clip = mushAudioClips[randomClip];
                }
            }
            else if(rayfloorhit.transform.tag == "Dirt Ground")
            {
                if (playerController.hardImpact)
                {
                    playerController.hardImpact = false;
                    audioSource.clip = sandImpact[0];
                    timer = 0.0f;
                }
                else if (playerController.softImpact)
                {
                    playerController.softImpact = false;
                    audioSource.clip = sandImpact[1];
                    timer = 0.0f;
                }
                else
                {
                    randomClip = Random.Range(0, dirtAudioClips.Length);
                    audioSource.clip = dirtAudioClips[randomClip];
                }

            }
            else if(rayfloorhit.transform.tag == "Dome Floor")
            {
                randomClip = Random.Range(0, domeAudioClips.Length);
                audioSource.clip = domeAudioClips[randomClip];
            }
        }
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
