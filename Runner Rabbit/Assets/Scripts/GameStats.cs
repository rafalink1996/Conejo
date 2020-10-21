﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameStats : MonoBehaviour
{
    public Power powerLight;
    public Power powerDark;


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
    public float crystals;
    public int numOfHearts;

    public int totalLightMana;
    public int totalDarkMana;

    // crystal store

    public bool CoinTicket = false;
    public bool PortalBoost = false;
    public bool fenixFeather = false;
    public bool ExtraHearts = false;
    public bool ManaJar = false;

    public bool LevelBought = false;



    public int leveBoughtID;

    public int timedReward;
    public long timedRewardLastDate;


    public int CarrotMissleLevel;
    public int RadishMissleLevel;
    public int EarDefenceLevel;
    public int KickReflectLevel;
    public int MagicLaserLevel;


    public int LevelReached;

    public List<Power> UnlockedPowers = new List<Power>();





    // level indicator

    public int LevelCount;
    public int LevelIndicator;

    //skins
    public int topSkinID;
    public int botSkinID;


    //audio saved stats
    public float MusicVolume;
    public float AudioVolume;
    

    public bool[] skinConditions = new [ ]
    {
        false,// 0. tophat
        false,// 1. Astral Traveler
        false // 2. Slime

    };
    public bool bossDead;
    public bool spawnHouse;

    // achievemnts
    public bool[] AchivementConditions =  new[ ]{
        false, // 1.Wyrm Defeated
        false, // 2.MageGoblin Defeated
        false, // 3.Yeti Defeated
        false, // 4.CarnivorousPlant Defeated
        false, // 5.ClockworkGriffin Defeated
        false, // 6.Wizard Defeated
        false, // 7.acumulated 1000 Gold
        false, // 8.Acumulated 500 Crystals
        false, // 9.Bought All PowerUps for one run
        false, // 10.Have one legendary spell equiped
        false, // 11.Have two legendary spells equiped
        false, // 12.Killed 100 monsters
        false, // 13.spend over 1000 gold
        false, // 14.died 50 times
        false, // 15.kill a boss while having full health

        };
  
     
    


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

        LoadPlayer();


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
        // detect mas level reached for level bought store

        if (LevelIndicator == 2 && LevelReached <= 1)
        {

            LevelReached = 1;
        }

        if (LevelIndicator == 3 && LevelReached <= 2)
        {

            LevelReached = 2;
        }

        if (LevelIndicator == 4 && LevelReached <= 3)
        {

            LevelReached = 3;
        }

        if (LevelIndicator == 5 && LevelReached <= 4)
        {

            LevelReached = 4;
        }
        if (LevelIndicator == 6 && LevelReached <= 5)
        {

            LevelReached = 5;
        }




        if (LevelCount == 4)
        {
            LevelIndicator += 1;
            LevelCount -= 3;
        }

        lightPowerName = powerLight.name;
        lightPowerSprite = powerLight.iconLight;
        lightpowerID = powerLight.id;
        lightMana = powerLight.mana;

        darkPowerName = powerDark.name;
        darkPowerSprite = powerDark.iconDark;
        DarkpowerID = powerDark.id;
        darkMana = powerDark.mana;

        // achivments

        if (coins >= 1000)
        {
            AchivementConditions[6] = true;
        }
        


     

    }


    public void addSavedPowers()
    {

    }

    public void SaveStats()
    {
        SaveSystem.SavePlayer(this);
       // Debug.Log("game saved");
    }

    public void LoadPlayer ()
    {
        PlayerData data = SaveSystem.loadPlayer();

        CoinTicket = data.CoinTicketBought;
        PortalBoost = data.PortalBoostBought;
        fenixFeather = data.fenixfetherBought;
        ExtraHearts = data.ExtraHeartsBought;
        ManaJar = data.ManaJarBought;

        crystals = data.Crystals;
        leveBoughtID = data.level;

        LevelReached = data.levelReached;
        botSkinID = data.BotSkin;
        topSkinID = data.TopSkin;

        timedReward = data.TimeReward;
        timedRewardLastDate = data.TimedRewardLastDate;

        skinConditions[0] = data.skinConditions[0];
        skinConditions[1] = data.skinConditions[1];
        skinConditions[2] = data.skinConditions[2];


        CarrotMissleLevel = data.CarrotMissleLevel;
        EarDefenceLevel = data.EarDefenceLevel;
        RadishMissleLevel = data.RadishMissleLevel;
        KickReflectLevel = data.KickReflectLevel;
        MagicLaserLevel = data.MagicLaserLevel;

        AudioVolume = data.AudioVolume;
        MusicVolume = data.MusicVolume;

        

    }





}
