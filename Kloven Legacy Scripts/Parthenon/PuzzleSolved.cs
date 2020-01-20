using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSolved : MonoBehaviour
{
    public GameObject mazeDoor;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 12f;
    }

    public void OpenDoorToMaze()
    {
        if (timer > 0f)
        {
            mazeDoor.transform.Translate(0, Time.deltaTime * 4f, 0);
            timer -= Time.deltaTime;
        }
    }
}
