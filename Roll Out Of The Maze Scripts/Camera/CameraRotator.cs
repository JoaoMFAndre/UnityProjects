using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public GameObject player;
    public Rigidbody Rb;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        GameObject thePlayer = GameObject.Find("Player");
        Rb = player.GetComponent<Rigidbody>();
        PlayerController playerScript = thePlayer.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalSpeed = Input.GetAxis("Mouse X");
        transform.Rotate(0, horizontalSpeed, 0);

        transform.position = player.transform.position;

        if(PauseMenu.GameIsPaused == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (PauseMenu.GameIsPaused == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

    }
}
