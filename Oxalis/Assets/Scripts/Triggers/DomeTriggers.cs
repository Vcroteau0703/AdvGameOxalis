using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomeTriggers : MonoBehaviour
{
    public PlayerController playerController;

    private void OnTriggerExit(Collider other)
    {
        playerController.jetpackActive = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        playerController.jetpackActive = false;
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    gameMusic = Resources.Load<AudioClip>("oxalis_mx_farming");
    //    gameMusicTransitions.SetBool("FadeOut", true);
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    gameMusic = Resources.Load<AudioClip>("oxalis_mx_exploration");
    //    gameMusicTransitions.SetBool("FadeOut", true);
    //}
}
