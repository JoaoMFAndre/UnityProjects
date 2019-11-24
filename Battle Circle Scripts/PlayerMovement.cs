using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{

    CharacterController cc;
    NavMeshAgent agent;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        agent = GetComponent<NavMeshAgent>();

        Physics.IgnoreCollision(GetComponent<Collider>(), GetComponentInChildren<Collider>());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (cc.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        cc.Move(moveDirection * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {   
        //Danger Area
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 3f);

        //Battle Circle
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, 10f);
    }
}
