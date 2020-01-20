using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{
    //mouse (void CamControl)
    public float RotationSpeed;
    public Transform Target, Player;
    private float mouseX, mouseY;

    //zoom (void ViewObstructed)
    public Collider PlayerCollider;
    private bool Parede;
    private float ZoomSpeed = 5f;

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -20, 30);


        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        //Player.rotation = Quaternion.Euler(0, mouseX, 0);
    }

    void LateUpdate() // if bug try FixedUpdate
    {
        CamControl();
    }
}
