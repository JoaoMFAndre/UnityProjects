using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceNFire : MonoBehaviour
{
    RFX4_DeactivateByTime deactivateByTime;
    RFX4_StartDelay startDelay;
    UnfreezeTarget unfreezeTarget;

    public GameObject explosionEffet;
    private GameObject fire;

    // Start is called before the first frame update
    void Start()
    {
        deactivateByTime = GetComponentInParent<RFX4_DeactivateByTime>();
        startDelay = GetComponentInParent<RFX4_StartDelay>();
        unfreezeTarget = GetComponentInParent<UnfreezeTarget>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fire")
        {
            unfreezeTarget.EffectTimer = 0;
            Instantiate(explosionEffet, transform.position, transform.rotation);
            Destroy(GameObject.Find("Effect23(Clone)"));
            Destroy(GameObject.Find("Effects"));
            Destroy(GameObject.Find("testCrystal (2)"));
            Destroy(GameObject.Find("Audio"));
        }
    }
}
