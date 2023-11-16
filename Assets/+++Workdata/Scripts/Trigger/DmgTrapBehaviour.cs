using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgTrapBehaviour : MonoBehaviour
{
    public bool playerIsInTrap;
    public int dmg;

    public float dmgTimer;
    private float dmgTime;
    
    private GameObject playerReference;

    private void Update()
    {
        if (playerIsInTrap)
        {
            dmgTime -= Time.deltaTime;
            if (dmgTime < 0)
            {
                playerReference.GetComponent<CharacterInformations>().GetDamage(dmg);
                SetDmgTimer();
            }
        }
    }

    void SetDmgTimer()
    {
        dmgTime = dmgTimer;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsInTrap = true;
            playerReference = other.gameObject;
            dmgTime = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsInTrap = false;
            playerReference = null;
        }
    }
}
