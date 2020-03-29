using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalStats : MonoBehaviour
{
    public int str;
    public int animalID = 1;
    public enum AnimalTypes
    {
        squirell,
        wolf,
        bear,
    }

    public AnimalTypes myType;// Start is called before the first frame update
    void Start()
    {
        switch (myType)
        {
            case AnimalTypes.squirell:
                str = 1;
                break;
            case AnimalTypes.wolf:
                str = 2;
                break;
            case AnimalTypes.bear:
                str = 3;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
