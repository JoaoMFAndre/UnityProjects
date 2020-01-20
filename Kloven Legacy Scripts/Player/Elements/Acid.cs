using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour
{
    private  GameObject target;

    private Quaternion side_wall;
    private bool floor;
    


    public GameObject pool;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Capsule");
        floor = false;
    }


    void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.name != "Player")
        {
            Ray ray = new Ray(transform.position, transform.forward);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                side_wall = Quaternion.LookRotation(transform.up,hit.normal);
            }
            
            
        }

        if(collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
            floor = true;
        }
        else
        {
            Destroy(gameObject);
            floor = false;
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDestroy()
    {
        if (floor)
        {
            Instantiate(pool, transform.position,new Quaternion(0,0,0,0));
        }
        else
        {
            Instantiate(pool, transform.position, side_wall);
        }
    }
}
