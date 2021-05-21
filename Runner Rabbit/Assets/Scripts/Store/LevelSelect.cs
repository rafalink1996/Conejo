using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelect : MonoBehaviour
{
    public GameObject LibraryLock;
    public GameObject DungeonLock;
    public GameObject FrozenRoomLock;
    public GameObject JungleLock;
    public GameObject PortalRoomLock;


    [SerializeField] GameObject[] activatedLevels; 


    public Button LibraryButton, DungeonButton, FrozenRoomButton, JungleButton, PortalRoomButton;

    [SerializeField] PowerMEnu myPowerMenu = null;
    
    public GameObject RewriteLevelObject;
    private int RewriteLevelID;

    private int CrystalsSpent;
    private int CoinsGiven;

    public TextMeshProUGUI RefundCrystals;

    [SerializeField] GameObject[] LevelInfoPopUps = null;


    


    // Start is called before the first frame update
    void Start()
    {

        CrystalsSpent = GameStats.stats.LevelBoughtCrystals;
        CoinsGiven = GameStats.stats.LevelBoughtCoins;

        myPowerMenu = gameObject.GetComponent<PowerMEnu>();
        if (GameStats.stats.LevelReached >= 1)
        {
            LibraryLock.SetActive(false);
            LibraryButton.interactable = true;
        }
        else
        {
            LibraryLock.SetActive(true);
            LibraryButton.interactable = false;
        }

        if (GameStats.stats.LevelReached >= 2)
        {
            DungeonLock.SetActive(false);
            DungeonButton.interactable = true;
        }
        else
        {
            DungeonLock.SetActive(true);
            DungeonButton.interactable = false;
        }
        if (GameStats.stats.LevelReached >= 3)
        {
            FrozenRoomLock.SetActive(false);
            FrozenRoomButton.interactable = true;
        } else
        {
            FrozenRoomLock.SetActive(true);
            FrozenRoomButton.interactable = false;
        }
        if (GameStats.stats.LevelReached >= 4)
        {
            JungleLock.SetActive(false);
            JungleButton.interactable = true;
        }
        else
        {
            JungleLock.SetActive(true);
            JungleButton.interactable = false;
        }
        if (GameStats.stats.LevelReached >= 5)
        {
            PortalRoomLock.SetActive(false);
            PortalRoomButton.interactable = true;
        }
        else
        {
            PortalRoomLock.SetActive(true);
            PortalRoomButton.interactable = false;
        }
        RefundCrystals.text = CrystalsSpent.ToString();

        for (int i = 0; i < activatedLevels.Length; i++)
        {
            activatedLevels[i].SetActive(false);
        }
        activatedLevels[GameStats.stats.leveBoughtID - 1].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        RefundCrystals.text = CrystalsSpent.ToString();

       
    }


    public void BuyLevel (int levelID)
    {
        if (levelID == GameStats.stats.leveBoughtID)
        {
            return;
        }

        if (GameStats.stats.LevelBought == false)
        {
            if (levelID == 1)
            {
                GameStats.stats.LevelBought = false;
                GameStats.stats.leveBoughtID = levelID;
                GameStats.stats.LevelIndicator = levelID;
                
                CrystalsSpent = 0;
                CoinsGiven = 0;

            }
            if (levelID == 2)
            {
                if (GameStats.stats.crystals >= 20)
                {
                    GameStats.stats.LevelIndicator = levelID;

                    GameStats.stats.LevelBought = true;
                    GameStats.stats.leveBoughtID = levelID;

                    GameStats.stats.LevelBoughtCoins = 200;
                    GameStats.stats.crystals -= 20;


                    CrystalsSpent = 20;
                    CoinsGiven = 200;

                   


                }
                else
                {

                    myPowerMenu.NotEnoughCrystals();
                }

            }

            if (levelID == 3)
            {
                if (GameStats.stats.crystals >= 40)
                {
                    GameStats.stats.LevelIndicator = levelID;

                    GameStats.stats.LevelBought = true;
                    GameStats.stats.leveBoughtID = levelID;

                    GameStats.stats.LevelBoughtCoins = 400;
                    GameStats.stats.crystals -= 40;

                    CrystalsSpent = 40;
                    CoinsGiven = 400;

                   
                }
                else
                {

                    myPowerMenu.NotEnoughCrystals();
                }


            }
            if (levelID == 4)
            {
                if (GameStats.stats.crystals >= 80)
                {
                    GameStats.stats.LevelIndicator = levelID;

                    GameStats.stats.LevelBought = true;
                    GameStats.stats.leveBoughtID = levelID;

                    GameStats.stats.LevelBoughtCoins = 800;
                    GameStats.stats.crystals -= 80;

                    CrystalsSpent = 80;
                    CoinsGiven = 800;

                   
                }
                else
                {

                    myPowerMenu.NotEnoughCrystals();
                }


            }

            if (levelID == 5)
            {
                if (GameStats.stats.crystals >= 100)
                {
                    GameStats.stats.LevelIndicator = levelID;

                    GameStats.stats.LevelBought = true;
                    GameStats.stats.leveBoughtID = levelID;

                    GameStats.stats.LevelBoughtCoins = 1000;
                    GameStats.stats.crystals -= 100;


                    CrystalsSpent = 100;
                    CoinsGiven = 1000;

                   
                }
                else
                {

                    myPowerMenu.NotEnoughCrystals();
                }


            }

            GameStats.stats.LevelBoughtCrystals = CrystalsSpent;
            GameStats.stats.LevelBoughtCoins = CoinsGiven;


            for (int i = 0; i < activatedLevels.Length; i++)
            {
                activatedLevels[i].SetActive(false);
            }
            activatedLevels[levelID - 1].SetActive(true);

            GameStats.stats.SaveStats();
            
        } else
        {
            RewriteLevelID = levelID;
            RewriteLevelObject.SetActive(true);

        }

       
        
    }

    public void ShowLevelInfo(int LevelID)
    {
        if(LevelID == GameStats.stats.leveBoughtID)
        {
            return;
        }
        LevelInfoPopUps[LevelID - 2].SetActive(true);
    }

    public void rewriteLevelFunction()
    {
        GameStats.stats.crystals += CrystalsSpent;
        GameStats.stats.LevelBoughtCoins = 0;
        GameStats.stats.LevelBought = false;
        BuyLevel(RewriteLevelID);
       

    }
}
