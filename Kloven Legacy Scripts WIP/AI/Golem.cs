using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Golem : MonoBehaviour
{
    public float lookRadius;

    Transform target;
    NavMeshAgent agent;
    EnemyDamage enemyDamage;

    // Start is called before the first frame update
    void Start()
    {
        enemyDamage = GetComponent<EnemyDamage>();
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
        agent.SetDestination(target.transform.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
