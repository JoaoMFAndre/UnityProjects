using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GreekAlien : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    FOVDetection fovDetection;
    Animator animator;

    void Start()
    {
        fovDetection = GetComponent<FOVDetection>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (points.Length == 0)
        {
            initialPosition = transform.position;
            initialRotation = transform.rotation;
        }
        else
        {
            GotoNextPoint();
        }
    }

    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;

        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }

    void GotoInitialPosition()
    {
        agent.destination = initialPosition;
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, initialRotation, Time.deltaTime * 5);
                }
            }
        }
    }

    void Update()
    {
        if (!fovDetection.isInFOV)
        {
            agent.autoBraking = false;
            agent.speed = 3.5f;
            animator.SetBool("ChasingPlayer", false);

            if (points.Length == 0)
            {
                if (!agent.pathPending && agent.remainingDistance < 6.5f)
                {
                    GotoInitialPosition();
                }
            }
            else
            {
                if (!agent.pathPending && agent.remainingDistance < 6.5f)
                    GotoNextPoint();
            }

        }
        else if (fovDetection.isInFOV)
        {
            AlertNearbyAllies();
            agent.autoBraking = true;
            agent.speed = 6;
        }

        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    animator.SetFloat("Speed", 0f);
                }
            }
        }
        else
        {
            animator.SetFloat("Speed", 0.2f);
        }
    }

    public void AlertNearbyAllies()
    {
        GameObject[] allies = GameObject.FindGameObjectsWithTag("Enemy");
        if (fovDetection.isInFOV)
        {
            foreach (GameObject ally in allies)
            {
                if (Vector3.Distance(this.transform.position, ally.transform.position) <= 50f)
                {
                    ally.gameObject.GetComponent<EnemyTactics>().alerted = true;
                }
            }
        }
    }
}
