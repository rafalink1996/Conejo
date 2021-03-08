using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PowerMEnu : MonoBehaviour
{
    public Animator powerbuttontransition;


    // transition to power menu
    public GameObject mainmenu;
    public GameObject powermenu;
    public GameObject TowerDark;
    public GameObject TowerLight;


    public float transitionTimein;
    public float transitionTimeout;


    // store manager
    public float FenixFeatherCost;
    public float PortalBoostCost;
    public float CoinTicketCost;
    public float ExtraHeartsCost;
    public float ManaJarCost;


    public float Level1toBossCost;
    public float level2Cost;

    public TextMeshProUGUI FenixFeather;
    public TextMeshProUGUI PortalBoost;
    public TextMeshProUGUI CoinTicket;
    public TextMeshProUGUI ExtraHearts;
    public TextMeshProUGUI ManaJar; 

    public GameObject FenixFeatherSoldOut;
    public GameObject PortalBoostSoldOut;
    public GameObject CoinTicketSoldOut;
    public GameObject ExtraHeartsSoldOut;
    public GameObject ManaJarSoldOut;

    public Animator notEnoughCrystals;

    public Power[] CarrotMissleTiers;
    public Power[] EarShieldTiers;
    public Power[] RadishMissleTiers;
    public Power[] KickReflectTiers;
    public Power[] MagicLaserTiers;

    public float CarrotMissleCrystalCost;
    public float EarShieldCrystalCost;
    public float RadishtMissleCrystalCost;
    public float KickReflectCrystalCost;
    public float MagicLaserCrystalCost;

    //public int CarrotMissleTierID;
    //public int EarShieldTierID;
    // public int RadishMissleTierID;
    // public int KickReflectTierID;

    public GameObject[] CarrotMissleTierUI;
    public GameObject[] EarShieldTierUI;
    public GameObject[] RadishMissleTierUI;
    public GameObject[] KickReflectTierUI;
    public GameObject[] MagicLaserTierUI;

    public TextMeshProUGUI CarrotMissleCostText;
    public TextMeshProUGUI EarShieldCostText;
    public TextMeshProUGUI RadishMissleCostText;
    public TextMeshProUGUI KickReflectCostText;
    public TextMeshProUGUI MagicLaserCostText;







    private void Start()
    {
        FenixFeather.text = FenixFeatherCost.ToString();
        PortalBoost.text = PortalBoostCost.ToString();
        CoinTicket.text = CoinTicketCost.ToString();
        ExtraHearts.text = ExtraHeartsCost.ToString();
        ManaJar.text = ManaJarCost.ToString();


        /*
        CarrotMissleTierID = GameStats.stats.CarrotMissleLevel;
        EarShieldTierID = GameStats.stats.EarDefenceLevel;
        KickReflectTierID = GameStats.stats.KickReflectLevel;
        RadishMissleTierID = GameStats.stats.RadishMissleLevel;
        */

        #region saved powers
        // Saved data loder
        // Save Data Carrot Missle
        if (GameStats.stats.CarrotMissleLevel == 2)
        {
            GameStats.stats.UnlockedPowers.Add(CarrotMissleTiers[1]);
        } else if (GameStats.stats.CarrotMissleLevel == 3)
        {
            GameStats.stats.UnlockedPowers.Add(CarrotMissleTiers[1]);
            GameStats.stats.UnlockedPowers.Add(CarrotMissleTiers[2]);
        }   else if (GameStats.stats.CarrotMissleLevel == 4)
        {
            GameStats.stats.UnlockedPowers.Add(CarrotMissleTiers[1]);
            GameStats.stats.UnlockedPowers.Add(CarrotMissleTiers[2]);
            GameStats.stats.UnlockedPowers.Add(CarrotMissleTiers[3]);
        }

        // Save data ear shield
        if (GameStats.stats.EarDefenceLevel == 2)
        {
            GameStats.stats.UnlockedPowers.Add(EarShieldTiers[1]);
        }
        else if (GameStats.stats.EarDefenceLevel == 3)
        {
            GameStats.stats.UnlockedPowers.Add(EarShieldTiers[1]);
            GameStats.stats.UnlockedPowers.Add(EarShieldTiers[2]);
        }
        else if (GameStats.stats.EarDefenceLevel == 4)
        {
            GameStats.stats.UnlockedPowers.Add(EarShieldTiers[1]);
            GameStats.stats.UnlockedPowers.Add(EarShieldTiers[2]);
            GameStats.stats.UnlockedPowers.Add(EarShieldTiers[3]);
        }

        // Save Data radish missle
        if (GameStats.stats.RadishMissleLevel == 1)
        {
            GameStats.stats.UnlockedPowers.Add(RadishMissleTiers[0]);
        }
        if (GameStats.stats.RadishMissleLevel == 2)
        {
            GameStats.stats.UnlockedPowers.Add(RadishMissleTiers[0]);
            GameStats.stats.UnlockedPowers.Add(RadishMissleTiers[1]);
        }
        else if (GameStats.stats.RadishMissleLevel == 3)
        {
            GameStats.stats.UnlockedPowers.Add(RadishMissleTiers[0]);
            GameStats.stats.UnlockedPowers.Add(RadishMissleTiers[1]);
            GameStats.stats.UnlockedPowers.Add(RadishMissleTiers[2]);
        }
        else if (GameStats.stats.RadishMissleLevel == 4)
        {
            GameStats.stats.UnlockedPowers.Add(RadishMissleTiers[0]);
            GameStats.stats.UnlockedPowers.Add(RadishMissleTiers[1]);
            GameStats.stats.UnlockedPowers.Add(RadishMissleTiers[2]);
            GameStats.stats.UnlockedPowers.Add(RadishMissleTiers[3]);
        }

        // save data KickReflect
        if (GameStats.stats.KickReflectLevel== 1)
        {
            GameStats.stats.UnlockedPowers.Add(KickReflectTiers[0]);
        }
        else if (GameStats.stats.KickReflectLevel == 2)
        {
            GameStats.stats.UnlockedPowers.Add(KickReflectTiers[1]);
            GameStats.stats.UnlockedPowers.Add(KickReflectTiers[0]);
        }
        else if (GameStats.stats.KickReflectLevel == 3)
        {
            GameStats.stats.UnlockedPowers.Add(KickReflectTiers[0]);
            GameStats.stats.UnlockedPowers.Add(KickReflectTiers[1]);
            GameStats.stats.UnlockedPowers.Add(KickReflectTiers[2]);
        }
        else if (GameStats.stats.KickReflectLevel == 4)
        {
            GameStats.stats.UnlockedPowers.Add(KickReflectTiers[0]);
            GameStats.stats.UnlockedPowers.Add(KickReflectTiers[1]);
            GameStats.stats.UnlockedPowers.Add(KickReflectTiers[2]);
            GameStats.stats.UnlockedPowers.Add(KickReflectTiers[3]);
        }

        // save data laser 
        if (GameStats.stats.MagicLaserLevel == 1)
        {
            GameStats.stats.UnlockedPowers.Add(MagicLaserTiers[0]);
            
        }
        else if (GameStats.stats.MagicLaserLevel == 2)
        {
            GameStats.stats.UnlockedPowers.Add(MagicLaserTiers[0]);
            GameStats.stats.UnlockedPowers.Add(MagicLaserTiers[1]);
        }
        else if (GameStats.stats.MagicLaserLevel == 3)
        {
            GameStats.stats.UnlockedPowers.Add(MagicLaserTiers[0]);
            GameStats.stats.UnlockedPowers.Add(MagicLaserTiers[1]);
            GameStats.stats.UnlockedPowers.Add(MagicLaserTiers[2]);
        }
        else if (GameStats.stats.MagicLaserLevel == 4)
        {
            GameStats.stats.UnlockedPowers.Add(MagicLaserTiers[0]);
            GameStats.stats.UnlockedPowers.Add(MagicLaserTiers[1]);
            GameStats.stats.UnlockedPowers.Add(MagicLaserTiers[2]);
            GameStats.stats.UnlockedPowers.Add(MagicLaserTiers[3]);
        }


        #endregion

        #region SetPowerUI
        // set power upgrade tier in UI
        //CarrotMissle UI
        if (GameStats.stats.CarrotMissleLevel == 0)
        {
            CarrotMissleTierUI[0].SetActive(false);
            CarrotMissleTierUI[1].SetActive(false);
            CarrotMissleTierUI[2].SetActive(false);
            CarrotMissleTierUI[3].SetActive(false);
        }
        if (GameStats.stats.CarrotMissleLevel == 1)
        {
            CarrotMissleTierUI[0].SetActive(true);
            CarrotMissleTierUI[1].SetActive(false);
            CarrotMissleTierUI[2].SetActive(false);
            CarrotMissleTierUI[3].SetActive(false);
        }
        else if (GameStats.stats.CarrotMissleLevel == 2)
        {
            CarrotMissleTierUI[0].SetActive(true);
            CarrotMissleTierUI[1].SetActive(true);
            CarrotMissleTierUI[2].SetActive(false);
            CarrotMissleTierUI[3].SetActive(false);
        }
        else if (GameStats.stats.CarrotMissleLevel == 3)
        {
            CarrotMissleTierUI[0].SetActive(true);
            CarrotMissleTierUI[1].SetActive(true);
            CarrotMissleTierUI[2].SetActive(true);
            CarrotMissleTierUI[3].SetActive(false);
        }
        else if (GameStats.stats.CarrotMissleLevel == 4)
        {
            CarrotMissleTierUI[0].SetActive(true);
            CarrotMissleTierUI[1].SetActive(true);
            CarrotMissleTierUI[2].SetActive(true);
            CarrotMissleTierUI[3].SetActive(true);
        }
        //EarShieldUI

        if (GameStats.stats.EarDefenceLevel == 0)
        {
            EarShieldTierUI[0].SetActive(false);
            EarShieldTierUI[1].SetActive(false);
            EarShieldTierUI[2].SetActive(false);
            EarShieldTierUI[3].SetActive(false);
        }
        if (GameStats.stats.EarDefenceLevel == 1)
        {
            EarShieldTierUI[0].SetActive(true);
            EarShieldTierUI[1].SetActive(false);
            EarShieldTierUI[2].SetActive(false);
            EarShieldTierUI[3].SetActive(false);
        }
        else if (GameStats.stats.EarDefenceLevel == 2)
        {
            EarShieldTierUI[0].SetActive(true);
            EarShieldTierUI[1].SetActive(true);
            EarShieldTierUI[2].SetActive(false);
            EarShieldTierUI[3].SetActive(false);
        }
        else if (GameStats.stats.EarDefenceLevel == 3)
        {
            EarShieldTierUI[0].SetActive(true);
            EarShieldTierUI[1].SetActive(true);
            EarShieldTierUI[2].SetActive(true);
            EarShieldTierUI[3].SetActive(false);
        }
        else if (GameStats.stats.EarDefenceLevel == 4)
        {
            EarShieldTierUI[0].SetActive(true);
            EarShieldTierUI[1].SetActive(true);
            EarShieldTierUI[2].SetActive(true);
            EarShieldTierUI[3].SetActive(true);
        }

        // RadishMissle UI

        if (GameStats.stats.RadishMissleLevel == 0)
        {
            RadishMissleTierUI[0].SetActive(false);
            RadishMissleTierUI[1].SetActive(false);
            RadishMissleTierUI[2].SetActive(false);
            RadishMissleTierUI[3].SetActive(false);
        }
        if (GameStats.stats.RadishMissleLevel == 1)
        {
            RadishMissleTierUI[0].SetActive(true);
            RadishMissleTierUI[1].SetActive(false);
            RadishMissleTierUI[2].SetActive(false);
            RadishMissleTierUI[3].SetActive(false);
        }
        else if (GameStats.stats.RadishMissleLevel == 2)
        {
            RadishMissleTierUI[0].SetActive(true);
            RadishMissleTierUI[1].SetActive(true);
            RadishMissleTierUI[2].SetActive(false);
            RadishMissleTierUI[3].SetActive(false);
        }
        else if (GameStats.stats.RadishMissleLevel == 3)
        {
            RadishMissleTierUI[0].SetActive(true);
            RadishMissleTierUI[1].SetActive(true);
            RadishMissleTierUI[2].SetActive(true);
            RadishMissleTierUI[3].SetActive(false);
        }
        else if (GameStats.stats.RadishMissleLevel == 4)
        {
            RadishMissleTierUI[0].SetActive(true);
            RadishMissleTierUI[1].SetActive(true);
            RadishMissleTierUI[2].SetActive(true);
            RadishMissleTierUI[3].SetActive(true);
        }

        // kickReflect Ui
        if (GameStats.stats.KickReflectLevel == 0)
        {
            KickReflectTierUI[0].SetActive(false);
            KickReflectTierUI[1].SetActive(false);
            KickReflectTierUI[2].SetActive(false);
            KickReflectTierUI[3].SetActive(false);
        }
        if (GameStats.stats.KickReflectLevel == 1)
        {
            KickReflectTierUI[0].SetActive(true);
            KickReflectTierUI[1].SetActive(false);
            KickReflectTierUI[2].SetActive(false);
            KickReflectTierUI[3].SetActive(false);
        }
        else if (GameStats.stats.KickReflectLevel == 2)
        {
            KickReflectTierUI[0].SetActive(true);
            KickReflectTierUI[1].SetActive(true);      
            KickReflectTierUI[2].SetActive(false);
            KickReflectTierUI[3].SetActive(false);
        }
        else if (GameStats.stats.KickReflectLevel == 3)
        {
            KickReflectTierUI[0].SetActive(true);
            KickReflectTierUI[1].SetActive(true);
            KickReflectTierUI[2].SetActive(true);
            KickReflectTierUI[3].SetActive(false);
        }
        else if (GameStats.stats.KickReflectLevel == 4)
        {
            KickReflectTierUI[0].SetActive(true);
            KickReflectTierUI[1].SetActive(true);
            KickReflectTierUI[2].SetActive(true);
            KickReflectTierUI[3].SetActive(true);
        }

        // Magic Laser UI
        if (GameStats.stats.MagicLaserLevel == 0)
        {
            MagicLaserTierUI[0].SetActive(false);
            MagicLaserTierUI[1].SetActive(false);
            MagicLaserTierUI[2].SetActive(false);
            MagicLaserTierUI[3].SetActive(false);
        }
        if (GameStats.stats.MagicLaserLevel == 1)
        {
            MagicLaserTierUI[0].SetActive(true);
            MagicLaserTierUI[1].SetActive(false);
            MagicLaserTierUI[2].SetActive(false);
            MagicLaserTierUI[3].SetActive(false);
        }
        else if (GameStats.stats.MagicLaserLevel == 2)
        {
            MagicLaserTierUI[0].SetActive(true);
            MagicLaserTierUI[1].SetActive(true);
            MagicLaserTierUI[2].SetActive(false);
            MagicLaserTierUI[3].SetActive(false);
        }
        else if (GameStats.stats.MagicLaserLevel == 3)
        {
            MagicLaserTierUI[0].SetActive(true);
            MagicLaserTierUI[1].SetActive(true);
            MagicLaserTierUI[2].SetActive(true);
            MagicLaserTierUI[3].SetActive(false);
        }
        else if (GameStats.stats.MagicLaserLevel == 4)
        {
            MagicLaserTierUI[0].SetActive(true);
            MagicLaserTierUI[1].SetActive(true);
            MagicLaserTierUI[2].SetActive(true);
            MagicLaserTierUI[3].SetActive(true);
        }
        #endregion


    }



    private void Update()
    {


        // Update GameStats

        /*
        GameStats.stats.CarrotMissleLevel = CarrotMissleTierID;
        GameStats.stats.EarDefenceLevel = EarShieldTierID;
        GameStats.stats.RadishMissleLevel = RadishMissleTierID;
        GameStats.stats.KickReflectLevel = KickReflectTierID;
        */


        if (GameStats.stats.CarrotMissleLevel >= 4)
        {
            GameStats.stats.CarrotMissleLevel = 4;
        }
        if (GameStats.stats.EarDefenceLevel >= 4)
        {
            GameStats.stats.EarDefenceLevel = 4;
        }
        if(GameStats.stats.KickReflectLevel >= 4)
        {
            GameStats.stats.KickReflectLevel = 4;
        }
        if (GameStats.stats.RadishMissleLevel >= 4)
        {
            GameStats.stats.RadishMissleLevel = 4;
        }
        if (GameStats.stats.MagicLaserLevel >= 4)
        {
            GameStats.stats.MagicLaserLevel = 4;
        }

        // buy upgrades

        if (GameStats.stats.fenixFeather == true)
        {
            FenixFeatherSoldOut.SetActive(true);

        }
        else
        {
            FenixFeatherSoldOut.SetActive(false);
        }

        if (GameStats.stats.PortalBoost == true)
        {
            PortalBoostSoldOut.SetActive(true);

        }
        else
        {
            PortalBoostSoldOut.SetActive(false);
        }


        if (GameStats.stats.CoinTicket == true)
        {
            CoinTicketSoldOut.SetActive(true);

        }
        else
        {
            CoinTicketSoldOut.SetActive(false);
        }

        if (GameStats.stats.ExtraHearts == true)
        {
            ExtraHeartsSoldOut.SetActive(true);

        }
        else
        {
            ExtraHeartsSoldOut.SetActive(false);
        }

        if (GameStats.stats.ManaJar == true)
        {
            ManaJarSoldOut.SetActive(true);

        }
        else
        {
            ManaJarSoldOut.SetActive(false);
        }

        #region SetPowerUI
        // set power upgrade tier in UI
        //CarrotMissle UI
        if (GameStats.stats.CarrotMissleLevel == 0)
        {
            CarrotMissleTierUI[0].SetActive(false);
            CarrotMissleTierUI[1].SetActive(false);
            CarrotMissleTierUI[2].SetActive(false);
            CarrotMissleTierUI[3].SetActive(false);
        }
        if (GameStats.stats.CarrotMissleLevel == 1)
        {
            CarrotMissleTierUI[0].SetActive(true);
            CarrotMissleTierUI[1].SetActive(false);
            CarrotMissleTierUI[2].SetActive(false);
            CarrotMissleTierUI[3].SetActive(false);
        }
        else if (GameStats.stats.CarrotMissleLevel == 2)
        {
            CarrotMissleTierUI[0].SetActive(true);
            CarrotMissleTierUI[1].SetActive(true);
            CarrotMissleTierUI[2].SetActive(false);
            CarrotMissleTierUI[3].SetActive(false);
        }
        else if (GameStats.stats.CarrotMissleLevel == 3)
        {
            CarrotMissleTierUI[0].SetActive(true);
            CarrotMissleTierUI[1].SetActive(true);
            CarrotMissleTierUI[2].SetActive(true);
            CarrotMissleTierUI[3].SetActive(false);
        }
        else if (GameStats.stats.CarrotMissleLevel == 4)
        {
            CarrotMissleTierUI[0].SetActive(true);
            CarrotMissleTierUI[1].SetActive(true);
            CarrotMissleTierUI[2].SetActive(true);
            CarrotMissleTierUI[3].SetActive(true);
        }
        //EarShieldUI

        if (GameStats.stats.EarDefenceLevel == 0)
        {
            EarShieldTierUI[0].SetActive(false);
            EarShieldTierUI[1].SetActive(false);
            EarShieldTierUI[2].SetActive(false);
            EarShieldTierUI[3].SetActive(false);
        }
        if (GameStats.stats.EarDefenceLevel == 1)
        {
            EarShieldTierUI[0].SetActive(true);
            EarShieldTierUI[1].SetActive(false);
            EarShieldTierUI[2].SetActive(false);
            EarShieldTierUI[3].SetActive(false);
        }
        else if (GameStats.stats.EarDefenceLevel == 2)
        {
            EarShieldTierUI[0].SetActive(true);
            EarShieldTierUI[1].SetActive(true);
            EarShieldTierUI[2].SetActive(false);
            EarShieldTierUI[3].SetActive(false);
        }
        else if (GameStats.stats.EarDefenceLevel == 3)
        {
            EarShieldTierUI[0].SetActive(true);
            EarShieldTierUI[1].SetActive(true);
            EarShieldTierUI[2].SetActive(true);
            EarShieldTierUI[3].SetActive(false);
        }
        else if (GameStats.stats.EarDefenceLevel == 4)
        {
            EarShieldTierUI[0].SetActive(true);
            EarShieldTierUI[1].SetActive(true);
            EarShieldTierUI[2].SetActive(true);
            EarShieldTierUI[3].SetActive(true);
        }

        // RadishMissle UI

        if (GameStats.stats.RadishMissleLevel == 0)
        {
            RadishMissleTierUI[0].SetActive(false);
            RadishMissleTierUI[1].SetActive(false);
            RadishMissleTierUI[2].SetActive(false);
            RadishMissleTierUI[3].SetActive(false);
        }
        if (GameStats.stats.RadishMissleLevel == 1)
        {
            RadishMissleTierUI[0].SetActive(true);
            RadishMissleTierUI[1].SetActive(false);
            RadishMissleTierUI[2].SetActive(false);
            RadishMissleTierUI[3].SetActive(false);
        }
        else if (GameStats.stats.RadishMissleLevel == 2)
        {
            RadishMissleTierUI[0].SetActive(true);
            RadishMissleTierUI[1].SetActive(true);
            RadishMissleTierUI[2].SetActive(false);
            RadishMissleTierUI[3].SetActive(false);
        }
        else if (GameStats.stats.RadishMissleLevel == 3)
        {
            RadishMissleTierUI[0].SetActive(true);
            RadishMissleTierUI[1].SetActive(true);
            RadishMissleTierUI[2].SetActive(true);
            RadishMissleTierUI[3].SetActive(false);
        }
        else if (GameStats.stats.RadishMissleLevel == 4)
        {
            RadishMissleTierUI[0].SetActive(true);
            RadishMissleTierUI[1].SetActive(true);
            RadishMissleTierUI[2].SetActive(true);
            RadishMissleTierUI[3].SetActive(true);
        }

        // kickReflect Ui
        if (GameStats.stats.KickReflectLevel == 0)
        {
            KickReflectTierUI[0].SetActive(false);
            KickReflectTierUI[1].SetActive(false);
            KickReflectTierUI[2].SetActive(false);
            KickReflectTierUI[3].SetActive(false);
        }
        if (GameStats.stats.KickReflectLevel == 1)
        {
            KickReflectTierUI[0].SetActive(true);
            KickReflectTierUI[1].SetActive(false);
            KickReflectTierUI[2].SetActive(false);
            KickReflectTierUI[3].SetActive(false);
        }
        else if (GameStats.stats.KickReflectLevel == 2)
        {
            KickReflectTierUI[0].SetActive(true);
            KickReflectTierUI[1].SetActive(true);
            KickReflectTierUI[2].SetActive(false);
            KickReflectTierUI[3].SetActive(false);
        }
        else if (GameStats.stats.KickReflectLevel == 3)
        {
            KickReflectTierUI[0].SetActive(true);
            KickReflectTierUI[1].SetActive(true);
            KickReflectTierUI[2].SetActive(true);
            KickReflectTierUI[3].SetActive(false);
        }
        else if (GameStats.stats.KickReflectLevel == 4)
        {
            KickReflectTierUI[0].SetActive(true);
            KickReflectTierUI[1].SetActive(true);
            KickReflectTierUI[2].SetActive(true);
            KickReflectTierUI[3].SetActive(true);
        }

        // Magic Laser UI
        if (GameStats.stats.MagicLaserLevel == 0)
        {
            MagicLaserTierUI[0].SetActive(false);
            MagicLaserTierUI[1].SetActive(false);
            MagicLaserTierUI[2].SetActive(false);
            MagicLaserTierUI[3].SetActive(false);
        }
        if (GameStats.stats.MagicLaserLevel == 1)
        {
            MagicLaserTierUI[0].SetActive(true);
            MagicLaserTierUI[1].SetActive(false);
            MagicLaserTierUI[2].SetActive(false);
            MagicLaserTierUI[3].SetActive(false);
        }
        else if (GameStats.stats.MagicLaserLevel == 2)
        {
            MagicLaserTierUI[0].SetActive(true);
            MagicLaserTierUI[1].SetActive(true);
            MagicLaserTierUI[2].SetActive(false);
            MagicLaserTierUI[3].SetActive(false);
        }
        else if (GameStats.stats.MagicLaserLevel == 3)
        {
            MagicLaserTierUI[0].SetActive(true);
            MagicLaserTierUI[1].SetActive(true);
            MagicLaserTierUI[2].SetActive(true);
            MagicLaserTierUI[3].SetActive(false);
        }
        else if (GameStats.stats.MagicLaserLevel == 4)
        {
            MagicLaserTierUI[0].SetActive(true);
            MagicLaserTierUI[1].SetActive(true);
            MagicLaserTierUI[2].SetActive(true);
            MagicLaserTierUI[3].SetActive(true);
        }

        #endregion


        #region Set Crystal Cost for Powers

        // set Crystal Cost for powers
        // CarrotMissle Crystal Cost

        if (GameStats.stats.CarrotMissleLevel == 0)
        {
            CarrotMissleCrystalCost = 10;
        }
        else if (GameStats.stats.CarrotMissleLevel == 1)
        {
            CarrotMissleCrystalCost = 25;
        }
        else if (GameStats.stats.CarrotMissleLevel == 2)
        {
            CarrotMissleCrystalCost = 40;
        }
        else if (GameStats.stats.CarrotMissleLevel == 3)
        {
            CarrotMissleCrystalCost = 80;
        }
       

        // EarDefence Crystal Cost

        if (GameStats.stats.EarDefenceLevel == 0)
        {
            EarShieldCrystalCost = 10;
        }
        else if (GameStats.stats.EarDefenceLevel == 1)
        {
            EarShieldCrystalCost = 25;
        }
        else if (GameStats.stats.EarDefenceLevel == 2)
        {
            EarShieldCrystalCost = 40;
        }
        else if (GameStats.stats.EarDefenceLevel == 3)
        {
            EarShieldCrystalCost = 80;
        }
        


        // radish Missle crystal cost

        if (GameStats.stats.RadishMissleLevel == 0)
        {
            RadishtMissleCrystalCost = 15;
        }
        else if (GameStats.stats.RadishMissleLevel == 1)
        {
            RadishtMissleCrystalCost = 30;
        }
        else if (GameStats.stats.RadishMissleLevel == 2)
        {
            RadishtMissleCrystalCost = 50;
        }
        else if (GameStats.stats.RadishMissleLevel == 3)
        {
            RadishtMissleCrystalCost = 100;
        }
       

        // KickReflect Crystal Cost

        if (GameStats.stats.KickReflectLevel == 0)
        {
            KickReflectCrystalCost = 15;
        }
        else if (GameStats.stats.KickReflectLevel == 1)
        {
            KickReflectCrystalCost = 30;
        }
        else if (GameStats.stats.KickReflectLevel == 2)
        {
            KickReflectCrystalCost = 50;
        }
        else if (GameStats.stats.KickReflectLevel == 3)
        {
            KickReflectCrystalCost = 100;
        }

        // MagicLaser Crystal Cost

        if (GameStats.stats.MagicLaserLevel == 0)
        {
            MagicLaserCrystalCost = 50;
        }
        else if (GameStats.stats.MagicLaserLevel == 1)
        {
            MagicLaserCrystalCost = 75;
        }
        else if (GameStats.stats.MagicLaserLevel == 2)
        {
            MagicLaserCrystalCost = 100;
        }
        else if (GameStats.stats.MagicLaserLevel == 3)
        {
            MagicLaserCrystalCost = 150;
        }


        #endregion

        // power Cost to text in UI
        if (GameStats.stats.CarrotMissleLevel < 4)
        {
            CarrotMissleCostText.text = CarrotMissleCrystalCost.ToString();
        } else
        {
            CarrotMissleCostText.text = "Max";
        }

        if (GameStats.stats.EarDefenceLevel < 4)
        {
            EarShieldCostText.text = EarShieldCrystalCost.ToString();
        }
        else
        {
            EarShieldCostText.text = "Max";
        }

        if (GameStats.stats.KickReflectLevel < 4)
        {
            KickReflectCostText.text = KickReflectCrystalCost.ToString();
        }
        else
        {
            KickReflectCostText.text = "Max";
        }

        if (GameStats.stats.RadishMissleLevel < 4)
        {
            RadishMissleCostText.text = RadishtMissleCrystalCost.ToString();
        }
        else
        {
            RadishMissleCostText.text = "Max";
        }

        if (GameStats.stats.MagicLaserLevel < 4)
        {
            MagicLaserCostText.text = MagicLaserCrystalCost.ToString();
        }
        else
        {
            MagicLaserCostText.text = "Max";
        }




    }



    public void PowerMenu()
    {
        powerbuttontransition.SetTrigger("Powers");


        StartCoroutine(GoToPowersMenu());
    }

    public void PowerMenuBack()
    {
        powerbuttontransition.SetTrigger("Powers Out");


        StartCoroutine(backfromPowersMenu());
    }

    IEnumerator GoToPowersMenu()
    {

        yield return new WaitForSeconds(transitionTimein);

        powermenu.SetActive(true);
        TowerDark.SetActive(false);
        TowerDark.SetActive(false);

        Debug.Log("powermenu!");

        yield return null;
    }

    IEnumerator backfromPowersMenu()
    {

        yield return new WaitForSeconds(transitionTimeout);

        mainmenu.SetActive(true);
        TowerDark.SetActive(true);
        TowerDark.SetActive(true);

        yield return null;
    }


    public void BuyItem(float ItemID)
    {
        if (ItemID == 1)
        {
            if (GameStats.stats.crystals >= CoinTicketCost && GameStats.stats.CoinTicket == false)
            {
                GameStats.stats.crystals -= CoinTicketCost;
                GameStats.stats.CoinTicket = true;
                GameStats.stats.SaveStats();

            }
            else
            {
                if (GameStats.stats.crystals >= CoinTicketCost)
                {
                    Debug.Log("not enough crystals");
                    notEnoughCrystals.SetTrigger("NotEnoughCrystals");
                } else if (GameStats.stats.CoinTicket == false)
                {
                    Debug.Log("already bought"); 
                }

               
            }

        }

        if (ItemID == 2)
        {
            if (GameStats.stats.crystals >= PortalBoostCost && GameStats.stats.PortalBoost == false)
            {
                GameStats.stats.crystals -= PortalBoostCost;
                GameStats.stats.PortalBoost = true;
                GameStats.stats.SaveStats();

            }
            else
            {
                if (GameStats.stats.crystals >= PortalBoostCost)
                {
                    Debug.Log("not enough crystals");
                    notEnoughCrystals.SetTrigger("NotEnoughCrystals");
                }
                else if (GameStats.stats.PortalBoost == false)
                {
                    Debug.Log("already bought");
                }
            }
        }

        if (ItemID == 3)
        {
            if (GameStats.stats.crystals >= FenixFeatherCost && GameStats.stats.fenixFeather == false)
            {
                GameStats.stats.crystals -= FenixFeatherCost;
                GameStats.stats.fenixFeather = true;
                GameStats.stats.SaveStats();

            }
            else
            {
                if (GameStats.stats.crystals >= FenixFeatherCost)
                {
                    Debug.Log("not enough crystals");
                    notEnoughCrystals.SetTrigger("NotEnoughCrystals");
                }
                else if (GameStats.stats.fenixFeather == false)
                {
                    Debug.Log("already bought");
                }
            }
        }

        if (ItemID == 4)
        {
            if (GameStats.stats.crystals >= ExtraHeartsCost && GameStats.stats.ExtraHearts == false)
            {
                GameStats.stats.crystals -= ExtraHeartsCost;
                GameStats.stats.ExtraHearts = true;
                GameStats.stats.SaveStats();

            }
            else
            {
                if (GameStats.stats.crystals >= ExtraHeartsCost)
                {
                    Debug.Log("not enough crystals");
                    notEnoughCrystals.SetTrigger("NotEnoughCrystals");
                }
                else if (GameStats.stats.ExtraHearts == false)
                {
                    Debug.Log("already bought");
                }
            }
        }
        if (ItemID == 5)
        {
            if (GameStats.stats.crystals >= ManaJarCost && GameStats.stats.ManaJar == false)
            {
                GameStats.stats.crystals -= ManaJarCost;
                GameStats.stats.ManaJar = true;
                GameStats.stats.SaveStats();

            }
            else
            {
                if (GameStats.stats.crystals >= ManaJarCost)
                {
                    Debug.Log("not enough crystals");
                    notEnoughCrystals.SetTrigger("NotEnoughCrystals");
                }
                else if (GameStats.stats.ManaJar == false)
                {
                    Debug.Log("already bought");
                }
            }
        }

    }

    // buy power void by utton with ID

    public void BuyPowerUpgrade(int PowerStoreID)
    {
        // Carrot missle buy and add to list
        if (PowerStoreID == 1)
        {
            if (GameStats.stats.crystals >= CarrotMissleCrystalCost)
            {
                
                GameStats.stats.CarrotMissleLevel += 1;
                

                if (GameStats.stats.CarrotMissleLevel == 2)
                {
                    
                    GameStats.stats.UnlockedPowers.Add(CarrotMissleTiers[1]);
                    GameStats.stats.crystals -= CarrotMissleCrystalCost;
                }
                else if (GameStats.stats.CarrotMissleLevel == 3)
                {
                    GameStats.stats.UnlockedPowers.Add(CarrotMissleTiers[2]);
                    GameStats.stats.crystals -= CarrotMissleCrystalCost;
                }
                else if (GameStats.stats.CarrotMissleLevel == 4)
                {
                    GameStats.stats.UnlockedPowers.Add(CarrotMissleTiers[3]);
                    GameStats.stats.crystals -= CarrotMissleCrystalCost;
                }

            }
            else
            {
                Debug.Log("not enough crystals");
                notEnoughCrystals.SetTrigger("NotEnoughCrystals");
            }

        }

        // EarShield buy and add to list
        if (PowerStoreID == 2)
        {
            if (GameStats.stats.crystals >= EarShieldCrystalCost)
            {
               
                GameStats.stats.EarDefenceLevel += 1;
                

                if (GameStats.stats.EarDefenceLevel == 2)
                {
                    GameStats.stats.UnlockedPowers.Add(EarShieldTiers[1]);
                    GameStats.stats.crystals -= EarShieldCrystalCost;
                }
                else if (GameStats.stats.EarDefenceLevel == 3)
                {
                    GameStats.stats.UnlockedPowers.Add(EarShieldTiers[2]);
                    GameStats.stats.crystals -= EarShieldCrystalCost;
                }
                else if (GameStats.stats.EarDefenceLevel == 4)
                {
                    GameStats.stats.UnlockedPowers.Add(EarShieldTiers[3]);
                    GameStats.stats.crystals -= EarShieldCrystalCost;
                }
            }

            else
            {
                Debug.Log("not enough crystals");
                notEnoughCrystals.SetTrigger("NotEnoughCrystals");
            }
            }

        // kick reflect upgrade

            if (PowerStoreID == 3)
            {
                if (GameStats.stats.crystals >= KickReflectCrystalCost)
                {
                GameStats.stats.KickReflectLevel += 1;
                if (GameStats.stats.KickReflectLevel == 1)
                {
                    GameStats.stats.UnlockedPowers.Add(KickReflectTiers[0]);
                    GameStats.stats.crystals -= KickReflectCrystalCost;

                }
                else if (GameStats.stats.KickReflectLevel == 2)
                {
                    GameStats.stats.UnlockedPowers.Add(KickReflectTiers[1]);
                    GameStats.stats.crystals -= KickReflectCrystalCost;
                }
                else if (GameStats.stats.KickReflectLevel == 3)
                {
                    GameStats.stats.UnlockedPowers.Add(KickReflectTiers[2]);
                    GameStats.stats.crystals -= KickReflectCrystalCost;
                }
                else if (GameStats.stats.KickReflectLevel == 4)
                {
                    GameStats.stats.UnlockedPowers.Add(KickReflectTiers[3]);
                    GameStats.stats.crystals -= KickReflectCrystalCost;
                }

            }

           else
                {
                    Debug.Log("not enough crystals");
                    notEnoughCrystals.SetTrigger("NotEnoughCrystals");
                }
            }

            // radish missle upgrade

            if (PowerStoreID == 4)
            {
                if (GameStats.stats.crystals >= RadishtMissleCrystalCost)
                {
                  GameStats.stats.RadishMissleLevel += 1;
                  if (GameStats.stats.RadishMissleLevel == 1)
                  {
                    GameStats.stats.UnlockedPowers.Add(RadishMissleTiers[0]);
                    GameStats.stats.crystals -= RadishtMissleCrystalCost;
                  }
                  else if (GameStats.stats.RadishMissleLevel == 2)
                  {
                    GameStats.stats.UnlockedPowers.Add(RadishMissleTiers[1]);
                    GameStats.stats.crystals -= RadishtMissleCrystalCost;
                  }

                  else if (GameStats.stats.RadishMissleLevel == 3)
                  {
                    GameStats.stats.UnlockedPowers.Add(RadishMissleTiers[2]);
                    GameStats.stats.crystals -= RadishtMissleCrystalCost;
                  }
                  else if (GameStats.stats.RadishMissleLevel == 4)
                  {
                    GameStats.stats.UnlockedPowers.Add(RadishMissleTiers[3]);
                    GameStats.stats.crystals -= RadishtMissleCrystalCost;
                  }

            }
                else
                {
                    Debug.Log("not enough crystals");
                    notEnoughCrystals.SetTrigger("NotEnoughCrystals");
                }
            }

        // MagicLaser Upgrade
        if (PowerStoreID == 5)
        {
            if (GameStats.stats.crystals >= MagicLaserCrystalCost)
            {
                GameStats.stats.MagicLaserLevel += 1;
                if (GameStats.stats.MagicLaserLevel == 1)
                {
                    GameStats.stats.UnlockedPowers.Add(MagicLaserTiers[0]);
                    GameStats.stats.crystals -= MagicLaserCrystalCost;
                }
                else if (GameStats.stats.MagicLaserLevel == 2)
                {
                    GameStats.stats.UnlockedPowers.Add(MagicLaserTiers[1]);
                    GameStats.stats.crystals -= MagicLaserCrystalCost;
                }

                else if (GameStats.stats.MagicLaserLevel == 3)
                {
                    GameStats.stats.UnlockedPowers.Add(MagicLaserTiers[2]);
                    GameStats.stats.crystals -= MagicLaserCrystalCost;
                }
                else if (GameStats.stats.MagicLaserLevel == 4)
                {
                    GameStats.stats.UnlockedPowers.Add(MagicLaserTiers[3]);
                    GameStats.stats.crystals -= MagicLaserCrystalCost;
                }

            }
            else
            {
                Debug.Log("not enough crystals");
                notEnoughCrystals.SetTrigger("NotEnoughCrystals");
            }
        }
    }

}

