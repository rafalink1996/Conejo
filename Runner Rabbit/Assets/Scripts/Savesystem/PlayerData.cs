using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float Crystals;
    public float Coins;

    public bool fenixfetherBought;
    public bool PortalBoostBought;
    public bool CoinTicketBought;
    public bool ExtraHeartsBought;
    public bool ManaJarBought;

    public int level;
    public int MaxLevelReached;

    public int TimeReward;
    public long TimedRewardLastDate;

    public int CarrotMissleLevel;
    public int EarDefenceLevel;
    public int RadishMissleLevel;
    public int KickReflectLevel;
    public int MagicLaserLevel;

    public int levelReached;

    public int BotSkin;
    public int TopSkin;

    public float AudioVolume;
    public float MusicVolume;

    public int SavedLevelIndicator;
    public int SavedLevelCount;
    public bool RunInProgress;
    public float savedLevelPercentage;
    public int MaxHearts;
    public int CurrentHearts;
    public bool IsInStore;

    public int Manalight;
    public int ManaDark;





    public bool[] skinConditions = new[]
    {
        false,
        false,
        false,
        false,
        false,
        false
        
    };

    //achivements

    public bool[] AchivementConditions = new []
    {
        false,
        false,
        false,
        false,
        false,
        false,
        false,
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


    public float GoldSpent;
    public float monstersKilled;
    public float diedTimes;

    public int Rune1Id;
    public int Rune2Id;

    public bool[] unlockedRunes = new[]{
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
    };

    public int SavedDarkPowerID;
    public int SavedLightPowerID;






    public PlayerData(GameStats gamestats)
    {
        Crystals = gamestats.crystals;
        Coins = gamestats.coins;

        fenixfetherBought = gamestats.fenixFeather;
        PortalBoostBought = gamestats.PortalBoost;
        CoinTicketBought = gamestats.CoinTicket;
        ExtraHeartsBought = gamestats.ExtraHearts;
        ManaJarBought = gamestats.ManaJar;

        level = gamestats.leveBoughtID;

        SavedLevelIndicator = gamestats.SavedLevelIndicator;
        SavedLevelCount = gamestats.SavedLevelCount;
        RunInProgress = gamestats.RunInProgress;
        savedLevelPercentage = gamestats.SavedLevelPercentage;
        IsInStore = gamestats.isInStore;
        MaxHearts = gamestats.numOfHearts;

        SavedDarkPowerID = gamestats.savedDarkPowerID;
        SavedLightPowerID = gamestats.savedLightPowerID;

        ManaDark = gamestats.totalDarkMana;
        Manalight = gamestats.totalLightMana;

        

        levelReached = gamestats.LevelReached;

        BotSkin = gamestats.botSkinID;
        TopSkin = gamestats.topSkinID;

        AudioVolume = gamestats.AudioVolume;
        MusicVolume = gamestats.MusicVolume;



        TimeReward = gamestats.timedReward;
        TimedRewardLastDate = gamestats.timedRewardLastDate;

        skinConditions[0] = gamestats.skinConditions[0];
        skinConditions[1] = gamestats.skinConditions[1];
        skinConditions[2] = gamestats.skinConditions[2];



        AchivementConditions[0] = gamestats.AchivementConditions[0];
        AchivementConditions[1] = gamestats.AchivementConditions[1];
        AchivementConditions[2] = gamestats.AchivementConditions[2];
        AchivementConditions[3] = gamestats.AchivementConditions[3];
        AchivementConditions[4] = gamestats.AchivementConditions[4];
        AchivementConditions[5] = gamestats.AchivementConditions[5];
        AchivementConditions[6] = gamestats.AchivementConditions[6];
        AchivementConditions[7] = gamestats.AchivementConditions[7];
        AchivementConditions[8] = gamestats.AchivementConditions[8];
        AchivementConditions[9] = gamestats.AchivementConditions[9];
        AchivementConditions[10] = gamestats.AchivementConditions[10];
        AchivementConditions[11] = gamestats.AchivementConditions[11];
        AchivementConditions[12] = gamestats.AchivementConditions[12];
        AchivementConditions[13] = gamestats.AchivementConditions[13];
        

        GoldSpent = gamestats.MoneySpent;
        monstersKilled = gamestats.monstersKilled;
        diedTimes = gamestats.diedTimes;







        CarrotMissleLevel = gamestats.CarrotMissleLevel;
        EarDefenceLevel = gamestats.EarDefenceLevel;
        RadishMissleLevel = gamestats.RadishMissleLevel;
        KickReflectLevel = gamestats.KickReflectLevel;
        MagicLaserLevel = gamestats.MagicLaserLevel;

        Rune1Id = gamestats.Rune1ID;
        Rune2Id = gamestats.Rune2ID;

        unlockedRunes[0] = gamestats.UnlockedRunes[0];
        unlockedRunes[1] = gamestats.UnlockedRunes[1];
        unlockedRunes[2] = gamestats.UnlockedRunes[2];
        unlockedRunes[3] = gamestats.UnlockedRunes[3];
        unlockedRunes[4] = gamestats.UnlockedRunes[4];
        unlockedRunes[5] = gamestats.UnlockedRunes[5];
        unlockedRunes[6] = gamestats.UnlockedRunes[6];
        unlockedRunes[7] = gamestats.UnlockedRunes[7];
        unlockedRunes[8] = gamestats.UnlockedRunes[8];
        unlockedRunes[9] = gamestats.UnlockedRunes[9];

    }
}
