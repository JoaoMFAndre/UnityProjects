using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTarget : MonoBehaviour
{
    UnfreezeTarget unfreezeTarget;

    void Start()
    {
        unfreezeTarget = GetComponentInParent<UnfreezeTarget>();
    }

    void Update()
    {
        /*if (unfreezeTarget.EffectTimer <= 0)
        {

        }*/
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            collider.GetComponent<EnemyDamage>().frozen = true;
        }

        if (unfreezeTarget.EffectTimer <= 0.2f)
        {
            collider.GetComponent<EnemyDamage>().frozen = false;
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            collider.GetComponent<EnemyDamage>().frozen = true;
        }
    }
}
