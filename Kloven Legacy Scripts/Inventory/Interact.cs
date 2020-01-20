using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public Item item;
    Inventory inventory;
    public GameObject text;

    private void Start()
    {
        inventory = GameObject.Find("GM").GetComponent<Inventory>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                text.SetActive(false);
                inventory.numberOfArtifacts++;
                Inventory.instance.Add(item);
                Destroy(gameObject);
            }
        }
    }
}
