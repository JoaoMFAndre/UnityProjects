using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGreeceLevel : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Loading Selected Level");
                LoadTheLevel(5);
            }
        }
    }

    public void LoadTheLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
