using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anubis : MonoBehaviour
{

    private float timer;

    public GameObject[] mummySpawner;

    // Start is called before the first frame update
    void Start()
    {
        timer = 5f;        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (transform.position.y <= 24)
        {
            transform.Translate(Vector3.up * 3 * Time.deltaTime);
        }

        if(timer <= 0)
        {
            RaiseMummies();
            Destroy(gameObject);
        } 
    }
    
    public void RaiseMummies()
    {
        mummySpawner = GameObject.FindGameObjectsWithTag("Mummy Spawner");
        for (int i = 0; i < mummySpawner.Length; i++)
        {
            mummySpawner[i].SendMessage("SpawnTheMummies");
        }
    }
}
