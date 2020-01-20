using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public float pushPower;
    public bool pressure_plate_1;
    public bool pressure_plate_2;

    private Plates script1;
    private Plates script2;
    public GameObject plate1;
    public GameObject plate2;
    public GameObject door;

    private Vector3 stone_move;
    public GameObject stone;

    private bool pushinStone;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        //is using the variables of the script plates
        script1 = plate1.GetComponent<Plates>();//acesses plate 1
        script2 = plate2.GetComponent<Plates>();//acesses plate 2
        pressure_plate_1 = false;
        pressure_plate_2 = false;
    }

    void OnControllerColliderHit(ControllerColliderHit hit) //checks collisions if it's something
    {

        if(hit.gameObject.name == "Stone" && Input.GetKey(KeyCode.E))//(chance name according to stone name in unity) if the player it's the stone and is pressing E
        {
            
            pushinStone = true;

            //basic control stuff
            stone_move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            stone_move = transform.TransformDirection(stone_move); 
            stone_move.Normalize();
            stone_move *= 6.0f;
            stone.transform.Translate(stone_move * Time.deltaTime);
        }
        else if (!Input.GetKey(KeyCode.E)) 
        {
            pushinStone = false;

        }
    }

    void Update()
    {
        animator.SetBool("Push", pushinStone);


        if (script1.stone_on == true || script1.player_on == true)//if the stone or the player is on the plate1
        {
            pressure_plate_1 = true;
        }
        else //if the stone is NOT on the plate1
        {
            pressure_plate_1 = false;
        }

        if (script2.stone_on == true || script2.player_on == true)//if the stone or the player is on the plate2
        {
            pressure_plate_2 = true;
        }
        else////if the stone is NOT on the plate2
        {
            pressure_plate_2 = false;
        }


        if (pressure_plate_1 == true && pressure_plate_2 == true)//if booth plates are beeing pressed the door will open
        {
            gameObject.SendMessage("RunForDoor");
            if (door.transform.position.y >= -4f)
            {
                door.transform.Translate(Vector3.down * 3f * Time.deltaTime);//velocity at wich the door is opening
            }
            
        }
        else// if the plates aren't beeing pressed the door wil close or stay closed
        {
            if (door.transform.position.y <= 10.2f)//if the door is not closed it will close
            {
                door.transform.Translate(Vector3.up * 0.2f * Time.deltaTime);//velocity at wich the dorr is closing
            }
        }
    }
}


