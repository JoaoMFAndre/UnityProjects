using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAbuSimbelLevel : MonoBehaviour
{

    public GameObject Door;

    Inventory inventory;

    private void Start()
    {
        inventory = GameObject.Find("GM").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (inventory.numberOfArtifacts == 3)
        {
            Door.transform.Translate(0, 10 * Time.deltaTime, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (inventory.numberOfArtifacts == 3)
        {
            //Need to add condition of all the artifacts must be collected first
            if (other.CompareTag("Player"))
            {
                Debug.Log("Loading Abu Simbel");
                LoadAbuSimbel(3);
            }
        } 
    }

    public void LoadAbuSimbel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
