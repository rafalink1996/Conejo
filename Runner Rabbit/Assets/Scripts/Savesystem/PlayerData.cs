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
    public int level;
    public int MaxLevelReached;


    public int CarrotMissleLevel;
    public int EarDefenceLevel;
    public int RadishMissleLevel;
    public int KickReflectLevel;

    public int levelReached;

    public int BotSkin;
    public int TopSkin;

    

    

    public PlayerData (GameStats gamestats)
    {
        Crystals = gamestats.crystals;
        fenixfetherBought = gamestats.fenixFeather;
        PortalBoostBought = gamestats.PortalBoost;
        CoinTicketBought = gamestats.CoinTicket;
        level = gamestats.leveBoughtID;

        levelReached = gamestats.LevelReached;

        BotSkin = gamestats.botSkinID;
        TopSkin = gamestats.topSkinID;




        CarrotMissleLevel = gamestats.CarrotMissleLevel;
        EarDefenceLevel = gamestats.EarDefenceLevel;
        RadishMissleLevel = gamestats.RadishMissleLevel;
        KickReflectLevel = gamestats.KickReflectLevel;
    }

}
