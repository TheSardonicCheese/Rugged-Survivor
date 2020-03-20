using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int hunger = 1;
    public int thirst = 1;
    public int muscles;
    public int wakefulness;
    public int speed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        speed = hunger + thirst * muscles;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
