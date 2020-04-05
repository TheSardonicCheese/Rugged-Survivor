using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public AudioClip treeFallingSound;
    private AudioSource source;

    public int health;// Start is called before the first frame update


    void Start()
    {
        health = Random.Range(2, 6);
        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            source.PlayOneShot(treeFallingSound,  1);
            Destroy(this.gameObject);
        }
    }
}
