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
        false
    };






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





        skinConditions[0] = gamestats.skinConditions[0];
        skinConditions[1] = gamestats.skinConditions[1];
        skinConditions[2] = gamestats.skinConditions[2];









        CarrotMissleLevel = gamestats.CarrotMissleLevel;
        EarDefenceLevel = gamestats.EarDefenceLevel;
        RadishMissleLevel = gamestats.RadishMissleLevel;
        KickReflectLevel = gamestats.KickReflectLevel;
        MagicLaserLevel = gamestats.MagicLaserLevel;

    }
}
