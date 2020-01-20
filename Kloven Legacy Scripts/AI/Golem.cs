using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Golem : MonoBehaviour
{
    public float lookRadius;
    private bool roar;
    Transform target;
    NavMeshAgent agent;
    EnemyDamage enemyDamage;
    GolemAttack enemyAttack;
    Animator animator;
    public CombatState combatState;

    // Start is called before the first frame update
    void Start()
    {
        combatState = GameObject.Find("GM").GetComponent<CombatState>();
        roar = true;
        enemyDamage = GetComponent<EnemyDamage>();
        enemyAttack = GetComponent<GolemAttack>();
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyDamage.health <= 0)
        {
            combatState.inCombat = false;
        }

        if (roar == false)
        {
            float distance = Vector3.Distance(target.transform.position, transform.position);

            //When the prey is within the enemy field of view, the enemy will chase it
            if (distance <= lookRadius)
            {
                //Always look at the prey if i can see him
                if (enemyDamage.health > 0)
                {
                    transform.LookAt(target.transform);
                    agent.SetDestination(target.transform.position);
                }
            }

            if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                    {
                        if (Vector3.Distance(transform.position, target.transform.position) < 8f)
                        {
                            animator.SetFloat("Speed", 0f);
                            enemyAttack.Attack();
                        }
                    }
                }
            }
            else
            {
                animator.SetFloat("Speed", 0.2f);
            }
        }
    }

    public void RoarEnd()
    {
        combatState.inCombat = true;
        roar = false;
        animator.SetBool("Roar", false);

        //GameObject.Find("GM").gameObject.SendMessage("GolemCinematicEnd");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
