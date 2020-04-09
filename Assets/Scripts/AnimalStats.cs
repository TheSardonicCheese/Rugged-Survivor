using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalStats : MonoBehaviour
{
    public int str;
    public int meat;
    public int animalID = 1;
    public GameObject body;
    public Material squirrel, wolf, bear;
    public Vector3 scaleChange;
    public AudioClip squirrelSound;
    public AudioClip wolfSound;
    public AudioClip bearSound;
    AudioClip mysound;
    public AudioSource mysource;
    //determine animal type
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
                meat = 1;
                body.GetComponent<Renderer>().material = squirrel;
                scaleChange = new Vector3(-.5f, -.5f, -.5f);
                body.transform.localScale += scaleChange;
                GetComponentInChildren<AIBehaviour>().isAgressive = false;
                mysound = squirrelSound;
                break;
            case AnimalTypes.wolf:
                str = 40;
                meat = 2;
                body.GetComponent<Renderer>().material = wolf;
                scaleChange = new Vector3(1f, 1f,1f);
                body.transform.localScale += scaleChange;
                GetComponentInChildren<AIBehaviour>().isAgressive = true;
                mysound = wolfSound;
                break;
            case AnimalTypes.bear:
                str = 80;
                meat = 5;
                body.GetComponent<Renderer>().material = bear;
                scaleChange = new Vector3(2f, 2f, 2f);
                body.transform.localScale += scaleChange;
                GetComponentInChildren<AIBehaviour>().isAgressive = false;
                mysound = bearSound;
                break;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            mysource.PlayOneShot(mysound, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
