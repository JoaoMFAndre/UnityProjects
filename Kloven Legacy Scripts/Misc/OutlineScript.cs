using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineScript : MonoBehaviour
{
    public GameObject[] interactables;
    private Camera Camera;
    public Vector3 targetpoint;
    Renderer interactableRenderer;
   
    void Start()
    {
        Camera = GetComponent<Camera>();
        interactables = GameObject.FindGameObjectsWithTag("Interactable");

        for (int i = 0; i < interactables.Length; i++)
        {
            interactables[i].GetComponent<Renderer>().material.SetColor("_OutlineColor", Color.clear);
        }
    }

    void Outline_Color()
    {
        /*
        Vector3 startingPosition = position;
        Ray ray = Camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit))
        {
            if(hit.transform.tag == "Interactable")
            {
                position = hit.point;
                Debug.DrawLine(startingPosition, position, Color.blue);
                material.SetColor("_OutlineColor", Color.yellow);
            }
        }
        else
        {
            position += transform.forward * 50;
            Debug.DrawLine(startingPosition, position, Color.black);
            material.SetColor("_OutlineColor", Color.clear);
        }
        */
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            for (int i = 0; i < interactables.Length; i++)
            {
                interactables[i].GetComponent<Renderer>().material.SetColor("_OutlineColor", Color.yellow);
                //interactableRenderer.material.SetColor("_OutlineColor", Color.yellow); 
            }
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            for (int i = 0; i < interactables.Length; i++)
            {
                interactables[i].GetComponent<Renderer>().material.SetColor("_OutlineColor", Color.clear);
            }   
        }
    }

    // Update is called once per frame
    void Update()
    {
        Outline_Color();
    }
}
