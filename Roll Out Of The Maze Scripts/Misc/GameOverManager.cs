using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public float restartDelay = 5f;         // Time to wait before restarting the level

    public Exit Exit;

    Animator anim;                          // Reference to the animator component.
    float restartTimer;                     // Timer to count up to restarting the level

    public string levelToLoad;


    void Awake()
    {
        // Set up the reference.
        anim = GetComponent<Animator>();
        
    }


    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Scene1"))
        {
            // If the player has run out of health...
            if (Exit.reachedExit == true)
            {
                // ... tell the animator the game is over.
                anim.SetTrigger("GameOver");

                // .. increment a timer to count up to restarting.
                restartTimer += Time.deltaTime;

                // .. if it reaches the restart delay...
                if (restartTimer >= restartDelay)
                {
                    // .. then reload the currently loaded level.
                    // Application.LoadLevel(Application.loadedLevel);
                    SceneManager.LoadScene(levelToLoad);
                }
            }
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Scene2"))
        {
            // If the player has run out of health...
            if (Exit.reachedExit == true)
            {
                // ... tell the animator the game is over.
                anim.SetTrigger("GameOver");

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Application.Quit();
                    Debug.Log("Quitting Game....");
                }
                if (Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene(0);
                }
            }
            
        }
    }
}
