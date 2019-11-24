using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public Exit Exit;

    public GameObject tutorialUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            tutorialUI.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && Exit.reachedExit == false)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        Debug.Log("Restarting Current Level....");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        Debug.Log("Restarting Game....");
        SceneManager.LoadScene(0);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void LoadOptions()
    {
        Debug.Log("Loading Options....");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game....");
        Application.Quit();
    }
}
