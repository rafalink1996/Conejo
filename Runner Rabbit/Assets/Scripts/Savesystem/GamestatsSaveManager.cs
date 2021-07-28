using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamestatsSaveManager : MonoBehaviour
{
    #region Save and Load Local
    [Header("JsonSaveSystem")]
    [SerializeField] DataManager myDataManager;
    public bool NoLocalSaveDetected;
    public bool DataLoaded;


    public void LoadGamestats()
    {
        if (LocalFileAvailable())
        {
            Debug.Log("loaded Json");
            myDataManager.LoadJson();
            SetJsonDataStats(myDataManager);
            DataLoaded = true;
        }
        else if (SaveSystem.IsBinaryFilePresent())
        {
            Debug.Log("loaded binary");
            PlayerData data = SaveSystem.loadPlayer();
            SetBinarySavedStats(data);
            DataLoaded = true;
        }
        else
        {
            NoLocalSaveDetected = true;
        }

    }

    public void SaveGamestats()
    {
        //SaveSystem.SavePlayer(this); Old Binary Safe System
        myDataManager.SaveJson();
    }


    private bool LocalFileAvailable()
    {
        bool ReturnBool;
        if (myDataManager.IsFilePresent())
        {
            ReturnBool = true;
        }
        else
        {
            ReturnBool = false;
        }

        return ReturnBool;
    }

    void SetJsonDataStats(DataManager dataMagaer)
    {
        var data = dataMagaer.data;

        GameStats.stats.CoinTicket = data.CoinTicketBought;
        GameStats.stats.PortalBoost = data.PortalBoostBought;
        GameStats.stats.fenixFeather = data.fenixfetherBought;
        GameStats.stats.ExtraHearts = data.ExtraHeartsBought;
        GameStats.stats.ManaJar = data.ManaJarBought;

        GameStats.stats.crystals = data.Crystals;
        GameStats.stats.leveBoughtID = data.level;
        GameStats.stats.LevelBought = data.LevelBought;
        GameStats.stats.LevelBoughtCrystals = data.LevelBoughtCrystals;
        GameStats.stats.LevelBoughtCoins = data.LevelBoughtCoins;


        GameStats.stats.coins = data.Coins;

        GameStats.stats.SavedLevelCount = data.SavedLevelCount;
        GameStats.stats.SavedLevelIndicator = data.SavedLevelIndicator;
        GameStats.stats.RunInProgress = data.RunInProgress;
        GameStats.stats.SavedLevelPercentage = data.savedLevelPercentage;
        GameStats.stats.numOfHearts = data.MaxHearts;
        GameStats.stats.SaveCurrentHearts = data.CurrentHearts;
        GameStats.stats.isInStore = data.IsInStore;

        GameStats.stats.savedDarkPowerID = data.SavedDarkPowerID;
        GameStats.stats.savedLightPowerID = data.SavedLightPowerID;

        GameStats.stats.totalDarkMana = data.ManaDark;
        GameStats.stats.totalLightMana = data.Manalight;


        GameStats.stats.LevelReached = data.levelReached;
        GameStats.stats.botSkinID = data.BotSkin;
        GameStats.stats.topSkinID = data.TopSkin;

        GameStats.stats.timedReward = data.TimeReward;
        GameStats.stats.timedRewardLastDate = data.TimedRewardLastDate;

        GameStats.stats.skinConditions[0] = data.skinConditions[0];
        GameStats.stats.skinConditions[1] = data.skinConditions[1];
        GameStats.stats.skinConditions[2] = data.skinConditions[2];
        GameStats.stats.skinConditions[3] = data.skinConditions[3];
        GameStats.stats.skinConditions[4] = data.skinConditions[4];
        GameStats.stats.skinConditions[5] = data.skinConditions[5];


        GameStats.stats.CarrotMissleLevel = data.CarrotMissleLevel;
        GameStats.stats.EarDefenceLevel = data.EarDefenceLevel;
        GameStats.stats.RadishMissleLevel = data.RadishMissleLevel;
        GameStats.stats.KickReflectLevel = data.KickReflectLevel;
        GameStats.stats.MagicLaserLevel = data.MagicLaserLevel;

        GameStats.stats.AudioVolume = data.AudioVolume;
        GameStats.stats.MusicVolume = data.MusicVolume;

        GameStats.stats.AchivementConditions[0] = data.AchivementConditions[0];
        GameStats.stats.AchivementConditions[1] = data.AchivementConditions[1];
        GameStats.stats.AchivementConditions[2] = data.AchivementConditions[2];
        GameStats.stats.AchivementConditions[3] = data.AchivementConditions[3];
        GameStats.stats.AchivementConditions[4] = data.AchivementConditions[4];
        GameStats.stats.AchivementConditions[5] = data.AchivementConditions[5];
        GameStats.stats.AchivementConditions[6] = data.AchivementConditions[6];
        GameStats.stats.AchivementConditions[7] = data.AchivementConditions[7];
        GameStats.stats.AchivementConditions[8] = data.AchivementConditions[8];
        GameStats.stats.AchivementConditions[9] = data.AchivementConditions[9];
        GameStats.stats.AchivementConditions[10] = data.AchivementConditions[10];
        GameStats.stats.AchivementConditions[11] = data.AchivementConditions[11];
        GameStats.stats.AchivementConditions[12] = data.AchivementConditions[12];
        GameStats.stats.AchivementConditions[13] = data.AchivementConditions[13];


        GameStats.stats.MoneySpent = data.GoldSpent;
        GameStats.stats.monstersKilled = data.monstersKilled;
        GameStats.stats.diedTimes = data.diedTimes;

        GameStats.stats.Rune1ID = data.Rune1Id;
        GameStats.stats.Rune2ID = data.Rune2Id;

        GameStats.stats.UnlockedRunes[0] = data.unlockedRunes[0];
        GameStats.stats.UnlockedRunes[1] = data.unlockedRunes[1];
        GameStats.stats.UnlockedRunes[2] = data.unlockedRunes[2];
        GameStats.stats.UnlockedRunes[3] = data.unlockedRunes[3];
        GameStats.stats.UnlockedRunes[4] = data.unlockedRunes[4];
        GameStats.stats.UnlockedRunes[5] = data.unlockedRunes[5];
        GameStats.stats.UnlockedRunes[6] = data.unlockedRunes[6];
        GameStats.stats.UnlockedRunes[7] = data.unlockedRunes[7];
        GameStats.stats.UnlockedRunes[8] = data.unlockedRunes[8];
        GameStats.stats.UnlockedRunes[9] = data.unlockedRunes[9];

        GameStats.stats.NoAdsBought = data.NoAdsBought;
        GameStats.stats.SkinPackBought = data.SkinPackBought;
        GameStats.stats.NoAdsBoughtBackup = data.NoAdsBoughtBackUp;

        GameStats.stats.LanguageSelect = data.LanguageSelect;
        GameStats.stats.languageselected = data.languageSelected;

        GameStats.stats.BossRewardCollected = data.BossRewardCollected;

    }
    void SetBinarySavedStats(PlayerData data)
    {
        GameStats.stats.CoinTicket = data.CoinTicketBought;
        GameStats.stats.PortalBoost = data.PortalBoostBought;
        GameStats.stats.fenixFeather = data.fenixfetherBought;
        GameStats.stats.ExtraHearts = data.ExtraHeartsBought;
        GameStats.stats.ManaJar = data.ManaJarBought;

        GameStats.stats.crystals = data.Crystals;
        GameStats.stats.leveBoughtID = data.level;
        GameStats.stats.LevelBought = data.LevelBought;
        GameStats.stats.LevelBoughtCrystals = data.LevelBoughtCrystals;
        GameStats.stats.LevelBoughtCoins = data.LevelBoughtCoins;


        GameStats.stats.coins = data.Coins;

        GameStats.stats.SavedLevelCount = data.SavedLevelCount;
        GameStats.stats.SavedLevelIndicator = data.SavedLevelIndicator;
        GameStats.stats.RunInProgress = data.RunInProgress;
        GameStats.stats.SavedLevelPercentage = data.savedLevelPercentage;
        GameStats.stats.numOfHearts = data.MaxHearts;
        GameStats.stats.SaveCurrentHearts = data.CurrentHearts;
        GameStats.stats.isInStore = data.IsInStore;

        GameStats.stats.savedDarkPowerID = data.SavedDarkPowerID;
        GameStats.stats.savedLightPowerID = data.SavedLightPowerID;

        GameStats.stats.totalDarkMana = data.ManaDark;
        GameStats.stats.totalLightMana = data.Manalight;


        GameStats.stats.LevelReached = data.levelReached;
        GameStats.stats.botSkinID = data.BotSkin;
        GameStats.stats.topSkinID = data.TopSkin;

        GameStats.stats.timedReward = data.TimeReward;
        GameStats.stats.timedRewardLastDate = data.TimedRewardLastDate;

        GameStats.stats.skinConditions[0] = data.skinConditions[0];
        GameStats.stats.skinConditions[1] = data.skinConditions[1];
        GameStats.stats.skinConditions[2] = data.skinConditions[2];
        GameStats.stats.skinConditions[3] = data.skinConditions[3];
        GameStats.stats.skinConditions[4] = data.skinConditions[4];
        GameStats.stats.skinConditions[5] = data.skinConditions[5];


        GameStats.stats.CarrotMissleLevel = data.CarrotMissleLevel;
        GameStats.stats.EarDefenceLevel = data.EarDefenceLevel;
        GameStats.stats.RadishMissleLevel = data.RadishMissleLevel;
        GameStats.stats.KickReflectLevel = data.KickReflectLevel;
        GameStats.stats.MagicLaserLevel = data.MagicLaserLevel;

        GameStats.stats.AudioVolume = data.AudioVolume;
        GameStats.stats.MusicVolume = data.MusicVolume;

        GameStats.stats.AchivementConditions[0] = data.AchivementConditions[0];
        GameStats.stats.AchivementConditions[1] = data.AchivementConditions[1];
        GameStats.stats.AchivementConditions[2] = data.AchivementConditions[2];
        GameStats.stats.AchivementConditions[3] = data.AchivementConditions[3];
        GameStats.stats.AchivementConditions[4] = data.AchivementConditions[4];
        GameStats.stats.AchivementConditions[5] = data.AchivementConditions[5];
        GameStats.stats.AchivementConditions[6] = data.AchivementConditions[6];
        GameStats.stats.AchivementConditions[7] = data.AchivementConditions[7];
        GameStats.stats.AchivementConditions[8] = data.AchivementConditions[8];
        GameStats.stats.AchivementConditions[9] = data.AchivementConditions[9];
        GameStats.stats.AchivementConditions[10] = data.AchivementConditions[10];
        GameStats.stats.AchivementConditions[11] = data.AchivementConditions[11];
        GameStats.stats.AchivementConditions[12] = data.AchivementConditions[12];
        GameStats.stats.AchivementConditions[13] = data.AchivementConditions[13];


        GameStats.stats.MoneySpent = data.GoldSpent;
        GameStats.stats.monstersKilled = data.monstersKilled;
        GameStats.stats.diedTimes = data.diedTimes;

        GameStats.stats.Rune1ID = data.Rune1Id;
        GameStats.stats.Rune2ID = data.Rune2Id;

        GameStats.stats.UnlockedRunes[0] = data.unlockedRunes[0];
        GameStats.stats.UnlockedRunes[1] = data.unlockedRunes[1];
        GameStats.stats.UnlockedRunes[2] = data.unlockedRunes[2];
        GameStats.stats.UnlockedRunes[3] = data.unlockedRunes[3];
        GameStats.stats.UnlockedRunes[4] = data.unlockedRunes[4];
        GameStats.stats.UnlockedRunes[5] = data.unlockedRunes[5];
        GameStats.stats.UnlockedRunes[6] = data.unlockedRunes[6];
        GameStats.stats.UnlockedRunes[7] = data.unlockedRunes[7];
        GameStats.stats.UnlockedRunes[8] = data.unlockedRunes[8];
        GameStats.stats.UnlockedRunes[9] = data.unlockedRunes[9];

        GameStats.stats.NoAdsBought = data.NoAdsBought;
        GameStats.stats.SkinPackBought = data.SkinPackBought;
        GameStats.stats.NoAdsBoughtBackup = data.NoAdsBoughtBackUp;

        GameStats.stats.LanguageSelect = data.LanguageSelect;
        GameStats.stats.languageselected = data.languageSelected;

        GameStats.stats.BossRewardCollected = data.BossRewardCollected;
    }

    #endregion Save and Load Local

}
