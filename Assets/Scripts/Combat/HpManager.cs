using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpManager : MonoBehaviour
{

    public int currentHP;
    public int maxHP;
    public int armor;
    //resist physical damage.
    public int resistance;
    //resist magical damage.


    private void Start()
    {
        currentHP = maxHP;
    }

    public void RemoveHp(int pvPerdu, int damageType)
        //reduces hp depending on damage type. 0 is physical, 1, magical. 
    {
        if (damageType == 0) { currentHP -= Mathf.Max (pvPerdu - armor,1); }
        if (damageType == 1) { currentHP -= Mathf.Max(pvPerdu - resistance); }
        if(currentHP <= 0)
        {
            Die();
        }
    }
    

    public void Die()
    {
        Destroy(gameObject);
    }
}
