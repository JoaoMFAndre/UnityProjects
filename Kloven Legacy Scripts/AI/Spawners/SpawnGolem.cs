using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGolem : MonoBehaviour
{
    public GameObject golem;
    public GameObject golemChecker;

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.G))
        {
            SpawnTheGolem();
        }*/
    }

    public void SpawnTheGolem()
    {
        GameObject instance = Instantiate(golem, transform.position, transform.rotation);
        GameObject check = Instantiate(golemChecker, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
