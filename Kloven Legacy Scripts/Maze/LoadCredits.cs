using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCredits : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerStay(Collider other)
    {

        //Need to add condition of all the artifacts must be collected first
        if (other.CompareTag("Player"))
        {
            Debug.Log("Loading Credits");
            LoadCreditsScene(8);
        }

    }

    public void LoadCreditsScene(int level)
    {
        SceneManager.LoadScene(level);
    }
}
