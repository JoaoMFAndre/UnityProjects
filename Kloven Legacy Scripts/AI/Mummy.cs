using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mummy : MonoBehaviour
{
    public float lookRadius;
    public bool changeBehaviour;
    public int mummies;

    private bool kicking;
    private float chooseAttack;

    Transform target;
    NavMeshAgent agent;
    EnemyDamage enemyDamage;
    EnemyAttack enemyAttack;
    Animator animator;
    Collider collider;
    CombatState combatState;
    GameObject tomb;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
        combatState = GameObject.Find("GM").GetComponent<CombatState>();
        enemyDamage = GetComponent<EnemyDamage>();
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        enemyAttack = GetComponent<EnemyAttack>();
        animator = GetComponent<Animator>();
        changeBehaviour = false;
        tomb = GameObject.Find("Base_Tumulo");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!kicking)
        {
            if (!changeBehaviour)
            {
                Mummy1stBehaviour();
            }
            else
            {
                Mummy2ndBehaviour();
            }
        }

        if (enemyDamage.health <= 0)
        {
            animator.SetBool("Dead", true);
            enemyAttack.enabled = false;
            enemyDamage.enabled = false;
            agent.enabled = false;
            collider.enabled = false;
        }
    }
    public void Arise()
    {
        animator.SetBool("Dead", false);
        animator.SetBool("Arise", true);
        enemyDamage.health = 100;
    }
    public void AnimationEnded()
    {
        changeBehaviour = true;
        animator.SetLayerWeight(1, 1);
        animator.SetBool("Arise", false);
        
        enemyAttack.enabled = true;
        enemyDamage.enabled = true;
        agent.enabled = true;
        collider.enabled = true;
    }

    public void OnMummyDeath()
    {
        tomb.SendMessage("NumberOfMummiesAlive");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public void Mummy1stBehaviour()
    {
        if (enemyDamage.frozen == true)
        {
            agent.Stop();
            animator.enabled = false;
        }
        else if (enemyDamage.frozen == false)
        {
            agent.Resume();
            animator.enabled = true;
        }

        float distance = Vector3.Distance(target.transform.position, transform.position);

        //When the prey is within the enemy field of view, the enemy will chase it
        if (distance <= lookRadius)
        {
            //Always look at the prey if i can see him
            if (enemyDamage.health > 0)
            {
                transform.LookAt(target.transform);
            }
            agent.SetDestination(target.transform.position);
        }

        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    animator.SetFloat("Speed", 0f);
                    enemyAttack.Attack();
                }
            }
        }
        else
        {
            animator.SetFloat("Speed", 0.2f);
        }
    }

    public void Mummy2ndBehaviour()
    {
        if (enemyDamage.frozen == true)
        {
            agent.Stop();
            animator.enabled = false;
        }
        else if (enemyDamage.frozen == false)
        {
            agent.Resume();
            animator.enabled = true;
        }

        agent.speed = 6f;
        enemyAttack.damage = 30;
        float distance = Vector3.Distance(target.transform.position, transform.position);

        //When the prey is within the enemy field of view, the enemy will chase it
        if (distance <= lookRadius)
        {
            transform.LookAt(target.transform);
            agent.SetDestination(target.transform.position);
        }

        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    animator.SetFloat("Speed", 0f);
                    enemyAttack.Attack();
                }
            }
        }
        else
        {
            animator.SetFloat("Speed", 0.2f);
        }
    }

    public void MummyDeath()
    {
        if (changeBehaviour)
        {
            Destroy(gameObject);
        }
    }

    public void KickingEnd()
    {
        combatState.inCombat = true;
        kicking = false;
        animator.SetBool("Kicking", false);
    }
}
