using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireNAcid : MonoBehaviour
{
    public GameObject explosionEffet;
    private GameObject fire;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fire")
        {
            Instantiate(explosionEffet, transform.position, transform.rotation);
            Destroy(GameObject.Find("Effect23(Clone)"));
            Destroy(GameObject.Find("Effect12_Explosion(Clone)"));

            if (GameObject.FindWithTag("Enemy") != null)
            {
                if (GameObject.FindWithTag("Enemy").GetComponent<EnemyDamage>().takingPoisonDamage == true)
                {
                    EnemyDamage enemyDamage = GameObject.FindWithTag("Enemy").GetComponent<EnemyDamage>();
                    enemyDamage.comboDamageAmount = enemyDamage.projectileDamageAmount * 2;
                    enemyDamage.health -= enemyDamage.comboDamageAmount;
                    Debug.Log(gameObject + " took " + enemyDamage.comboDamageAmount + " damage");
                }
            }
        }
    }
}
