using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSpaceshipPostAbuSimbelLevel : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Loading Spaceship");
            LoadSpaceshipPostAbuSimbel(4);
        }
    }

    public void LoadSpaceshipPostAbuSimbel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
