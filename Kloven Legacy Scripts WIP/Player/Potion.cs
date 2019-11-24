using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    AidenHealth aidenHealth;

    // Start is called before the first frame update
    void Start()
    {
        aidenHealth = GetComponent<AidenHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && aidenHealth.health < aidenHealth.maxHealth)
        {
            aidenHealth.health += 20;
            Debug.Log("HP: " +aidenHealth.health+ "/" +aidenHealth.maxHealth);
        }
        else if (aidenHealth.health >= aidenHealth.maxHealth)
        {
            aidenHealth.health = aidenHealth.maxHealth;
        }
    }
}
