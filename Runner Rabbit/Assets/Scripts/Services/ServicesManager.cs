using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudOnce;

public class ServicesManager : MonoBehaviour
{
    public static ServicesManager instance;
    

    private void Awake()
    {
        TestSingelton();
    }
    private void TestSingelton()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SubmitScoreToLeaderBoard(int score)
    {
        Leaderboards.LevelReachedLeaderboard.SubmitScore(score);
    }
    public void SumbitMonstersDefeatedScore(int score)
    {
        Leaderboards.MonstersDefeatedLeaderBoard.SubmitScore(score);
    }

    public void SaveCloudData()
    {
        // currencies and IAPs
        CloudVariables.Crystals = Mathf.FloorToInt(GameStats.stats.crystals);
        CloudVariables.SkinPack = GameStats.stats.skinConditions[1];
        CloudVariables.Noadsbought = GameStats.stats.NoAdsBought;

        //level
        CloudVariables.LevelReached = GameStats.stats.LevelReached;
        CloudVariables.levelBoughtID = GameStats.stats.leveBoughtID;

        // Powers
        CloudVariables.carrotMissleLevel = GameStats.stats.CarrotMissleLevel;
        CloudVariables.earShieldLevel = GameStats.stats.EarDefenceLevel;
        CloudVariables.radishMissleLevel = GameStats.stats.RadishMissleLevel;
        CloudVariables.kickReflectLevel = GameStats.stats.KickReflectLevel;
        CloudVariables.magicLaserLevel = GameStats.stats.MagicLaserLevel;

        //Runes
        CloudVariables.RuneFloatBought = GameStats.stats.UnlockedRunes[0];
        CloudVariables.RuneFallBought = GameStats.stats.UnlockedRunes[1];
        CloudVariables.RuneMagnetBought = GameStats.stats.UnlockedRunes[2];
        CloudVariables.RuneManaBought = GameStats.stats.UnlockedRunes[3];
        CloudVariables.RuneSpellBought = GameStats.stats.UnlockedRunes[4];
        CloudVariables.RuneShieldBought = GameStats.stats.UnlockedRunes[5];
        CloudVariables.RuneGreedBought = GameStats.stats.UnlockedRunes[6];
        CloudVariables.RuneMerchatBought = GameStats.stats.UnlockedRunes[7];
        CloudVariables.RuneDestructionBought = GameStats.stats.UnlockedRunes[8];
        CloudVariables.RuneUnknownBought = GameStats.stats.UnlockedRunes[9];

        //Achievment progression

        CloudVariables.MonstersKilled = Mathf.FloorToInt(GameStats.stats.monstersKilled);
        CloudVariables.MoneySpent = Mathf.FloorToInt(GameStats.stats.MoneySpent);
        CloudVariables.DiedTimes = Mathf.FloorToInt(GameStats.stats.diedTimes);

        //PowerUps

        CloudVariables.ManaJarPowerUp = GameStats.stats.ManaJar;
        CloudVariables.ExtraHeartsPowerUp = GameStats.stats.ExtraHearts;
        CloudVariables.PhoenixFeatherPowerUp = GameStats.stats.fenixFeather;
        CloudVariables.Coinx2TicketPowerUp = GameStats.stats.CoinTicket;
        CloudVariables.PortalBoostPowerUp = GameStats.stats.PortalBoost;


        

    }

    public void StoreCloudData()
    {
        Cloud.Storage.Save();
    }

    public void LoadCloudSaveData()
    {
        // currencies and IAPs
        GameStats.stats.crystals = CloudVariables.Crystals;
        GameStats.stats.skinConditions[1] = CloudVariables.SkinPack;
        GameStats.stats.NoAdsBought = CloudVariables.Noadsbought;

        //level
       GameStats.stats.LevelReached = CloudVariables.LevelReached;
       GameStats.stats.leveBoughtID = CloudVariables.levelBoughtID;

        // Powers
        GameStats.stats.CarrotMissleLevel = CloudVariables.carrotMissleLevel;
        GameStats.stats.EarDefenceLevel = CloudVariables.earShieldLevel;
        GameStats.stats.RadishMissleLevel = CloudVariables.radishMissleLevel;
        GameStats.stats.KickReflectLevel = CloudVariables.kickReflectLevel;
        GameStats.stats.MagicLaserLevel = CloudVariables.magicLaserLevel;

        //Runes
        GameStats.stats.UnlockedRunes[0] = CloudVariables.RuneFloatBought;
        GameStats.stats.UnlockedRunes[1] = CloudVariables.RuneFallBought;
        GameStats.stats.UnlockedRunes[2] = CloudVariables.RuneMagnetBought;
        GameStats.stats.UnlockedRunes[3] = CloudVariables.RuneManaBought;
        GameStats.stats.UnlockedRunes[4] = CloudVariables.RuneSpellBought;
        GameStats.stats.UnlockedRunes[5] = CloudVariables.RuneShieldBought;
        GameStats.stats.UnlockedRunes[6] = CloudVariables.RuneGreedBought;
        GameStats.stats.UnlockedRunes[7] = CloudVariables.RuneMerchatBought;
        GameStats.stats.UnlockedRunes[8] = CloudVariables.RuneDestructionBought;
        GameStats.stats.UnlockedRunes[9] = CloudVariables.RuneUnknownBought;

        //Achievment progression

        GameStats.stats.monstersKilled = CloudVariables.MonstersKilled;
        GameStats.stats.MoneySpent = CloudVariables.MoneySpent;
        GameStats.stats.diedTimes = CloudVariables.DiedTimes;

        //PowerUps

        GameStats.stats.ManaJar= CloudVariables.ManaJarPowerUp;
        GameStats.stats.ExtraHearts = CloudVariables.ExtraHeartsPowerUp;
        GameStats.stats.fenixFeather = CloudVariables.PhoenixFeatherPowerUp;
        GameStats.stats.CoinTicket = CloudVariables.Coinx2TicketPowerUp;
        GameStats.stats.PortalBoost = CloudVariables.PortalBoostPowerUp;

       

    }

    public void CloudAchievements(int achievement)
    {
        if(achievement == 0)
        {
            Achievements.LibraryFlame.Unlock();
        }
        if (achievement == 1)
        {
            Achievements.DungeonBone.Unlock();
        }
        if (achievement == 2)
        {
            Achievements.FrostCrystal.Unlock();
        }
        if (achievement == 3)
        {
            Achievements.SharpLeaf.Unlock();
        }
        if (achievement == 4)
        {
            Achievements.SpinningCog.Unlock();
        }
        if (achievement == 5)
        {
            Achievements.EndGame.Unlock();
        }
        if (achievement == 6)
        {
            Achievements.Rich.Unlock();
        }
        if (achievement == 7)
        {
            Achievements.CrystalHoarder.Unlock();
        }
        if (achievement == 8)
        {
            Achievements.PoweredUp.Unlock();
        }
        if (achievement == 9)
        {
            Achievements.SpellMaster.Unlock();
        }
        if (achievement == 10)
        {
            Achievements.UltimateMage.Unlock();
        }
        if (achievement == 11)
        {
            Achievements.MonsterHunter.Unlock();
        }
        if (achievement == 12)
        {
            Achievements.NecessaryExpenses.Unlock();
        }
        if (achievement == 13)
        {
            Achievements.ThatsNotHowItHappened.Unlock();
        }
        if (achievement == 14)
        {
            Achievements.FlawlessBoss.Unlock();
        }
    }
}
