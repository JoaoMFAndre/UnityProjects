using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{

    GameObject tampa;

    // Start is called before the first frame update
    void Start()
    {
        tampa = GameObject.Find("Tampa_Tumulo");
        Physics.IgnoreCollision(GetComponent<Collider>(), tampa.GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name != "Player")
        {
            Destroy(gameObject);
        }
    }
}
