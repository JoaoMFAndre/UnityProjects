using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol3 : MonoBehaviour
{
    public float speed;

    public Camera playerCamera;

    public Transform[] moveSpots;

    int x = 0;

    private void Start()
    {

    }

    private void Update()
    {
        if (playerCamera.enabled == true)
        {
            transform.Rotate(new Vector3(45, 45, 45) * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, moveSpots[x].position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, moveSpots[x].position) < 0.2f)
            {
                x++;
            }
            if (x == 2)
            {
                x = 0;
            }
        }
    }
}
