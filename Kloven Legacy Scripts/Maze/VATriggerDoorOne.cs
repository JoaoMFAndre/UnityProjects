﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VATriggerDoorOne : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            other.SendMessage("OpenFirstDoorSound");
        }
    }
}
