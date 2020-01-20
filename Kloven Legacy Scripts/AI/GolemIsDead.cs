using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemIsDead : MonoBehaviour
{
    public GameObject golem;
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        golem = GameObject.Find("Golem(Clone)");
        door = GameObject.Find("NoMove Door");
    }

    // Update is called once per frame
    void Update()
    {
        if (golem == null)
        {
            GameObject.Find("Player").SendMessage("TakeTheArtifactSound");
            if (door.transform.position.y <= 37f)
            {
                door.transform.Translate(Vector3.up * 5 * Time.deltaTime);
            }
            GameObject.Find("Spawnpoint Book of The Dead").SendMessage("SpawnBook");
        }
    }
}
