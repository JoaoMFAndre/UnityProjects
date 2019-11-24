using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ToggleNavMeshObstacule : MonoBehaviour
{

    NavMeshObstacle obstacle;

    // Start is called before the first frame update
    void Start()
    {
        obstacle = GetComponent<NavMeshObstacle>();
        obstacle.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            obstacle.enabled = true;
        }
        else
        {
            obstacle.enabled = false;
        }
    }
}
