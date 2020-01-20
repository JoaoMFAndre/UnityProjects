using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDamage : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public int currentHealth;

    public float hitAnimationTimer;

    public int projectileDamageAmount = 20;
    public int DOTDamageAmount = 5;
    public int comboDamageAmount;

    public int rockDamageResistance;
    public int fireDamageResistance;
    public int iceDamageResistance;
    public int acidDamageResistance;
    public int poisonCloudDamageResistance;
    public int electricityDamageResistance;

    public float freezeTimer;

    public GameObject freezeEffect;

    public bool takingIceDamage;
    public bool frozen;
    public bool takingPoisonDamage;
    public bool isWet;
    public bool takingElectricDamage;

    private float damTimer;

    NavMeshAgent agent;
    EnemyTactics enemyTactics;
    GameObject aiden;
    public Gun gun;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        currentHealth = maxHealth;
        takingIceDamage = false;
        frozen = false;
        takingPoisonDamage = false;
        isWet = false;
        takingElectricDamage = false;

        aiden = PlayerManager.instance.player.gameObject;
        gun = aiden.GetComponentInChildren<Gun>();

        agent = GetComponent<NavMeshAgent>();
        enemyTactics = GetComponent<EnemyTactics>();

        animator = GetComponent<Animator>();
        animator.SetBool("Dead", false);

        hitAnimationTimer = Random.Range(3f, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        Death();

        if (damTimer > 0)
        {
            damTimer -= Time.deltaTime;
        }

        if (takingIceDamage == false && frozen == false)
        {
            if (freezeTimer > 3)
            {
                freezeTimer -= Time.deltaTime;
            }
            else if (freezeTimer < 3)
            {
                freezeTimer += Time.deltaTime;
            }
        }

        if (gun.shootingIce == false)
        {
            takingIceDamage = false;
        }

        if (gun.shootingShock == false)
        {
            takingElectricDamage = false;
        }

        if (hitAnimationTimer > 0)
        {
            hitAnimationTimer -= Time.deltaTime;
        }

        if (currentHealth > health)
        {
            enemyTactics.alerted = true;
            currentHealth = health;
            if (hitAnimationTimer <= 0)
            {
                animator.SetBool("Hit", true);
                agent.Stop();
            }
        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.name == "Rock")
        {
            health = health - (projectileDamageAmount - rockDamageResistance);
            Debug.Log(gameObject + " took " + projectileDamageAmount + " damage");
        }
        

        else if (other.tag == "Ice")
        {
            takingIceDamage = true;
            
            if (damTimer <= 0)
            {
                health = health - (DOTDamageAmount - iceDamageResistance);
                damTimer = 1;
            }
            Debug.Log(gameObject + " took " + DOTDamageAmount + " damage");

            if (freezeTimer > 0 && frozen == false)
            {
                freezeTimer -= Time.deltaTime;
            }
            if (freezeTimer <= 0)
            {
                takingIceDamage = false;
                Instantiate(freezeEffect, transform.position, transform.rotation);
                freezeTimer = 5;
            }
        }
        
        else if (other.tag == "Electricity")
        {
            takingElectricDamage = true;
            if (damTimer <= 0)
            {
                health = health - (DOTDamageAmount - electricityDamageResistance);
                damTimer = 1;
            }
            Debug.Log(gameObject + " took " + DOTDamageAmount + " damage");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            health = health - (projectileDamageAmount - fireDamageResistance);
            Debug.Log(gameObject + " took " + projectileDamageAmount + " damage");
        }
        else if (collision.gameObject.tag == "Acid")
        {
            health = health - (projectileDamageAmount - acidDamageResistance);
            Debug.Log(gameObject + " took " + projectileDamageAmount + " damage");
        }
    }

    void OnTriggerStay(Collider collider)
    {   
        if (collider.gameObject.tag == "Acid_Pool")
        {
            takingPoisonDamage = true;
            if (takingPoisonDamage == true)
            {
                if (damTimer <= 0)
                {
                    health = health - (DOTDamageAmount - poisonCloudDamageResistance);
                    damTimer = 1;
                }
                Debug.Log(gameObject + " took " + DOTDamageAmount + " damage");
            }
        }  
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Acid_Pool")
        {
            takingPoisonDamage = false;
        }
    }

    public void Death()
    {
        if (health <= 0)
        {
            animator.SetBool("Dead", true);
            agent.Stop();
        }
    }

    //Animation Death Event
    public void OnDeath()
    {
        Destroy(gameObject);
    }

    public void HitAnimationEnd()
    {
        animator.SetBool("Hit", false);
        hitAnimationTimer = Random.Range(3f, 6f);
        agent.Resume();
    }
}
