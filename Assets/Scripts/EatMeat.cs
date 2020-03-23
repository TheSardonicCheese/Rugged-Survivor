using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatMeat : MonoBehaviour
{
    public GameObject myplayer;
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

    public void EatFood()
    {
        print("you ate a " + itemName);
        //recover stats
        myplayer.GetComponent<PlayerStats>().health += healthImpact;
        myplayer.GetComponent<PlayerStats>().hunger += saturation;
        myplayer.GetComponent<PlayerStats>().thirst += hydration;
    }
}
