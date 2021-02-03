using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossRewards : MonoBehaviour
{

    public GameObject BossRewardsObject;

    public TextMeshProUGUI CoinRewardDisplay;
    public TextMeshProUGUI CrystalRewardDisplay;

    public int BossCoinReward;
    public int BossCrystalReward;

    // Start is called before the first frame update
    void Start()
    {
        // set rewards
        if (GameStats.stats.LevelIndicator == 2)
        {
            BossCoinReward = 100;
            BossCrystalReward = 10;
        }
        if (GameStats.stats.LevelIndicator == 3)
        {
            BossCoinReward = 125;
            BossCrystalReward = 15;
        }
        if (GameStats.stats.LevelIndicator == 4)
        {
            BossCoinReward = 150;
            BossCrystalReward = 20;
        }
        if (GameStats.stats.LevelIndicator == 5)
        {
            BossCoinReward = 200;
            BossCrystalReward = 25;
        }
        if (GameStats.stats.LevelIndicator == 6)
        {
            BossCoinReward = 250;
            BossCrystalReward = 30;
        }

        // display on
        if (GameStats.stats.LevelCount == 3)
        {
            BossRewardsObject.SetActive(true);
        }
        else
        {
            BossRewardsObject.SetActive(false);
        }


    }

    public void Collect()
    {
        GameStats.stats.coins += BossCoinReward;
        GameStats.stats.crystals += BossCrystalReward;
    }
}
