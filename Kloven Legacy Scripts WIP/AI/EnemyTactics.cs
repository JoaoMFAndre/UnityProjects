using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTactics : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject prey;
    EnemyAttack enemyAttack;

    private Transform target;

    public float wanderRadius;
    public float lookRadius;

    private float wanderTimer;
    private float timer;
    private float reactTimer;
    private float lastReact;

    private bool canAttack;
    private bool seekingEnemy;
    

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        prey = PlayerManager.instance.player.gameObject;
        enemyAttack = GetComponent<EnemyAttack>();

        canAttack = false;
        seekingEnemy = true;

        wanderTimer = Random.Range(3, 7);
        reactTimer = Random.Range(5, 10);
        timer = wanderTimer;
        timer = reactTimer;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Get the distance between the prey/player and the enemy
        float distance = Vector3.Distance(prey.transform.position, transform.position);

        //When the prey is within the enemy field of view, the enemy will chase it
        if (distance <= lookRadius && seekingEnemy)
        {
            //Always look at the prey if i can see him
            transform.LookAt(prey.transform);
            agent.SetDestination(prey.transform.position);   
        }
        
        if (distance <= 30f)
        {
            seekingEnemy = false;
            if (canAttack)
            {
                transform.LookAt(prey.transform);
                agent.SetDestination(prey.transform.position);
                agent.avoidancePriority = 10;
                if (distance <= 3.5f)
                {
                    enemyAttack.Attack();
                }
            }
            else if (!canAttack)
            {
                transform.LookAt(prey.transform);
                Wander();
                agent.avoidancePriority = 50;

                if ((Time.fixedTime - lastReact) > reactTimer)
                {
                    React();
                }
            }
        }
    }


    void React()
    {
        lastReact = Time.fixedTime;

        if (canAttack == false)
        {
            RequestAttack();
        }
    }

    void Wander()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(prey.transform.position, wanderRadius, -1);
            if(Vector3.Distance(prey.transform.position, newPos) < 3f)
            {
                newPos = RandomNavSphere(prey.transform.position, wanderRadius, -1);
            }
            else
            {
                agent.SetDestination(newPos);
                timer = 0;
            }
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
        return navHit.position;
    }
    
    //Ask the Player if I can Attack 
    void RequestAttack()
    {
        Debug.Log("I want to attack you");
        prey.gameObject.SendMessage("OnRequestAttack", gameObject);
    }

    void AttackAccepted()
    {
        canAttack = true;
    }

    void AttackRejected()
    {
        canAttack = false;
    }

    void StopAttack()
    {
        Debug.Log("Im dont want hit you anymore");
        prey.gameObject.SendMessage("OnCancelAttack", gameObject);
        canAttack = false;
    }

    void OnJoiningBattle(GameObject requestor)
    {
        //I have joined the battle
        seekingEnemy = false;
        if (canAttack == false)
        {
           React();
        }
    }

    void OnLeavingBattle(GameObject requestor)
    {
        //I have left the battle
        seekingEnemy = true;
        StopAttack();
    }
}