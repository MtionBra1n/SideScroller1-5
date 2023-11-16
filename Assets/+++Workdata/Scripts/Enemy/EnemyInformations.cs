using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInformations : MonoBehaviour
{
    private SpriteRenderer sr;
    public int enemyHealth;
    private bool isAlive;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void GetDamage(int dmg)
    {
        enemyHealth -= dmg;
        sr.color = Color.red;
        
        Invoke("SetColorBack", .5f);
    }

    void SetColorBack()
    {
        sr.color = Color.white;
    }
}
