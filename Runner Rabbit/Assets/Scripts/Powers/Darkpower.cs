﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Darkpower : MonoBehaviour


{
    private character Cha;
    Button button;
    HoldButton holdbutton;


    // Start is called before the first frame update
    void Start()
    {
        Cha = GameObject.FindGameObjectWithTag("Player").GetComponent<character>();
        button = GetComponent<Button>();
        holdbutton = GetComponent<HoldButton>();
        button.image.sprite = GameStats.stats.darkPowerSprite;
        if (GameStats.stats.DarkpowerID < 51)
        {
            button.onClick.AddListener(Cha.DarkPower);
        }
        
        if (GameStats.stats.DarkpowerID == 51)
        {
            holdbutton.OnHoldDown.AddListener(Cha.DarkPowerHold);
            holdbutton.OnHoldUp.AddListener(Cha.DarkPowerHoldStop);
            print("holdButtonWithLaser");

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
