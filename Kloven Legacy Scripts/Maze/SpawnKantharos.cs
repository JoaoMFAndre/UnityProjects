using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKantharos : MonoBehaviour
{
    public GameObject Kantharos;
    GameObject Minotaur;

    private void Start()
    {
        Minotaur = GameObject.Find("Minotaur");
    }

    private void Update()
    {
        if (!Minotaur)
        {
            SpawnTheKantharos();
        }
    }

    public void SpawnTheKantharos()
    {
        GameObject instance = Instantiate(Kantharos, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
