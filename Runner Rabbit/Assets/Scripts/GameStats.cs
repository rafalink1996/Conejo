using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameStats : MonoBehaviour
{
    public Power powerLight;
    public Power powerDark;

    [SerializeField] private Power originalLightPower;
    [SerializeField] private Power originalDarkPower;


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


    public bool[] skinConditions = new[]
    {
        false,// 0. tophat
        false,// 1. skinpack1bought
        false,// 2. Angel
        false,// 3. Imp
        false,// 4. Snowman
        false,// 5. wizard
       

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
        false, // 12.Killed 400 monsters
        false, // 13.spend over 1000 gold
        false, // 14.died 50 times
        false, // 15.kill a boss while having full health

        };

    public float monstersKilled, MoneySpent, diedTimes;

    //passives - Runes

    public enum Rune
    {
        Default,
        FloatRune,// floats faster
        FallRune,// falls Faster
        MagnetRune,// coins fly towards the character
        ManaRune,// recharge mana faster
        SpellRune,// spells cost less mana to cast
        ShieldRune, // prevents first time you take damage
        GreedRune,// multiplies coins by 1.1 when reaching the store
        MerchandRune,// the first item you buy from the store is 50% off
        DestructionRune,// enemies spawn with 75% health
        AlternateWorldsRune// start the game with a random powerup you dont own
    };

    public Rune Rune1;
    public Rune Rune2;

    public int Rune1ID;
    public int Rune2ID;

    public bool[] UnlockedRunes = new[]{

        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false
    };

    public Sprite[] runeSprites;

    public bool MerchantRune;






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

        Rune1 = (Rune)Rune1ID;
        Rune2 = (Rune)Rune2ID;

        


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
        if (powerDark.id == 4 || powerDark.id == 14 || powerDark.id == 24 || powerDark.id == 34 || powerDark.id == 54 || powerLight.id == 4 || powerLight.id == 14 || powerLight.id == 24 || powerLight.id == 34 || powerLight.id == 54)
        {
            AchivementConditions[9] = true;
        }

        if ((powerDark.id == 4 || powerDark.id == 14 || powerDark.id == 24 || powerDark.id == 34 || powerDark.id == 54)&&(powerLight.id == 4 || powerLight.id == 14 || powerLight.id == 24 || powerLight.id == 34 || powerLight.id == 54))
        {
            AchivementConditions[10] = true;
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
        skinConditions[3] = data.skinConditions[3];
        skinConditions[4] = data.skinConditions[4];
        skinConditions[5] = data.skinConditions[5];


        CarrotMissleLevel = data.CarrotMissleLevel;
        EarDefenceLevel = data.EarDefenceLevel;
        RadishMissleLevel = data.RadishMissleLevel;
        KickReflectLevel = data.KickReflectLevel;
        MagicLaserLevel = data.MagicLaserLevel;

        AudioVolume = data.AudioVolume;
        MusicVolume = data.MusicVolume;

        AchivementConditions[0] = data.AchivementConditions[0];
        AchivementConditions[1] = data.AchivementConditions[1];
        AchivementConditions[2] = data.AchivementConditions[2];
        AchivementConditions[3] = data.AchivementConditions[3];
        AchivementConditions[4] = data.AchivementConditions[4];
        AchivementConditions[5] = data.AchivementConditions[5];
        AchivementConditions[6] = data.AchivementConditions[6];
        AchivementConditions[7] = data.AchivementConditions[7];
        AchivementConditions[8] = data.AchivementConditions[8];
        AchivementConditions[9] = data.AchivementConditions[9];
        AchivementConditions[10] = data.AchivementConditions[10];
        AchivementConditions[11] = data.AchivementConditions[11];
        AchivementConditions[12] = data.AchivementConditions[12];
        AchivementConditions[13] = data.AchivementConditions[13];
       

        MoneySpent = data.GoldSpent;
        monstersKilled = data.monstersKilled;
        diedTimes = data.diedTimes;

        Rune1ID = data.Rune1Id;
        Rune2ID = data.Rune2Id;

        UnlockedRunes[0] = data.unlockedRunes[0];
        UnlockedRunes[1] = data.unlockedRunes[1];
        UnlockedRunes[2] = data.unlockedRunes[2];
        UnlockedRunes[3] = data.unlockedRunes[3];
        UnlockedRunes[4] = data.unlockedRunes[4];
        UnlockedRunes[5] = data.unlockedRunes[5];
        UnlockedRunes[6] = data.unlockedRunes[6];
        UnlockedRunes[7] = data.unlockedRunes[7];
        UnlockedRunes[8] = data.unlockedRunes[8];
        UnlockedRunes[9] = data.unlockedRunes[9];

    }

    public void ResetStats()
    {
       stats.LevelIndicator = 2;
       stats.LevelCount = 1;
       stats.numOfHearts = 3;
       stats.ExtraHearts = false;
       stats.ManaJar = false;
       powerDark = originalDarkPower;
       powerLight = originalLightPower;
       coins = 0;


    }



}
