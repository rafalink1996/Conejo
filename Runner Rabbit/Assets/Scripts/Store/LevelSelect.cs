using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public Image LibraryLock;
    public Image DungeonLock;
    public Image FrozenRoomLock;
    public Image JungleLock;
    public Image PortalRoomLock;

    public Animator notEnoughCrystals;


    // Start is called before the first frame update
    void Start()
    {
        if (GameStats.stats.LevelReached >= 1)
        {
            LibraryLock.enabled = false;
        }
        else
        {
            LibraryLock.enabled = true;
        }

        if (GameStats.stats.LevelReached >= 2)
        {
            DungeonLock.enabled = false;
        }
        else
        {
            DungeonLock.enabled = true;
        }
        if (GameStats.stats.LevelReached >= 3)
        {
            FrozenRoomLock.enabled = false;
        } else
        {
            FrozenRoomLock.enabled = true;
        }
        if (GameStats.stats.LevelReached >= 4)
        {
            JungleLock.enabled = false;
        }
        else
        {
            JungleLock.enabled = true;
        }
        if (GameStats.stats.LevelReached >= 5)
        {
            PortalRoomLock.enabled = false;
        }else
        {
            PortalRoomLock.enabled = true;
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
                GameStats.stats.LevelIndicator = 3;

                GameStats.stats.LevelBought = true;
                GameStats.stats.leveBoughtID = 3;

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
                GameStats.stats.LevelIndicator = 4;

                GameStats.stats.LevelBought = true;
                GameStats.stats.leveBoughtID = 4;

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
                GameStats.stats.LevelIndicator = 5;

                GameStats.stats.LevelBought = true;
                GameStats.stats.leveBoughtID = 5;

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
                GameStats.stats.LevelIndicator = 6;

                GameStats.stats.LevelBought = true;
                GameStats.stats.leveBoughtID = 6;

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
