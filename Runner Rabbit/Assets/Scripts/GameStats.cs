using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GameStats : MonoBehaviour
{
    #region Variables
    [Header("JsonSaveSystem")]
   // [SerializeField] DataManager myDataManager;
    public string debugLoad = "";

    [Space(15)]
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
    [Space(15)]
    [Header("POWER UPS")]


    public bool CoinTicket = false;
    public bool PortalBoost = false;
    public bool fenixFeather = false;
    public bool ExtraHearts = false;
    public bool ManaJar = false;

    [Space(5)]
    [Header("LEVEL BOUGHT")]

    public bool LevelBought = false;
    public int LevelBoughtCrystals;
    public int LevelBoughtCoins;
    public int leveBoughtID;

    [Space(5)]
    [Header("TIMED REWARD")]

    public int timedReward;
    public long timedRewardLastDate;


    [Space(5)]
    [Header("POWER LEVELS")]
    public int CarrotMissleLevel;
    public int RadishMissleLevel;
    public int EarDefenceLevel;
    public int KickReflectLevel;
    public int MagicLaserLevel;



    [Space(5)]

    public int LevelReached;

    public List<Power> UnlockedPowers = new List<Power>();

    public bool NoAdsBought = false;
    public bool NoAdsBoughtBackup = false;
    public bool SkinPackBought = false;



    // level indicator
    [Space(5)]
    [Header("CURRENT LEVEL")]
    public int LevelCount;// level stage
    public int LevelIndicator;// Scene ID

    [Space(5)]
    [Header("END OF LEVEL CONDITIONS")]
    public bool bossDead;
    public bool spawnHouse;


    [Space(15)]

    //skins
    [Header("SKINS")]
    public int topSkinID;
    public int botSkinID;


    [Space(5)]
    [Header("UNLOCKED SKINS")]
    public bool[] skinConditions = new[]
    {
        false,// 0. tophat
        false,// 1. skinpack1bought
        false,// 2. Angel
        false,// 3. Imp
        false,// 4. Snowman
        false,// 5. wizard
       

    };


    // achievemnts
    public bool[] AchivementConditions = new[]{
        false, // 0.Wyrm Defeated
        false, // 1.MageGoblin Defeated
        false, // 2.Yeti Defeated
        false, // 3.CarnivorousPlant Defeated
        false, // 4.ClockworkGriffin Defeated
        false, // 5.Wizard Defeated
        false, // 6.acumulated 1000 Gold
        false, // 7.Acumulated 500 Crystals
        false, // 8.Bought All PowerUps for one run
        false, // 9.Have one legendary spell equiped
        false, // 10.Have two legendary spells equiped
        false, // 11.Killed 400 monsters
        false, // 12.spend over 1000 gold
        false, // 13.died 50 times
        false, // 14.kill a boss while having full health

        };

    //audio saved stats
    [Space(10)]
    [Header("AUDIO SETTINGS")]
    public float MusicVolume;
    public float AudioVolume;



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


    [Space(10)]
    [Header("RUNES")]
    public Rune Rune1;
    public Rune Rune2;

    public int Rune1ID;
    public int Rune2ID;

    public bool[] UnlockedRunes = new[]{

        false, // 0.float
        false, // 1.fall
        false, // 2.magnet
        false, // 3.mana
        false, // 4.spell
        false, // 5.shield
        false, // 6.greed
        false, // 7.merchant
        false, // 8.destruction
        false  // 9.unknown
    };

    public Sprite[] runeSprites;

    public bool MerchantRune;



    // save Progress
    [Space(10)]
    [Header("SAVED PROGRESS")]

    public String LevelName;
    public int SavedLevelIndicator;
    public int SavedLevelCount;
    public float SavedLevelPercentage;
    public bool RunInProgress;


    public int SaveCurrentHearts;
    public bool isInStore;
    public int savedDarkPowerID;
    public int savedLightPowerID;
    public bool RunInProgressPortalBoost;
    public bool LoadingSavedLevel;
    public int Levelstartcoins;
    public bool BossRewardCollected;

    public float monstersKilled, MoneySpent, diedTimes;


    [Space(10)]
    [Header("LANGUAGE")]

    public int LanguageSelect;
    public bool languageselected;


    // 1 = english
    // 2 = Español
    [Space(10)]
    [Header("PLAYFAB")]
    public bool loginFinalized;


    [Space(10)]
    [Header("DEPENDENCIES")]
    public GamestatsSaveManager myGamestatsSaveManager;



    #endregion Variables

   
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

        //LevelCount = 1;
        //LevelIndicator = 3;

        Rune1 = (Rune)Rune1ID;
        Rune2 = (Rune)Rune2ID;
    }

    private void Update()
    {
        // detect mas level reached for level bought store

        if (LevelIndicator == 3 && LevelReached <= 1)
        {

            LevelReached = 1;
        }

        if (LevelIndicator == 4 && LevelReached <= 2)
        {

            LevelReached = 2;
        }

        if (LevelIndicator == 5 && LevelReached <= 3)
        {

            LevelReached = 3;
        }

        if (LevelIndicator == 6 && LevelReached <= 4)
        {

            LevelReached = 4;
        }
        if (LevelIndicator == 7 && LevelReached <= 5)
        {

            LevelReached = 5;
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

        if ((powerDark.id == 4 || powerDark.id == 14 || powerDark.id == 24 || powerDark.id == 34 || powerDark.id == 54) && (powerLight.id == 4 || powerLight.id == 14 || powerLight.id == 24 || powerLight.id == 34 || powerLight.id == 54))
        {
            AchivementConditions[10] = true;
        }




    }

    public void CheckLevelIndicator()
    {

        if (LevelCount == 4)
        {
            LevelIndicator += 1;
            LevelCount -= 3;
        }
    }

    public void CloudAchievements()
    {
        for (int i = 0; i < AchivementConditions.Length; i++)
        {
            if(AchivementConditions[i] == true)
            {
                ServicesManager.instance.CloudAchievements(i);
            }
           
        }
    }


    public string CheckLevel()
    {
        if (LevelIndicator == 1)
        {

            LevelName = "Level 1 (Library)";
        }
        if (LevelIndicator == 2)
        {

            LevelName = "Level 2 (dungeon)";
        }
        if (LevelIndicator == 3)
        {

            LevelName = "Level 3 (Frozen Room)";
        }
        if (LevelIndicator == 4)
        {

            LevelName = "Level 4 (Inner Jungle)";
        }
        if (LevelIndicator == 5)
        {

            LevelName = "Level 5 (SteampunkPortalRoom)";
        }
        if (LevelIndicator == 6)
        {

            LevelName = "Level 6 (FinalBattle)";
        }

        return LevelName;
    }

    public void SaveLevelBackUp()
    {
        SavedLevelCount = LevelCount;
        SavedLevelIndicator = LevelIndicator;
        RunInProgress = true;
        SaveStats();
    }

    public void CheckSavedPowers()
    {

        for (int i = 0; i < UnlockedPowers.Count; i++)
        {
            if (UnlockedPowers[i].id == savedDarkPowerID)
            {
                powerDark = UnlockedPowers[i];
            }

            if (UnlockedPowers[i].id == savedLightPowerID)
            {
                powerLight = UnlockedPowers[i];
            }

        }

    }
    public void HealToFull()
    {
        SaveCurrentHearts = numOfHearts;
        SaveStats();
    }


    public void CheckAchievements()
    {
        if (LevelReached > 1)
        {
            AchivementConditions[0] = true;
        }
        if (LevelReached >= 2)
        {
            AchivementConditions[1] = true;

        }
        if (LevelReached >= 3)
        {
            AchivementConditions[2] = true;

        }
        if (LevelReached >= 4)
        {
            AchivementConditions[3] = true;

        }
        if (LevelReached >= 5)
        {
            AchivementConditions[4] = true;

        }
    }

    #region SAVE STATS METHODS
    #region local Save Methods
    public void SaveStats()
    {

        myGamestatsSaveManager.SaveGamestats();
        
    }

    public void LoadPlayer()
    {
        myGamestatsSaveManager.LoadGamestats();
    }

    #endregion local Save Methods
    #region Cloud Save Methods
    public void UploadStats()
    {
        PlayFabData.PFD.SaveStats();
        saveServices();
    }

    public void LoadCloudSaveData()
    {  
      PlayFabData.PFD.LoadStats();

    }
    #endregion Cloud Save Methods
    #endregion SAVE STATS METHODS



    public void ResetStats()
    {
        stats.LevelIndicator = 1;
        stats.LevelCount = 1;
        stats.numOfHearts = 6;
        //stats.ExtraHearts = false;
        //stats.ManaJar = false;
        powerDark = originalDarkPower;
        powerLight = originalLightPower;
        coins = 0;
        stats.SavedLevelPercentage = 0;
        stats.SaveCurrentHearts = 3;
        savedDarkPowerID = originalDarkPower.id;
        savedLightPowerID = originalLightPower.id;
        totalLightMana = 30;
        totalDarkMana = 30;



        SaveStats();


    }


    void saveServices()
    {
        ServicesManager.instance.SubmitScoreToLeaderBoard(LevelReached);
        ServicesManager.instance.SumbitMonstersDefeatedScore(Mathf.FloorToInt(monstersKilled));
        
    }





}
