using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpening : MonoBehaviour
{

    AudioSource sound;


    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            sound.Play();
            Debug.Log("wsaws");
        }
    }
}
