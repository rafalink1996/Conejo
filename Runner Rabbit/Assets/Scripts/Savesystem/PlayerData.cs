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


    public int CarrotMissleLevel;
    public int EarDefenceLevel;
    public int RadishMissleLevel;
    public int KickReflectLevel;

    

    

    public PlayerData (GameStats gamestats)
    {
        Crystals = gamestats.crystals;
        fenixfetherBought = gamestats.fenixFeather;
        PortalBoostBought = gamestats.PortalBoost;
        CoinTicketBought = gamestats.CoinTicket;
        level = gamestats.leveBoughtID;


        CarrotMissleLevel = gamestats.CarrotMissleLevel;
        EarDefenceLevel = gamestats.EarDefenceLevel;
        RadishMissleLevel = gamestats.RadishMissleLevel;
        KickReflectLevel = gamestats.KickReflectLevel;
    }

}
