using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{

    public GameObject Lid;
    public bool open;
    private float waitTime;
    public float startWaitTime;
    AudioSource sound;
    int vezes = 0;


    private void Start()
    {
        sound = GetComponent<AudioSource>();

        waitTime = startWaitTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        open = true;
        if (vezes == 0)
        {
            sound.Play();
            vezes++;
        }
    }

    private void FixedUpdate()
    {
        if (open == true && waitTime >= 0)
        {
            
            Lid.transform.Rotate(5f * Time.deltaTime * 5f, 0, 0, Space.Self);
            waitTime -= Time.deltaTime;
            

        }
        if (waitTime <= 0)
        {
            open = false;
            Destroy(GetComponent<OpenChest>());
        }
    }
}
