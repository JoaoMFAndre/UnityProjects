using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonCloudTimer : MonoBehaviour
{
    public float poisonEffectTimer;
    public GameObject sphere;

    // Start is called before the first frame update
    void Start()
    {
        poisonEffectTimer = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        poisonEffectTimer -= Time.deltaTime;
        if (poisonEffectTimer <= 0)
        {
            if (GameObject.FindWithTag("Enemy") != null)
            {
                EnemyDamage enemyDamage = GameObject.FindWithTag("Enemy").GetComponent<EnemyDamage>();
                enemyDamage.takingPoisonDamage = false;
                Destroy(sphere);
            }
        }
    }
}
