using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponTrigger : MonoBehaviour
{
    public int weaponDmg;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            col.gameObject.GetComponent<EnemyInformations>().GetDamage(weaponDmg);
        }
    }
}
