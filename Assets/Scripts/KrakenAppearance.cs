using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenAppearance : MonoBehaviour
{
    public AudioSource source;
    public AudioClip Kraken;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time + timer;

        if (timer > 10f)
        {
            source.PlayOneShot(Kraken);
        }
    }
}
