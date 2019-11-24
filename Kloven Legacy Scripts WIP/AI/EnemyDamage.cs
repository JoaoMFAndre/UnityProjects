using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int maxHealth;

    public int health;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Death();   
    }

    void OnCollisionEnter(Collision collision)
    {
        int projectileDamageAmount = 20;

        if (collision.gameObject.tag == "Earth")
        {
            health -= projectileDamageAmount;
        }
        else if (collision.gameObject.tag == "Fire")
        {
            health -= projectileDamageAmount;
        }
        else if (collision.gameObject.tag == "Acid")
        {
            health -= projectileDamageAmount;
        }
        Debug.Log(gameObject + " took " + projectileDamageAmount + " damage");
    }

    void OnTriggerStay(Collider collider)
    {
        int DOTDamageAmount = 5;
        
        if (collider.gameObject.tag == "Ice")
        {
            health -= DOTDamageAmount;
            Debug.Log(gameObject + " took " + DOTDamageAmount + " damage");
        }
        else if (collider.gameObject.tag == "Electricity")
        {
            health -= DOTDamageAmount;
            Debug.Log(gameObject + " took " + DOTDamageAmount + " damage");
        }
        else if (collider.gameObject.tag == "Acid Pool")
        {
            health -= DOTDamageAmount;
            Debug.Log(gameObject + " took " + DOTDamageAmount + " damage");
        }
        
    }

    public void Death()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
