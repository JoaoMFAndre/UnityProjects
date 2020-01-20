using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Reflect : MonoBehaviour
{
    private GameObject last_obj_hit;

    private float timer;
    public float maxDistance = 50;
    public float turnAngle;
    public bool isCasting = false;
    public bool mainRay = false;
    private Quaternion turn_value;
    private Quaternion last_pos;
    private bool can_interact = true;
    public Transform player;


    public LineRenderer LR;
    private Ray r;

    private void Start()
    {
        timer = 2;
        LR = GetComponent<LineRenderer>();
        last_pos = transform.rotation;
        turn_value = transform.rotation;
    }

    public void StartCasting()
    {
        isCasting = true;
        LR.SetPosition(0, transform.position);
    }

    public void StopCasting()
    {
        isCasting = false;
        LR.SetPosition(1, transform.position);
    }


    void Update()
    {
        Rotating();

        if (isCasting || mainRay)
        {
            Reflecting(transform.position, transform.forward);
        }
        else
        {
            StopHit(last_obj_hit);
            last_obj_hit = null;
        }
    }


    void Rotating()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, turn_value, Time.deltaTime * 4f);

        if (Vector3.Distance(transform.position, player.position) < 15f)
        {
            Debug.Log("On range for pillar");
            if (Input.GetKeyUp(KeyCode.E) && can_interact)
            {
                Debug.Log("interacting");
                turn_value = transform.rotation * Quaternion.Euler(0, turnAngle, 0);
                last_pos = turn_value;
            }
        }

        if (last_pos == transform.rotation)
        {
            can_interact = true;
        }
        else
        {
            can_interact = false;
        }
    }

    void Reflecting(Vector3 position, Vector3 direction)
    {

        Vector3 startingPosition = position;
        Ray ray = new Ray(position, direction);
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, 1 << LayerMask.NameToLayer("Pillar")))
        {
            if (hit.transform.tag == "pillar")
            {
                last_obj_hit = hit.collider.gameObject;
                position = hit.point;
                HasHit(hit.collider.gameObject);
                Debug.DrawLine(startingPosition, position, Color.blue);
                LR.SetPosition(1, hit.point);
            }
            else if (hit.transform.tag == "Snake")
                {
                    if (timer > 0)
                    {
                    GameObject.Find("Player").SendMessage("FoundMazeEntranceSound");
                    timer -= Time.deltaTime;
                    }
                    else
                    {
                        last_obj_hit = hit.collider.gameObject;
                        position = hit.point;
                        HasHit(hit.collider.gameObject);
                        Debug.DrawLine(startingPosition, position, Color.blue);
                        hit.transform.SendMessage("OpenDoorToMaze");
                    }
                }
        }
        else
        {
            position += direction * maxDistance;
            LR.SetPosition(1, position);
            Debug.DrawLine(startingPosition, position, Color.black);
            StopHit(last_obj_hit);
            
        }
    }

    public void HasHit(GameObject obj)
    {
        obj.SendMessage("StartCasting");
        Debug.Log("NOME do objecto: " + obj.name);

    }

    public void StopHit(GameObject obj)
    {
        obj.SendMessage("StopCasting");
    }
}
