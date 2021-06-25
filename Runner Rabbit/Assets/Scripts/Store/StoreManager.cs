using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    [SerializeField] Button ContinueButton;

    private void Start()
    {
        if(GameStats.stats.LevelCount == 3)
        {
            UnlockSkins();
            Debug.Log("unlocking Skins" + (GameStats.stats.LevelIndicator - 1));
        }
    }

    void UnlockSkins()
    {
        if(GameStats.stats.LevelIndicator == 1)
        {
            GameStats.stats.AchivementConditions[0] = true;
            GameStats.stats.SaveStats();
        }
        if (GameStats.stats.LevelIndicator == 2)
        {
            GameStats.stats.AchivementConditions[1] = true;
            GameStats.stats.SaveStats();
        }
        if (GameStats.stats.LevelIndicator == 3)
        {
            GameStats.stats.AchivementConditions[2] = true;
            GameStats.stats.SaveStats();
        }
        if (GameStats.stats.LevelIndicator == 4)
        {
            GameStats.stats.AchivementConditions[3] = true;
            GameStats.stats.SaveStats();
        }
        if (GameStats.stats.LevelIndicator == 5)
        {
            GameStats.stats.AchivementConditions[4] = true;
            GameStats.stats.SaveStats();
        }
        if (GameStats.stats.LevelIndicator == 6)
        {
            GameStats.stats.AchivementConditions[5] = true;
            GameStats.stats.SaveStats();
        }
    }
}
