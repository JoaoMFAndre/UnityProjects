using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class People : MonoBehaviour
{
    NavMeshAgent agent;
    Transform light;

    TrafficLight trafficLight;
    public float walkRadius = 8f;
    

    // Start is called before the first frame update
    void Start()
    {
        light = StreeLight.instance.streetLight.transform;
        
        agent = GetComponent<NavMeshAgent>();
        trafficLight = light.GetComponent<TrafficLight>();

        SetDestination();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if we've reached the destination
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance + 1f)
            {
                    SetDestination();
            }
        }

        if (trafficLight.greenLight != true)
        {
            float distance = Vector3.Distance(light.position, transform.position);

            if (distance < 4f)
            {
                Vector3 distanceToPlayer = transform.position - light.position;

                Vector3 newPos = transform.position + distanceToPlayer;

                agent.SetDestination(newPos);
            }
            if (distance > 4f && distance < 4.1f)
            {
                agent.isStopped = true;
            }
        }
        else
        {
            agent.isStopped = false;
        }
    }

    void SetDestination()
    {
        agent.speed = 1;
        Vector3 randomDirection = Random.insideUnitSphere * walkRadius;    //randomDirection is set to a random location inside a unitsphere with radius walkRadius

        randomDirection += transform.position;
        NavMeshHit hit;                                                    //Flag set when NavMesh is hit
        NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);   //Takes in a source position and NavMesh hit information and sets it onto the navmesh
        Vector3 finalPosition = hit.position;                              //finalPosition takes in all this data

        agent.destination = finalPosition;                                 //destination of agent is final destination

    }

    void TakeCover()
    {
        agent.speed = 3;
        
    }

}
