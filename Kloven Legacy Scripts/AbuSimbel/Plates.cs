using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plates : MonoBehaviour
{
    public bool stone_on;
    public bool player_on;
    public Transform player;
    public Transform stone;




    // Start is called before the first frame update
    void Start()
    {
        stone_on = false;
        player_on = false;
    }

   

   void Collision()
    {
        RaycastHit hit;

        if(Vector3.Distance(transform.position,player.position) <= 3.5f)//sends a ray from the plate to the player
        {
            player_on = true;
        }
        else
        {
            player_on = false;
        }
       
        if(Vector3.Distance(transform.position,stone.position) <=3.5f)//sends a ray from the plate to the stone
        {
            stone_on = true;
        }
        else
        {
            stone_on = false;
        }
       
    }

    void Update()
    {
        Collision();
    }
}
