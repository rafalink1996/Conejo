using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float Crystals;

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






    public PlayerData(GameStats gamestats)
    {
        Crystals = gamestats.crystals;

        fenixfetherBought = gamestats.fenixFeather;
        PortalBoostBought = gamestats.PortalBoost;
        CoinTicketBought = gamestats.CoinTicket;
        ExtraHeartsBought = gamestats.ExtraHearts;
        ManaJarBought = gamestats.ManaJar;

        level = gamestats.leveBoughtID;

        

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

    }
}
