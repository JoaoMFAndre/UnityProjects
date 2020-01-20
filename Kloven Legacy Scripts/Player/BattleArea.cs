using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleArea : MonoBehaviour
{


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Tell the AI that he joined the battle
            other.gameObject.SendMessage("OnJoiningBattle", gameObject);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Tell the AI that he left the battle
            other.gameObject.SendMessage("OnLeavingBattle", gameObject);
        }
    }
}
