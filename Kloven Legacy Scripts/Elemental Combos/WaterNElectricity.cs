using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterNElectricity : MonoBehaviour
{
    public GameObject electricEffect;
    private bool isCreated;
    private float damTimer;

    void Update()
    {
        if (GameObject.FindWithTag("Enemy") != null)
        {
            if (GameObject.FindWithTag("Enemy").GetComponent<EnemyDamage>().isWet == true && GameObject.FindWithTag("Enemy").GetComponent<EnemyDamage>().takingElectricDamage == true)
            {
                if (!isCreated)
                {
                    Instantiate(electricEffect, transform.position, transform.rotation);
                    isCreated = true;
                    GameObject.FindWithTag("Enemy").GetComponent<EnemyDamage>().takingElectricDamage = true;
                }

                damTimer -= Time.deltaTime;
                
                EnemyDamage enemyDamage = GameObject.FindWithTag("Enemy").GetComponent<EnemyDamage>();
                enemyDamage.comboDamageAmount = enemyDamage.DOTDamageAmount * 2;
                
                if (damTimer <= 0)
                {
                    enemyDamage.health -= enemyDamage.comboDamageAmount;
                    damTimer = 1;
                    Debug.Log(gameObject + " took " + enemyDamage.comboDamageAmount + " damage");
                }
            }
        }
    }
}
