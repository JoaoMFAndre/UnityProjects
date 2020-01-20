using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinotaurAttack : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    private Animator animator;
    private float attackTimer;
    private float altAttackTimer;

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = PlayerManager.instance.player.gameObject;
        attackTimer = Random.Range(2, 6);
        //altAttackTimer = Random.Range(2, 6);
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer -= Time.deltaTime;
        //altAttackTimer -= Time.deltaTime;
    }

    public void Attack()
    {
        if (attackTimer <= 0)
        {
            agent.Stop();
            animator.SetBool("Attack", true);
        }
    }
    /*public void AlternativeAttack()
    {
        if (altAttackTimer <= 0)
        {
            animator.SetBool("Alternative Attack", true);
        }
    }*/

    //Animation Event
    public void OnAttackEnd()
    {
        //Send Damage To Player
        if (Vector3.Distance(transform.position, player.transform.position) < 22f)
        {
            player.GetComponent<AidenHealth>().health -= damage;
            Debug.Log(player + " took " + damage);
            Debug.Log("Aiden HP: " + player.GetComponent<AidenHealth>().health + "/" + player.GetComponent<AidenHealth>().maxHealth);
        }
    }
    /*public void OnAlternativeAttackEnd()
    {
        //Send Damage To Player
        if (Vector3.Distance(transform.position, player.transform.position) < 10f)
        {
            player.GetComponent<AidenHealth>().health -= damage;
            Debug.Log(player + " took " + damage);
            Debug.Log("Aiden HP: " + player.GetComponent<AidenHealth>().health + "/" + player.GetComponent<AidenHealth>().maxHealth);
        }
    }*/
    public void AnimationEnd()
    {
        animator.SetBool("Attack", false);
        attackTimer = Random.Range(2, 6);
        agent.Resume();
    }
    /*public void AlternativeAttackEnd()
    {
        animator.SetBool("Alternative Attack", false);
        altAttackTimer = Random.Range(2, 6);
    }*/
}
