using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBookOfTheDead : MonoBehaviour
{
    public GameObject Book;

    public void SpawnBook()
    {
        GameObject instance = Instantiate(Book, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
