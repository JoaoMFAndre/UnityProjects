using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    public GameObject HingeLeft;
    public GameObject HingeRight;

    bool interact;
    float timer = 8;

    // Update is called once per frame
    void Update()
    {
        if (interact)
        {
            
            timer -= Time.deltaTime;
            if (timer > 0)
            {
                HingeLeft.transform.Rotate(0, 0, -10 * Time.deltaTime);
            }
            else
            {
                interact = false;
            }

            if (timer > 0)
            {
                HingeRight.transform.Rotate(0, 0, 10 * Time.deltaTime);
            }
            else
            {
                interact = false;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                interact = true;
            }
        }
    }
}
