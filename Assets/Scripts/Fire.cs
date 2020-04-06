using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public AudioClip fire;
    public AudioSource source;
    public float timer;
    public float firelength;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.PlayOneShot(fire, 1f);
        firelength = Random.Range(55, 60);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= firelength)
        {
            Destroy(gameObject);
        }
    }
}
