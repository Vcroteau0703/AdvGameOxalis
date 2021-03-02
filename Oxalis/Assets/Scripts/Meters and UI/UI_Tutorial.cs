using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Tutorial : MonoBehaviour
{

    [TextArea]
    public string[] tutorialMessages;
    public Text textDisplay;
    public Text continueMessage;
    public PlayerController playerController;

    private Controls controls;

    private int index = 0;
    public GameObject tutorialUI;
    public bool tutorialActive = false;

    //bools for tutorial triggering
    public bool firstTill = true;
    public bool firstPlant = true;
    public bool firstWater = true;
    public bool firstHarvest = true;
    public bool firstGermination = true;
    public bool firstCompost = true;
    public bool firstConsume = true;

    //accessing germinator, compost and storage
    public GameObject germinator;
    public GameObject compost;
    public GameObject storage;

    private void Awake()
    {
        StartCoroutine(TutorialWait());
        controls = new Controls();
        controls.Gameplay.Escape.performed += ctx => CloseTutorial();
    }

    public IEnumerator TutorialWait()
    {
        yield return new WaitForSeconds(2);
        NextTutorial();
    }

    IEnumerator FlashText()
    {
        while (true)
        {
            // Opaque to Transparent
            for (float i = 1; i >= 0; i -= Time.unscaledDeltaTime)
            {
                continueMessage.color = new Color(continueMessage.color.r, continueMessage.color.g, continueMessage.color.b, i);
                yield return null;
            }
            // Transparent to Opaque
            for (float i = 0; i <= 1; i += Time.unscaledDeltaTime)
            {
                continueMessage.color = new Color(continueMessage.color.r, continueMessage.color.g, continueMessage.color.b, i);
                yield return null;
            }

        }

    }

    // pauses everything affected by timescale
    public void PauseGame()
    {
        Time.timeScale = 0;
        playerController.enabled = false;
    }

    // sets timescale back to normal
    public void ResumeGame()
    {
        Time.timeScale = 1;
        playerController.enabled = true;
    }

    // load next tutorial message
    public void NextTutorial()
    {
        if (index < tutorialMessages.Length - 1)
        {
            tutorialUI.SetActive(true);
            tutorialActive = true;
            textDisplay.text = tutorialMessages[index];
            StartCoroutine(FlashText());
            PauseGame();
            index++;
        }
    }

    // close the tutorial window
    public void CloseTutorial()
    {
        if (tutorialActive)
        {
            tutorialActive = false;
            StopCoroutine(TutorialWait());
            StopCoroutine(FlashText());
            tutorialUI.SetActive(false);
            ResumeGame();
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
