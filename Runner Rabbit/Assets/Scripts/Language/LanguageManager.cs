using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LanguageManager : MonoBehaviour
{

    // Initial Select Language
    public TextMeshProUGUI InitialSelectLanguageTitle;
    public TextMeshProUGUI ConfirmButton;
    


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
    public TextMeshProUGUI RewriteLevelQuestion, RewriteLevelDescription, RewriteLevelButton, RewriteLevelBackButton; //Rewrite level

    [Space(15)]
    [Header("RuneForge")]
    //Texts RuneForge
    public TextMeshProUGUI toStoreFromRunesButton;
    public TextMeshProUGUI RuneforgeTitle, RuneforgeBackButtonText, RuneName1, RuneName2, RuneName3, RuneName4, RuneName5, RuneName6, RuneName7, RuneName8, RuneName9, RuneName10, RuneDescription1, // RuneForge
                           RuneDescription2, RuneDescription3, RuneDescription4, RuneDescription5, RuneDescription6, RuneDescription7, RuneDescription8, RuneDescription9, RuneDescription10, EquipedRunes,
                           RuneSlot1Unequip, RuneSlot2Unequip, RuneSlot1Select, RuneSlot2Select;
    public TextMeshProUGUI RuneStoreDescription;
    public TextMeshProUGUI RuneStoreDescription2;
    public TextMeshProUGUI NotEnoughCrystalsRune;

    //texts Skin Menú
    public TextMeshProUGUI SkinTitle, DefaultSkinText, DragonFireSkinText, BoneSkinText, IceGolemSkinText, PlantSkinText, ClockWorkSkinText, ShadowWizardSkinText, TophatSkinText, AngelSkinText, ImpSkinText, SnowmanSkinText,
                           WizardSkinText, AstralTravelerSkinText, SlimeSkinText, AlienSkinText, AssasinBlackSkinText, AssasinWhiteSkinText, FoxSkinText, IceCreamSkinText, MechSkinText, BackButtonSkinMenu, buySkinButton, selectButton1Text, selectButton2Text;
    // AchivementMenú
    public TextMeshProUGUI AchievmentTitle, AchivementBackButton;
    //HowToPlay
    public TextMeshProUGUI HowToPlayTitle, MovmentHowToPlayButton, PowersHowToPlayButton, BackHowToPlayButton;
    public Sprite English_HowToPlayMovmentSprite, English_HowToPlayPowersSpirte, Español_HowToPlayMovmentSprite, Español_HowToPlayPowersSpirte, Frances_HowToPlayMovmentSprite, Frances_HowToPlayPowersSpirte;
    public Image HowToPlayDisplayMovementImage, HowToPlayDisplayPowersImage;
    //Crystal Store
    public Text NoAdsTitle, RestorePurchaseTitle, CrystalBunch, CrystalPile, CryslatBag, CrystalChest, skinpacktitle;
    public TextMeshProUGUI NineSkinsDescription;
    public TextMeshProUGUI BackToSkinStoreButton;
    public TextMeshProUGUI backToNormalStoreButton;


    public TextMeshProUGUI NotEnoughCrystalsText;


    [SerializeField] LanguageManagerLogin myLanguageManagerLogin;
    [SerializeField] PlayfabLoginUI myplayfabLoginUi;
    //strings language
    #region Language Strings
    #region English Strings
    //English **********************

    string English_InitialSelectLanguage = "Select Language";
    string English_ConfirmButton = "confirm";

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
    public string English_ManaJarText = "Mana Jar";
    public string English_CointX2TicketText = "Coin x2 Ticket";
    public string English_ExtraHeartsText = "Extra Hearts";
    public string English_PortalBoostText = "Portal Boost";
    public string English_FenixFeatherText = "phoenix Feather";
    string English_RuneButton = "Rune Forge";

    string English_CarrotPower = "Carrot Missile";
    string English_EarShieldPower = "Ear Shield";
    string English_RadishMisslePower = "Radish Missile";
    string English_KickReflectPower = "Kick Reflect";
    string English_MagicLaserPower = "Magic Laser";

    string English_GetCrystalText = "Get Crystals"; 
    string English_WatchAdText = "Watch ad to get crystals?";
    string English_CrystalText = "Crystals";
    string English_WatchButton = "Watch";
    string English_CongratulationsText = "Congratulations! You Got:";
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
    string English_DungeonStartCoins = "200 Coins";
    string English_DungeonStartCrystals = "20 crystals";
   

    string English_IceCaveStartText = "Frozen Room Start";
    string English_IceCaveStartDescriptionText = "Start in Frozen Room Level With";
    string English_IceCaveStartCoins = "400 Coins";
    string English_IceCaveStartCrystals = "40 crystals";

    string English_JungleStartText = "Jungle Start";
    string English_JungleStartDescriptionText = "Start in Jungle Level With";
    string English_JungleStartCoins = "800 Coins";
    string English_JungleStartCrystals = "80 crystals";

    string English_PortalRoomStartText = "Portal Room Start";
    string English_PortalRoomStartDescriptionText = "Start in the portal room Level With";
    string English_PortalRoomStartCoins = "1000 Coins";
    string English_PortalRoomStartCrystals = "100 crystals";


    string English_RewriteLevelQuestion = "You already bought a level. are you sure you want to change the starting level?";
    string English_RewriteLevelDescription = "Will be refunded";

    // runeforge
    string English_RuneForgeTitle = "Rune Forge";
    string English_EquipedRunes = "Equipped Runes";

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
    string English_RuneDescription3 = "Coins are attracted to you";
    string English_RuneDescription4 = "Recharge mana faster";
    string English_RuneDescription5 = "Spells cost less mana";
    string English_RuneDescription6 = "Grants you a shield that protects you from one hit in each level";
    string English_RuneDescription7 = "gives you 25% more coins when you reach the store";
    string English_RuneDescription8 = "the first item in the coin shop is 50% off";
    string English_RuneDescription9 = "Enemies spawn with less health";
    string English_RuneDescription10 = "gives you one random power up when starting a new run";

    string English_RuneShopDescription = "Unlock passive abilities";
    string English_RuneShopDescription2 = "Equip up to two runes that will help you in your escape";

    


    string English_DefaultSkin = "Default";
    string English_DragonFireSkin = "Dragon Fire";
    string English_BoneSkin = "Bone";
    string English_IceGolemSkin = "Ice Golem";
    string English_PlantSkin = "Plant";
    string English_ClokworkSkin = "Clockwork";
    string English_ShadowWizardSkin = "Shadow Wizard";
    string English_TophatSkin = "Top hat";
    string English_AngelSkin = "Angel";
    string English_ImpSkin = "Imp";
    string English_SnowmanSkin = "Snowman";
    string English_WizardSkin = "Wizard";
    string English_AstralTravelerSKin = "Astral Traveler";
    string English_SlimeSkin = "Slime";
    string English_AlienSkin = "Alien";
    string English_AssasinBlackSkin = "Dark Assasin";
    string English_AssasinWhiteSkin = "Light Assasin";
    string English_FoxSkin = "Fox";
    string English_IceCreamSkin = "Ice Cream";
    string English_MechSkin = "Mech";


    string English_RuneStoreDescription = ""; // TODO

    // achievment menú
    string English_Achievments = "Achievements";

    //HowToPlay

    string English_HowToPlay = "How to Play";
    string English_MovemntHowToPlay = "Movement";
    string English_PowersHowToPlay = "Powers";

    //Crystal Store

    string English_RemoveAds = "Remove Ads";
    string English_RestorePurchases = "Restore Purchases";
    string English_CrystalBunch = "Crystal Bunch";
    string English_CrystalPile = "Crystal Pile";
    string English_CrystalBag = "Crystal Bag";
    string English_CrystalChest = "Crystal Chest";
    string English_SkinPack = "Skin pack";
    string English_9Skins = "9 skins";



    public string English_CoinsX2Description = "Every coin you collect counts as 2";
    public string English_PortalBoostDescription = "non-boss levels last half as long";
    public string English_PhoenixFeatherDescription = "If you die, you'll be automatically resurrected with full health a single time";
    public string English_ExtraHeartsDescription = "Start the run with 2 extra hearts";
    public string English_ManaJarDescription = "Start the run with 30 extra dark mana and 30 extra light mana";


    string English_NotEnoughCrystals = "Not Enough Crystals";

    #endregion English Strings
    #region Spanish Strings
    //Español******************

    string Español_InitialSelectLanguage = "Escoger Idioma";
    string Español_ConfirmButton = "confirmar";

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
    public string Español_ManaJarText = "Jarra de mana";
    public string Español_CointX2TicketText = "Tiquete monedas x2";
    public string Español_ExtraHeartsText = "Corazones extra";
    public string Español_PortalBoostText = "Boost de portal";
    public string Español_FenixFeatherText = "Pluma de fénix";
    string Español_RuneButton = "Forja de Runas";

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

    string Español_DungeonStartText = "Comienzo Calabozo";
    string Español_DungeonStartDescriptionText = "Comienza en el calabozo con";
    string Español_DungeonStartCoins = "100 monedas";
    string Español_DungeonStartCrystals = "20 cristales";


    string Español_IceCaveStartText = "comienzo cuarto congelado";
    string Español_IceCaveStartDescriptionText = "empieza en el cuarto conjelado con";
    string Español_IceCaveStartCoins = "200 monedas";
    string Español_IceCaveStartCrystals = "40 cristales";

    string Español_JungleStartText = "comienzo jungla";
    string Español_JungleStartDescriptionText = "Empieza en la jungla con";
    string Español_JungleStartCoins = "400 monedas";
    string Español_JungleStartCrystals = "80 cristales";

    string Español_PortalRoomStartText = "comienzo Cuarto de portales";
    string Español_PortalRoomStartDescriptionText = "comienza en el cuarto de portales con";
    string Español_PortalRoomStartCoins = "500 Monedas";
    string Español_PortalRoomStartCrystals = "100 cristales";

    string Español_RewriteLevelQuestion = "ya has comprado un nivel, ¿estás seguro que quieres cambiar el nivel de inicio? ";
    string Español_RewriteLevelDescription = "serán reembolsados";

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
    string Español_RuneDescription6 = "Te da un escudo que te protege de un golpe en cada nivel";
    string Español_RuneDescription7 = "Te da mas monedas al llegar a la tienda";
    string Español_RuneDescription8 = "la primera compra en la tienda de monedas esta a mitad de precio";
    string Español_RuneDescription9 = "Los enemigos aparecen con menos vida";
    string Español_RuneDescription10 = "te da un power up al azar cuendo empiezas un juego";

    string Español_RuneShopDescription = "Desbloquea habilidiades pasivas";
    string Español_RuneShopDescription2 = "Equipa hasta dos runas que te ayudarán en tu escape.";

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
    string Español_AssasinBlackSkin = "Asesino de oscuridad";
    string Español_AssasinWhiteSkin = "Asesino de luz";
    string Español_FoxSkin = "Zorro";
    string Español_IceCreamSkin = "Paleta";
    string Español_MechSkin = "Mech";

    // logros

    string Español_Achievments = "Logros";

    //Como Jugar

    string Español_HowToPlay = "Cómo Jugar";
    string Español_MovemntHowToPlay = "Movimiento";
    string Español_PowersHowToPlay = "Poderes";

    //Tienda IAP

    string Español_RemoveAds = "Quitar Ads";
    string Español_RestorePurchases = "Reestablecer compras";
    string Español_CrystalBunch = "Manojo de cristales";
    string Español_CrystalPile = "Pila de cristales";
    string Español_CrystalBag = "Bolsa de cristales";
    string Español_CrystalChest = "Cofre de Cristales";

    string Español_SkinPack = "Paquete de Aspectos";
    string Español_9Skins = "9 Aspectos";

   


    public string Español_CoinsX2Description = "Cada moneda que recoges cuenta por 2";
    public string Español_PortalBoostDescription = "los niveles que no son de jefes duran la mitad de tiempo";
    public string Español_PhoenixFeatherDescription = "Si mueres, resusitarás con la vida completa una vez";
    public string Español_ExtraHeartsDescription = "Empieza la partida con 2 corazones extra";
    public string Español_ManaJarDescription = "Empieza la partida con 30 mana de luz y 30 mana de oscuridad extra";

    string Español_NotEnoughCrystals = "No tienes suficientes cristales";

    #endregion Spanish Strings
    #region French Strings

    // Frances******************

    string Frances_InitialSelectLanguage = "Select Language";
    string Frances_ConfirmButton = "confirm";

    string Frances_BackButton = "Back";

    string Frances_StartButton = "Start";
    string Frances_ContinueButton = "Continue";
    string Frances_NewRunButton = "New Run";
    string Frances_StoreButton = "Store";
    string Frances_SkinsButton = "Skins";
    string Frances_HowToPlayButton = "How to play";

    string Frances_OptionsTitle = "Options";
    string Frances_Music = "Music";
    string Frances_Sound = "Sound";
    string Frances_Notifications = "Notifications";
    string Frances_Language = "Language";

    //Store

    string Frances_StoreTitle = "Store";
    string Frances_PowerUpsTitle = "Power Ups";
    public string Frances_ManaJarText = "Mana Jar";
    public string Frances_CointX2TicketText = "Coin x2 Ticket";
    public string Frances_ExtraHeartsText = "Extra Hearts";
    public string Frances_PortalBoostText = "Portal Boost";
    public string Frances_FenixFeatherText = "phoenix Feather";
    string Frances_RuneButton = "Runes";

    string Frances_CarrotPower = "Carrot Missile";
    string Frances_EarShieldPower = "Ear Shield";
    string Frances_RadishMisslePower = "Radish Missile";
    string Frances_KickReflectPower = "Kick Reflect";
    string Frances_MagicLaserPower = "Magic Laser";

    string Frances_GetCrystalText = "Get Crystals";
    string Frances_WatchAdText = "Watch ad to get crystals?";
    string Frances_CrystalText = "Crystals";
    string Frances_WatchButton = "Watch";
    string Frances_CongratulationsText = "Congratulations! You Got:";
    string Frances_Collect = "Collect";

    string Frances_DamageText1 = "Damage";
    string Frances_DamageText2 = "Damage";
    string Frances_DamageText3 = "Damage";
    string Frances_DamageText4 = "Damage";
    string Frances_LevelText1 = "Level 1";
    string Frances_LevelText2 = "Level 2";
    string Frances_LevelText3 = "Level 3";
    string Frances_LevelText4 = "Level 4";
    string Frances_UpgradePowerText = "Upgrade";
    string Frances_MaxLevelText = "Max Level";

    string Frances_BuyButton = "buy";

    string Frances_LevelSelectCostText = "Cost:";

    string Frances_DungeonStartText = "Dungeon Start";
    string Frances_DungeonStartDescriptionText = "Start in Dungeon Level With";
    string Frances_DungeonStartCoins = "200 Coins";
    string Frances_DungeonStartCrystals = "20 crystals";


    string Frances_IceCaveStartText = "Frozen Room Start";
    string Frances_IceCaveStartDescriptionText = "Start in Frozen Room Level With";
    string Frances_IceCaveStartCoins = "400 Coins";
    string Frances_IceCaveStartCrystals = "40 crystals";

    string Frances_JungleStartText = "Jungle Start";
    string Frances_JungleStartDescriptionText = "Start in Jungle Level With";
    string Frances_JungleStartCoins = "800 Coins";
    string Frances_JungleStartCrystals = "80 crystals";

    string Frances_PortalRoomStartText = "Portal Room Start";
    string Frances_PortalRoomStartDescriptionText = "Start in the portal room Level With";
    string Frances_PortalRoomStartCoins = "1000 Coins";
    string Frances_PortalRoomStartCrystals = "100 crystals";


    string Frances_RewriteLevelQuestion = "You already bought a level. are you sure you want to change the starting level?";
    string Frances_RewriteLevelDescription = "previous coins will be removed and previous crystals will be refunded before making the new purchase";

    // runeforge
    string Frances_RuneForgeTitle = "Rune Forge";
    string Frances_EquipedRunes = "Equipped Runes";

    string Frances_RuneSlotUnequip = "unequip";
    string Frances_Select = "Select";



    string Frances_RuneName1 = "Float Rune";
    string Frances_RuneName2 = "Fall Rune";
    string Frances_RuneName3 = "Magnet Rune";
    string Frances_RuneName4 = "Mana Rune";
    string Frances_RuneName5 = "Spell Rune";
    string Frances_RuneName6 = "Shield Rune";
    string Frances_RuneName7 = "Greed Rune";
    string Frances_RuneName8 = "Merchant Rune";
    string Frances_RuneName9 = "Destruction Rune";
    string Frances_RuneName10 = "Unknown Rune";

    string Frances_RuneDescription1 = "Gives you extra magic for floating";
    string Frances_RuneDescription2 = "you fall faster towards the rift";
    string Frances_RuneDescription3 = "Coins are attracted to you";
    string Frances_RuneDescription4 = "Recharge mana faster";
    string Frances_RuneDescription5 = "Spells cost less mana";
    string Frances_RuneDescription6 = "Prevents the first time you would get hit each level";
    string Frances_RuneDescription7 = "gives you more coins when you reach the store";
    string Frances_RuneDescription8 = "the first item in the coin shop is 50% off";
    string Frances_RuneDescription9 = "Enemies spawn with less health";
    string Frances_RuneDescription10 = "gives you one random power up when starting a new run";

    string Frances_RuneShopDescription = "Desbloquea habilidiades pasivas";
    string Frances_RuneShopDescription2 = "Équipez jusqu'à deux runes qui vous aideront dans votre évasion";


    string Frances_DefaultSkin = "Default";
    string Frances_DragonFireSkin = "Dragon Fire";
    string Frances_BoneSkin = "Bone";
    string Frances_IceGolemSkin = "Ice Golem";
    string Frances_PlantSkin = "Plant";
    string Frances_ClokworkSkin = "Clockwork";
    string Frances_ShadowWizardSkin = "Shadow Wizard";
    string Frances_TophatSkin = "Top hat";
    string Frances_AngelSkin = "Angel";
    string Frances_ImpSkin = "Imp";
    string Frances_SnowmanSkin = "Snowman";
    string Frances_WizardSkin = "Wizard";
    string Frances_AstralTravelerSKin = "Astral Traveler";
    string Frances_SlimeSkin = "Slime";
    string Frances_AlienSkin = "Alien";
    string Frances_AssasinBlackSkin = "Assassin Black";
    string Frances_AssasinWhiteSkin = "Assassin White";
    string Frances_FoxSkin = "Fox";
    string Frances_IceCreamSkin = "Ice Cream";
    string Frances_MechSkin = "Mech";

    // achievment menú
    string Frances_Achievments = "Achievements";

    //HowToPlay

    string Frances_HowToPlay = "How to Play";
    string Frances_MovemntHowToPlay = "Movement";
    string Frances_PowersHowToPlay = "Powers";

    //Crystal Store

    string Frances_RemoveAds = "Remove Ads";
    string Frances_RestorePurchases = "Restore Purchases";
    string Frances_CrystalBunch = "Crystal Bunch";
    string Frances_CrystalPile = "Crystal Pile";
    string Frances_CrystalBag = "Crystal Bag";
    string Frances_CrystalChest = "Crystal Chest";
    string Frances_SkinPack = "Skin pack";
    string Frances_9Skins = "9 skins";



    public string Frances_CoinsX2Description = "Every coin you collect counts as 2";
    public string Frances_PortalBoostDescription = "Start each level at the halfway point, does not count boss levels";
    public string Frances_PhoenixFeatherDescription = "When you die heal to full once";
    public string Frances_ExtraHeartsDescription = "Start the run with 2 extra hearts";
    public string Frances_ManaJarDescription = "Start the run with 30 extra dark mana and 30 extra light mana";

    string Frances_NotEnoughCrystals = "No tienes suficientes cristales";

    #endregion French Strings

#endregion Language Strings



    void Start()
    {
        if (Application.systemLanguage == SystemLanguage.English)
        {
            InitialSelectLanguageTitle.text = English_InitialSelectLanguage;
        } else if (Application.systemLanguage == SystemLanguage.Spanish)
        {
            InitialSelectLanguageTitle.text = Español_InitialSelectLanguage;
        }
            SetLanguage(GameStats.stats.LanguageSelect);
        LanguageDropdownSettings.value = GameStats.stats.LanguageSelect;
    }

    public void DelayedStart()
    {
        if (Application.systemLanguage == SystemLanguage.English)
        {
            InitialSelectLanguageTitle.text = English_InitialSelectLanguage;
        }
        else if (Application.systemLanguage == SystemLanguage.Spanish)
        {
            InitialSelectLanguageTitle.text = Español_InitialSelectLanguage;
        }
        SetLanguage(GameStats.stats.LanguageSelect);
        LanguageDropdownSettings.value = GameStats.stats.LanguageSelect;
    }

    public void SetLanguage(int Language)
    {
        myLanguageManagerLogin.UpdateLanguage(Language);
        myplayfabLoginUi.checkDataAndUpdateLanguage(myLanguageManagerLogin, Language);

        switch (Language)
        {
            case 0:// English

                GameStats.stats.LanguageSelect = 0;
                GameStats.stats.languageselected = true;
                GameStats.stats.SaveStats();
                //main menu and options

                InitialSelectLanguageTitle.text = English_InitialSelectLanguage;
                ConfirmButton.text = English_ConfirmButton;

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

                RewriteLevelQuestion.text = English_RewriteLevelQuestion;
                RewriteLevelDescription.text = English_RewriteLevelDescription;
                RewriteLevelBackButton.text = English_BackButton;
                RewriteLevelButton.text = English_BuyButton;

                // rune Forge
                toStoreFromRunesButton.text = English_StoreTitle;

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

                RuneStoreDescription.text = English_RuneShopDescription;
                RuneStoreDescription2.text = English_RuneShopDescription2;

                NotEnoughCrystalsRune.text = English_NotEnoughCrystals;

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


                //Store IAP

                NoAdsTitle.text = English_RemoveAds;
                RestorePurchaseTitle.text = English_RestorePurchases;
                CrystalBunch.text = English_CrystalBunch;
                CrystalPile.text = English_CrystalPile;
                CryslatBag.text = English_CrystalBag;
                CrystalChest.text = English_CrystalChest;

                skinpacktitle.text = English_SkinPack;
                NineSkinsDescription.text = English_9Skins;
                BackToSkinStoreButton.text = English_BackButton;
                backToNormalStoreButton.text = English_BackButton;


                NotEnoughCrystalsText.text = English_NotEnoughCrystals;





                break;

            case 1:// Español

                GameStats.stats.LanguageSelect = 1;
                GameStats.stats.languageselected = true;
                GameStats.stats.SaveStats();
                //menú principal y opciones

                InitialSelectLanguageTitle.text = Español_InitialSelectLanguage;
                ConfirmButton.text = Español_ConfirmButton;

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

                RewriteLevelQuestion.text = Español_RewriteLevelQuestion;
                RewriteLevelDescription.text = Español_RewriteLevelDescription;
                RewriteLevelBackButton.text = Español_BackButton;
                RewriteLevelButton.text = Español_BuyButton;

                // Forja de runas
                toStoreFromRunesButton.text = Español_StoreTitle;
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

                RuneStoreDescription.text = Español_RuneShopDescription;
                RuneStoreDescription2.text = Español_RuneShopDescription2;

                NotEnoughCrystalsRune.text = Español_NotEnoughCrystals;


                //skins
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

                NoAdsTitle.text = Español_RemoveAds;
                RestorePurchaseTitle.text = Español_RestorePurchases;
                CrystalBunch.text = Español_CrystalBunch;
                CrystalPile.text = Español_CrystalPile;
                CryslatBag.text = Español_CrystalBag;
                CrystalChest.text = Español_CrystalChest;

                skinpacktitle.text = Español_SkinPack;
                NineSkinsDescription.text = Español_9Skins;
                BackToSkinStoreButton.text = Español_BackButton;
                backToNormalStoreButton.text = Español_BackButton;

                NotEnoughCrystalsText.text = Español_NotEnoughCrystals;


                break;

            case 2: // frances
                GameStats.stats.LanguageSelect = 2;
                GameStats.stats.languageselected = true;
                GameStats.stats.SaveStats();
                //main menu and options

                InitialSelectLanguageTitle.text = Frances_InitialSelectLanguage;
                ConfirmButton.text = Frances_ConfirmButton;

                BackButton1.text = Frances_BackButton;

                StartButton.text = Frances_StartButton;
                ContinueButton.text = Frances_ContinueButton;
                NewRunButton.text = Frances_NewRunButton;
                StoreButton.text = Frances_StoreButton;
                SkinsButtom.text = Frances_SkinsButton; SkinsButtom.fontSize = 34;
                HowToPlayButton.text = Frances_HowToPlayButton;

                OptionsTitle.text = Frances_OptionsTitle;
                MusicText.text = Frances_Music;
                SoundText.text = Frances_Sound;
                NotificationsText.text = Frances_Notifications;
                LanguageText.text = Frances_Language;
                BackButton1.text = Frances_BackButton;

                // store
                StoreTitle.text = Frances_StoreTitle;
                PowerUpsTitle.text = Frances_PowerUpsTitle;
                ManaJarText.text = Frances_ManaJarText;
                CoinX2text.text = Frances_CointX2TicketText;
                ExtraHeartsText.text = Frances_ExtraHeartsText;
                PoertalBoostText.text = Frances_PortalBoostText;
                FenixFeatherText.text = Frances_FenixFeatherText;
                RuneText.text = Frances_RuneButton;
                BackButtonStoreText.text = Frances_BackButton;

                CarrotPowerText.text = Frances_CarrotPower;
                EarShieldText.text = Frances_EarShieldPower;
                RadishMissleText.text = Frances_RadishMisslePower;
                KickReflectText.text = Frances_KickReflectPower;
                MagicLaserText.text = Frances_MagicLaserPower;

                GetCrystalText.text = Frances_GetCrystalText; GetCrystalText.fontSize = 16;
                WatchAdText.text = Frances_WatchAdText;
                rewardCrystalText.text = Frances_CrystalText;
                WatchAdCrystaltext.text = Frances_CrystalText;
                WatchButtonText.text = Frances_WatchButton;
                CongratulationsText.text = Frances_CongratulationsText;
                CollectText.text = Frances_Collect;
                WhatchAdBackButtonText.text = Frances_BackButton;

                DamageText1.text = Frances_DamageText1;
                DamageText2.text = Frances_DamageText2;
                DamageText3.text = Frances_DamageText3;
                DamageText4.text = Frances_DamageText4;
                level1Text.text = Frances_LevelText1;
                level2Text.text = Frances_LevelText2;
                level3Text.text = Frances_LevelText3;
                level4Text.text = Frances_LevelText4;
                UpgradePowerText.text = Frances_UpgradePowerText;
                UpgradePowerCrystalText.text = Frances_CrystalText;
                UpgradePowerMaxLevelText.text = Frances_MaxLevelText;

                //level select

                DungeonStartText.text = Frances_DungeonStartText;
                DungeonStartDescriptionText.text = Frances_DungeonStartDescriptionText;
                DungeonStartCoins.text = Frances_DungeonStartCoins;
                DungeonStartCostText.text = Frances_LevelSelectCostText;
                DungeonStartCrystals.text = Frances_DungeonStartCrystals;
                DungeonStartBuyButton.text = Frances_BuyButton;
                DungeonStartBackButton.text = Frances_BackButton;

                IceCaveStartText.text = Frances_IceCaveStartText;
                IceCaveStartDescriptionText.text = Frances_IceCaveStartDescriptionText;
                IceCaveStartCoins.text = Frances_IceCaveStartCoins;
                IceCaveStartCostText.text = Frances_LevelSelectCostText;
                IceCaveStartCrystals.text = Frances_IceCaveStartCrystals;
                IceCaveStartBuyButton.text = Frances_BuyButton;
                IceCaveStartBackButton.text = Frances_BackButton;

                JungleStartText.text = Frances_JungleStartText;
                JungleStartDescriptionText.text = Frances_JungleStartDescriptionText;
                JungleStartCoins.text = Frances_JungleStartCoins;
                JungleStartCostText.text = Frances_LevelSelectCostText;
                JungleStartCrystals.text = Frances_JungleStartCrystals;
                JungleStartBuyButton.text = Frances_BuyButton;
                JungleStartBackButton.text = Frances_BackButton;

                PortalRoomStartText.text = Frances_PortalRoomStartText;
                PortalRoomStartDescriptionText.text = Frances_PortalRoomStartDescriptionText;
                PortalRoomStartCoins.text = Frances_PortalRoomStartCoins;
                PortalRoomStartCostText.text = Frances_LevelSelectCostText;
                PortalRoomStartCrystals.text = Frances_PortalRoomStartCrystals;
                PortalRoomStartBuyButton.text = Frances_BuyButton;
                PortalRoomStartBackButton.text = Frances_BackButton;

                RewriteLevelQuestion.text = Frances_RewriteLevelQuestion;
                RewriteLevelDescription.text = Frances_RewriteLevelDescription;
                RewriteLevelBackButton.text = Frances_BackButton;
                RewriteLevelButton.text = Frances_BuyButton;

                // rune Forge
                toStoreFromRunesButton.text = Frances_StoreTitle;
                RuneforgeTitle.text = Frances_RuneForgeTitle;
                EquipedRunes.text = Frances_EquipedRunes;

                RuneSlot1Unequip.text = Frances_RuneSlotUnequip;
                RuneSlot2Unequip.text = Frances_RuneSlotUnequip;

                RuneSlot1Select.text = Frances_Select;
                RuneSlot2Select.text = Frances_Select;

                RuneforgeBackButtonText.text = Frances_BackButton;

                RuneName1.text = Frances_RuneName1;
                RuneName2.text = Frances_RuneName2;
                RuneName3.text = Frances_RuneName3;
                RuneName4.text = Frances_RuneName4;
                RuneName5.text = Frances_RuneName5;
                RuneName6.text = Frances_RuneName6;
                RuneName7.text = Frances_RuneName7;
                RuneName8.text = Frances_RuneName8;
                RuneName9.text = Frances_RuneName9;
                RuneName10.text = Frances_RuneName10;

                RuneDescription1.text = Frances_RuneDescription1;
                RuneDescription2.text = Frances_RuneDescription2;
                RuneDescription3.text = Frances_RuneDescription3;
                RuneDescription4.text = Frances_RuneDescription4;
                RuneDescription5.text = Frances_RuneDescription5;
                RuneDescription6.text = Frances_RuneDescription6;
                RuneDescription7.text = Frances_RuneDescription7;
                RuneDescription8.text = Frances_RuneDescription8;
                RuneDescription9.text = Frances_RuneDescription9;
                RuneDescription10.text = Frances_RuneDescription10;

                RuneStoreDescription.text = Frances_RuneShopDescription;
                RuneStoreDescription2.text = Frances_RuneShopDescription2;

                NotEnoughCrystalsText.text = Frances_NotEnoughCrystals;

                // Skin menu

                SkinTitle.text = Frances_SkinsButton;
                BackButtonSkinMenu.text = Frances_BackButton;
                buySkinButton.text = Frances_BuyButton;
                selectButton1Text.text = Frances_Select; selectButton1Text.fontSize = 14;
                selectButton2Text.text = Frances_Select; selectButton2Text.fontSize = 14;

                DefaultSkinText.text = Frances_DefaultSkin;
                DragonFireSkinText.text = Frances_DragonFireSkin;
                BoneSkinText.text = Frances_BoneSkin;
                IceGolemSkinText.text = Frances_IceGolemSkin;
                PlantSkinText.text = Frances_PlantSkin;
                ClockWorkSkinText.text = Frances_ClokworkSkin;
                ShadowWizardSkinText.text = Frances_ShadowWizardSkin;
                TophatSkinText.text = Frances_TophatSkin;
                AngelSkinText.text = Frances_AngelSkin;
                ImpSkinText.text = Frances_ImpSkin;
                SnowmanSkinText.text = Frances_SnowmanSkin;
                WizardSkinText.text = Frances_WizardSkin;
                AstralTravelerSkinText.text = Frances_AstralTravelerSKin;
                SlimeSkinText.text = Frances_SlimeSkin;
                AlienSkinText.text = Frances_AlienSkin;
                AssasinBlackSkinText.text = Frances_AssasinBlackSkin;
                AssasinWhiteSkinText.text = Frances_AssasinWhiteSkin;
                FoxSkinText.text = Frances_FoxSkin;
                IceCreamSkinText.text = Frances_IceCreamSkin;
                MechSkinText.text = Frances_MechSkin;

                //Achievemnt menú

                AchievmentTitle.text = Frances_Achievments;
                AchivementBackButton.text = Frances_BackButton;

                //HowToPlay

                HowToPlayTitle.text = Frances_HowToPlay;
                PowersHowToPlayButton.text = Frances_PowersHowToPlay;
                MovmentHowToPlayButton.text = Frances_MovemntHowToPlay;
                BackHowToPlayButton.text = Frances_BackButton;
                HowToPlayDisplayMovementImage.sprite = Frances_HowToPlayMovmentSprite;  
                HowToPlayDisplayPowersImage.sprite = Frances_HowToPlayPowersSpirte; 


                //Store IAP

                NoAdsTitle.text = Frances_RemoveAds;
                RestorePurchaseTitle.text = Frances_RestorePurchases;
                CrystalBunch.text = Frances_CrystalBunch;
                CrystalPile.text = Frances_CrystalPile;
                CryslatBag.text = Frances_CrystalBag;
                CrystalChest.text = Frances_CrystalChest;

                skinpacktitle.text = Frances_SkinPack;
                NineSkinsDescription.text = Frances_9Skins;
                BackToSkinStoreButton.text = Frances_BackButton;
                backToNormalStoreButton.text = Frances_BackButton;

                NotEnoughCrystalsText.text = Frances_NotEnoughCrystals;


                break;


        }
    }

    public void ConfirmLanguage()
    {
        if (GameStats.stats.languageselected == false)
        {
            GameStats.stats.languageselected = true;
            //GameStats.stats.LanguageSelect = 0;
            GameStats.stats.SaveStats();
        }
    }
}
