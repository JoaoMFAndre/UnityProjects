using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VATrigger : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            other.SendMessage("OpenSarcophagousSound");
        }
    }
}
