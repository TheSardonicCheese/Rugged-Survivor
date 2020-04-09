using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //create stats
    public int maxHealth = 100;
    public int health = 100;
    public int maxHunger = 100;
    public int hunger = 100;
    public int maxThirst = 100;
    public int thirst = 100;
    public int maxMuscles = 100;
    public int muscles = 1;
    public int muscleChargeMax = 3;
    public int muscleCharge;
    public int wakefulness;
    public float speed;
    public bool atTree = false;

    //create timers
    public float hungertime = 7;
    public float thirsttime = 3.5f;

    //inventory
    public int apples;
    public int steak;
    public int meat;
    public int wood;

    public int waitingTime = 3;
    private IEnumerator chopTimer;
    public GameObject tree;

    //Audio
    public AudioClip woodChop;
    public AudioClip treeFallingSound;
    public AudioClip treeRustling;

    //dialouge
    public AudioClip lowHealth;
    public AudioClip starvation;
    public AudioClip dehydration;
    public AudioClip ohWow;
    public AudioClip protein;
    public AudioClip recover;
    public AudioClip unstoppable;


    public AudioSource speaker;
    public AudioSource Narrator;
    public AudioSource source;



    //checks
    bool starvationPlayed = false;
    bool lowhealthPlayed = false;
    bool dehydrationPlayed = false;
    bool ohWowPlayed = false;
    bool unstoppablePlayed = false;
    bool hungerPlayed = false;
    bool recoverPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        //speed = 1 + (hunger/2) + (thirst/2) * muscles;
        //GetComponent<NavMeshAgent>().speed = speed;
        speed = GetComponent<NavMeshAgent>().speed;
        //source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //say dialouge
        if ((health < 20) && lowhealthPlayed == false)
            {
                print("playing low health line");
                playSound(lowHealth, 1);
                lowhealthPlayed = true;
            }
        if ((hunger <= 0) && starvationPlayed == false)
            {
                print("playing starvation line");
                playSound(starvation, 1);
                starvationPlayed = true;
            }
        if ((thirst < 0) && dehydrationPlayed == false)
            {
                print("playing dehydration line");
                playSound(dehydration, 1);
                dehydrationPlayed = true;
            }
        if (maxMuscles > 50 && ohWowPlayed == false)
        {
            Narrator.PlayOneShot(ohWow, 1);
            ohWowPlayed = true;
        }
        if(maxMuscles > 80 && unstoppablePlayed == false)
        {
            Narrator.PlayOneShot(unstoppable, 1);
            unstoppablePlayed = true;
        }
        if (hunger < 80 && hungerPlayed == false)
        {
            Narrator.PlayOneShot(protein, 1);
            hungerPlayed = true;
        }
        if(muscleCharge == 0 && recoverPlayed == false)
        {
            Narrator.PlayOneShot(recover, 1);
            recoverPlayed = true;
        }

        //don't let stats exceed maximum or minimum
        if (health > maxHealth) health = maxHealth;
        if (hunger > maxHunger) hunger = maxHunger;
        if (hunger < 0) hunger = 0;
        if (thirst > maxThirst) thirst = maxThirst;
        if (thirst < 0) thirst = 0;
        if (muscles > maxMuscles) muscles = maxMuscles;

        //run timers
        hungertime -= Time.deltaTime;
        if (hungertime < 0)
        {
            hunger -= 1;
            hungertime = 7;
        }

        thirsttime -= Time.deltaTime;
        if (thirsttime < 0)
        {
            thirst -= 1;
            thirsttime = 7;
        }


        GetComponent<NavMeshAgent>().speed = speed;

        if(atTree = true && Input.GetKeyDown(KeyCode.Space))
        {
            source.PlayOneShot(woodChop, 1f);
            wood ++;
            tree.GetComponent<Tree>().health --;
            Debug.Log("chopping wood");
            if(tree.GetComponent<Tree>().health == 0)
            {
                source.PlayOneShot(treeFallingSound, 1);
                Debug.Log("Tree fell");
                atTree = false;
                tree = null;
                GetComponent<PlayerController>().DeselectTarget();
                maxMuscles++;
            }
        }
    }
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Fighting animal");

        if (col.gameObject.tag == "Animal" && col.gameObject.GetComponent<AnimalStats>().str <= muscles)
        {
            meat += col.gameObject.GetComponent<AnimalStats>().meat;
            Destroy(col.gameObject);
            GetComponent<PlayerController>().selectedTarget = null;
            GetComponent<PlayerController>().gotTarget = false;
            GetComponent<PlayerController>().target = null;
            Debug.Log("won the rastle");
            maxMuscles += 5;
        }
        if(col.gameObject.tag == "Animal" && col.gameObject.GetComponent<AnimalStats>().str >= muscles)
        {
            Debug.Log("Lost the rastle");
            transform.position = GameObject.FindGameObjectWithTag("StartPos").transform.position;
            GetComponent<PlayerController>().target = null;
            GetComponent<PlayerController>().gotTarget = false;
            GetComponent<PlayerController>().selectedTarget = GameObject.FindGameObjectWithTag("StartPos").transform;
            maxMuscles += 5;
        }
        if (col.gameObject.tag == "Tree")
        {
            Debug.Log("at tree");
            atTree = true;
            source.PlayOneShot(treeRustling, 1f);
            tree = col.gameObject;
            //StartCoroutine(ChopTimer(3f,col));
        }
    }
    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Tree")
        {
            atTree = false;
            tree = null;
            Debug.Log("left tree");
        }
    }

    void playSound(AudioClip mysound, float vol)
    {
        speaker.PlayOneShot(mysound, vol);
    }



}
