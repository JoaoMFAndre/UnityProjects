using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mummy : MonoBehaviour
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
        if (enemyDamage.health <= 0)
        {
            GameObject instance = Instantiate((Resources.Load("Spawnpoint", typeof(GameObject))) as GameObject, transform.position, transform.rotation);
        }
    }

    void FaceTarget()
    {

        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
