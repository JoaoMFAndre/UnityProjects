using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnableMummy : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;
    EnemyDamage enemyDamage;
    EnemyAttack enemyAttack;
    Animator animator;
    Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
        enemyDamage = GetComponent<EnemyDamage>();
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        enemyAttack = GetComponent<EnemyAttack>();
        animator = GetComponent<Animator>();
    }

    public void Arise()
    {
        animator.SetBool("Dead", false);
        animator.SetBool("Arise", true);
    }
    public void AnimationEnded()
    {
        animator.SetBool("Arise", false);
        animator.SetLayerWeight(1, 1);

        enemyAttack.enabled = true;
        enemyDamage.enabled = true;
        agent.enabled = true;
        collider.enabled = true;
    }
}
