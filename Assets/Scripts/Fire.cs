using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public AudioClip fire;
    public AudioSource source;
    public float timer;
    public float firelength;
    public bool playerAtFire;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.PlayOneShot(fire, 1f);
        firelength = Random.Range(55, 60);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= firelength)
        {
            Destroy(gameObject);
        }
        if(playerAtFire == true)
        {
            player.GetComponent<PlayerStats>().health += (2 * Time.deltaTime);
            player.GetComponent<PlayerStats>().muscles += (5 * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerStats>().steak += other.GetComponent<PlayerStats>().meat;
            other.GetComponent<PlayerStats>().meat = 0;
            playerAtFire = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerAtFire = false;
        }
    }
}
