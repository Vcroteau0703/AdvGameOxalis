using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCycle : MonoBehaviour
{
    private PlayerController playerController;

    public AudioClip[] mushAudioClips;
    public AudioClip[] dirtAudioClips;
    public AudioClip[] domeAudioClips;

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
        if(playerController.isGrounded && playerController.isMoving)
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
    
    //public void StopAudio()
    //{
    //    audioSource.loop = false;
    //    audioSource.Play();
    //}

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

        hit = Physics.RaycastAll(transform.position, Vector3.down, 3.0f);
        Debug.DrawRay(transform.position, Vector3.down * 3f , Color.red, 0.5f);

        foreach (RaycastHit rayfloorhit in hit)
        {
            if(rayfloorhit.transform.tag == "Mushroom Top")
            {
                randomClip = Random.Range(0, mushAudioClips.Length);
                audioSource.clip = mushAudioClips[randomClip];
            }
            else if(rayfloorhit.transform.tag == "Dirt Ground")
            {
                randomClip = Random.Range(0, dirtAudioClips.Length);
                audioSource.clip = dirtAudioClips[randomClip];
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
