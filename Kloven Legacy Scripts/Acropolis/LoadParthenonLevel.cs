using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadParthenonLevel : MonoBehaviour
{
    Interactable interactable;
    Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        inventory = GameObject.Find("GM").GetComponent<Inventory>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (interactable.interact && inventory.numberOfArtifacts == 3)
        {
            //Need to add condition of all the artifacts must be collected first
            if (other.CompareTag("Player"))
            {
                Debug.Log("Loading Parthenon");
                LoadParthenon(6);
            }
        }
    }

    public void LoadParthenon(int level)
    {
        SceneManager.LoadScene(level);
    }
}
