using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchivmentsMenu : MonoBehaviour
{
    public GameObject[] AchivmentsLocked;


    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < GameStats.stats.AchivementConditions.Length; i++)
        {
            if (GameStats.stats.AchivementConditions[i] == true)
            {
                AchivmentsLocked[i].SetActive(false);
            }

        }

    }

    public void DelayedStart()
    {
        for (int i = 0; i < GameStats.stats.AchivementConditions.Length; i++)
        {
            if (GameStats.stats.AchivementConditions[i] == true)
            {
                AchivmentsLocked[i].SetActive(false);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {

        // check Conditions

        if (GameStats.stats.PortalBoost == true && GameStats.stats.fenixFeather == true && GameStats.stats.CoinTicket == true && GameStats.stats.ExtraHearts == true && GameStats.stats.ManaJar == true)
        {
            GameStats.stats.AchivementConditions[8] = true;
            GameStats.stats.SaveStats();
        }

        if (GameStats.stats.crystals >= 500)
        {
            GameStats.stats.AchivementConditions[7] = true;
            GameStats.stats.SaveStats();
        }

        if (GameStats.stats.LevelReached >= 2)
        {
            GameStats.stats.AchivementConditions[0] = true;
            GameStats.stats.SaveStats();

        }
        if (GameStats.stats.LevelReached >= 3)
        {
            GameStats.stats.AchivementConditions[1] = true;
            GameStats.stats.SaveStats();

        }
        if (GameStats.stats.LevelReached >= 4)
        {
            GameStats.stats.AchivementConditions[2] = true;
            GameStats.stats.SaveStats();

        }
        if (GameStats.stats.LevelReached >= 5)
        {
            GameStats.stats.AchivementConditions[3] = true;
            GameStats.stats.SaveStats();

        }
        if (GameStats.stats.LevelReached >= 6)
        {
            GameStats.stats.AchivementConditions[4] = true;
            GameStats.stats.SaveStats();

        }
        if (GameStats.stats.LevelReached == 7)
        {
            GameStats.stats.AchivementConditions[5] = true;
            GameStats.stats.SaveStats();

        }

        if (GameStats.stats.MoneySpent >= 1000)
        {
            GameStats.stats.AchivementConditions[12] = true;
            GameStats.stats.SaveStats();

        }

        if (GameStats.stats.MoneySpent >= 1000)
        {
            GameStats.stats.AchivementConditions[12] = true;
            GameStats.stats.SaveStats();

        }

        if(GameStats.stats.monstersKilled >= 400)
        {
            GameStats.stats.AchivementConditions[11] = true;
        }

        // update achivements

        for (int i = 0; i < GameStats.stats.AchivementConditions.Length; i++)
        {
            if (GameStats.stats.AchivementConditions[i] == true)
            {
                AchivmentsLocked[i].SetActive(false);
            }

        }

        /*
        if (GameStats.stats.AchivementConditions[0]== true)
        {
            AchivmentsLocked[0].SetActive(false);
        }
        if (GameStats.stats.AchivementConditions[1] == true)
        {
            AchivmentsLocked[1].SetActive(false);
        }
        if (GameStats.stats.AchivementConditions[2] == true)
        {
            AchivmentsLocked[2].SetActive(false);
        }
        if (GameStats.stats.AchivementConditions[3] == true)
        {
            AchivmentsLocked[3].SetActive(false);
        }
        if (GameStats.stats.AchivementConditions[4] == true)
        {
            AchivmentsLocked[4].SetActive(false);
        }
        if (GameStats.stats.AchivementConditions[5] == true)
        {
            AchivmentsLocked[5].SetActive(false);
        }
        if (GameStats.stats.AchivementConditions[6] == true)
        {
            AchivmentsLocked[6].SetActive(false);
        }
        if (GameStats.stats.AchivementConditions[7] == true)
        {
            AchivmentsLocked[7].SetActive(false);
        }
        if (GameStats.stats.AchivementConditions[8] == true)
        {
            AchivmentsLocked[8].SetActive(false);
        }
        if (GameStats.stats.AchivementConditions[9] == true)
        {
            AchivmentsLocked[9].SetActive(false);
        }
        if (GameStats.stats.AchivementConditions[10] == true)
        {
            AchivmentsLocked[10].SetActive(false);
        }
        if (GameStats.stats.AchivementConditions[11] == true)
        {
            AchivmentsLocked[11].SetActive(false);
        }
        if (GameStats.stats.AchivementConditions[12] == true)
        {
            AchivmentsLocked[12].SetActive(false);
        }
        if (GameStats.stats.AchivementConditions[13] == true)
        {
            AchivmentsLocked[13].SetActive(false);
        }
        if (GameStats.stats.AchivementConditions[14] == true)
        {
            AchivmentsLocked[14].SetActive(false);
        }
        */
    }
}
