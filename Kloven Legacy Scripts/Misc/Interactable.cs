using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool interact;

    void Start()
    {
        interact = false;
    }

    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Aiden is here");
            if (Input.GetKeyUp(KeyCode.E))
            {
                interact = true;
            }
            else
            {
                interact = false;
            }
        }
    }
}
