using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{

    private List<GameObject> attackers;

    public int simultaneousAttackers = 2;

    // Start is called before the first frame update
    void Awake()
    {
        attackers = new List<GameObject>();
    }

    void OnRequestAttack(GameObject requestor)
    {
        attackers.RemoveAll(item => item == null);

        if (attackers.Count < simultaneousAttackers)
        {
            if (!attackers.Contains(requestor))
            Debug.Log("Enemy Wants to Hit Me");
            attackers.Add(requestor);
            requestor.SendMessage("AttackAccepted", gameObject);
            Debug.Log("Attack accepted, current attackers: " + attackers.Count);
        }
        else
        {
            requestor.SendMessage("AttackRejected", gameObject);
            Debug.Log("Attack REJECTED, current attackers: " + attackers.Count);
        }
    }

    //If the enemy canceled the attack
    void OnCancelAttack(GameObject requestor)
    {
        attackers.Remove(requestor);
        Debug.Log("Attacker REMOVED, current attackers: " + attackers.Count);
    }
}
