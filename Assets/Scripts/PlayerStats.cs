using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 1;
    public int health = 1;
    public int maxHunger = 1;
    public int hunger = 1;
    public int maxThirst = 1;
    public int thirst = 1;
    public int muscles;
    public int wakefulness;
    public int speed;

    //inventory
    public int apples;
    public int meat;
    public int wood;
    
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<NavMeshAgent>().speed = 1 + hunger + thirst * muscles;
    }

    // Update is called once per frame
    void Update()
    {
        if (health > maxHealth) health = maxHealth;
        if (hunger > maxHunger) hunger = maxHunger;
        if (thirst > maxThirst) thirst = maxThirst;
    }
}
