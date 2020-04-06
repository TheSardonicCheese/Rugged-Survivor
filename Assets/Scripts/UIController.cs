using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Image HealthWheel;
    public Image HungerWheel;
    public Image ThirstWheel;
    public Image MuscleBar;
    public GameObject myPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthWheel.fillAmount = (float)myPlayer.GetComponent<PlayerStats>().health/(float)myPlayer.GetComponent<PlayerStats>().maxHealth;
        HungerWheel.fillAmount = (float)myPlayer.GetComponent<PlayerStats>().hunger / (float)myPlayer.GetComponent<PlayerStats>().maxHunger;
        ThirstWheel.fillAmount = (float)myPlayer.GetComponent<PlayerStats>().thirst / (float)myPlayer.GetComponent<PlayerStats>().maxThirst;
        MuscleBar.fillAmount = (float)myPlayer.GetComponent<PlayerStats>().muscles / (float)myPlayer.GetComponent<PlayerStats>().maxMuscles;
    }
}
