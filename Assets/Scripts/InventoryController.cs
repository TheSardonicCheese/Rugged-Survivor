using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    //assign text
    public Text SteakNum;
    public Text MeatNum;
    public Text FruitNum;
    public Text WoodNum;

    //assign player
    public GameObject myPlayer;

    // Start is called before the first frame update
    void Start()
    {
        SteakNum.text = myPlayer.GetComponent<PlayerStats>().steak.ToString();
        MeatNum.text = myPlayer.GetComponent<PlayerStats>().meat.ToString();
        FruitNum.text = myPlayer.GetComponent<PlayerStats>().apples.ToString();
        WoodNum.text = myPlayer.GetComponent<PlayerStats>().wood.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        SteakNum.text = myPlayer.GetComponent<PlayerStats>().steak.ToString();
        MeatNum.text = myPlayer.GetComponent<PlayerStats>().meat.ToString();
        FruitNum.text = myPlayer.GetComponent<PlayerStats>().apples.ToString();
        WoodNum.text = myPlayer.GetComponent<PlayerStats>().wood.ToString();
    }
}
