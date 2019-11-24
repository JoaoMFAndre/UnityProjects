using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMummy : MonoBehaviour
{
    public GameObject mummy;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnTheMummies()
    {
        GameObject instance = Instantiate(mummy, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
