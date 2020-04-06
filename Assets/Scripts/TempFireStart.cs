using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempFireStart : MonoBehaviour
{
    public AudioClip buildFire;
    public AudioSource source;
    public GameObject fireplace;
    public Transform buildLocation;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        buildLocation = GameObject.FindGameObjectWithTag("buildPos").transform;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MakeFireplace()
    {
        if(player.GetComponent<PlayerStats>().wood > 5)
        {
            source.PlayOneShot(buildFire, 1f);
            Instantiate(fireplace, buildLocation.position, buildLocation.rotation);
            player.GetComponent<PlayerStats>().wood -= 5;
        }
            
    }
}
