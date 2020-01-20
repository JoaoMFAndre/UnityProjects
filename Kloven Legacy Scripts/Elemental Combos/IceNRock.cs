using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceNRock : MonoBehaviour
{

    RFX4_DeactivateByTime deactivateByTime;
    RFX4_StartDelay startDelay;
    UnfreezeTarget unfreezeTarget;

    // Start is called before the first frame update
    void Start()
    {
        deactivateByTime = GetComponentInParent<RFX4_DeactivateByTime>();
        startDelay = GetComponentInParent<RFX4_StartDelay>();
        unfreezeTarget = GetComponentInParent<UnfreezeTarget>();
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.name == "Rock")
        {
            if (GameObject.Find("testCrystal") != null && GameObject.Find("Box001") != null)
            {
                GameObject go = GameObject.Find("testCrystal");
                GameObject go2 = GameObject.Find("Box001");

                unfreezeTarget.EffectTimer = 0;

                deactivateByTime.DeactivateTime = 0;
                startDelay.Delay = 0;
                Destroy(go);
                Destroy(go2);
            }
            
            if (GameObject.FindWithTag("Enemy") != null)
            {
                EnemyDamage enemyDamage = GameObject.FindWithTag("Enemy").GetComponent<EnemyDamage>();
                if (enemyDamage.frozen == true)
                {
                    enemyDamage.comboDamageAmount = enemyDamage.projectileDamageAmount * 2;
                    enemyDamage.health -= enemyDamage.comboDamageAmount;
                }
            }
        }
    }
}
