using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGolem : MonoBehaviour
{
    public GameObject golem;
    public GameObject golemChecker;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void SpawnTheGolem()
    {
        GameObject instance = Instantiate(golem, transform.position, transform.rotation);
        GameObject check = Instantiate(golemChecker, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
