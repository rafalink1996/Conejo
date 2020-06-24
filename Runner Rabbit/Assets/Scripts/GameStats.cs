﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    public Power powerDark;
    public Power powerLight;

    public static GameStats stats;
    public string lightPowerName;
    public Sprite lightPowerSprite;
    public int lightpowerID;
    public float lightMana;
    public string darkPowerName;
    public Sprite darkPowerSprite;
    public int DarkpowerID;
    public float darkMana; 
    public float coins;
    public int numOfHearts;

    public int totalLightMana;
    public int totalDarkMana;




    // level indicator

    public int LevelCount;
    public int LevelIndicator;
  
    // Start is called before the first frame update
    void Awake()
    {
        if (stats == null)
        {
            DontDestroyOnLoad(gameObject);
            stats = this;
        }
        else if (stats != this)
        {
            Destroy(gameObject);
        }
    }
        void Start()
    {



        lightPowerName = powerLight.name;
        lightPowerSprite = powerLight.iconLight;
        lightpowerID = powerLight.id;
        lightMana = powerLight.mana;

        darkPowerName = powerDark.name;
        darkPowerSprite = powerDark.iconDark;
        DarkpowerID = powerDark.id;
        darkMana = powerDark.mana;

        LevelCount = 1;
        LevelIndicator = 2;


    }

    private void Update()
    {
        if (LevelCount == 4)
        {
            LevelIndicator += 1;
            LevelCount -= 3;
        }

        
    }





}
