using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PowerMenuBackup : MonoBehaviour
{
    /*
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
    public float Level1toBossCost;
    public float level2Cost;

    public TextMeshProUGUI FenixFeather;
    public TextMeshProUGUI PortalBoost;
    public TextMeshProUGUI CoinTicket;

    public GameObject FenixFeatherSoldOut;
    public GameObject PortalBoostSoldOut;
    public GameObject CoinTicketSoldOut;

    public Animator notEnoughCrystals;

    public Power[] CarrotMissleTiers;
    public Power[] EarShieldTiers;
    public Power[] RadishMissleTiers;
    public Power[] KickReflectTiers;

    public float CarrotMissleCrystalCost;
    public float EarShieldCrystalCost;
    public float RadishtMissleCrystalCost;
    public float KickReflectCrystalCost;

    public int CarrotMissleTierID;
    public int EarShieldTierID;
    public int RadishMissleTierID;
    public int KickReflectTierID;

    public GameObject[] CarrotMissleTierUI;
    public GameObject[] EarShieldTierUI;
    public GameObject[] RadishMissleTierUI;
    public GameObject[] KickReflectTierUI;

    public TextMeshProUGUI CarrotMissleCostText;
    public TextMeshProUGUI EarShieldCostText;
    public TextMeshProUGUI RadishMissleCostText;
    public TextMeshProUGUI KickReflectCostText;







    private void Start()
    {
        FenixFeather.text = FenixFeatherCost.ToString();
        PortalBoost.text = PortalBoostCost.ToString();
        CoinTicket.text = CoinTicketCost.ToString();


        CarrotMissleTierID = GameStats.stats.CarrotMissleLevel;
        EarShieldTierID = GameStats.stats.EarDefenceLevel;
        KickReflectTierID = GameStats.stats.KickReflectLevel;
        RadishMissleTierID = GameStats.stats.RadishMissleLevel;

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

        if (GameStats.stats.RadishMissleLevel == 2)
        {
            GameStats.stats.UnlockedPowers.Add(RadishMissleTiers[1]);
        }
        else if (GameStats.stats.RadishMissleLevel == 3)
        {
            GameStats.stats.UnlockedPowers.Add(RadishMissleTiers[1]);
            GameStats.stats.UnlockedPowers.Add(RadishMissleTiers[2]);
        }
        else if (GameStats.stats.RadishMissleLevel == 4)
        {
            GameStats.stats.UnlockedPowers.Add(RadishMissleTiers[1]);
            GameStats.stats.UnlockedPowers.Add(RadishMissleTiers[2]);
            GameStats.stats.UnlockedPowers.Add(RadishMissleTiers[3]);
        }

        // save data KickReflect

        if (GameStats.stats.KickReflectLevel == 2)
        {
            GameStats.stats.UnlockedPowers.Add(KickReflectTiers[1]);
        }
        else if (GameStats.stats.KickReflectLevel == 3)
        {
            GameStats.stats.UnlockedPowers.Add(KickReflectTiers[1]);
            GameStats.stats.UnlockedPowers.Add(KickReflectTiers[2]);
        }
        else if (GameStats.stats.KickReflectLevel == 4)
        {
            GameStats.stats.UnlockedPowers.Add(KickReflectTiers[1]);
            GameStats.stats.UnlockedPowers.Add(KickReflectTiers[2]);
            GameStats.stats.UnlockedPowers.Add(KickReflectTiers[3]);
        }
        #region SetPowerUI
        // set power upgrade tier in UI
        //CarrotMissle UI
        if (CarrotMissleTierID == 1)
        {
            CarrotMissleTierUI[0].SetActive(true);
        }
        else if (CarrotMissleTierID <= 2)
        {
            CarrotMissleTierUI[1].SetActive(true);
        }
        else if (CarrotMissleTierID <= 3)
        {
            CarrotMissleTierUI[2].SetActive(true);
        }
        else if (CarrotMissleTierID <= 4)
        {
            CarrotMissleTierUI[3].SetActive(true);
        }
        //EarShieldUI

        if (EarShieldTierID <= 1)
        {
            EarShieldTierUI[0].SetActive(true);
        }
        else if (EarShieldTierID <= 2)
        {
            EarShieldTierUI[1].SetActive(true);
        }
        else if (EarShieldTierID <= 3)
        {
            EarShieldTierUI[2].SetActive(true);
        }
        else if (EarShieldTierID <= 4)
        {
            EarShieldTierUI[3].SetActive(true);
        }

        // RadishMissle UI

        if (RadishMissleTierID == 1)
        {
            RadishMissleTierUI[0].SetActive(true);
        }
        else if (RadishMissleTierID <= 2)
        {
            RadishMissleTierUI[1].SetActive(true);
        }
        else if (RadishMissleTierID <= 3)
        {
            RadishMissleTierUI[2].SetActive(true);
        }
        else if (RadishMissleTierID <= 4)
        {
            RadishMissleTierUI[3].SetActive(true);
        }

        // kickReflect Ui

        if (KickReflectTierID <= 1)
        {
            KickReflectTierUI[0].SetActive(true);
        }
        else if (KickReflectTierID <= 2)
        {
            KickReflectTierUI[1].SetActive(true);
        }
        else if (KickReflectTierID <= 3)
        {
            KickReflectTierUI[2].SetActive(true);
        }
        else if (KickReflectTierID <= 4)
        {
            KickReflectTierUI[3].SetActive(true);
        }
        #endregion


    }



    private void Update()
    {


        // Update GameStats

        GameStats.stats.CarrotMissleLevel = CarrotMissleTierID;
        GameStats.stats.EarDefenceLevel = EarShieldTierID;
        GameStats.stats.RadishMissleLevel = RadishMissleTierID;
        GameStats.stats.KickReflectLevel = KickReflectTierID;


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

        #region SetPowerUI
        // set power upgrade tier in UI
        //CarrotMissle UI
        if (CarrotMissleTierID <= 1)
        {
            CarrotMissleTierUI[0].SetActive(true);
        }
        else if (CarrotMissleTierID <= 2)
        {
            CarrotMissleTierUI[1].SetActive(true);
        }
        else if (CarrotMissleTierID <= 3)
        {
            CarrotMissleTierUI[2].SetActive(true);
        }
        else if (CarrotMissleTierID <= 4)
        {
            CarrotMissleTierUI[3].SetActive(true);
        }
        //EarShieldUI

        if (EarShieldTierID <= 1)
        {
            EarShieldTierUI[0].SetActive(true);
        }
        else if (EarShieldTierID <= 2)
        {
            EarShieldTierUI[1].SetActive(true);
        }
        else if (EarShieldTierID <= 3)
        {
            EarShieldTierUI[2].SetActive(true);
        }
        else if (EarShieldTierID <= 4)
        {
            EarShieldTierUI[3].SetActive(true);
        }

        // RadishMissle UI

        if (RadishMissleTierID == 1)
        {
            RadishMissleTierUI[0].SetActive(true);
        }
        else if (RadishMissleTierID <= 2)
        {
            RadishMissleTierUI[1].SetActive(true);
        }
        else if (RadishMissleTierID <= 3)
        {
            RadishMissleTierUI[2].SetActive(true);
        }
        else if (RadishMissleTierID <= 4)
        {
            RadishMissleTierUI[3].SetActive(true);
        }

        // kickReflect Ui

        if (KickReflectTierID <= 1)
        {
            KickReflectTierUI[0].SetActive(true);
        }
        else if (KickReflectTierID <= 2)
        {
            KickReflectTierUI[1].SetActive(true);
        }
        else if (KickReflectTierID <= 3)
        {
            KickReflectTierUI[2].SetActive(true);
        }
        else if (KickReflectTierID <= 4)
        {
            KickReflectTierUI[3].SetActive(true);
        }
        #endregion




        // set Crystal Cost for powers
        // CarrotMissle Crystal Cost

        if (CarrotMissleTierID == 0)
        {
            CarrotMissleCrystalCost = 10;
        }
        else if (CarrotMissleTierID == 1)
        {
            CarrotMissleCrystalCost = 25;
        }
        else if (CarrotMissleTierID == 2)
        {
            CarrotMissleCrystalCost = 40;
        }
        else if (CarrotMissleTierID == 3)
        {
            CarrotMissleCrystalCost = 80;
        }

        // EarDefence Crystal Cost

        if (EarShieldTierID == 0)
        {
            EarShieldCrystalCost = 10;
        }
        else if (EarShieldTierID == 1)
        {
            EarShieldCrystalCost = 25;
        }
        else if (EarShieldTierID == 2)
        {
            EarShieldCrystalCost = 40;
        }
        else if (EarShieldTierID == 3)
        {
            EarShieldCrystalCost = 80;
        }


        // radish Missle crystal cost

        if (RadishMissleTierID == 0)
        {
            RadishtMissleCrystalCost = 15;
        }
        else if (RadishMissleTierID == 1)
        {
            RadishtMissleCrystalCost = 30;
        }
        else if (RadishMissleTierID == 2)
        {
            RadishtMissleCrystalCost = 50;
        }
        else if (RadishMissleTierID == 3)
        {
            RadishtMissleCrystalCost = 100;
        }

        // KickReflect Crystal Cost

        if (KickReflectTierID == 0)
        {
            KickReflectCrystalCost = 15;
        }
        else if (KickReflectTierID == 1)
        {
            KickReflectCrystalCost = 30;
        }
        else if (KickReflectTierID == 2)
        {
            KickReflectCrystalCost = 50;
        }
        else if (KickReflectTierID == 3)
        {
            KickReflectCrystalCost = 100;
        }

        // power Cost to text in UI

        CarrotMissleCostText.text = CarrotMissleCrystalCost.ToString();
        EarShieldCostText.text = EarShieldCrystalCost.ToString();
        RadishMissleCostText.text = RadishtMissleCrystalCost.ToString();
        KickReflectCostText.text = KickReflectCrystalCost.ToString();
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
            if (GameStats.stats.crystals >= CoinTicketCost)
            {
                GameStats.stats.crystals -= CoinTicketCost;
                GameStats.stats.CoinTicket = true;
                GameStats.stats.SaveStats();

            }
            else
            {
                Debug.Log("not enough crystals");
                notEnoughCrystals.SetTrigger("NotEnoughCrystals");
            }

        }

        if (ItemID == 2)
        {
            if (GameStats.stats.crystals >= PortalBoostCost)
            {
                GameStats.stats.crystals -= PortalBoostCost;
                GameStats.stats.PortalBoost = true;
                GameStats.stats.SaveStats();

            }
            else
            {
                Debug.Log("not enough crystals");
                notEnoughCrystals.SetTrigger("NotEnoughCrystals");
            }
        }

        if (ItemID == 3)
        {
            if (GameStats.stats.crystals >= FenixFeatherCost)
            {
                GameStats.stats.crystals -= FenixFeatherCost;
                GameStats.stats.fenixFeather = true;
                GameStats.stats.SaveStats();

            }
            else
            {
                Debug.Log("not enough crystals");
                notEnoughCrystals.SetTrigger("NotEnoughCrystals");
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

                CarrotMissleTierID += 1;


                if (CarrotMissleTierID == 2)
                {

                    GameStats.stats.UnlockedPowers.Add(CarrotMissleTiers[1]);
                    GameStats.stats.crystals -= CarrotMissleCrystalCost;
                }
                else if (CarrotMissleTierID == 3)
                {
                    GameStats.stats.UnlockedPowers.Add(CarrotMissleTiers[2]);
                    GameStats.stats.crystals -= CarrotMissleCrystalCost;
                }
                else if (CarrotMissleTierID == 4)
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

                EarShieldTierID += 1;


                if (EarShieldTierID == 2)
                {
                    GameStats.stats.UnlockedPowers.Add(EarShieldTiers[1]);
                    GameStats.stats.crystals -= EarShieldCrystalCost;
                }
                else if (EarShieldTierID == 3)
                {
                    GameStats.stats.UnlockedPowers.Add(EarShieldTiers[2]);
                    GameStats.stats.crystals -= EarShieldCrystalCost;
                }
                else if (EarShieldTierID == 4)
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

        if (PowerStoreID == 3)
        {
            if (GameStats.stats.crystals >= KickReflectCrystalCost)
            {



            }
            else
            {
                Debug.Log("not enough crystals");
                notEnoughCrystals.SetTrigger("NotEnoughCrystals");
            }
        }

        if (PowerStoreID == 4)
        {
            if (GameStats.stats.crystals >= RadishtMissleCrystalCost)
            {



            }
            else
            {
                Debug.Log("not enough crystals");
                notEnoughCrystals.SetTrigger("NotEnoughCrystals");
            }
        }

    }
    */

}

