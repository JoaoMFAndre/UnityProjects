using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : MonoBehaviour
{
    public float RotationSpeed;
    public Transform Target, Player;
    private float mouseX, mouseY;

    
    private float zoomSpeed = 5f;
    private bool againstWall;



    void Start()
    {
       
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }







    void LateUpdate() // if bug try FixedUpdate
    {
        CamControl();
        
    }


    private void FixedUpdate()
    {
        AgainstWall();

    }




    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -20, 30);


        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Player.rotation = Quaternion.Euler(0, mouseX, 0);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            againstWall = true;
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            againstWall = false;
        }
    }


    private void AgainstWall()
    {
        if(againstWall == true)
        {
            if (Vector3.Distance(transform.position, Target.position) > 2.3f) //change the value according to your liking
            {
                transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, Target.position) < 5f) //change the value according to your liking
            {
                transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime);
            }
        }
    }

}