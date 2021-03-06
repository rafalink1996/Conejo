﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PowerMEnu : MonoBehaviour
{
    public GameObject BGSpriteGoup;


    // transition to power menu
    public GameObject MainMenuHolder;
    public GameObject StoreHolder;
    public GameObject SkinMenuHolder;
    public GameObject TowerDark;
    public GameObject TowerLight;


    public float TransTime;
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

    public GameObject notEnoughCrystals;
    CanvasGroup NoCrystalsCanvasG;
    public GameObject notEnoughCrystalsRune;
    CanvasGroup NoCrystalsCanvasRuneG;

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

    bool isInRuneShop;
    [SerializeField] Button RuneStoreButton = null;
    [SerializeField] GameObject SeRunesTextHolder = null;
    [SerializeField] GameObject seStoreTextHolder = null;

    [SerializeField] PowerMenuDescription myPowerMenuDescription;
    [SerializeField] AudioSource BuySFX;
    [SerializeField] AudioSource NotEnough;








    private void Start()
    {
        FenixFeather.text = FenixFeatherCost.ToString();
        PortalBoost.text = PortalBoostCost.ToString();
        CoinTicket.text = CoinTicketCost.ToString();
        ExtraHearts.text = ExtraHeartsCost.ToString();
        ManaJar.text = ManaJarCost.ToString();

        NoCrystalsCanvasG = notEnoughCrystals.GetComponent<CanvasGroup>();
        NoCrystalsCanvasRuneG = notEnoughCrystalsRune.GetComponent<CanvasGroup>();

        myPowerMenuDescription = GetComponent<PowerMenuDescription>();
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

        PowerUpgradeCostUpdate();
    }

    public void DelayedStart()
    {
        FenixFeather.text = FenixFeatherCost.ToString();
        PortalBoost.text = PortalBoostCost.ToString();
        CoinTicket.text = CoinTicketCost.ToString();
        ExtraHearts.text = ExtraHeartsCost.ToString();
        ManaJar.text = ManaJarCost.ToString();

        #region saved powers
        // Saved data loder
        // Save Data Carrot Missle
        if (GameStats.stats.CarrotMissleLevel == 2)
        {
            GameStats.stats.UnlockedPowers.Add(CarrotMissleTiers[1]);
        }
        else if (GameStats.stats.CarrotMissleLevel == 3)
        {
            GameStats.stats.UnlockedPowers.Add(CarrotMissleTiers[1]);
            GameStats.stats.UnlockedPowers.Add(CarrotMissleTiers[2]);
        }
        else if (GameStats.stats.CarrotMissleLevel == 4)
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
        if (GameStats.stats.KickReflectLevel == 1)
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

        PowerUpgradeCostUpdate();
    }

    private void Update()
    {
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

        PowerUpgradeCostUpdate();


        #endregion


        PowerCostsDisplayUpdate();


    }



    public void PowerMenu()
    {
        LeanTween.moveLocalX(BGSpriteGoup, -1920, TransTime).setEase(LeanTweenType.easeOutExpo);
        LeanTween.moveLocalX(MainMenuHolder, -1920, TransTime).setEase(LeanTweenType.easeOutExpo);
        LeanTween.moveLocalX(SkinMenuHolder, -1920, TransTime).setEase(LeanTweenType.easeOutExpo);
        LeanTween.moveLocalX(StoreHolder, 0, TransTime).setEase(LeanTweenType.easeOutExpo);
       


        //StartCoroutine(GoToPowersMenu());
    }

    public void PowerMenuBack()
    {
        LeanTween.moveLocalX(BGSpriteGoup, 0, TransTime).setEase(LeanTweenType.easeOutExpo);
        LeanTween.moveLocalX(MainMenuHolder, 0, TransTime).setEase(LeanTweenType.easeOutExpo);
        LeanTween.moveLocalX(SkinMenuHolder, 0, TransTime).setEase(LeanTweenType.easeOutExpo);
        LeanTween.moveLocalX(StoreHolder, 1920, TransTime).setEase(LeanTweenType.easeOutExpo);
        //StartCoroutine(backfromPowersMenu());
    }

 

    public void GoToRuneShop()
    {
        if (!isInRuneShop)
        {
            isInRuneShop = true;
            StartCoroutine(DeactivateRuneButton());
            //LeanTween.moveLocalX(BGSpriteGoup, -3640, TransTime).setEase(LeanTweenType.easeOutExpo);
            LeanTween.moveLocalX(MainMenuHolder, -3840, TransTime).setEase(LeanTweenType.easeOutExpo);
            LeanTween.moveLocalX(SkinMenuHolder, -3840, TransTime).setEase(LeanTweenType.easeOutExpo);
            LeanTween.moveLocalX(StoreHolder, -1920, TransTime).setEase(LeanTweenType.easeOutExpo);
            LeanTween.moveLocalY(seStoreTextHolder, 138, TransTime).setEase(LeanTweenType.easeOutExpo);
            LeanTween.moveLocalY(SeRunesTextHolder, -88, TransTime).setEase(LeanTweenType.easeOutExpo);
        }
        else
        {
            isInRuneShop = false;
            StartCoroutine(DeactivateRuneButton());
           // LeanTween.moveLocalX(BGSpriteGoup, -1920, TransTime).setEase(LeanTweenType.easeOutExpo);
            LeanTween.moveLocalX(MainMenuHolder, -1920, TransTime).setEase(LeanTweenType.easeOutExpo);
            LeanTween.moveLocalX(SkinMenuHolder, -1920, TransTime).setEase(LeanTweenType.easeOutExpo);
            LeanTween.moveLocalX(StoreHolder, 0, TransTime).setEase(LeanTweenType.easeOutExpo);
            LeanTween.moveLocalY(seStoreTextHolder, -88, TransTime).setEase(LeanTweenType.easeOutExpo);
            LeanTween.moveLocalY(SeRunesTextHolder, 138, TransTime).setEase(LeanTweenType.easeOutExpo);

        }
    }

    IEnumerator DeactivateRuneButton()
    {
        RuneStoreButton.interactable = false;
        yield return new WaitForSeconds(TransTime);
        RuneStoreButton.interactable = true;
    }
       


    public void BuyItem(float ItemID)
    {
        if (ItemID == 1)
        {
            if (GameStats.stats.crystals >= CoinTicketCost && GameStats.stats.CoinTicket == false)
            {
                GameStats.stats.crystals -= CoinTicketCost;
                GameStats.stats.CoinTicket = true;

                BuySFX.Play();
                GameStats.stats.SaveStats();
                GameStats.stats.UploadStats();

            }
            else
            {
                if (GameStats.stats.crystals < CoinTicketCost)
                {
                    //Debug.Log("not enough crystals");
                    //notEnoughCrystals.SetTrigger("NotEnoughCrystals");
                    NotEnoughCrystals();
                } else if (GameStats.stats.CoinTicket == true)
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
                GameStats.stats.UploadStats();
                BuySFX.Play();

            }
            else
            {
                if (GameStats.stats.crystals < PortalBoostCost)
                {
                    //Debug.Log("not enough crystals");
                    //notEnoughCrystals.SetTrigger("NotEnoughCrystals");
                    NotEnoughCrystals();
                }
                else if (GameStats.stats.PortalBoost == true)
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
                GameStats.stats.UploadStats();
                BuySFX.Play();
            }
            else
            {
                if (GameStats.stats.crystals < FenixFeatherCost)
                {
                    //Debug.Log("not enough crystals");
                    //notEnoughCrystals.SetTrigger("NotEnoughCrystals");
                    NotEnoughCrystals();
                }
                else if (GameStats.stats.fenixFeather == true)
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
                GameStats.stats.UploadStats();
                BuySFX.Play();

            }
            else
            {
                if (GameStats.stats.crystals < ExtraHeartsCost)
                {
                    //Debug.Log("not enough crystals");
                    //notEnoughCrystals.SetTrigger("NotEnoughCrystals");
                    NotEnoughCrystals();
                }
                else if (GameStats.stats.ExtraHearts == true)
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
                GameStats.stats.UploadStats();
                BuySFX.Play();

            }
            else
            {
                if (GameStats.stats.crystals < ManaJarCost)
                {
                    //Debug.Log("not enough crystals");
                    //notEnoughCrystals.SetTrigger("NotEnoughCrystals");
                    NotEnoughCrystals();
                }
                else if (GameStats.stats.ManaJar == true)
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
                BuySFX.Play();

                GameStats.stats.SaveStats();
                GameStats.stats.UploadStats();

            }
            else
            {
                //Debug.Log("not enough crystals");
                //notEnoughCrystals.SetTrigger("NotEnoughCrystals");
                NotEnoughCrystals();
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
                BuySFX.Play();

                GameStats.stats.SaveStats();
                GameStats.stats.UploadStats();
            }

            else
            {
                //Debug.Log("not enough crystals");
                //notEnoughCrystals.SetTrigger("NotEnoughCrystals");
                NotEnoughCrystals();
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

                BuySFX.Play();
                GameStats.stats.SaveStats();
                GameStats.stats.UploadStats();

            }

           else
                {
                //Debug.Log("not enough crystals");
                //notEnoughCrystals.SetTrigger("NotEnoughCrystals");
                NotEnoughCrystals();
            }
            }

            // radish missle upgrade

            if (PowerStoreID == 4)
            {
                if (GameStats.stats.crystals >= RadishtMissleCrystalCost)
                {
                  GameStats.stats.RadishMissleLevel += 1;
                  if (GameStats.stats.RadishMissleLevel == 0)
                  {
                    GameStats.stats.UnlockedPowers.Add(RadishMissleTiers[0]);
                    GameStats.stats.crystals -= RadishtMissleCrystalCost;
                  }
                  else if (GameStats.stats.RadishMissleLevel == 1)
                  {
                    GameStats.stats.UnlockedPowers.Add(RadishMissleTiers[1]);
                    GameStats.stats.crystals -= RadishtMissleCrystalCost;
                  }

                  else if (GameStats.stats.RadishMissleLevel == 2)
                  {
                    GameStats.stats.UnlockedPowers.Add(RadishMissleTiers[2]);
                    GameStats.stats.crystals -= RadishtMissleCrystalCost;
                  }
                  else if (GameStats.stats.RadishMissleLevel == 3)
                  {
                    GameStats.stats.UnlockedPowers.Add(RadishMissleTiers[3]);
                    GameStats.stats.crystals -= RadishtMissleCrystalCost;
                  }

                BuySFX.Play();
                GameStats.stats.SaveStats();
                GameStats.stats.UploadStats();

            }
                else
                {
                //Debug.Log("not enough crystals");
                //notEnoughCrystals.SetTrigger("NotEnoughCrystals");
                
                NotEnoughCrystals();
            }
            }

        // MagicLaser Upgrade
        if (PowerStoreID == 5)
        {
            if (GameStats.stats.crystals >= MagicLaserCrystalCost)
            {
                GameStats.stats.MagicLaserLevel += 1;
                if (GameStats.stats.MagicLaserLevel == 0)
                {
                    GameStats.stats.UnlockedPowers.Add(MagicLaserTiers[0]);
                    GameStats.stats.crystals -= MagicLaserCrystalCost;

                }
                else if (GameStats.stats.MagicLaserLevel == 1)
                {
                    GameStats.stats.UnlockedPowers.Add(MagicLaserTiers[1]);
                    GameStats.stats.crystals -= MagicLaserCrystalCost;
                }

                else if (GameStats.stats.MagicLaserLevel == 2)
                {
                    GameStats.stats.UnlockedPowers.Add(MagicLaserTiers[2]);
                    GameStats.stats.crystals -= MagicLaserCrystalCost;
                }
                else if (GameStats.stats.MagicLaserLevel == 3)
                {
                    GameStats.stats.UnlockedPowers.Add(MagicLaserTiers[3]);
                    GameStats.stats.crystals -= MagicLaserCrystalCost;
                }

                BuySFX.Play();
                GameStats.stats.SaveStats();
                GameStats.stats.UploadStats();

            }
            else
            {
                //Debug.Log("not enough crystals");
                //notEnoughCrystals.SetTrigger("NotEnoughCrystals");
                NotEnoughCrystals();
            }
        }
        PowerCostsDisplayUpdate();
        PowerUpgradeCostUpdate();
        myPowerMenuDescription.CheckCrystalCost();
        myPowerMenuDescription.UpdateCrystalCost(myPowerMenuDescription.CurrentID);
    }


   public void NotEnoughCrystals()
    {
        LeanTween.cancel(notEnoughCrystals);
        LeanTween.alphaCanvas(NoCrystalsCanvasG, 1, 0.5f);
        LeanTween.alphaCanvas(NoCrystalsCanvasG, 0, 0.5f).setDelay(1);

        LeanTween.cancel(notEnoughCrystalsRune);
        LeanTween.alphaCanvas(NoCrystalsCanvasRuneG, 1, 0.5f);
        LeanTween.alphaCanvas(NoCrystalsCanvasRuneG, 0, 0.5f).setDelay(1);

        NotEnough.Play();
    }


     void PowerCostsDisplayUpdate()
    {
        // power Cost to text in UI
        if (GameStats.stats.CarrotMissleLevel < 4)
        {
            CarrotMissleCostText.text = CarrotMissleCrystalCost.ToString();
        }
        else
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

    void PowerUpgradeCostUpdate()
    {
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
            MagicLaserCrystalCost = 100;
        }
        else if (GameStats.stats.MagicLaserLevel == 1)
        {
            MagicLaserCrystalCost = 150;
        }
        else if (GameStats.stats.MagicLaserLevel == 2)
        {
            MagicLaserCrystalCost = 200;
        }
        else if (GameStats.stats.MagicLaserLevel == 3)
        {
            MagicLaserCrystalCost = 300;
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


