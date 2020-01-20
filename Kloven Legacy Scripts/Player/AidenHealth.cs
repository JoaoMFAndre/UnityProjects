using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AidenHealth : MonoBehaviour
{
    public int maxHealth;

    public int health;

    private Vector3 attackerRelativePoint;

    public Slider healthBar;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
        animator.SetBool("Health", true);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health;
        if (health <= 0)
        {
            animator.SetLayerWeight(3, 1);
            animator.SetBool("Health", false);
        }
    }

    public void AidenHitAnimation(GameObject attacker)
    {
        //attackerRelativePoint = attacker.transform.InverseTransformPoint(transform.position);
        attackerRelativePoint = attacker.transform.position;
        if (attackerRelativePoint.x < transform.position.x && attackerRelativePoint.z < transform.position.z)
        {
            //Debug.Log("Left");
            //Debug.Log("Under");
            animator.SetBool("HitBackLeft", true);
        }
        if (attackerRelativePoint.x > transform.position.x && attackerRelativePoint.z < transform.position.z)
        {
            //Debug.Log("Right");
            //Debug.Log("Under");
            animator.SetBool("HitBackRight", true);
        }
        if (attackerRelativePoint.x < transform.position.x && attackerRelativePoint.z > transform.position.z)
        {
            //Debug.Log("Left");
            //Debug.Log("Above");
            animator.SetBool("HitFrontLeft", true);
        }
        if (attackerRelativePoint.x > transform.position.x && attackerRelativePoint.z < transform.position.z)
        {
            //Debug.Log("Right");
            //Debug.Log("Above");
            animator.SetBool("HitFrontRight", true);
        }
    }


    public void OnAidenDeathAnimationEnd()
    {
        animator.SetLayerWeight(3, 0);
        SceneManager.LoadScene(0);
    }

    public void HitFromBackLeftEnd()
    {
        animator.SetBool("HitBackLeft", false);
    }

    public void HitFromBackRightEnd()
    {
        animator.SetBool("HitBackRight", false);
    }

    public void HitFromFrontLeftEnd()
    {
        animator.SetBool("HitFrontLeft", false);
    }

    public void HitFromFrontRightEnd()
    {
        animator.SetBool("HitFrontRight", false);
    }
}
