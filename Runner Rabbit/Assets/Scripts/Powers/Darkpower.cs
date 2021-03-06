﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Darkpower : MonoBehaviour


{
    public character Cha;
    public Button button;
    public  HoldButton holdbutton;


    // Start is called before the first frame update
    void Start()
    {
        //Cha = GameObject.FindGameObjectWithTag("Player").GetComponent<character>();
        //button = GetComponent<Button>();
        //holdbutton = GetComponent<HoldButton>();
        button.image.sprite = GameStats.stats.powerDark.iconDark;


        /*
        if (GameStats.stats.DarkpowerID < 51)
        {
            button.onClick.AddListener(Cha.DarkPower);
        }
        
        else if (GameStats.stats.DarkpowerID == 51 || GameStats.stats.DarkpowerID == 52 || GameStats.stats.DarkpowerID == 53 || GameStats.stats.DarkpowerID == 54)
        {
            holdbutton.OnHoldDown.AddListener(Cha.DarkPowerHold);
            holdbutton.OnHoldUp.AddListener(Cha.DarkPowerHoldStop);
            print("holdButtonWithLaserDark");

        }
        */


        if (GameStats.stats.powerDark.id < 51)
        {
            button.enabled = true;
            holdbutton.enabled = false;
        }
        else if (GameStats.stats.powerDark.id == 51 || GameStats.stats.powerDark.id == 52 || GameStats.stats.powerDark.id == 53 || GameStats.stats.powerDark.id == 54)
        {
            button.enabled = false;
            holdbutton.enabled = true;
        }





    }

    // Update is called once per frame
    void Update()
    {
        if (Cha.top == true)
        {
            button.interactable = true;
            transform.SetSiblingIndex(1);

        }
        else
        {
            button.interactable = false;
            transform.SetSiblingIndex(0);
        }


    }
}
