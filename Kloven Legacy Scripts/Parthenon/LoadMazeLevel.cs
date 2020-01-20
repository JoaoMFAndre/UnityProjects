using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMazeLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Need to add condition of all the artifacts must be collected first
        if (other.CompareTag("Player"))
        {
            Debug.Log("Loading Maze");
            LoadMaze(7);
        }
    }

    public void LoadMaze(int level)
    {
        SceneManager.LoadScene(level);
    }
}
