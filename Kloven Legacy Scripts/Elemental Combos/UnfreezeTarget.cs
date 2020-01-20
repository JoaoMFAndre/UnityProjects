using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnfreezeTarget : MonoBehaviour
{
    public float EffectTimer;

    void Start()
    {
        EffectTimer = 6;
    }

    void Update()
    {
        EffectTimer -= Time.deltaTime;
        if (EffectTimer <= 0)
        {
            Destroy(GameObject.Find("testCrystal (2)").GetComponent<BoxCollider>());
            Destroy(this);
        }
    }
}
