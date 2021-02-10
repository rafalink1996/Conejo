using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerMenuDescription : MonoBehaviour
{
    public GameObject PowerDescription;
    public PowerMEnu PowerMenu;

    //name
    public TextMeshProUGUI PowerName;

    //image
    public Image PowerImageTier1;
    public Image PowerImageTier2;
    public Image PowerImageTier3;
    public Image PowerImageTier4;

    //Damage Value
    public TextMeshProUGUI DamageTier1;
    public TextMeshProUGUI DamageTier2;
    public TextMeshProUGUI DamageTier3;
    public TextMeshProUGUI DamageTier4;

    //Mana Cost
    public TextMeshProUGUI ManaTier1;
    public TextMeshProUGUI ManaTier2;
    public TextMeshProUGUI ManaTier3;
    public TextMeshProUGUI ManaTier4;


    //locked

    public Image LockedTier1;
    public Image LockedTier2;
    public Image LockedTier3;
    public Image LockedTier4;

    //description

    public TextMeshProUGUI DescriptionTier1;
    public TextMeshProUGUI DescriptionTier2;
    public TextMeshProUGUI DescriptionTier3;
    public TextMeshProUGUI DescriptionTier4;

    //cost
    public TextMeshProUGUI Cost;
    float CrystalCost;

    //id
    public int selectedPowerID;

    //buy Upgrade Button
    public Button UpgradeButton;
    public TextMeshProUGUI ButtonCrystalText;
    public Image buttonCrystalImage;
    public TextMeshProUGUI MaxLevelText;
    public TextMeshProUGUI UpgradeText;

    private void Start()
    {
        UpgradeButton.onClick.AddListener(BuyPowerUpgrade);
    }
    public void SelectPowerToUpgrade(int PowerID)
    {
        
        List<Power> SelectedPowers = new List<Power>();
        

        if (PowerID == 1)
        {
            SelectedPowers.AddRange(PowerMenu.CarrotMissleTiers);
            PowerName.text = "Carrot Missle";
            CrystalCost = PowerMenu.CarrotMissleCrystalCost;
            selectedPowerID = 1;
        }
        else if (PowerID == 2)
        {
            SelectedPowers.AddRange(PowerMenu.EarShieldTiers);
            PowerName.text = "Ear Shield";
            CrystalCost = PowerMenu.EarShieldCrystalCost;
            selectedPowerID = 2;
        }
        else if (PowerID == 4)
        {
            SelectedPowers.AddRange(PowerMenu.RadishMissleTiers);
            PowerName.text = "Radish Missle";
            CrystalCost = PowerMenu.RadishtMissleCrystalCost;
            selectedPowerID = 4;
        }
        else if (PowerID == 3)
        {
            SelectedPowers.AddRange(PowerMenu.KickReflectTiers);
            PowerName.text = "Kick Reflect";
            CrystalCost = PowerMenu.KickReflectCrystalCost;
            selectedPowerID = 3;
            
        }
        else if (PowerID == 5)
        {
            SelectedPowers.AddRange(PowerMenu.MagicLaserTiers);
            PowerName.text = "Magic Laser";
            CrystalCost = PowerMenu.MagicLaserCrystalCost;
            selectedPowerID = 5;
            

        }

        UpdateCrystalCost(PowerID);


        UpdateLockedUi(PowerID);

            PowerImageTier1.sprite = SelectedPowers[0].iconLight;
            PowerImageTier2.sprite = SelectedPowers[0].iconLight;
            PowerImageTier3.sprite = SelectedPowers[0].iconLight;
            PowerImageTier4.sprite = SelectedPowers[0].iconLight;

            DamageTier1.text = SelectedPowers[0].Damage.ToString();
            DamageTier2.text = SelectedPowers[1].Damage.ToString();
            DamageTier3.text = SelectedPowers[2].Damage.ToString();
            DamageTier4.text = SelectedPowers[3].Damage.ToString();

            ManaTier1.text = SelectedPowers[0].mana.ToString();
            ManaTier2.text = SelectedPowers[1].mana.ToString();
            ManaTier3.text = SelectedPowers[2].mana.ToString();
            ManaTier4.text = SelectedPowers[3].mana.ToString();

            DescriptionTier1.text = SelectedPowers[0].description;
            DescriptionTier2.text = SelectedPowers[1].description;
            DescriptionTier3.text = SelectedPowers[2].description;
            DescriptionTier4.text = SelectedPowers[3].description;

       // UpgradeButton.onClick.RemoveAllListeners();
       // UpgradeButton.onClick.AddListener(BuyPowerUpgrade);

        
    }

    void UpdateCrystalCost(int SelectedPowerID)
    {
        if (SelectedPowerID == 1)
        {
            CrystalCost = PowerMenu.CarrotMissleCrystalCost;
            Cost.text = CrystalCost.ToString();
            if (GameStats.stats.CarrotMissleLevel == 4)
            {
                ButtonCrystalText.enabled = false;
                buttonCrystalImage.enabled = false;
                UpgradeText.enabled = false;
                Cost.enabled = false;
                MaxLevelText.enabled = true;

            }
            else
            {
                ButtonCrystalText.enabled = true;
                buttonCrystalImage.enabled = true;
                UpgradeText.enabled = true;
                Cost.enabled = true;
                MaxLevelText.enabled = false;
            }

        }
        if (SelectedPowerID == 2)
        {
            CrystalCost = PowerMenu.EarShieldCrystalCost;
            Cost.text = CrystalCost.ToString();

            if (GameStats.stats.EarDefenceLevel == 4)
            {
                ButtonCrystalText.enabled = false;
                buttonCrystalImage.enabled = false;
                UpgradeText.enabled = false;
                Cost.enabled = false;
                MaxLevelText.enabled = true;

            }
            else
            {
                ButtonCrystalText.enabled = true;
                buttonCrystalImage.enabled = true;
                UpgradeText.enabled = true;
                Cost.enabled = true;
                MaxLevelText.enabled = false;
            }
        }
        if (SelectedPowerID == 3)
        {
            CrystalCost = PowerMenu.KickReflectCrystalCost;
            Cost.text = CrystalCost.ToString();

            if (GameStats.stats.KickReflectLevel == 4)
            {
                ButtonCrystalText.enabled = false;
                buttonCrystalImage.enabled = false;
                UpgradeText.enabled = false;
                Cost.enabled = false;
                MaxLevelText.enabled = true;

            }
            else
            {
                ButtonCrystalText.enabled = true;
                buttonCrystalImage.enabled = true;
                UpgradeText.enabled = true;
                Cost.enabled = true;
                MaxLevelText.enabled = false;
            }
        }
        if (SelectedPowerID == 4)
        {
            CrystalCost = PowerMenu.RadishtMissleCrystalCost;
            Cost.text = CrystalCost.ToString();

            if (GameStats.stats.RadishMissleLevel == 4)
            {
                ButtonCrystalText.enabled = false;
                buttonCrystalImage.enabled = false;
                UpgradeText.enabled = false;
                Cost.enabled = false;
                MaxLevelText.enabled = true;

            }
            else
            {
                ButtonCrystalText.enabled = true;
                buttonCrystalImage.enabled = true;
                UpgradeText.enabled = true;
                Cost.enabled = true;
                MaxLevelText.enabled = false;
            }
        }
        if (SelectedPowerID == 5)
        {
            CrystalCost = PowerMenu.MagicLaserCrystalCost;
            Cost.text = CrystalCost.ToString();

            if (GameStats.stats.MagicLaserLevel == 4)
            {
                ButtonCrystalText.enabled = false;
                buttonCrystalImage.enabled = false;
                UpgradeText.enabled = false;
                Cost.enabled = false;
                MaxLevelText.enabled = true;

            }
            else
            {
                ButtonCrystalText.enabled = true;
                buttonCrystalImage.enabled = true;
                UpgradeText.enabled = true;
                Cost.enabled = true;
                MaxLevelText.enabled = false;
            }
        }

        Debug.Log("upgradeButtonPressed");

        
    }


    public void BuyPowerUpgrade()
    {
        PowerMenu.BuyPowerUpgrade(selectedPowerID);
        UpdateCrystalCost(selectedPowerID);
        UpdateLockedUi(selectedPowerID);

    }
    void UpdateLockedUi(int selectedID)
    {
        //Carrot Missle
        if (selectedID == 1)
        {
            if (GameStats.stats.CarrotMissleLevel == 1)
            {
                LockedTier1.enabled = false;
                LockedTier2.enabled = true;
                LockedTier3.enabled = true;
                LockedTier4.enabled = true;
            }
            else if (GameStats.stats.CarrotMissleLevel == 2)
            {
                LockedTier1.enabled = false;
                LockedTier2.enabled = false;
                LockedTier3.enabled = true;
                LockedTier4.enabled = true;
            }
            else if (GameStats.stats.CarrotMissleLevel == 3)
            {
                LockedTier1.enabled = false;
                LockedTier2.enabled = false;
                LockedTier3.enabled = false;
                LockedTier4.enabled = true;
            }
            else if (GameStats.stats.CarrotMissleLevel == 4)
            {
                LockedTier1.enabled = false;
                LockedTier2.enabled = false;
                LockedTier3.enabled = false;
                LockedTier4.enabled = false;
            }
        }
        //ear Shield
        if (selectedID == 2)
        {
            if (GameStats.stats.EarDefenceLevel == 1)
            {
                LockedTier1.enabled = false;
                LockedTier2.enabled = true;
                LockedTier3.enabled = true;
                LockedTier4.enabled = true;
            }
            else if (GameStats.stats.EarDefenceLevel == 2)
            {
                LockedTier1.enabled = false;
                LockedTier2.enabled = false;
                LockedTier3.enabled = true;
                LockedTier4.enabled = true;
            }
            else if (GameStats.stats.EarDefenceLevel == 3)
            {
                LockedTier1.enabled = false;
                LockedTier2.enabled = false;
                LockedTier3.enabled = false;
                LockedTier4.enabled = true;
            }
            else if (GameStats.stats.EarDefenceLevel == 4)
            {
                LockedTier1.enabled = false;
                LockedTier2.enabled = false;
                LockedTier3.enabled = false;
                LockedTier4.enabled = false;
            }
        }
        // Kick Reflect
        if (selectedID == 3)
        {
            if (GameStats.stats.KickReflectLevel == 1)
            {
                LockedTier1.enabled = false;
                LockedTier2.enabled = true;
                LockedTier3.enabled = true;
                LockedTier4.enabled = true;
            }
            else if (GameStats.stats.KickReflectLevel == 2)
            {
                LockedTier1.enabled = false;
                LockedTier2.enabled = false;
                LockedTier3.enabled = true;
                LockedTier4.enabled = true;
            }
            else if (GameStats.stats.KickReflectLevel == 3)
            {
                LockedTier1.enabled = false;
                LockedTier2.enabled = false;
                LockedTier3.enabled = false;
                LockedTier4.enabled = true;
            }
            else if (GameStats.stats.KickReflectLevel == 4)
            {
                LockedTier1.enabled = false;
                LockedTier2.enabled = false;
                LockedTier3.enabled = false;
                LockedTier4.enabled = false;
            }
        }
        // Radish Missle
        if (selectedID == 4)
        {
            if (GameStats.stats.RadishMissleLevel == 1)
            {
                LockedTier1.enabled = false;
                LockedTier2.enabled = true;
                LockedTier3.enabled = true;
                LockedTier4.enabled = true;
            }
            else if (GameStats.stats.RadishMissleLevel == 2)
            {
                LockedTier1.enabled = false;
                LockedTier2.enabled = false;
                LockedTier3.enabled = true;
                LockedTier4.enabled = true;
            }
            else if (GameStats.stats.RadishMissleLevel == 3)
            {
                LockedTier1.enabled = false;
                LockedTier2.enabled = false;
                LockedTier3.enabled = false;
                LockedTier4.enabled = true;
            }
            else if (GameStats.stats.RadishMissleLevel == 4)
            {
                LockedTier1.enabled = false;
                LockedTier2.enabled = false;
                LockedTier3.enabled = false;
                LockedTier4.enabled = false;
            }
        }
        // Magic Laser

        if (selectedID == 5)
        {
            if (GameStats.stats.MagicLaserLevel == 1)
            {
                LockedTier1.enabled = false;
                LockedTier2.enabled = true;
                LockedTier3.enabled = true;
                LockedTier4.enabled = true;
            }
            else if (GameStats.stats.MagicLaserLevel == 2)
            {
                LockedTier1.enabled = false;
                LockedTier2.enabled = false;
                LockedTier3.enabled = true;
                LockedTier4.enabled = true;
            }
            else if (GameStats.stats.MagicLaserLevel == 3)
            {
                LockedTier1.enabled = false;
                LockedTier2.enabled = false;
                LockedTier3.enabled = false;
                LockedTier4.enabled = true;
            }
            else if (GameStats.stats.MagicLaserLevel == 4)
            {
                LockedTier1.enabled = false;
                LockedTier2.enabled = false;
                LockedTier3.enabled = false;
                LockedTier4.enabled = false;
            }
        }
       
    }

}
