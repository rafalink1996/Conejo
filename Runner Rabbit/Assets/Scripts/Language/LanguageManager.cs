using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LanguageManager : MonoBehaviour
{
    public TMP_Dropdown LanguageDropdownSettings;
    // main menú Texts
    //BackText
    public TextMeshProUGUI BackButton1;
    // buttons MainMenu
    public TextMeshProUGUI StartButton, ContinueButton, NewRunButton, StoreButton, SkinsButtom, HowToPlayButton;
    //texts Options Menu
    public TextMeshProUGUI OptionsTitle, MusicText, SoundText, NotificationsText, LanguageText;
    //text Store
    public TextMeshProUGUI StoreTitle, PowerUpsTitle, ManaJarText, CoinX2text, ExtraHeartsText, PoertalBoostText, FenixFeatherText, RuneText, BackButtonStoreText; // Main texts
    public TextMeshProUGUI CarrotPowerText, EarShieldText, RadishMissleText, KickReflectText, MagicLaserText; // Powers
    public TextMeshProUGUI GetCrystalText, WatchAdText, WatchAdCrystaltext, WhatchAdBackButtonText, WatchButtonText, CongratulationsText, rewardCrystalText, CollectText; // timedReward
    public TextMeshProUGUI DamageText1, DamageText2, DamageText3, DamageText4, level1Text, level2Text, level3Text, level4Text, UpgradePowerText, UpgradePowerCrystalText, UpgradePowerMaxLevelText; // UpgradePowes
    public TextMeshProUGUI DungeonStartText, DungeonStartDescriptionText,DungeonStartCostText, DungeonStartCrystals, DungeonStartCoins, DungeonStartBackButton, DungeonStartBuyButton; //DungeonStart
    public TextMeshProUGUI IceCaveStartText, IceCaveStartDescriptionText, IceCaveStartCostText, IceCaveStartCrystals, IceCaveStartCoins, IceCaveStartBackButton, IceCaveStartBuyButton; //Ice caveStart
    public TextMeshProUGUI JungleStartText, JungleStartDescriptionText, JungleStartCostText, JungleStartCrystals, JungleStartCoins, JungleStartBackButton, JungleStartBuyButton; // Jungle Start
    public TextMeshProUGUI PortalRoomStartText, PortalRoomStartDescriptionText, PortalRoomStartCostText, PortalRoomStartCrystals, PortalRoomStartCoins, PortalRoomStartBackButton, PortalRoomStartBuyButton; //Portal roomStart
    //Texts RuneForge
    public TextMeshProUGUI RuneforgeTitle, RuneforgeBackButtonText, RuneName1, RuneName2, RuneName3, RuneName4, RuneName5, RuneName6, RuneName7, RuneName8, RuneName9, RuneName10, RuneDescription1, // RuneForge
                           RuneDescription2, RuneDescription3, RuneDescription4, RuneDescription5, RuneDescription6, RuneDescription7, RuneDescription8, RuneDescription9, RuneDescription10, EquipedRunes,
                           RuneSlot1Unequip, RuneSlot2Unequip, RuneSlot1Select, RuneSlot2Select;
    //texts Skin Menú
    public TextMeshProUGUI SkinTitle, DefaultSkinText, DragonFireSkinText, BoneSkinText, IceGolemSkinText, PlantSkinText, ClockWorkSkinText, ShadowWizardSkinText, TophatSkinText, AngelSkinText, ImpSkinText, SnowmanSkinText,
                           WizardSkinText, AstralTravelerSkinText, SlimeSkinText, AlienSkinText, AssasinBlackSkinText, AssasinWhiteSkinText, FoxSkinText, IceCreamSkinText, MechSkinText, BackButtonSkinMenu, buySkinButton, selectButton1Text, selectButton2Text;
    // AchivementMenú
    public TextMeshProUGUI AchievmentTitle, AchivementBackButton;
    //HowToPlay
    public TextMeshProUGUI HowToPlayTitle, MovmentHowToPlayButton, PowersHowToPlayButton, BackHowToPlayButton;
    public Sprite English_HowToPlayMovmentSprite, English_HowToPlayPowersSpirte, Español_HowToPlayMovmentSprite, Español_HowToPlayPowersSpirte;
    public Image HowToPlayDisplayMovementImage, HowToPlayDisplayPowersImage;


    //strings language
    //English **********************

    string English_BackButton = "Back";

    string English_StartButton = "Start";
    string English_ContinueButton = "Continue";
    string English_NewRunButton = "New Run";
    string English_StoreButton = "Store";
    string English_SkinsButton = "Skins";
    string English_HowToPlayButton = "How to play";

    string English_OptionsTitle = "Options";
    string English_Music = "Music";
    string English_Sound = "Sound";
    string English_Notifications = "Notifications";
    string English_Language = "Language";

         //Store

    string English_StoreTitle = "Store";
    string English_PowerUpsTitle = "Power Ups";
    string English_ManaJarText = "Mana Jar";
    string English_CointX2TicketText = "Coin x2 Ticket";
    string English_ExtraHeartsText = "Extra Hearts";
    string English_PortalBoostText = "Portal Boost";
    string English_FenixFeatherText = "phoenix Feather";
    string English_RuneButton = "Runes";

    string English_CarrotPower = "Carrot Missle";
    string English_EarShieldPower = "Ear Shield";
    string English_RadishMisslePower = "Radish Missle";
    string English_KickReflectPower = "Kick Reflect";
    string English_MagicLaserPower = "Magic Laser";

    string English_GetCrystalText = "Get Crystals"; 
    string English_WatchAdText = "Watch ad to get crystals?";
    string English_CrystalText = "Crystals";
    string English_WatchButton = "Watch";
    string English_CongratulationsText = "Congartulations! You Got:";
    string English_Collect = "Collect";

    string English_DamageText1 = "Damage";
    string English_DamageText2 = "Damage";
    string English_DamageText3 = "Damage";
    string English_DamageText4 = "Damage";
    string English_LevelText1 = "Level 1";
    string English_LevelText2 = "Level 2";
    string English_LevelText3 = "Level 3";
    string English_LevelText4 = "Level 4";
    string English_UpgradePowerText = "Upgrade";
    string English_MaxLevelText = "Max Level";

    string English_BuyButton = "buy";

    string English_LevelSelectCostText = "Cost:";

    string English_DungeonStartText = "Dungeon Start";
    string English_DungeonStartDescriptionText = "Start in Dungeon Level With";
    string English_DungeonStartCoins = "100 Coins";
    string English_DungeonStartCrystals = "20 crystals";
   

    string English_IceCaveStartText = "Frozen Room Start";
    string English_IceCaveStartDescriptionText = "Start in Frozen Room Level With";
    string English_IceCaveStartCoins = "200 Coins";
    string English_IceCaveStartCrystals = "40 crystals";

    string English_JungleStartText = "Jungle Start";
    string English_JungleStartDescriptionText = "Start in Jungle Level With";
    string English_JungleStartCoins = "350 Coins";
    string English_JungleStartCrystals = "80 crystals";

    string English_PortalRoomStartText = "Portal Room Start";
    string English_PortalRoomStartDescriptionText = "Start in the portal room Level With";
    string English_PortalRoomStartCoins = "500 Coins";
    string English_PortalRoomStartCrystals = "100 crystals";

    // runeforge
    string English_RuneForgeTitle = "Rune Forge";
    string English_EquipedRunes = "Equiped Runes";

    string English_RuneSlotUnequip = "unequip";
    string English_Select = "Select";



    string English_RuneName1 = "Float Rune";
    string English_RuneName2 = "Fall Rune";
    string English_RuneName3 = "Magnet Rune";
    string English_RuneName4 = "Mana Rune";
    string English_RuneName5 = "Spell Rune";
    string English_RuneName6 = "Shield Rune";
    string English_RuneName7 = "Greed Rune";
    string English_RuneName8 = "Merchant Rune";
    string English_RuneName9 = "Destruction Rune";
    string English_RuneName10 = "Unknown Rune";

    string English_RuneDescription1 = "Gives you extra magic for floating";
    string English_RuneDescription2 = "you fall faster towards the rift";
    string English_RuneDescription3 = "Coins are atracted to you";
    string English_RuneDescription4 = "Recharge mana faster";
    string English_RuneDescription5 = "Spells cost less mana";
    string English_RuneDescription6 = "Prevents the first time you would get hit each level";
    string English_RuneDescription7 = "gives you more coins when you reach the store";
    string English_RuneDescription8 = "the first item in the coin shop is 50% off";
    string English_RuneDescription9 = "Enemies spawn with less health";
    string English_RuneDescription10 = "gives you one random power up when starting a new run";


    string English_DefaultSkin = "Default";
    string English_DragonFireSkin = "Dragon Fire";
    string English_BoneSkin = "Bone";
    string English_IceGolemSkin = "Ice Golem";
    string English_PlantSkin = "Plant";
    string English_ClokworkSkin = "Clokwork";
    string English_ShadowWizardSkin = "Shadow Wizard";
    string English_TophatSkin = "Tophat";
    string English_AngelSkin = "Angel";
    string English_ImpSkin = "Imp";
    string English_SnowmanSkin = "Snowman";
    string English_WizardSkin = "Wizard";
    string English_AstralTravelerSKin = "Astral Traveler";
    string English_SlimeSkin = "Slime";
    string English_AlienSkin = "Alien";
    string English_AssasinBlackSkin = "Assassin Black";
    string English_AssasinWhiteSkin = "Assassin White";
    string English_FoxSkin = "Fox";
    string English_IceCreamSkin = "Ice Cream";
    string English_MechSkin = "Mech";

    // achievment menú
    string English_Achievments = "Achievements";

    //HowToPlay

    string English_HowToPlay = "How to Play";
    string English_MovemntHowToPlay = "Movement";
    string English_PowersHowToPlay = "Powers";
    






    //Español******************

    string Español_BackButton = "Volver";

    string Español_StartButton = "Empezar";
    string Español_ContinueButton = "Continuar";
    string Español_NewRunButton = "Nueva Partida";
    string Español_StoreButton = "Tienda";
    string Español_SkinsButton = "Aspectos";
    string Español_HowToPlayButton = "Cómo Jugar";

    string Español_OptionsTitle = "Opciones";
    string Español_Music = "Música";
    string Español_Sound = "Sonido";
    string Español_Notifications = "Notificaciones";
    string Español_Language = "Lenguaje";

         //Tienda 

    string Español_StoreTitle = "Tienda";
    string Español_PowerUpsTitle = "Power Ups";
    string Español_ManaJarText = "Jarra de mana";
    string Español_CointX2TicketText = "Tiquete monedas x2";
    string Español_ExtraHeartsText = "Corazones extra";
    string Español_PortalBoostText = "Boost de portal";
    string Español_FenixFeatherText = "Pluma de fenix";
    string Español_RuneButton = "Runas";

    string Español_CarrotPower = "Misil zanahoria";
    string Español_EarShieldPower = "Escudo Oreja";
    string Español_RadishMisslePower = "Misil Rábano";
    string Español_KickReflectPower = "Patada Reflectiva";
    string Español_MagicLaserPower = "Rayo Láser";

    string Español_GetCrystalText = "Conseguir Cristales";
    string Español_WatchAdText = "¿ver AD para conseguir cristales?";
    string Español_CrystalText = "Cristales";
    string Español_WatchButton = "ver";
    string Español_CongratulationsText = "¡Felicidades! consigues:";
    string Español_Collect = "Recoger";

    string Español_DamageText1 = "Daño";
    string Español_DamageText2 = "Daño";
    string Español_DamageText3 = "Daño";
    string Español_DamageText4 = "Daño";
    string Español_LevelText1 = "Nivel  1";
    string Español_LevelText2 = "Nivel  2";
    string Español_LevelText3 = "Nivel  3";
    string Español_LevelText4 = "Nivel  4";
    string Español_UpgradePowerText = "Mejorar";
    string Español_MaxLevelText = "Nivel Máximo";

    string Español_BuyButton = "Comprar";
    string Español_LevelSelectCostText = "Costo:";

    string Español_DungeonStartText = "Comienzo Mazmorra";
    string Español_DungeonStartDescriptionText = "Comienza en la mazmorra con";
    string Español_DungeonStartCoins = "100 monedas";
    string Español_DungeonStartCrystals = "20 cristales";


    string Español_IceCaveStartText = "comienzo cuarto congelado";
    string Español_IceCaveStartDescriptionText = "empieza en el cuarto conjelado con";
    string Español_IceCaveStartCoins = "200 monedas";
    string Español_IceCaveStartCrystals = "40 cristales";

    string Español_JungleStartText = "comienzo jungla";
    string Español_JungleStartDescriptionText = "Empieza en la jungla con";
    string Español_JungleStartCoins = "350 monedas";
    string Español_JungleStartCrystals = "80 cristales";

    string Español_PortalRoomStartText = "comienzo Cuarto de portales";
    string Español_PortalRoomStartDescriptionText = "comienza en el cuarto de portales con";
    string Español_PortalRoomStartCoins = "500 Monedas";
    string Español_PortalRoomStartCrystals = "100 cristales";

    // Forja de runas
    string Español_RuneForgeTitle = "Forja de Runas";
    string Español_EquipedRunes = "Runas equipadas";

    string Español_RuneSlotUnequip = "Desequipar";
    string Español_Select = "seleccionar";

    string Español_RuneName1 = "Runa Flotar";
    string Español_RuneName2 = "Runa Caida";
    string Español_RuneName3 = "Runa Magneto";
    string Español_RuneName4 = "Runa Mana";
    string Español_RuneName5 = "Runa Hechizo";
    string Español_RuneName6 = "Runa escudo";
    string Español_RuneName7 = "Runa Avaricia";
    string Español_RuneName8 = "Runa Comerciante";
    string Español_RuneName9 = "Runa Destrucción";
    string Español_RuneName10 = "Runa desconocida";

    string Español_RuneDescription1 = "Te da mas magia para Flotar";
    string Español_RuneDescription2 = "Caes mas rápido hacia la grieta";
    string Español_RuneDescription3 = "Las monedas son atraidas a tí";
    string Español_RuneDescription4 = "Recarga maná Más rápido";
    string Español_RuneDescription5 = "los hechizos Cuestan Menos maná";
    string Español_RuneDescription6 = "Previene la primera vez que tomas daño cada nivel";
    string Español_RuneDescription7 = "Te da mas monedas al llegar a la tienda";
    string Español_RuneDescription8 = "la primera compra en la tienda de monedas esta a mitad de precio";
    string Español_RuneDescription9 = "Los enemigos aparecen con menos vida";
    string Español_RuneDescription10 = "te da un power up al azar cuendo empiezas un juego";

    string Español_DefaultSkin = "Normal";
    string Español_DragonFireSkin = "Fuego de dragón";
    string Español_BoneSkin = "Hueso";
    string Español_IceGolemSkin = "Golem de hielo";
    string Español_PlantSkin = "Planta";
    string Español_ClokworkSkin = "Relojería";
    string Español_ShadowWizardSkin = "Mago de sombras";
    string Español_TophatSkin = "Sombrero de copa";
    string Español_AngelSkin = "Angel";
    string Español_ImpSkin = "Diablillo";
    string Español_SnowmanSkin = "Hombre de nieve";
    string Español_WizardSkin = "Mago";
    string Español_AstralTravelerSKin = "Viajero Astral";
    string Español_SlimeSkin = "Slime";
    string Español_AlienSkin = "Alien";
    string Español_AssasinBlackSkin = "Asesino negro";
    string Español_AssasinWhiteSkin = "Asesino blanco";
    string Español_FoxSkin = "Zorro";
    string Español_IceCreamSkin = "Paleta";
    string Español_MechSkin = "Mech";

    // logros

    string Español_Achievments = "Logros";

    //Como Jugar

    string Español_HowToPlay = "Cómo Jugar";
    string Español_MovemntHowToPlay = "Movimiento";
    string Español_PowersHowToPlay = "Poderes";






    void Start()
    {
        SetLanguage(GameStats.stats.LanguageSelect);
        LanguageDropdownSettings.value = GameStats.stats.LanguageSelect;
    }

    public void SetLanguage(int Language)
    {
        switch (Language)
        {
            case 0:// English

                GameStats.stats.LanguageSelect = 0;
                GameStats.stats.SaveStats();
                  //main menu and options
                BackButton1.text = English_BackButton;

                StartButton.text = English_StartButton;
                ContinueButton.text = English_ContinueButton;
                NewRunButton.text = English_NewRunButton;
                StoreButton.text = English_StoreButton;
                SkinsButtom.text = English_SkinsButton; SkinsButtom.fontSize = 34;
                HowToPlayButton.text = English_HowToPlayButton;

                OptionsTitle.text = English_OptionsTitle;
                MusicText.text = English_Music;
                SoundText.text = English_Sound;
                NotificationsText.text = English_Notifications;
                LanguageText.text = English_Language;
                BackButton1.text = English_BackButton;

                  // store
                StoreTitle.text = English_StoreTitle;
                PowerUpsTitle.text = English_PowerUpsTitle;
                ManaJarText.text = English_ManaJarText;
                CoinX2text.text = English_CointX2TicketText;
                ExtraHeartsText.text = English_ExtraHeartsText;
                PoertalBoostText.text = English_PortalBoostText;
                FenixFeatherText.text = English_FenixFeatherText;
                RuneText.text = English_RuneButton;
                BackButtonStoreText.text = English_BackButton;

                CarrotPowerText.text = English_CarrotPower;
                EarShieldText.text = English_EarShieldPower;
                RadishMissleText.text = English_RadishMisslePower;
                KickReflectText.text = English_KickReflectPower;
                MagicLaserText.text = English_MagicLaserPower;

                GetCrystalText.text = English_GetCrystalText; GetCrystalText.fontSize = 16;
                WatchAdText.text = English_WatchAdText;
                rewardCrystalText.text = English_CrystalText;
                WatchAdCrystaltext.text = English_CrystalText;
                WatchButtonText.text = English_WatchButton;
                CongratulationsText.text = English_CongratulationsText;
                CollectText.text = English_Collect;
                WhatchAdBackButtonText.text = English_BackButton;

                DamageText1.text = English_DamageText1;
                DamageText2.text = English_DamageText2;
                DamageText3.text = English_DamageText3;
                DamageText4.text = English_DamageText4;
                level1Text.text = English_LevelText1;
                level2Text.text = English_LevelText2;
                level3Text.text = English_LevelText3;
                level4Text.text = English_LevelText4;
                UpgradePowerText.text = English_UpgradePowerText;
                UpgradePowerCrystalText.text = English_CrystalText;
                UpgradePowerMaxLevelText.text = English_MaxLevelText;

                    //level select

                DungeonStartText.text = English_DungeonStartText;
                DungeonStartDescriptionText.text = English_DungeonStartDescriptionText;
                DungeonStartCoins.text = English_DungeonStartCoins;
                DungeonStartCostText.text = English_LevelSelectCostText;
                DungeonStartCrystals.text = English_DungeonStartCrystals;
                DungeonStartBuyButton.text = English_BuyButton;
                DungeonStartBackButton.text = English_BackButton;

                IceCaveStartText.text = English_IceCaveStartText;
                IceCaveStartDescriptionText.text = English_IceCaveStartDescriptionText;
                IceCaveStartCoins.text = English_IceCaveStartCoins;
                IceCaveStartCostText.text = English_LevelSelectCostText;
                IceCaveStartCrystals.text = English_IceCaveStartCrystals;
                IceCaveStartBuyButton.text = English_BuyButton;
                IceCaveStartBackButton.text = English_BackButton;

                JungleStartText.text = English_JungleStartText;
                JungleStartDescriptionText.text = English_JungleStartDescriptionText;
                JungleStartCoins.text = English_JungleStartCoins;
                JungleStartCostText.text = English_LevelSelectCostText;
                JungleStartCrystals.text = English_JungleStartCrystals;
                JungleStartBuyButton.text = English_BuyButton;
                JungleStartBackButton.text = English_BackButton;

                PortalRoomStartText.text = English_PortalRoomStartText;
                PortalRoomStartDescriptionText.text = English_PortalRoomStartDescriptionText;
                PortalRoomStartCoins.text = English_PortalRoomStartCoins;
                PortalRoomStartCostText.text = English_LevelSelectCostText;
                PortalRoomStartCrystals.text = English_PortalRoomStartCrystals;
                PortalRoomStartBuyButton.text = English_BuyButton;
                PortalRoomStartBackButton.text = English_BackButton;

                // rune Forge
                RuneforgeTitle.text = English_RuneForgeTitle;
                EquipedRunes.text = English_EquipedRunes;

                RuneSlot1Unequip.text = English_RuneSlotUnequip;
                RuneSlot2Unequip.text = English_RuneSlotUnequip;

                RuneSlot1Select.text = English_Select;
                RuneSlot2Select.text = English_Select;

                RuneforgeBackButtonText.text = English_BackButton;

                RuneName1.text = English_RuneName1;
                RuneName2.text = English_RuneName2;
                RuneName3.text = English_RuneName3;
                RuneName4.text = English_RuneName4;
                RuneName5.text = English_RuneName5;
                RuneName6.text = English_RuneName6;
                RuneName7.text = English_RuneName7;
                RuneName8.text = English_RuneName8;
                RuneName9.text = English_RuneName9;
                RuneName10.text = English_RuneName10;

                RuneDescription1.text = English_RuneDescription1;
                RuneDescription2.text = English_RuneDescription2;
                RuneDescription3.text = English_RuneDescription3;
                RuneDescription4.text = English_RuneDescription4;
                RuneDescription5.text = English_RuneDescription5;
                RuneDescription6.text = English_RuneDescription6;
                RuneDescription7.text = English_RuneDescription7;
                RuneDescription8.text = English_RuneDescription8;
                RuneDescription9.text = English_RuneDescription9;
                RuneDescription10.text = English_RuneDescription10;

                // Skin menu

                SkinTitle.text = English_SkinsButton;
                BackButtonSkinMenu.text = English_BackButton;
                buySkinButton.text = English_BuyButton;
                selectButton1Text.text = English_Select; selectButton1Text.fontSize = 14;
                selectButton2Text.text = English_Select; selectButton2Text.fontSize = 14;

                DefaultSkinText.text = English_DefaultSkin;
                DragonFireSkinText.text = English_DragonFireSkin;
                BoneSkinText.text = English_BoneSkin;
                IceGolemSkinText.text = English_IceGolemSkin;
                PlantSkinText.text = English_PlantSkin;
                ClockWorkSkinText.text = English_ClokworkSkin;
                ShadowWizardSkinText.text = English_ShadowWizardSkin;
                TophatSkinText.text = English_TophatSkin;
                AngelSkinText.text = English_AngelSkin;
                ImpSkinText.text = English_ImpSkin;
                SnowmanSkinText.text = English_SnowmanSkin;
                WizardSkinText.text = English_WizardSkin;
                AstralTravelerSkinText.text = English_AstralTravelerSKin;
                SlimeSkinText.text = English_SlimeSkin;
                AlienSkinText.text = English_AlienSkin;
                AssasinBlackSkinText.text = English_AssasinBlackSkin;
                AssasinWhiteSkinText.text = English_AssasinWhiteSkin;
                FoxSkinText.text = English_FoxSkin;
                IceCreamSkinText.text = English_IceCreamSkin;
                MechSkinText.text = English_MechSkin;

                //Achievemnt menú

                AchievmentTitle.text = English_Achievments;
                AchivementBackButton.text = English_BackButton;

                //HowToPlay

                HowToPlayTitle.text = English_HowToPlay;
                PowersHowToPlayButton.text = English_PowersHowToPlay;
                MovmentHowToPlayButton.text = English_MovemntHowToPlay;
                BackHowToPlayButton.text = English_BackButton;
                HowToPlayDisplayMovementImage.sprite = English_HowToPlayMovmentSprite;
                HowToPlayDisplayPowersImage.sprite = English_HowToPlayPowersSpirte;






                break;

            case 1:// Español

                GameStats.stats.LanguageSelect = 1;
                GameStats.stats.SaveStats();
                //menú principal y opciones
                BackButton1.text = Español_BackButton;

                StartButton.text = Español_StartButton;
                ContinueButton.text = Español_ContinueButton;
                NewRunButton.text = Español_NewRunButton;
                StoreButton.text = Español_StoreButton;
                SkinsButtom.text = Español_SkinsButton; SkinsButtom.fontSize = 28;
                HowToPlayButton.text = Español_HowToPlayButton;

                OptionsTitle.text = Español_OptionsTitle;
                MusicText.text = Español_Music;
                SoundText.text = Español_Sound;
                NotificationsText.text = Español_Notifications;
                LanguageText.text = Español_Language;
                BackButton1.text = Español_BackButton;

                //Tienda
                StoreTitle.text = Español_StoreTitle; 
                PowerUpsTitle.text = Español_PowerUpsTitle;
                ManaJarText.text = Español_ManaJarText;
                CoinX2text.text = Español_CointX2TicketText;
                ExtraHeartsText.text = Español_ExtraHeartsText;
                PoertalBoostText.text = Español_PortalBoostText;
                FenixFeatherText.text = Español_FenixFeatherText;
                RuneText.text = Español_RuneButton;
                BackButtonStoreText.text = Español_BackButton;

                CarrotPowerText.text = Español_CarrotPower;
                EarShieldText.text = Español_EarShieldPower;
                RadishMissleText.text = Español_RadishMisslePower;
                KickReflectText.text = Español_KickReflectPower;
                MagicLaserText.text = Español_MagicLaserPower;

                GetCrystalText.text = Español_GetCrystalText; GetCrystalText.fontSize = 11;
                WatchAdText.text = Español_WatchAdText;
                rewardCrystalText.text = Español_CrystalText;
                WatchAdCrystaltext.text = Español_CrystalText;
                WatchButtonText.text = Español_WatchButton;
                CongratulationsText.text = Español_CongratulationsText;
                CollectText.text = Español_Collect;
                WhatchAdBackButtonText.text = Español_BackButton;

                DamageText1.text = Español_DamageText1;
                DamageText2.text = Español_DamageText2;
                DamageText3.text = Español_DamageText3;
                DamageText4.text = Español_DamageText4;
                level1Text.text = Español_LevelText1;
                level2Text.text = Español_LevelText2;
                level3Text.text = Español_LevelText3;
                level4Text.text = Español_LevelText4;
                UpgradePowerText.text = Español_UpgradePowerText;
                UpgradePowerCrystalText.text = Español_CrystalText;
                UpgradePowerMaxLevelText.text = Español_MaxLevelText;

                // comienzo de nivel

                DungeonStartText.text = Español_DungeonStartText;
                DungeonStartDescriptionText.text = Español_DungeonStartDescriptionText;
                DungeonStartCoins.text = Español_DungeonStartCoins;
                DungeonStartCostText.text = Español_LevelSelectCostText;
                DungeonStartCrystals.text = Español_DungeonStartCrystals;
                DungeonStartBuyButton.text = Español_BuyButton;
                DungeonStartBackButton.text = Español_BackButton;

                IceCaveStartText.text = Español_IceCaveStartText;
                IceCaveStartDescriptionText.text = Español_IceCaveStartDescriptionText;
                IceCaveStartCoins.text = Español_IceCaveStartCoins;
                IceCaveStartCostText.text = Español_LevelSelectCostText;
                IceCaveStartCrystals.text = Español_IceCaveStartCrystals;
                IceCaveStartBuyButton.text = Español_BuyButton;
                IceCaveStartBackButton.text = Español_BackButton;

                JungleStartText.text = Español_JungleStartText;
                JungleStartDescriptionText.text = Español_JungleStartDescriptionText;
                JungleStartCoins.text = Español_JungleStartCoins;
                JungleStartCostText.text = Español_LevelSelectCostText;
                JungleStartCrystals.text = Español_JungleStartCrystals;
                JungleStartBuyButton.text = Español_BuyButton;
                JungleStartBackButton.text = Español_BackButton;

                PortalRoomStartText.text = Español_PortalRoomStartText;
                PortalRoomStartDescriptionText.text = Español_PortalRoomStartDescriptionText;
                PortalRoomStartCoins.text = Español_PortalRoomStartCoins;
                PortalRoomStartCostText.text = Español_LevelSelectCostText;
                PortalRoomStartCrystals.text = Español_PortalRoomStartCrystals;
                PortalRoomStartBuyButton.text = Español_BuyButton;
                PortalRoomStartBackButton.text = Español_BackButton;

                // Forja de runas
                RuneforgeTitle.text = Español_RuneForgeTitle;
                EquipedRunes.text = Español_EquipedRunes;

                RuneSlot1Unequip.text = Español_RuneSlotUnequip;
                RuneSlot2Unequip.text = Español_RuneSlotUnequip;

                RuneSlot1Select.text = Español_Select;
                RuneSlot2Select.text = Español_Select;

                RuneforgeBackButtonText.text = Español_BackButton;

                RuneName1.text = Español_RuneName1;
                RuneName2.text = Español_RuneName2;
                RuneName3.text = Español_RuneName3;
                RuneName4.text = Español_RuneName4;
                RuneName5.text = Español_RuneName5;
                RuneName6.text = Español_RuneName6;
                RuneName7.text = Español_RuneName7;
                RuneName8.text = Español_RuneName8;
                RuneName9.text = Español_RuneName9;
                RuneName10.text = Español_RuneName10;

                RuneDescription1.text = Español_RuneDescription1;
                RuneDescription2.text = Español_RuneDescription2;
                RuneDescription3.text = Español_RuneDescription3;
                RuneDescription4.text = Español_RuneDescription4;
                RuneDescription5.text = Español_RuneDescription5;
                RuneDescription6.text = Español_RuneDescription6;
                RuneDescription7.text = Español_RuneDescription7;
                RuneDescription8.text = Español_RuneDescription8;
                RuneDescription9.text = Español_RuneDescription9;
                RuneDescription10.text = Español_RuneDescription10;

                SkinTitle.text = Español_SkinsButton;
                BackButtonSkinMenu.text = Español_BackButton;
                buySkinButton.text = Español_BuyButton;
                selectButton1Text.text = Español_Select; selectButton1Text.fontSize = 8;
                selectButton2Text.text = Español_Select; selectButton2Text.fontSize = 8;

                DefaultSkinText.text = Español_DefaultSkin;
                DragonFireSkinText.text = Español_DragonFireSkin;
                BoneSkinText.text = Español_BoneSkin;
                IceGolemSkinText.text = Español_IceGolemSkin;
                PlantSkinText.text = Español_PlantSkin;
                ClockWorkSkinText.text = Español_ClokworkSkin;
                ShadowWizardSkinText.text = Español_ShadowWizardSkin;
                TophatSkinText.text = Español_TophatSkin;
                AngelSkinText.text = Español_AngelSkin;
                ImpSkinText.text = Español_ImpSkin;
                SnowmanSkinText.text = Español_SnowmanSkin;
                WizardSkinText.text = Español_WizardSkin;
                AstralTravelerSkinText.text = Español_AstralTravelerSKin;
                SlimeSkinText.text = Español_SlimeSkin;
                AlienSkinText.text = Español_AlienSkin;
                AssasinBlackSkinText.text = Español_AssasinBlackSkin;
                AssasinWhiteSkinText.text = Español_AssasinWhiteSkin;
                FoxSkinText.text = Español_FoxSkin;
                IceCreamSkinText.text = Español_IceCreamSkin;
                MechSkinText.text = Español_MechSkin;

                //Achievemnt menú

                AchievmentTitle.text = Español_Achievments;
                AchivementBackButton.text = Español_BackButton;

                //cómo Jugar

                HowToPlayTitle.text = Español_HowToPlay;
                PowersHowToPlayButton.text = Español_PowersHowToPlay;
                MovmentHowToPlayButton.text = Español_MovemntHowToPlay;
                BackHowToPlayButton.text = Español_BackButton;
                HowToPlayDisplayMovementImage.sprite = Español_HowToPlayMovmentSprite;
                HowToPlayDisplayPowersImage.sprite = Español_HowToPlayPowersSpirte;


                break;


        }
    }
}
