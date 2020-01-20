using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCoffin : MonoBehaviour
{
    public Rigidbody rb;

    public void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            rb.AddForce(-transform.forward * 500f);
        }
    }
}
