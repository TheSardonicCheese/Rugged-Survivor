using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public int health;// Start is called before the first frame update
    void Start()
    {
        health = Random.Range(2, 6);
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
