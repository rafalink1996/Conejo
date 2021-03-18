using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanguageManagerStore : MonoBehaviour
{

    public TextMeshProUGUI PlusHealthButton, PlusLightManaButton, PlusDarkManaButton, PowerTabButton, UpgradeTabButton, RewardbuttonGetText, ContinueButton, CurrentHealthDisplayText, CurrentManaDisplayText;
    public TextMeshProUGUI SettingsTitle, MusicSubtitle, soundSubtitle, CloseButton, MainMenuButton;
    public TextMeshProUGUI DamagePowerDisplay, ManaPowerDisplay, BuyPowerDisplay, BackPowerDisplay;
    public TextMeshProUGUI WatchAdText, WatchAdCoinsText, WatchAdBackButton, WatchAdWatchButton, CongratulationsText, RewardCoinText, CollectButton;


    //English************************

    string English_PlusHealth = "+ Health";
    string English_PlusMana = "+ Mana";
    string English_PowerTab = "Powers";
    string English_UpgradesTab = "Upgrades";
    string English_RewardButtonGet = "Get";
    string English_Continue = "Continue";
    string English_Settings = "Settings";
    string English_Music = "Music";
    string English_Sound = "Sound";
    string English_Colse = "Close";
    string English_MainMenu = "Main Menu";
    string English_CurrentHealth = "Current health";
    string English_CurrentMana = "Mana";
    string English_Damage = "Damage";
    string English_ManaPowerDisplay = "Mana Cost";
    string English_BuyPowerDisplay = "Buy";
    string English_BackButton = "Back";

    string English_WhatchAdText = "Watch ad to get";
    string English_WatchAdCoinText = "Coins";
    string English_WhatchAdBackButton = "Back";
    string English_WatchAdWatchButton = "Watch";
    string English_Congratulation = "Congratulations! You Got";
    string English_Collectbutton = "collect";
    


    //Español***********************

    string Español_PlusHealth = "+ Vida";
    string Español_PlusMana = "+ Mana";
    string Español_PowerTab = "Poderes";
    string Español_UpgradesTab = "Mejoras";
    string Español_RewardButtonGet = "Conseguir";
    string Español_Continue = "Continuar";
    string Español_Settings = "Opciones";
    string Español_Music = "Musica";
    string Español_Sound = "Sonido";
    string Español_Colse = "Cerrar";
    string Español_MainMenu = "Menú Principal";
    string Español_CurrentHealth = "vida";
    string Español_CurrentMana = "Mana";
    string Español_Damage = "Daño";
    string Español_ManaPowerDisplay = "Costo Mana";
    string Español_BuyPowerDisplay = "Comprar";
    string Español_BackButton = "Cerrar";

    string Español_WhatchAdText = "Ver Ad Para conesguir";
    string Español_WatchAdCoinText = "Monedas";
    string Español_WhatchAdBackButton = "Cerrar";
    string Español_WatchAdWatchButton = "Ver";
    string Español_Congratulation = "¡Felicidades! consigues";
    string Español_Collectbutton = "Recoger";




    void Start()
    {
        SetLanguage(GameStats.stats.LanguageSelect);
    }

    public void SetLanguage(int Language)
    {
        switch (Language)
        {
            case 0:// English

                PlusHealthButton.text = English_PlusHealth;
                PlusLightManaButton.text = English_PlusMana;
                PlusDarkManaButton.text = English_PlusMana;
                PowerTabButton.text = English_PowerTab;
                UpgradeTabButton.text = English_UpgradesTab;
                RewardbuttonGetText.text = English_RewardButtonGet;
                ContinueButton.text = English_Continue;
                CurrentHealthDisplayText.text = English_CurrentHealth;
                CurrentManaDisplayText.text = English_CurrentMana;

                SettingsTitle.text = English_Settings;
                MusicSubtitle.text = English_Music;
                soundSubtitle.text = English_Sound;
                CloseButton.text = English_Colse;
                MainMenuButton.text = English_MainMenu;

                DamagePowerDisplay.text = English_Damage;
                ManaPowerDisplay.text = English_ManaPowerDisplay;
                BuyPowerDisplay.text = English_BuyPowerDisplay;
                BackPowerDisplay.text = English_BackButton;

                WatchAdText.text = English_WhatchAdText;
                WatchAdCoinsText.text = English_WatchAdCoinText;
                WatchAdBackButton.text = English_WhatchAdBackButton; WatchAdBackButton.fontSize = 60;
                WatchAdWatchButton.text = English_WatchAdWatchButton;
                CongratulationsText.text = English_Congratulation;
                RewardCoinText.text = English_WatchAdCoinText;
                CollectButton.text = English_Collectbutton;

                break;

            case 1:// English

                PlusHealthButton.text = Español_PlusHealth;
                PlusLightManaButton.text = Español_PlusMana;
                PlusDarkManaButton.text = Español_PlusMana;
                PowerTabButton.text = Español_PowerTab;
                UpgradeTabButton.text = Español_UpgradesTab;
                RewardbuttonGetText.text = Español_RewardButtonGet;
                ContinueButton.text = Español_Continue;
                CurrentHealthDisplayText.text = Español_CurrentHealth;
                CurrentManaDisplayText.text = Español_CurrentMana;

                SettingsTitle.text = Español_Settings;
                MusicSubtitle.text = Español_Music;
                soundSubtitle.text = Español_Sound;
                CloseButton.text = Español_Colse;
                MainMenuButton.text = Español_MainMenu;

                DamagePowerDisplay.text = Español_Damage;
                ManaPowerDisplay.text = Español_ManaPowerDisplay;
                BuyPowerDisplay.text = Español_BuyPowerDisplay;
                BackPowerDisplay.text = Español_BackButton;

                WatchAdText.text = Español_WhatchAdText;
                WatchAdCoinsText.text = Español_WatchAdCoinText;
                WatchAdBackButton.text = Español_WhatchAdBackButton; WatchAdBackButton.fontSize = 50;
                WatchAdWatchButton.text = Español_WatchAdWatchButton;
                CongratulationsText.text = Español_Congratulation;
                RewardCoinText.text = Español_WatchAdCoinText;
                CollectButton.text = Español_Collectbutton;

                break;
        }
    }
}

