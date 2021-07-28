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
    [SerializeField] GameObject[] prices;

    public int SelectedSkinID;


    public GameObject buttonTop;
    public GameObject buttonBot;

    public TextMeshProUGUI unlockedText;
    public TextMeshProUGUI UnlockDescription;

    public TextMeshProUGUI CrystalCounter;

    public GameObject buybutton;


    public GameObject normalstore;
    public GameObject CrystalStore;
    public GameObject BackToStoreButton;
    public GameObject BackToSkinMenuButton;
    public GameObject runeForgeButton;

    public PowerMEnu myPowerMenu;

    

    




    
    // Start is called before the first frame update
    void Start()
    {

        if (GameStats.stats.SkinPackBought)
        {
            GameStats.stats.skinConditions[1] = true;
        }
        selectdisplayimage.sprite = SkinIcons[SelectedSkinID];

        SkinTopPreview.sprite = SkinIcons[GameStats.stats.topSkinID];
        SkinBotPreview.sprite = SkinIcons[GameStats.stats.botSkinID];

        CrystalCounter.text = GameStats.stats.crystals.ToString();

        #region UnlockDisplayStart
        //
        CheckLocked();

        #endregion 
    }

    public void DelayedStart()
    {
        if (GameStats.stats.SkinPackBought)
        {
            GameStats.stats.skinConditions[1] = true;
        }
        selectdisplayimage.sprite = SkinIcons[SelectedSkinID];

        SkinTopPreview.sprite = SkinIcons[GameStats.stats.topSkinID];
        SkinBotPreview.sprite = SkinIcons[GameStats.stats.botSkinID];

        CrystalCounter.text = GameStats.stats.crystals.ToString();

        #region UnlockDisplayStart
        //
        CheckLocked();

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
        CheckLocked();

        #endregion

    }

    void CheckLocked()
    {
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
            prices[1].SetActive(false);
        }
        if (GameStats.stats.skinConditions[3] == true)
        {
            LockedSkins[14].enabled = false;
            prices[2].SetActive(false);
        }
        if (GameStats.stats.skinConditions[4] == true)
        {
            LockedSkins[17].enabled = false;
            prices[3].SetActive(false);
        }
        if (GameStats.stats.skinConditions[5] == true)
        {
            LockedSkins[18].enabled = false;
            prices[4].SetActive(false);
        }
        if (GameStats.stats.AchivementConditions[0])
        {
            LockedSkins[1].enabled = false;
            prices[0].SetActive(false);
        }
        if (GameStats.stats.AchivementConditions[1])
        {
            LockedSkins[2].enabled = false;
        }
        if (GameStats.stats.AchivementConditions[2])
        {
            LockedSkins[3].enabled = false;
        }
        if (GameStats.stats.AchivementConditions[3])
        {
            LockedSkins[4].enabled = false;
        }
        if (GameStats.stats.AchivementConditions[4])
        {
            LockedSkins[5].enabled = false;
        }
    }

   

    #region Select Skin
    public void SelectSkin (int SkinID)
	{
        SelectedSkinID = SkinID;


        if (SelectedSkinID == 0 )
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);

            if (GameStats.stats.LanguageSelect == 0)
            {
                unlockedText.text = "Unlocked";
                UnlockDescription.text = "select skin position";
            }
            else if (GameStats.stats.LanguageSelect == 1)
            {
                unlockedText.text = "Desbloqueado";
                UnlockDescription.text = "Seleccionar posición de skin";
            }
            buybutton.SetActive(false);

        }
        else if (SelectedSkinID == 2 && GameStats.stats.LevelReached >= 2)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);

            if (GameStats.stats.LanguageSelect == 0)
            {
                unlockedText.text = "Unlocked";
                UnlockDescription.text = "select skin position";
            }
            else if (GameStats.stats.LanguageSelect == 1)
            {
                unlockedText.text = "Desbloqueado";
                UnlockDescription.text = "Seleccionar posición de skin";
            }
            buybutton.SetActive(false);

        }

        else if (SelectedSkinID == 3 && GameStats.stats.LevelReached >= 3)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);

            if (GameStats.stats.LanguageSelect == 0)
            {
                unlockedText.text = "Unlocked";
                UnlockDescription.text = "select skin position";
            }
            else if (GameStats.stats.LanguageSelect == 1)
            {
                unlockedText.text = "Desbloqueado";
                UnlockDescription.text = "Seleccionar posición de skin";
            }
            buybutton.SetActive(false);
        }
        else if (SelectedSkinID == 4 && GameStats.stats.LevelReached >= 4)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);

            if (GameStats.stats.LanguageSelect == 0)
            {
                unlockedText.text = "Unlocked";
                UnlockDescription.text = "select skin position";
            }
            else if (GameStats.stats.LanguageSelect == 1)
            {
                unlockedText.text = "Desbloqueado";
                UnlockDescription.text = "Seleccionar posición de skin";
            }
            buybutton.SetActive(false);
        }
        else if (SelectedSkinID == 5 && GameStats.stats.LevelReached >= 5)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);

            if (GameStats.stats.LanguageSelect == 0)
            {
                unlockedText.text = "Unlocked";
                UnlockDescription.text = "select skin position";
            }
            else if (GameStats.stats.LanguageSelect == 1)
            {
                unlockedText.text = "Desbloqueado";
                UnlockDescription.text = "Seleccionar posición de skin";
            }
            buybutton.SetActive(false);
        }

        else if (SelectedSkinID == 6 && GameStats.stats.LevelReached >= 6)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);

            if (GameStats.stats.LanguageSelect == 0)
            {
                unlockedText.text = "Unlocked";
                UnlockDescription.text = "select skin position";
            }
            else if (GameStats.stats.LanguageSelect == 1)
            {
                unlockedText.text = "Desbloqueado";
                UnlockDescription.text = "Seleccionar posición de skin";
            }
            buybutton.SetActive(false);
        }

        else if (SelectedSkinID == 1 && GameStats.stats.skinConditions[0] == true)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);
            if (GameStats.stats.LanguageSelect == 0)
            {
                unlockedText.text = "Unlocked";
                UnlockDescription.text = "select skin position";
            }
            else if (GameStats.stats.LanguageSelect == 1)
            {
                unlockedText.text = "Desbloqueado";
                UnlockDescription.text = "Seleccionar posición de skin";
            }
            buybutton.SetActive(false);
        }

        else if (SelectedSkinID == 7 && GameStats.stats.skinConditions[1] == true)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);
            if (GameStats.stats.LanguageSelect == 0)
            {
                unlockedText.text = "Unlocked";
                UnlockDescription.text = "select skin position";
            }
            else if (GameStats.stats.LanguageSelect == 1)
            {
                unlockedText.text = "Desbloqueado";
                UnlockDescription.text = "Seleccionar posición de skin";
            }
            buybutton.SetActive(false);
        }
        else if (SelectedSkinID == 8 && GameStats.stats.skinConditions[1] == true)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);

            if (GameStats.stats.LanguageSelect == 0)
            {
                unlockedText.text = "Unlocked";
                UnlockDescription.text = "select skin position";
            } else if (GameStats.stats.LanguageSelect == 1)
            {
                unlockedText.text = "Desbloqueado";
                UnlockDescription.text = "Seleccionar posición de skin";
            }
            
            buybutton.SetActive(false);
        }
        else if (SelectedSkinID == 9 && GameStats.stats.skinConditions[1] == true)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);
            if (GameStats.stats.LanguageSelect == 0)
            {
                unlockedText.text = "Unlocked";
                UnlockDescription.text = "select skin position";
            }
            else if (GameStats.stats.LanguageSelect == 1)
            {
                unlockedText.text = "Desbloqueado";
                UnlockDescription.text = "Seleccionar posición de skin";
            }
            buybutton.SetActive(false);
        }

        else if (SelectedSkinID == 10 && GameStats.stats.skinConditions[2] == true)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);
            if (GameStats.stats.LanguageSelect == 0)
            {
                unlockedText.text = "Unlocked";
                UnlockDescription.text = "select skin position";
            }
            else if (GameStats.stats.LanguageSelect == 1)
            {
                unlockedText.text = "Desbloqueado";
                UnlockDescription.text = "Seleccionar posición de skin";
            }
            buybutton.SetActive(false);
        }

        else if (SelectedSkinID == 11 && GameStats.stats.skinConditions[1] == true)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);
            if (GameStats.stats.LanguageSelect == 0)
            {
                unlockedText.text = "Unlocked";
                UnlockDescription.text = "select skin position";
            }
            else if (GameStats.stats.LanguageSelect == 1)
            {
                unlockedText.text = "Desbloqueado";
                UnlockDescription.text = "Seleccionar posición de skin";
            }
            buybutton.SetActive(false);
        }
        else if (SelectedSkinID == 12 && GameStats.stats.skinConditions[1] == true)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);
            if (GameStats.stats.LanguageSelect == 0)
            {
                unlockedText.text = "Unlocked";
                UnlockDescription.text = "select skin position";
            }
            else if (GameStats.stats.LanguageSelect == 1)
            {
                unlockedText.text = "Desbloqueado";
                UnlockDescription.text = "Seleccionar posición de skin";
            }
            buybutton.SetActive(false);
        }
        else if (SelectedSkinID == 13 && GameStats.stats.skinConditions[1] == true)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);
            if (GameStats.stats.LanguageSelect == 0)
            {
                unlockedText.text = "Unlocked";
                UnlockDescription.text = "select skin position";
            }
            else if (GameStats.stats.LanguageSelect == 1)
            {
                unlockedText.text = "Desbloqueado";
                UnlockDescription.text = "Seleccionar posición de skin";
            }
            buybutton.SetActive(false);
        }
        else if (SelectedSkinID == 14 && GameStats.stats.skinConditions[1] == true)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);
            if (GameStats.stats.LanguageSelect == 0)
            {
                unlockedText.text = "Unlocked";
                UnlockDescription.text = "select skin position";
            }
            else if (GameStats.stats.LanguageSelect == 1)
            {
                unlockedText.text = "Desbloqueado";
                UnlockDescription.text = "Seleccionar posición de skin";
            }
            buybutton.SetActive(false);
        }
        else if (SelectedSkinID == 15 && GameStats.stats.skinConditions[3] == true)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);
            if (GameStats.stats.LanguageSelect == 0)
            {
                unlockedText.text = "Unlocked";
                UnlockDescription.text = "select skin position";
            }
            else if (GameStats.stats.LanguageSelect == 1)
            {
                unlockedText.text = "Desbloqueado";
                UnlockDescription.text = "Seleccionar posición de skin";
            }
            buybutton.SetActive(false);
        }
        else if (SelectedSkinID == 16 && GameStats.stats.skinConditions[1] == true)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);
            if (GameStats.stats.LanguageSelect == 0)
            {
                unlockedText.text = "Unlocked";
                UnlockDescription.text = "select skin position";
            }
            else if (GameStats.stats.LanguageSelect == 1)
            {
                unlockedText.text = "Desbloqueado";
                UnlockDescription.text = "Seleccionar posición de skin";
            }
            buybutton.SetActive(false);
        }
        else if (SelectedSkinID == 17 && GameStats.stats.LevelReached == 7)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);
            if (GameStats.stats.LanguageSelect == 0)
            {
                unlockedText.text = "Unlocked";
                UnlockDescription.text = "select skin position";
            }
            else if (GameStats.stats.LanguageSelect == 1)
            {
                unlockedText.text = "Desbloqueado";
                UnlockDescription.text = "Seleccionar posición de skin";
            }
            buybutton.SetActive(false);
        }

        else if (SelectedSkinID == 18 && GameStats.stats.skinConditions[4] == true)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);
            if (GameStats.stats.LanguageSelect == 0)
            {
                unlockedText.text = "Unlocked";
                UnlockDescription.text = "select skin position";
            }
            else if (GameStats.stats.LanguageSelect == 1)
            {
                unlockedText.text = "Desbloqueado";
                UnlockDescription.text = "Seleccionar posición de skin";
            }
            buybutton.SetActive(false);
        }
        else if (SelectedSkinID == 19 && GameStats.stats.skinConditions[5] == true)
        {
            buttonBot.SetActive(true);
            buttonTop.SetActive(true);
            if (GameStats.stats.LanguageSelect == 0)
            {
                unlockedText.text = "Unlocked";
                UnlockDescription.text = "select skin position";
            }
            else if (GameStats.stats.LanguageSelect == 1)
            {
                unlockedText.text = "Desbloqueado";
                UnlockDescription.text = "Seleccionar posición de skin";
            }
            buybutton.SetActive(false);
        }

        else
        {
            buttonBot.SetActive(false);
            buttonTop.SetActive(false);
            if (GameStats.stats.LanguageSelect == 0)
            {
                unlockedText.text = "Locked";

            } else if (GameStats.stats.LanguageSelect == 1)
            {
                unlockedText.text = "Bloqueado";
            }
           


            if (SelectedSkinID == 1)
            {
                if (GameStats.stats.LanguageSelect== 0)
                {
                    UnlockDescription.text = "buy skin for 50 Crystals";
                } else if (GameStats.stats.LanguageSelect == 1)
                {
                    UnlockDescription.text = "Comprar skin por 50 Cristales";
                }
                
                buybutton.SetActive(true);
            }
            else if (SelectedSkinID == 2)
            {
                if (GameStats.stats.LanguageSelect == 0)
                {
                    UnlockDescription.text = "Defeat the Wyrm at the library to unlock";
                } else if(GameStats.stats.LanguageSelect == 1)
                {
                    UnlockDescription.text = "Vence al Dragón en la librería para desbloquear";
                }
                    
                buybutton.SetActive(false);
            }
            else if (SelectedSkinID == 3)
            {
                if (GameStats.stats.LanguageSelect == 0)
                {
                    UnlockDescription.text = "Defeat the Mage Goblin at the Dungeon to unlock";
                } else if (GameStats.stats.LanguageSelect == 1)
                {
                    UnlockDescription.text = "Vence al goblin mago en la mazmorra para desbloquar";
                }
                    
                buybutton.SetActive(false);
            }
            else if (SelectedSkinID == 4)
            {
                if (GameStats.stats.LanguageSelect == 0)
                {
                    UnlockDescription.text = "Defeat the Yeti at the Ice Room to unlock";
                }
                else if (GameStats.stats.LanguageSelect == 1)
                {
                    UnlockDescription.text = "Vence al Yeti en el cuarto congelado para debloquear";
                }

                buybutton.SetActive(false);
            }
            else if (SelectedSkinID == 5)
            {
                if (GameStats.stats.LanguageSelect == 0)
                {
                    UnlockDescription.text = "Defeat the Carnivorous Plant at the Jungle to unlock";
                }
                else if (GameStats.stats.LanguageSelect == 1)
                {
                    UnlockDescription.text = "Vence a la planta carnivora en la jungla para desbloquear";
                }
                    buybutton.SetActive(false);
            }
            else if (SelectedSkinID == 6)
            {
                if (GameStats.stats.LanguageSelect == 0)
                {
                    UnlockDescription.text = "Defeat the Clockwork Griffin at the Portal Room to unlock";
                }
               else if (GameStats.stats.LanguageSelect == 1)
                {
                    UnlockDescription.text = "Vence al grifo de relojería para desbloquar";
                }
                    
                buybutton.SetActive(false);
            }
            else if (SelectedSkinID >= 7 && SelectedSkinID <= 9)
            {
                if (GameStats.stats.LanguageSelect == 0)
                {
                    UnlockDescription.text = "buy the skin pack to unlock";
                }
                else if (GameStats.stats.LanguageSelect == 1)
                {
                    UnlockDescription.text = "Compra el pack de skins para desbloquar";
                }
                    
                buybutton.SetActive(true);
            }
            else if (SelectedSkinID == 10)
            {
                if (GameStats.stats.LanguageSelect == 0)
                {
                    UnlockDescription.text = "buy skin for 50 Crystals";
                }
                else if (GameStats.stats.LanguageSelect == 1)
                {
                    UnlockDescription.text = "Comprar skin por 50 Cristales";
                }
                buybutton.SetActive(true);
            }

            else if (SelectedSkinID >= 11 && SelectedSkinID <= 14)
            {
                if (GameStats.stats.LanguageSelect == 0)
                {
                    UnlockDescription.text = "buy the skin pack to unlock";
                }
                else if (GameStats.stats.LanguageSelect == 1)
                {
                    UnlockDescription.text = "Compra el pack de skins para desbloquar";
                }
                buybutton.SetActive(true);
            }
            else if (SelectedSkinID == 15)
            {
                if (GameStats.stats.LanguageSelect == 0)
                {
                    UnlockDescription.text = "buy skin for 50 Crystals";
                }
                else if (GameStats.stats.LanguageSelect == 1)
                {
                    UnlockDescription.text = "Comprar skin por 50 Cristales";
                }
                buybutton.SetActive(true);
            }
            else if (SelectedSkinID == 16)
            {
                if (GameStats.stats.LanguageSelect == 0)
                {
                    UnlockDescription.text = "buy the skin pack to unlock";
                }
                else if (GameStats.stats.LanguageSelect == 1)
                {
                    UnlockDescription.text = "Compra el pack de skins para desbloquar";
                }
                buybutton.SetActive(true);
            }
            else if (SelectedSkinID == 17)
            {
                if (GameStats.stats.LanguageSelect == 0)
                {
                    UnlockDescription.text = "Defeat The Mage to unlock";

                } else if (GameStats.stats.LanguageSelect == 1)
                {
                    UnlockDescription.text = "Vence al mago para desbloquar";
                }
                   
                buybutton.SetActive(false);
            }
            else if (SelectedSkinID == 18)
            {
                if (GameStats.stats.LanguageSelect == 0)
                {
                    UnlockDescription.text = "buy skin for 50 Crystals";
                }
                else if (GameStats.stats.LanguageSelect == 1)
                {
                    UnlockDescription.text = "Comprar skin por 50 Cristales";
                }
                buybutton.SetActive(true);
            }
            else if (SelectedSkinID == 19)
            {
                if (GameStats.stats.LanguageSelect == 0)
                {
                    UnlockDescription.text = "buy skin for 50 Crystals";
                }
                else if (GameStats.stats.LanguageSelect == 1)
                {
                    UnlockDescription.text = "Comprar skin por 50 Cristales";
                }
                buybutton.SetActive(true);
            }


            else
            {
                UnlockDescription.text = "";
            }
            

        }

    }

    #endregion


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
                GameStats.stats.SaveStats();
                CheckLocked();
            }
        }

        if (SelectedSkinID == 7 || SelectedSkinID == 8 || SelectedSkinID == 9 || SelectedSkinID == 11 || SelectedSkinID == 12 || SelectedSkinID == 13 || SelectedSkinID == 14 || SelectedSkinID == 16)
        {
            // go to buy pack. Cuado pongamos lo de IN-APP purchases.
            normalstore.SetActive(false);
            CrystalStore.SetActive(true);
            BackToSkinMenuButton.SetActive(true);
            BackToStoreButton.SetActive(false);
            runeForgeButton.SetActive(false);
            myPowerMenu.PowerMenu();

        }
       
    }

    public void BackFromSkinMenu()
    {
        myPowerMenu.PowerMenuBack();
        Invoke("BackFromSkinMenuActives", 1);
    }

     void BackFromSkinMenuActives()
    {
        normalstore.SetActive(true);
        CrystalStore.SetActive(false);
        BackToSkinMenuButton.SetActive(false);
        BackToStoreButton.SetActive(true);
        runeForgeButton.SetActive(true);
    }


}
