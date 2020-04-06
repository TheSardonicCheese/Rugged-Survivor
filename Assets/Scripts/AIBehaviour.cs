using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviour : MonoBehaviour
{
    public bool isChasing;
    public bool isFleeing;
    public bool isPatroling = true;
    public bool isAgressive;
    public int speed = 6;
    public Vector3 wayPoint;
    public GameObject player;
    public int Range = 10;
    public GameObject body;

    public AudioClip narChase;
    public AudioClip narFlee;
    private AudioSource source;
    private int lineCountChase = 0;
    private int lineCountFlee = 0;



    // Start is called before the first frame update
    void Start()
    {
        Wander();
        player = GameObject.FindGameObjectWithTag("Player");
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPatroling == true)
        {
            body.transform.position += transform.TransformDirection(Vector3.forward) * speed * Time.deltaTime;
            if ((transform.position - wayPoint).magnitude < 3)
            {
                // when the distance between us and the target is less than 3
                // create a new way point target
                Wander();
            }
        }
        if (isChasing == true)
        {
            //set player as destination
            //move toward destination
            float step = speed * Time.deltaTime; // calculate distance to move
            body.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
            
        }
        if(isChasing == true && lineCountChase < 1)
        {
            source.PlayOneShot(narChase, 1f);
            lineCountChase++;

        }
        if (isFleeing == true)
        {
            //set player as desintation
            //move away from destination
            float step = speed * Time.deltaTime; // calculate distance to move
            body.transform.position = Vector3.MoveTowards(transform.position, new Vector3 (player.transform.position.x, 1, player.transform.position.z), -step);
        }
        if(isChasing == true && lineCountFlee < 1)
        {
            source.PlayOneShot(narFlee, 1f);
            lineCountFlee++;
        }


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && isAgressive == true)

        {
            isChasing = true;
            isPatroling = false;
            wayPoint = other.transform.position;
        }
        else if (other.gameObject.tag == "Player" && isAgressive == false)
        {
            isFleeing = true;
            isPatroling = false;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isChasing = false;
            isFleeing = false;
            isPatroling = true;
            Wander();
        }
    }
    void Wander()
    {
        // does nothing except pick a new destination to go to

        wayPoint = new Vector3(Random.Range(transform.position.x - Range, transform.position.x + Range),
            1, Random.Range(transform.position.z - Range, transform.position.z + Range));
        wayPoint.y = 1;
        // don't need to change direction every frame seeing as you walk in a straight line only
        body.transform.LookAt(wayPoint);
        //Debug.Log(wayPoint + " and " + (transform.position - wayPoint).magnitude);
    }
}

