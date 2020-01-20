using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    private Animator animator;
    private float attackTimer;
    

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = PlayerManager.instance.player.gameObject;
        attackTimer = Random.Range(2,6);
        
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer -= Time.deltaTime;

    }

    public void Attack()
    {
        if (attackTimer <= 0)
        {
            animator.SetBool("Attack", true);
            agent.Stop();
        }
    }


    //Animation Event
    public void OnAttackEnd()
    {
        //Send Damage To Player
        if (Vector3.Distance(transform.position, player.transform.position) < 5f)
        {
            player.gameObject.SendMessage("AidenHitAnimation", gameObject);
            player.GetComponent<AidenHealth>().health -= damage;
            Debug.Log(player + " took " + damage);
            Debug.Log("Aiden HP: " + player.GetComponent<AidenHealth>().health + "/" + player.GetComponent<AidenHealth>().maxHealth);
        }
    }
   
    public void AnimationEnd()
    {
        animator.SetBool("Attack", false);
        attackTimer = Random.Range(2, 6);
        agent.Resume();
    }

}
