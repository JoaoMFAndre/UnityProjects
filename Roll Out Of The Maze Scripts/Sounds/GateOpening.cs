using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpening : MonoBehaviour
{

    AudioSource audio;

    public AudioClip gateOpening;

    private static int doorOpening;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        GameObject thePlayer = GameObject.Find("Player");
        PlayerController playerScript = thePlayer.GetComponent<PlayerController>();
        doorOpening = playerScript.count;
    }

    // Update is called once per frame
    void Update()
    {
        if (doorOpening == 5)
        {
            audio.Play();
        }
        if (doorOpening == 10)
        {
            audio.Play();
        }
    }
}
