﻿using System.Collections;
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
    public int muscleChargeMax = 3;
    public int muscleCharge;
    public int wakefulness;
    public int speed;

    //inventory
    public int apples;
    public int meat;
    public int wood;
    
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 1 + hunger + thirst * muscles;
        GetComponent<NavMeshAgent>().speed = speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health > maxHealth) health = maxHealth;
        if (hunger > maxHunger) hunger = maxHunger;
        if (thirst > maxThirst) thirst = maxThirst;
        GetComponent<NavMeshAgent>().speed = speed;
    }
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Fighting animal");

        if (col.gameObject.tag == "Animal" && col.gameObject.GetComponent<AnimalStats>().str <= muscles)
        {
            Destroy(col.gameObject);
            GetComponent<PlayerController>().selectedTarget = null;
            GetComponent<PlayerController>().gotTarget = false;
            GetComponent<PlayerController>().target = null;
            Debug.Log("won the rastle");
        }
        if(col.gameObject.tag == "Animal" && col.gameObject.GetComponent<AnimalStats>().str >= muscles)
        {
            Debug.Log("Lost the rastle");
            transform.position = GameObject.FindGameObjectWithTag("StartPos").transform.position;
            GetComponent<PlayerController>().target = null;
            GetComponent<PlayerController>().gotTarget = false;
            GetComponent<PlayerController>().selectedTarget = GameObject.FindGameObjectWithTag("StartPos").transform;
        }
    }
}
