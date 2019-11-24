using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    private Vector3 pos1 = new Vector3(11, -10, -17);
    private Vector3 pos2 = new Vector3(11, 1, -17);
    public float speed = 1f;

    void Update()
    {
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.5f));
    }
}
