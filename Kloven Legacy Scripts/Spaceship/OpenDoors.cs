using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    public GameObject Door;
    bool openCloseDoor;

    private void Update()
    {
        if (openCloseDoor)
        {
            if (Door.transform.position.z >= -14f)
            {
                Door.transform.Translate(0, 50f * Time.deltaTime, 0);
            }
        }
        else
        {
            if (Door.transform.position.z <= 0)
            {
                Door.transform.Translate(0, -50f * Time.deltaTime, 0);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            openCloseDoor = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            openCloseDoor = false;
        }
    }
}
