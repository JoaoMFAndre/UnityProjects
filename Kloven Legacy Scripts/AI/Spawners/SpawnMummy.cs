using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMummy : MonoBehaviour
{
    public GameObject mummy;

    public void SpawnTheMummies()
    {
        GameObject instance = Instantiate(mummy, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
