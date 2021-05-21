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
    public TextMeshProUGUI GobacktoMainMenuquestionText, gobacktomainmenubutton, mainmenuquestionBackbutton;
    public TextMeshProUGUI DamageTextStats;
    public TextMeshProUGUI NotEnoughtCoins;


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

    string English_GobackToMainMenuQuestion = "Go back to main menu?";
    string English_goBackToMainMenuButton = "Go Back to main menu";

    string English_notEnoughCoins = "Not Enough Coins";


    public string English_Library = "Library";
    public string English_Dungeon = "Dungeon";
    public string English_IceRoom = "Ice Room";
    public string English_Jungle = "Jungle";
    public string English_PortalRoom = "Portal Room";




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

    string Español_GobackToMainMenuQuestion = "¿volver al menú principal?";
    string Español_goBackToMainMenuButton = "ir al menú principal";

    string Español_notEnoughCoins = "No tienes suficientes Monedas";

    public string Español_Library = "Biblioteca";
    public string Español_Dungeon = "Calabozo";
    public string Español_IceRoom = "Cuerto de hielo";
    public string Español_Jungle = "Jungla";
    public string Español_PortalRoom = "Cuarto de portales";

    // string English_PlusHealth = "+ Health";


    //Frances *******************

    string Frances_PlusHealth = "+ Vida";
    string Frances_PlusMana = "+ Mana";
    string Frances_PowerTab = "Powers";
    string Frances_UpgradesTab = "Upgrades";
    string Frances_RewardButtonGet = "Get";
    string Frances_Continue = "Continue";
    string Frances_Settings = "Settings";
    string Frances_Music = "Music";
    string Frances_Sound = "Sound";
    string Frances_Colse = "Close";
    string Frances_MainMenu = "Main Menu";
    string Frances_CurrentHealth = "Current health";
    string Frances_CurrentMana = "Mana";
    string Frances_Damage = "Damage";
    string Frances_ManaPowerDisplay = "Mana Cost";
    string Frances_BuyPowerDisplay = "Buy";
    string Frances_BackButton = "Back";

    string Frances_WhatchAdText = "Watch ad to get";
    string Frances_WatchAdCoinText = "Coins";
    string Frances_WhatchAdBackButton = "Back";
    string Frances_WatchAdWatchButton = "Watch";
    string Frances_Congratulation = "Congratulations! You Got";
    string Frances_Collectbutton = "collect";

    string Frances_GobackToMainMenuQuestion = "Go back to main menu?";
    string Frances_goBackToMainMenuButton = "Go Back to main menu";

    string Frances_notEnoughCoins = "Not Enough Coins";

    public string Frances_Library = "Biblioteca";
    public string Frances_Dungeon = "Calabozo";
    public string Frances_IceRoom = "Cuerto de hielo";
    public string Frances_Jungle = "Jungla";
    public string Frances_PortalRoom = "Cuarto de portales";




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

                GobacktoMainMenuquestionText.text = English_GobackToMainMenuQuestion;
                gobacktomainmenubutton.text = English_goBackToMainMenuButton;

                DamageTextStats.text = English_Damage;

                NotEnoughtCoins.text = English_notEnoughCoins;

                break;

            case 1:// Español

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

                GobacktoMainMenuquestionText.text = Español_GobackToMainMenuQuestion;
                gobacktomainmenubutton.text = Español_goBackToMainMenuButton;

                DamageTextStats.text = Español_Damage;

                NotEnoughtCoins.text = Español_notEnoughCoins;

                break;

            case 2:// Frances


                PlusHealthButton.text = Frances_PlusHealth;
                PlusLightManaButton.text = Frances_PlusMana;
                PlusDarkManaButton.text = Frances_PlusMana;
                PowerTabButton.text = Frances_PowerTab;
                UpgradeTabButton.text = Frances_UpgradesTab;
                RewardbuttonGetText.text = Frances_RewardButtonGet;
                ContinueButton.text = Frances_Continue;
                CurrentHealthDisplayText.text = Frances_CurrentHealth;
                CurrentManaDisplayText.text = Frances_CurrentMana;

                SettingsTitle.text = Frances_Settings;
                MusicSubtitle.text = Frances_Music;
                soundSubtitle.text = Frances_Sound;
                CloseButton.text = Frances_Colse;
                MainMenuButton.text = Frances_MainMenu;

                DamagePowerDisplay.text = Frances_Damage;
                ManaPowerDisplay.text = Frances_ManaPowerDisplay;
                BuyPowerDisplay.text = Frances_BuyPowerDisplay;
                BackPowerDisplay.text = Frances_BackButton;

                WatchAdText.text = Frances_WhatchAdText;
                WatchAdCoinsText.text = Frances_WatchAdCoinText;
                WatchAdBackButton.text = Frances_WhatchAdBackButton; WatchAdBackButton.fontSize = 50;
                WatchAdWatchButton.text = Frances_WatchAdWatchButton;
                CongratulationsText.text = Frances_Congratulation;
                RewardCoinText.text = Frances_WatchAdCoinText;
                CollectButton.text = Frances_Collectbutton;

                GobacktoMainMenuquestionText.text = Frances_GobackToMainMenuQuestion;
                gobacktomainmenubutton.text = Frances_goBackToMainMenuButton;

                DamageTextStats.text = Frances_Damage;

                NotEnoughtCoins.text = Frances_notEnoughCoins;


                break;
        }
    }
}

