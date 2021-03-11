using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkinMenuStore : MonoBehaviour
{
    public Image SkinTopPreview;
    public Image SkinBotPreview;
    public Image selectdisplayimage;


    public Sprite[] SkinIcons;
    public Image[] LockedSkins;

    public int SelectedSkinID;


    public GameObject buttonTop;
    public GameObject buttonBot;

    public TextMeshProUGUI unlockedText;
    public TextMeshProUGUI UnlockDescription;

    public TextMeshProUGUI CrystalCounter;

    public GameObject buybutton;

    public GameStats GS;

    




    
    // Start is called before the first frame update
    void Start()
    {
        GS = FindObjectOfType<GameStats>();
        
        selectdisplayimage.sprite = SkinIcons[SelectedSkinID];

        SkinTopPreview.sprite = SkinIcons[GameStats.stats.topSkinID];
        SkinBotPreview.sprite = SkinIcons[GameStats.stats.botSkinID];

        CrystalCounter.text = GameStats.stats.crystals.ToString();

        #region UnlockDisplayStart
        //
        if (GameStats.stats.skinConditions[1] == true)
        {
            LockedSkins[6].enabled = false;
            LockedSkins[7].enabled = false;
            LockedSkins[8].enabled = false;
            LockedSkins[10].enabled = false;
            LockedSkins[11].enabled = false;
            LockedSkins[12].enabled = false;
            LockedSkins[13].enabled = false;
            LockedSkins[15].enabled = false;

        }

        if (GameStats.stats.skinConditions[0] == true)
        {
            LockedSkins[0].enabled = false;
        }

        if (GameStats.stats.skinConditions[2] == true)
        {
            LockedSkins[9].enabled = false;
        }
        if (GameStats.stats.skinConditions[3] == true)
        {
            LockedSkins[14].enabled = false;
        }
        if (GameStats.stats.skinConditions[4] == true)
        {
            LockedSkins[17].enabled = false;
        }
        if (GameStats.stats.skinConditions[5] == true)
        {
            LockedSkins[18].enabled = false;
        }
        if (GameStats.stats.LevelReached >= 2)
        {
            LockedSkins[1].enabled = false;
        }
        if (GameStats.stats.LevelReached >= 3)
        {
            LockedSkins[2].enabled = false;
        }
        if (GameStats.stats.LevelReached >= 4)
        {
            LockedSkins[3].enabled = false;
        }
        if (GameStats.stats.LevelReached >= 5)
        {
            LockedSkins[4].enabled = false;
        }
        if (GameStats.stats.LevelReached >= 6)
        {
            LockedSkins[5].enabled = false;
        }

        #endregion 
    }

    // Update is called once per frame
    void Update()
    {
        selectdisplayimage.sprite = SkinIcons[SelectedSkinID];

        SkinTopPreview.sprite = SkinIcons[GameStats.stats.topSkinID];
        SkinBotPreview.sprite = SkinIcons[GameStats.stats.botSkinID];

        CrystalCounter.text = GameStats.stats.crystals.ToString();

        #region UnlockDisplayUpdate
        //
        if (GameStats.stats.skinConditions[1] == true)
        {
            LockedSkins[6].enabled = false;
            LockedSkins[7].enabled = false;
            LockedSkins[8].enabled = false;
            LockedSkins[10].enabled = false;
            LockedSkins[11].enabled = false;
            LockedSkins[12].enabled = false;
            LockedSkins[13].enabled = false;
            LockedSkins[15].enabled = false;

        }

        if (GameStats.stats.skinConditions[0] == true)
        {
            LockedSkins[0].enabled = false;
        }

        if (GameStats.stats.skinConditions[2] == true)
        {
            LockedSkins[9].enabled = false;
        }
        if (GameStats.stats.skinConditions[3] == true)
        {
            LockedSkins[14].enabled = false;
        }
        if (GameStats.stats.skinConditions[4] == true)
        {
            LockedSkins[17].enabled = false;
        }
        if (GameStats.stats.skinConditions[4] == true)
        {
            LockedSkins[18].enabled = false;
        }
        if (GameStats.stats.LevelReached >= 2)
        {
            LockedSkins[1].enabled = false;
        }
        if (GameStats.stats.LevelReached >= 3)
        {
            LockedSkins[2].enabled = false;
        }
        if (GameStats.stats.LevelReached >= 4)
        {
            LockedSkins[3].enabled = false;
        }
        if (GameStats.stats.LevelReached >= 5)
        {
            LockedSkins[4].enabled = false;
        }
        if (GameStats.stats.LevelReached >= 6)
        {
            LockedSkins[5].enabled = false;
        }

        #endregion

    }

    public void SelectSkin (int SkinID)
	{
        SelectedSkinID = SkinID;


        if (SelectedSkinID == 0 )
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);

            unlockedText.text = "Unlocked";
            UnlockDescription.text = "select skin position";
            buybutton.SetActive(false);

        }
        else if (SelectedSkinID == 2 && GameStats.stats.LevelReached >= 2)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);

            unlockedText.text = "Unlocked";
            UnlockDescription.text = "select skin position";
            buybutton.SetActive(false);

        }

        else if (SelectedSkinID == 3 && GameStats.stats.LevelReached >= 3)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);

            unlockedText.text = "Unlocked";
            UnlockDescription.text = "select skin position";
            buybutton.SetActive(false);
        }
        else if (SelectedSkinID == 4 && GameStats.stats.LevelReached >= 4)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);

            unlockedText.text = "Unlocked";
            UnlockDescription.text = "select skin position";
            buybutton.SetActive(false);
        }
        else if (SelectedSkinID == 5 && GameStats.stats.LevelReached >= 5)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);

            unlockedText.text = "Unlocked";
            UnlockDescription.text = "select skin position";
            buybutton.SetActive(false);
        }

        else if (SelectedSkinID == 6 && GameStats.stats.LevelReached >= 6)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);

            unlockedText.text = "Unlocked";
            UnlockDescription.text = "select skin position";
            buybutton.SetActive(false);
        }

        else if (SelectedSkinID == 1 && GameStats.stats.skinConditions[0] == true)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);
            unlockedText.text = "Unlocked";
            UnlockDescription.text = "select skin position";
            buybutton.SetActive(false);
        }

        else if (SelectedSkinID == 7 && GameStats.stats.skinConditions[1] == true)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);
            unlockedText.text = "Unlocked";
            UnlockDescription.text = "select skin position";
            buybutton.SetActive(false);
        }
        else if (SelectedSkinID == 8 && GameStats.stats.skinConditions[1] == true)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);
            unlockedText.text = "Unlocked";
            UnlockDescription.text = "select skin position";
            buybutton.SetActive(false);
        }
        else if (SelectedSkinID == 9 && GameStats.stats.skinConditions[1] == true)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);
            unlockedText.text = "Unlocked";
            UnlockDescription.text = "select skin position";
            buybutton.SetActive(false);
        }

        else if (SelectedSkinID == 10 && GameStats.stats.skinConditions[2] == true)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);
            unlockedText.text = "Unlocked";
            UnlockDescription.text = "select skin position";
            buybutton.SetActive(false);
        }

        else if (SelectedSkinID == 11 && GameStats.stats.skinConditions[1] == true)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);
            unlockedText.text = "Unlocked";
            UnlockDescription.text = "select skin position";
            buybutton.SetActive(false);
        }
        else if (SelectedSkinID == 12 && GameStats.stats.skinConditions[1] == true)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);
            unlockedText.text = "Unlocked";
            UnlockDescription.text = "select skin position";
            buybutton.SetActive(false);
        }
        else if (SelectedSkinID == 13 && GameStats.stats.skinConditions[1] == true)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);
            unlockedText.text = "Unlocked";
            UnlockDescription.text = "select skin position";
            buybutton.SetActive(false);
        }
        else if (SelectedSkinID == 14 && GameStats.stats.skinConditions[1] == true)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);
            unlockedText.text = "Unlocked";
            UnlockDescription.text = "select skin position";
            buybutton.SetActive(false);
        }
        else if (SelectedSkinID == 15 && GameStats.stats.skinConditions[3] == true)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);
            unlockedText.text = "Unlocked";
            UnlockDescription.text = "select skin position";
            buybutton.SetActive(false);
        }
        else if (SelectedSkinID == 16 && GameStats.stats.skinConditions[1] == true)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);
            unlockedText.text = "Unlocked";
            UnlockDescription.text = "select skin position";
            buybutton.SetActive(false);
        }
        else if (SelectedSkinID == 17 && GameStats.stats.LevelReached == 7)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);
            unlockedText.text = "Unlocked";
            UnlockDescription.text = "select skin position";
            buybutton.SetActive(false);
        }

        else if (SelectedSkinID == 18 && GameStats.stats.skinConditions[4] == true)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);
            unlockedText.text = "Unlocked";
            UnlockDescription.text = "select skin position";
            buybutton.SetActive(false);
        }
        else if (SelectedSkinID == 19 && GameStats.stats.skinConditions[5] == true)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);
            unlockedText.text = "Unlocked";
            UnlockDescription.text = "select skin position";
            buybutton.SetActive(false);
        }

        else
        {
            buttonBot.SetActive(false);
            buttonTop.SetActive(false);
            unlockedText.text = "Locked";


            if (SelectedSkinID == 1)
            {
                UnlockDescription.text = " buy skin for 50 gems";
                buybutton.SetActive(true);
            }
            else if (SelectedSkinID == 2)
            {
                UnlockDescription.text = " Defeat the Wyrm at the library to unlock";
                buybutton.SetActive(false);
            }
            else if (SelectedSkinID == 3)
            {
                UnlockDescription.text = " Defeat the Mage Goblin at the Dungeon to unlock";
                buybutton.SetActive(false);
            }
            else if (SelectedSkinID == 4)
            {
                UnlockDescription.text = " Defeat the Yeti at the Ice Room to unlock";
                buybutton.SetActive(false);
            }
            else if (SelectedSkinID == 5)
            {
                UnlockDescription.text = " Defeat the Carnivorous Plant at the Jungle to unlock";
                buybutton.SetActive(false);
            }
            else if (SelectedSkinID == 6)
            {
                UnlockDescription.text = " Defeat the Clockwork Griffin at the Portal Room to unlock";
                buybutton.SetActive(false);
            }
            else if (SelectedSkinID >= 7 && SelectedSkinID <= 9)
            {
                UnlockDescription.text = " buy the skin pack to unlock";
                buybutton.SetActive(true);
            }
            else if (SelectedSkinID == 10)
            {
                UnlockDescription.text = "buy skin for 50 gems";
                buybutton.SetActive(true);
            }

            else if (SelectedSkinID >= 11 && SelectedSkinID <= 14)
            {
                UnlockDescription.text = " buy the skin pack to unlock";
                buybutton.SetActive(true);
            }
            else if (SelectedSkinID == 15)
            {
                UnlockDescription.text = "buy skin for 50 gems";
                buybutton.SetActive(true);
            }
            else if (SelectedSkinID == 16)
            {
                UnlockDescription.text = "buy the skin pack to unlock";
                buybutton.SetActive(true);
            }
            else if (SelectedSkinID == 17)
            {
                UnlockDescription.text = "Defeat The Mage to unlock";
                buybutton.SetActive(false);
            }
            else if (SelectedSkinID == 17)
            {
                UnlockDescription.text = "Defeat The Mage to unlock";
                buybutton.SetActive(false);
            }
            else if (SelectedSkinID == 18)
            {
                UnlockDescription.text = "buy skin for 50 gems";
                buybutton.SetActive(true);
            }
            else if (SelectedSkinID == 19)
            {
                UnlockDescription.text = "buy skin for 50 gems";
                buybutton.SetActive(true);
            }


            else
            {
                UnlockDescription.text = "";
            }
            

        }

    }


    public void confirmSkinTop ()
    {
        GameStats.stats.topSkinID = SelectedSkinID;

    }

    public void confirmSkinBot()
    {
        GameStats.stats.botSkinID = SelectedSkinID;

    }

    public void BuySkin()
    {
        if (SelectedSkinID == 1 || SelectedSkinID == 10 || SelectedSkinID == 15 || SelectedSkinID == 18 || SelectedSkinID == 19)
        {
            if (GameStats.stats.crystals >= 50)
            {
                GameStats.stats.crystals -= 50;
                if (SelectedSkinID == 1)
                {
                    GameStats.stats.skinConditions[0] = true;
                } else if (SelectedSkinID == 10)
                {
                    GameStats.stats.skinConditions[2] = true;

                }
                else if (SelectedSkinID == 15)
                {
                    GameStats.stats.skinConditions[3] = true;

                }
                else if (SelectedSkinID == 18)
                {
                    GameStats.stats.skinConditions[4] = true;

                }
                else if (SelectedSkinID == 19)
                {
                    GameStats.stats.skinConditions[5] = true;

                }

                buybutton.SetActive(false);
                buttonBot.SetActive(true);
                buttonTop.SetActive(true);
                unlockedText.text = "Unlocked";
                UnlockDescription.text = "select skin position";
            }
        }

        if (SelectedSkinID == 7)
        {
            // go to buy pack. Cuado pongamos lo de IN-APP purchases.
        }
        if (SelectedSkinID == 8)
        {
            // go to buy pack. Cuado pongamos lo de IN-APP purchases.
        }
    }


}
