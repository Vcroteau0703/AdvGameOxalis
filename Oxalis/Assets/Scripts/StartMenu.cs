using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject optionsMenu;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Options()
    {
        titleScreen.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void ExitOptions()
    {
        titleScreen.SetActive(true);
        optionsMenu.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
