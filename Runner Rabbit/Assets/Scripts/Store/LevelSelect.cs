using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public GameObject LibraryLock;
    public GameObject DungeonLock;
    public GameObject FrozenRoomLock;
    public GameObject JungleLock;
    public GameObject PortalRoomLock;

    public Animator notEnoughCrystals;


    // Start is called before the first frame update
    void Start()
    {
        if (GameStats.stats.LevelReached >= 1)
        {
            LibraryLock.SetActive(false);
        }
        else
        {
            LibraryLock.SetActive(true);
        }

        if (GameStats.stats.LevelReached >= 2)
        {
            DungeonLock.SetActive(false);
        }
        else
        {
            DungeonLock.SetActive(true);
        }
        if (GameStats.stats.LevelReached >= 3)
        {
            FrozenRoomLock.SetActive(false);
        } else
        {
            FrozenRoomLock.SetActive(true);
        }
        if (GameStats.stats.LevelReached >= 4)
        {
            JungleLock.SetActive(false);
        }
        else
        {
            JungleLock.SetActive(true);
        }
        if (GameStats.stats.LevelReached >= 5)
        {
            PortalRoomLock.SetActive(false);
        }else
        {
            PortalRoomLock.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BuyLevel (int levelID)
    {
        if (levelID == 2)
        {
            if (GameStats.stats.crystals >= 20)
            {
                GameStats.stats.LevelIndicator = levelID;

                GameStats.stats.LevelBought = true;
                GameStats.stats.leveBoughtID = levelID;

                GameStats.stats.coins += 100;
                GameStats.stats.crystals -= 20;

            }
            else
            {

                notEnoughCrystals.SetTrigger("NotEnoughCrystals");
            }

        }

        if (levelID == 3)
        {
            if (GameStats.stats.crystals >= 40)
            {
                GameStats.stats.LevelIndicator = levelID;

                GameStats.stats.LevelBought = true;
                GameStats.stats.leveBoughtID = levelID;

                GameStats.stats.coins += 200;
                GameStats.stats.crystals -= 40;
            }
            else
            {

                notEnoughCrystals.SetTrigger("NotEnoughCrystals");
            }


        }
        if (levelID == 4)
        {
            if (GameStats.stats.crystals >= 80)
            {
                GameStats.stats.LevelIndicator = levelID;

                GameStats.stats.LevelBought = true;
                GameStats.stats.leveBoughtID = levelID;

                GameStats.stats.coins += 350;
                GameStats.stats.crystals -= 80;
            }
            else
            {

                notEnoughCrystals.SetTrigger("NotEnoughCrystals");
            }


        }

        if (levelID == 5)
        {
            if (GameStats.stats.crystals >= 100)
            {
                GameStats.stats.LevelIndicator = levelID;

                GameStats.stats.LevelBought = true;
                GameStats.stats.leveBoughtID = levelID;

                GameStats.stats.coins += 500;
                GameStats.stats.crystals -= 100;
            }
            else
            {
                
                notEnoughCrystals.SetTrigger("NotEnoughCrystals");
            }
                

        }
    }
}
