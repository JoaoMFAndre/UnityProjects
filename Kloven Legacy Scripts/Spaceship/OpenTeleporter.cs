using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTeleporter : MonoBehaviour
{
    public GameObject Door;
    bool openCloseDoor;

    private void Update()
    {
        if (openCloseDoor)
        {
            if (Door.transform.rotation.z >= -80f)
            {
                Door.transform.Rotate(0, 0, -100f * Time.deltaTime);
            }
        }
        else
        {
            if (Door.transform.rotation.z <= 0)
            {
                Door.transform.Rotate(0, 0, 100f * Time.deltaTime);
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
