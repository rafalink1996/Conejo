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

    public int SelectedSkinID;


    public GameObject buttonTop;
    public GameObject buttonBot;

    public TextMeshProUGUI unlockedText;
    public TextMeshProUGUI UnlockDescription;

    public TextMeshProUGUI CrystalCounter;

    public GameObject buybutton;



    
    // Start is called before the first frame update
    void Start()
    {
        selectdisplayimage.sprite = SkinIcons[SelectedSkinID];

        SkinTopPreview.sprite = SkinIcons[GameStats.stats.topSkinID];
        SkinBotPreview.sprite = SkinIcons[GameStats.stats.botSkinID];

        CrystalCounter.text = GameStats.stats.crystals.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        selectdisplayimage.sprite = SkinIcons[SelectedSkinID];

        SkinTopPreview.sprite = SkinIcons[GameStats.stats.topSkinID];
        SkinBotPreview.sprite = SkinIcons[GameStats.stats.botSkinID];

        CrystalCounter.text = GameStats.stats.crystals.ToString();
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

        else if (SelectedSkinID == 1 && GameStats.stats.SkinConditions[0] == true)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);
            unlockedText.text = "Unlocked";
            UnlockDescription.text = "select skin position";
            buybutton.SetActive(false);
        }

        else if (SelectedSkinID == 2 && GameStats.stats.SkinConditions[1] == true)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);
            unlockedText.text = "Unlocked";
            UnlockDescription.text = "select skin position";
            buybutton.SetActive(false);
        }
        else if (SelectedSkinID == 3 && GameStats.stats.SkinConditions[2] == true)
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
            else if (SelectedSkinID == 7)
            {
                UnlockDescription.text = " buy the skin pack to unlock";
                buybutton.SetActive(true);
            }
            else if (SelectedSkinID == 8)
            {
                UnlockDescription.text = " buy the skin pack to unlock";
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


}
