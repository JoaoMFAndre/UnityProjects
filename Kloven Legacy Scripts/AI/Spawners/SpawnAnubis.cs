using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnubis : MonoBehaviour
{
    public GameObject anubis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTheAnubis()
    {
        GameObject instance = Instantiate(anubis, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
