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
    

    public PlayerData (GameStats gamestats)
    {
        Crystals = gamestats.crystals;
        fenixfetherBought = gamestats.fenixFeather;
        PortalBoostBought = gamestats.PortalBoost;
        CoinTicketBought = gamestats.CoinTicket;
        level = gamestats.leveBoughtID;
    }

}
