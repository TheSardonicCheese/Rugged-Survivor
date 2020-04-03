using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public string itemName;
    public int healthImpact;
    public int saturation;
    public int hydration;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(-Camera.main.transform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("You got a an apple.");
            other.GetComponent<PlayerStats>().apples += 1;
            /*other.GetComponent<PlayerStats>().health += healthImpact;
            other.GetComponent<PlayerStats>().hunger += saturation;
            other.GetComponent<PlayerStats>().thirst += hydration;*/
            Destroy(gameObject);
        }
    }
}
