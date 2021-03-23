using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    Controls controls;

    public GameObject playerHud;
    public GameObject pauseMenu;

    private void Awake()
    {
        controls = new Controls();
        controls.Gameplay.Escape.performed += ctx => PauseGame();
    }
    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0;
        playerHud.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        playerHud.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
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
