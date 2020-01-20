using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VATriggerEnteringMinotaurRoom : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            other.SendMessage("EnteringMinotaurRoomSound");
        }
    }
}
