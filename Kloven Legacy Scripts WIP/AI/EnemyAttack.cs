using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    GameObject player;

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
        }
    }

    //Animation Event
    public void OnAttackEnd()
    {
        //Send Damage To Player
        player.GetComponent<AidenHealth>().health -= damage;
        Debug.Log(player+ " took " +damage);
        Debug.Log("Aiden HP: " + player.GetComponent<AidenHealth>().health + "/" + player.GetComponent<AidenHealth>().maxHealth);
        animator.SetBool("Attack", false);
        attackTimer = Random.Range(2,6);
    }
}
