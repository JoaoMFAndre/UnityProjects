using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    Renderer light;
    float timeLeft = 10f;
    public bool greenLight;
    bool yellowLight;
    bool redLight;


    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Renderer>();
        light.material.color = Color.green;

        greenLight = true;
        yellowLight = false;
        redLight = false;

    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0 && greenLight == true)
        {
            light.material.color = Color.yellow;
            timeLeft = 4f;

            greenLight = false;
            yellowLight = true;
            redLight = false;
        }
        if(timeLeft < 0 && yellowLight == true)
        {
            light.material.color = Color.red;
            timeLeft = 10f;

            greenLight = false;
            yellowLight = false;
            redLight = true;
        }
        if (timeLeft < 0 && redLight == true)
        {
            light.material.color = Color.green;
            timeLeft = 10f;

            greenLight = true;
            yellowLight = false;
            redLight = false;
        }

    }
}
