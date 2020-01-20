using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractUIText : MonoBehaviour
{
    GameObject Aiden;
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        Aiden = PlayerManager.instance.player.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            text.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            text.SetActive(false);
        }
    }
}