/*
 ********* Power UI Tier old Update Method **************

 * if (GameStats.stats.CarrotMissleLevel <= 1)
        {
            CarrotMissleTierUI[0].SetActive(true);
        }
        else if (GameStats.stats.CarrotMissleLevel <= 2)
        {
            CarrotMissleTierUI[1].SetActive(true);
        }
        else if (GameStats.stats.CarrotMissleLevel <= 3)
        {
            CarrotMissleTierUI[2].SetActive(true);
        }
        else if (GameStats.stats.CarrotMissleLevel <= 4)
        {
            CarrotMissleTierUI[3].SetActive(true);
        }
        //EarShieldUI

        if (GameStats.stats.EarDefenceLevel <= 1)
        {
            EarShieldTierUI[0].SetActive(true);
        }
        else if (GameStats.stats.EarDefenceLevel <= 2)
        {
            EarShieldTierUI[1].SetActive(true);
        }
        else if (GameStats.stats.EarDefenceLevel <= 3)
        {
            EarShieldTierUI[2].SetActive(true);
        }
        else if (GameStats.stats.EarDefenceLevel <= 4)
        {
            EarShieldTierUI[3].SetActive(true);
        }

        // RadishMissle UI

        if (GameStats.stats.RadishMissleLevel == 1)
        {
            RadishMissleTierUI[0].SetActive(true);
        }
        else if (GameStats.stats.RadishMissleLevel <= 2)
        {
            RadishMissleTierUI[1].SetActive(true);
        }
        else if (GameStats.stats.RadishMissleLevel <= 3)
        {
            RadishMissleTierUI[2].SetActive(true);
        }
        else if (GameStats.stats.RadishMissleLevel <= 4)
        {
            RadishMissleTierUI[3].SetActive(true);
        }

        // kickReflect Ui

        if (GameStats.stats.KickReflectLevel == 0)
        {
            KickReflectTierUI[0].SetActive(false);
        }
        else if (GameStats.stats.KickReflectLevel == 1)
        {
            KickReflectTierUI[0].SetActive(true);
        }
        else if (GameStats.stats.KickReflectLevel <= 2)
        {
            KickReflectTierUI[1].SetActive(true);
        }
        else if (GameStats.stats.KickReflectLevel <= 3)
        {
            KickReflectTierUI[2].SetActive(true);
        }
        else if (GameStats.stats.KickReflectLevel <= 4)
        {
            KickReflectTierUI[3].SetActive(true);
        }

        // magic laser UI

        if (GameStats.stats.MagicLaserLevel <= 1)
        {
            MagicLaserTierUI[0].SetActive(true);
        }
        else if (GameStats.stats.MagicLaserLevel <= 2)
        {
            MagicLaserTierUI[1].SetActive(true);
        }
        else if (GameStats.stats.MagicLaserLevel <= 3)
        {
            MagicLaserTierUI[2].SetActive(true);
        }
        else if (GameStats.stats.MagicLaserLevel <= 4)
        {
            MagicLaserTierUI[3].SetActive(true);
        }
 */


