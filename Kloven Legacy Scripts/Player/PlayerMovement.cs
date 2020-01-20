using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6.0f;
    private float jumpspeed = 8.0f;
    private float gravity = 20.0f;

    private bool ableToDodge;

    private float dashSpeed = 7f;
    private float dashBrake = 0.1f;
    private float MaxDashTime = 2.0f;
    //private float currentDashTime;
    private float currentDashTime_b;
    private float currentDashTime_b2;
    private float currentDashTime_l;
    private float currentDashTime_r;
    private float currentDashTime_f;

    private Vector3 dashMovement;
    private float dashCoolDown;

    public Vector3 moveDirection;
    public Vector3 lastMoveDirection;
    private CharacterController controller;
    
    public GameObject playerModel;
    public float rotateSpeed;
    public Transform pivot;
    public CombatState combatState;
    Animator animator;
    //private int doOnce;


    void Start()
    {
        combatState = combatState.GetComponent<CombatState>();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        //currentDashTime = MaxDashTime;
        currentDashTime_l = MaxDashTime;
        currentDashTime_b = MaxDashTime;
        currentDashTime_b2 = MaxDashTime;
        currentDashTime_r = MaxDashTime;
        currentDashTime_f = MaxDashTime;
        //doOnce = 0;
    }

    //simple movement control binding
    private void Movement()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection); //moveDirection = local
            moveDirection.Normalize();
            moveDirection *= speed;


            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpspeed;
            }
            if (Input.GetKeyDown(KeyCode.Space)) //jump
            {
                moveDirection.y = jumpspeed;
                animator.SetBool("Jump", true);
            }
            else
            {
                animator.SetBool("Jump", false);
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))//run
            {
                speed = 20f;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))//stop run
            {
                speed = 10f;
            }

            else if (Input.GetKey(KeyCode.LeftControl) && dashCoolDown <= 0 && Input.GetKey(KeyCode.W))//dash(shift+w)
            {
                currentDashTime_f = 0f;
                dashCoolDown = 1f;
            }
            else if (Input.GetKey(KeyCode.LeftControl) && dashCoolDown <= 0 && Input.GetKey(KeyCode.A))//dash(shift+a)
            {
                currentDashTime_l = 0f;
                dashCoolDown = 1f;
            }
            else if (Input.GetKey(KeyCode.LeftControl) && dashCoolDown <= 0 && Input.GetKey(KeyCode.D))//dash(shift+d)
            {
                currentDashTime_r = 0f;
                dashCoolDown = 1f;
            }
            else if (Input.GetKeyUp(KeyCode.LeftControl) && dashCoolDown <= 0 && Input.GetKey(KeyCode.S))//dash(shift+s)
            {
                currentDashTime_b = 0f;
                dashCoolDown = 1f;
            }
            else if (Input.GetKeyUp(KeyCode.LeftControl) && dashCoolDown <= 0)//dash(shift+s)
            {
                currentDashTime_b2 = 0f;
                dashCoolDown = 1f;
            }

            if (currentDashTime_l < MaxDashTime)//dash left
            {

                dashMovement = transform.TransformDirection(new Vector3(-dashSpeed, 0, 0));
                currentDashTime_l += dashBrake;
            }
            else if (currentDashTime_r < MaxDashTime)//dash right
            {

                dashMovement = transform.TransformDirection(new Vector3(dashSpeed, 0, 0));
                currentDashTime_r += dashBrake;
            }
            else if (currentDashTime_b < MaxDashTime)//dash back
            {

                dashMovement = transform.TransformDirection(new Vector3(0, 0, -dashSpeed));
                currentDashTime_b += dashBrake;
            }
            else if (currentDashTime_b2 < MaxDashTime)//dash back
            {

                dashMovement = transform.TransformDirection(new Vector3(0, 0, -dashSpeed * 2));
                currentDashTime_b2 += dashBrake;
            }
            else if (currentDashTime_f < MaxDashTime)//dash front
            {

                dashMovement = transform.TransformDirection(new Vector3(0, 0, dashSpeed));
                currentDashTime_f += dashBrake;
            }
            else //don't dash
            {
                dashMovement = Vector3.zero;
            }
            controller.Move(dashMovement * Time.deltaTime);
            
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            if (!combatState.inCombat)
            {
                playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
            }
            else if (combatState.inCombat)
            {
                playerModel.transform.rotation = Quaternion.Euler(playerModel.transform.rotation.eulerAngles.x, Camera.main.transform.eulerAngles.y, playerModel.transform.rotation.eulerAngles.z);
            }
        }

        
        animator.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + (Mathf.Abs(Input.GetAxis("Horizontal")))));
        animator.SetBool("Sprint", Input.GetKey(KeyCode.LeftShift));
        animator.SetBool("Dodge", Input.GetKeyDown(KeyCode.LeftControl));

        if (combatState.inCombat == true)
        {
            animator.SetLayerWeight(1, 1);  
        }
        else if (combatState.inCombat == false)
        {
            animator.SetLayerWeight(1, 0);
        }

        animator.SetFloat("PosY", (Input.GetAxis("Vertical")));
        animator.SetFloat("PosX", (Input.GetAxis("Horizontal")));
    }


    public void canDodge()
    {
        ableToDodge = true;
    }
    public void cantDodge()
    {
        ableToDodge = false;
    }

    private void Update()
    {
        if (!ableToDodge)
        {
            if (dashCoolDown > 0)
            {
                dashCoolDown -= Time.deltaTime;
            }
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    public void OnCastingSpellAnimationEnd()
    {
        animator.SetBool("CastingSpell", false);
        animator.SetLayerWeight(4, 0);
        animator.SetLayerWeight(5, 0);
    }

    public void ShootingProjectile()
    {
        GameObject.Find("bullet_hole").gameObject.SendMessage("ShootProjectile");
    }

    public void ShootingRay()
    {
        GameObject.Find("bullet_hole").gameObject.SendMessage("ShootRay");
    }

    public void ShootingRayEnd()
    {
        GameObject.Find("bullet_hole").gameObject.SendMessage("ShootRayEnd");
    }
}
