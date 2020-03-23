﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public string itemName;
    public int healthImpact;
    public int saturation;
    public int hydration;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("You used a " + itemName);
            other.GetComponent<PlayerStats>().health += healthImpact;
            other.GetComponent<PlayerStats>().hunger += saturation;
            other.GetComponent<PlayerStats>().thirst += hydration;
            Destroy(gameObject);
        }
    }
}