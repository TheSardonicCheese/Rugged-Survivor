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
        if (itemName == "apple" && myplayer.GetComponent<PlayerStats>().apples >= 1)
        {
            print("you ate an " + itemName);
            //recover stats
            myplayer.GetComponent<PlayerStats>().health += healthImpact;
            myplayer.GetComponent<PlayerStats>().hunger += saturation;
            myplayer.GetComponent<PlayerStats>().thirst += hydration;
            //remove apple
            myplayer.GetComponent<PlayerStats>().apples -= 1;

        }
        else if (itemName == "meat" && myplayer.GetComponent<PlayerStats>().meat >= 1)
        {
            print("you ate some " + itemName);
            //recover stats
            myplayer.GetComponent<PlayerStats>().health += healthImpact;
            myplayer.GetComponent<PlayerStats>().hunger += saturation;
            myplayer.GetComponent<PlayerStats>().thirst += hydration;
            //remove meat
            myplayer.GetComponent<PlayerStats>().meat -= 1;
        }
        else if (itemName == "steak" && myplayer.GetComponent<PlayerStats>().steak >= 1)
        {
            print("you ate some " + itemName);
            //recover stats
            myplayer.GetComponent<PlayerStats>().health += healthImpact;
            myplayer.GetComponent<PlayerStats>().hunger += saturation;
            myplayer.GetComponent<PlayerStats>().thirst += hydration;
            //increase muscle charge
            myplayer.GetComponent<PlayerStats>().muscleCharge += 1;
            //remove meat
            myplayer.GetComponent<PlayerStats>().steak -= 1;
        }


    }
}
