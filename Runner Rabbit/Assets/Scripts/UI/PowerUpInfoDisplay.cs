using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerUpInfoDisplay : MonoBehaviour
{

    int CurrentPowerUp;
    [SerializeField] LanguageManager myLanguageManager = null;
    [SerializeField] PowerMEnu myPowerMenu = null;

    [Header("PowerUpsInfo")] 
    [SerializeField] Sprite[] PowerUpsSprites = null;
    
    
    
 
    [SerializeField] Image PowerUpImage = null;
    [SerializeField] TextMeshProUGUI PowerUpName = null;
    [SerializeField] TextMeshProUGUI PowerUpDescription = null;


    [SerializeField] TextMeshProUGUI Cost = null;

    // Start is called before the first frame update
    void Start()
    {
        myLanguageManager = FindObjectOfType<LanguageManager>();
    }


    public void DisplayPowerUp(int PowerUpID)
    {
        CurrentPowerUp = PowerUpID;
        switch (PowerUpID)
        {
            case 1:

                 
                PowerUpImage.sprite = PowerUpsSprites[PowerUpID - 1];
                Cost.text = myPowerMenu.CoinTicketCost.ToString();
                if (GameStats.stats.LanguageSelect == 0) // English
                {
                    PowerUpName.text = myLanguageManager.English_CointX2TicketText;
                    PowerUpDescription.text = myLanguageManager.English_CoinsX2Description;
                    
                }
                else if (GameStats.stats.LanguageSelect == 1)
                {
                    PowerUpName.text = myLanguageManager.Español_CointX2TicketText;
                    PowerUpDescription.text = myLanguageManager.Español_CoinsX2Description;
                }

                break;
            case 2:
                PowerUpImage.sprite = PowerUpsSprites[PowerUpID - 1];
                Cost.text = myPowerMenu.PortalBoostCost.ToString();
                if (GameStats.stats.LanguageSelect == 0) // English
                {
                    PowerUpName.text = myLanguageManager.English_PortalBoostText;
                    PowerUpDescription.text = myLanguageManager.English_PortalBoostDescription;
                }
                else if (GameStats.stats.LanguageSelect == 1)
                {
                    PowerUpName.text = myLanguageManager.Español_PortalBoostText;
                    PowerUpDescription.text = myLanguageManager.Español_PortalBoostDescription;
                }
                break;
            case 3:
                PowerUpImage.sprite = PowerUpsSprites[PowerUpID - 1];
                Cost.text = myPowerMenu.FenixFeatherCost.ToString();
                if (GameStats.stats.LanguageSelect == 0) // English
                {
                    PowerUpName.text = myLanguageManager.English_FenixFeatherText;
                    PowerUpDescription.text = myLanguageManager.English_PhoenixFeatherDescription;
                }
                else if (GameStats.stats.LanguageSelect == 1)
                {
                    PowerUpName.text = myLanguageManager.Español_FenixFeatherText;
                    PowerUpDescription.text = myLanguageManager.Español_PhoenixFeatherDescription;
                }
                break;

            case 4:
                PowerUpImage.sprite = PowerUpsSprites[PowerUpID - 1];
                Cost.text = myPowerMenu.ExtraHeartsCost.ToString();
                if (GameStats.stats.LanguageSelect == 0) // English
                {
                    PowerUpName.text = myLanguageManager.English_ExtraHeartsText;
                    PowerUpDescription.text = myLanguageManager.English_ExtraHeartsDescription;
                }
                else if (GameStats.stats.LanguageSelect == 1)
                {
                    PowerUpName.text = myLanguageManager.Español_ExtraHeartsText;
                    PowerUpDescription.text = myLanguageManager.Español_ExtraHeartsDescription;
                }
                break;
            case 5:
                PowerUpImage.sprite = PowerUpsSprites[PowerUpID - 1];
                Cost.text = myPowerMenu.ManaJarCost.ToString();
                if (GameStats.stats.LanguageSelect == 0) // English
                {
                    PowerUpName.text = myLanguageManager.English_ManaJarText;
                    PowerUpDescription.text = myLanguageManager.English_ManaJarDescription;
                }
                else if (GameStats.stats.LanguageSelect == 1)
                {
                    PowerUpName.text = myLanguageManager.Español_ManaJarText;
                    PowerUpDescription.text = myLanguageManager.Español_ManaJarDescription;
                }
                break;
            default:
                // No Power up SELECTED
                break;
        }
    }

    public void BuyPowerUp()
    {
        myPowerMenu.BuyItem(CurrentPowerUp);
    }
}
