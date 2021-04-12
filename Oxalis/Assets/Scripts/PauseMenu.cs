using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject playerHud;
    public GameObject pauseMenu;
    public GameObject optionsMenu;

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

    public void Options()
    {
        optionsMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }
    public void ExitOptions()
    {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
}
