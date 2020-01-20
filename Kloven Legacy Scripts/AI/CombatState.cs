using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatState : MonoBehaviour
{
    public bool inCombat;
    Transform target;
    public float enemyAlertPhaseTimer = 10f;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        FindClosestEnemy();
    }

    void FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        GameObject closestEnemy = null;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject currentEnemy in enemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - target.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }

        
        if (enemies[0] == null || Vector3.Distance(closestEnemy.transform.position, target.position) >= 50f)
        {
            inCombat = false;
            foreach (GameObject enemy in enemies)
            {
                if (enemy.gameObject.GetComponent<EnemyTactics>().alerted)
                {
                    if (enemyAlertPhaseTimer > 0f)
                    {
                        enemyAlertPhaseTimer -= Time.deltaTime;
                    }else
                    {
                        enemy.gameObject.GetComponent<EnemyTactics>().alerted = false;
                        enemyAlertPhaseTimer = 10f;
                    }
                }
            }
        }
        else if (enemies[0] != null && Vector3.Distance(closestEnemy.transform.position, target.position) <= 50f)
        {
            if (closestEnemy.GetComponent<FOVDetection>().isInFOV)
            {
                inCombat = true;
            }
        }

        //Alert Enemies if Aiden is too close
        if (Vector3.Distance(closestEnemy.transform.position, target.position) <= 6f)
        {
            closestEnemy.GetComponent<EnemyTactics>().alerted = true;
        }
        //Alert Enemies if Aiden casts a spell too close
        if (Vector3.Distance(closestEnemy.transform.position, target.position) <= 40f && Input.GetMouseButtonUp(0))
        {
            closestEnemy.GetComponent<EnemyTactics>().alerted = true;
        }
    }
}
