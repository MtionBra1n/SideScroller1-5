using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Variablen : MonoBehaviour
{
    public int healthpoints;
    private int playerDamage;
    int playerExp;

    public float jumpPower, rollPower, movementSpeed, runSpeed;


    public int playerLevel = 1;
    public float currentSpeed = 5.5f;

    public bool isAlive = true;
    public bool isDead = false;

    private void Start()
    {
        AddNumbers(5, 3, "Joachim");
        AddNumbers(5, 30, "Chris");
    }

    float AddNumbers(int a, float b, string name)
    {
        float result = a + b;
        print(name + " hat gesagt, dass " + a + " plus " + b + " gleich " + result + " ist");
        return result;
    }
}
