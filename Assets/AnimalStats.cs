using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalStats : MonoBehaviour
{
    public int str;
    public int animalID = 1;
    public GameObject body;
    public Material squirrel, wolf, bear;
    public Vector3 scaleChange;
    public enum AnimalTypes
    {
        squirrel,
        wolf,
        bear,
    }

    public AnimalTypes myType;// Start is called before the first frame update
    void Start()
    {
        switch (myType)
        {
            case AnimalTypes.squirrel:
                str = 1;
                body.GetComponent<Renderer>().material = squirrel;
                scaleChange = new Vector3(-.5f, -.5f, -.5f);
                body.transform.localScale += scaleChange;
                GetComponentInChildren<AIBehaviour>().isAgressive = false;
                break;
            case AnimalTypes.wolf:
                str = 2;
                body.GetComponent<Renderer>().material = wolf;
                scaleChange = new Vector3(1f, 1f,1f);
                body.transform.localScale += scaleChange;
                GetComponentInChildren<AIBehaviour>().isAgressive = true;
                break;
            case AnimalTypes.bear:
                str = 3;
                body.GetComponent<Renderer>().material = bear;
                scaleChange = new Vector3(2f, 2f, 2f);
                body.transform.localScale += scaleChange;
                GetComponentInChildren<AIBehaviour>().isAgressive = false;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
