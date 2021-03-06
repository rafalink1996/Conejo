﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugTexts : MonoBehaviour
{
    //public Text lightMana;
   // public Text darkMana;
   // public Text levelCount;
   // public Text levelIndicator;
    public Text PowerDarkID;
    public Text PowerLightID;
    public Text lightManaCost;
    public Text DarkManaCost;
    ManaHandle mana;
    // Start is called before the first frame update
    void Start()
    {
        mana = FindObjectOfType<ManaHandle>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (mana != null)
        {
            lightMana.text = "Light Mana: " + mana.CurrentLightMana.ToString("F2");
            darkMana.text = "Dark Mana: " + mana.CurrentDarkMana.ToString("F2");
        }
        levelCount.text = "Level Count: " + GameStats.stats.LevelCount;
        levelIndicator.text = "Level Indicator: " + GameStats.stats.LevelIndicator;
        */
        PowerDarkID.text = "PowerDark ID: " + GameStats.stats.powerDark.id.ToString() + "(" + GameStats.stats.powerDark.name + ")";
        PowerLightID.text = "PowerLight ID: " + GameStats.stats.powerLight.id.ToString() + "(" + GameStats.stats.powerLight.name + ")";

        if (mana != null)
        {
            lightManaCost.text = "lightmanaCost: " + mana.LightManaUsed.ToString();
            DarkManaCost.text = "DarkManaCost: " + mana.DarkManaUsed.ToString();
        }

    }
}
