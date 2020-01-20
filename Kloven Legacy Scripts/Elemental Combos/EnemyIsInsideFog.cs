using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIsInsideFog : MonoBehaviour
{
    public float fogCloudEffectTimer;
    public GameObject sphere;

    // Start is called before the first frame update
    void Start()
    {
        fogCloudEffectTimer = 9.5f;
    }

    // Update is called once per frame
    void Update()
    {
        fogCloudEffectTimer -= Time.deltaTime;
        if (fogCloudEffectTimer <= 0)
        {
            if (GameObject.FindWithTag("Enemy") != null)
            {
                EnemyDamage enemyDamage = GameObject.FindWithTag("Enemy").GetComponent<EnemyDamage>();
                enemyDamage.isWet = false;
                Destroy(sphere);
                if (GameObject.Find("EffectElectricCloud(Clone)") != null)
                {
                    Destroy(GameObject.Find("EffectElectricCloud(Clone)"));
                    GameObject.FindWithTag("Enemy").GetComponent<EnemyDamage>().takingElectricDamage = false;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (GameObject.FindWithTag("Enemy") != null)
        {
            if (other.gameObject.tag == "Enemy")
            {
                other.GetComponent<EnemyDamage>().isWet = true;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (GameObject.FindWithTag("Enemy") != null)
        {
            if (other.gameObject.tag == "Enemy")
            {
                other.GetComponent<EnemyDamage>().isWet = true;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (GameObject.FindWithTag("Enemy") != null)
        {
            if (other.gameObject.tag == "Enemy")
            {
                other.GetComponent<EnemyDamage>().isWet = false;
            }
        }
    }
}
