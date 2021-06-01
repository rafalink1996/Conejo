using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantHealth : MonoBehaviour
{
    public EnemyHealth healthTop;
    public EnemyHealth healthBot;
    //public Slider sliderTop;
    // Start is called before the first frame update
    void Start()
    {
        //sliderTop.maxValue = healthTop.healthSlider.maxValue;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (healthTop.health < healthBot.health)
        {
            //sliderTop.value = healthTop.health;
            healthBot.health = healthTop.health;
        }else 
        if (healthBot.health < healthTop.health)
        {
            //sliderTop.value = healthBot.health;
            healthTop.health = healthBot.health;
        }
    }
}
