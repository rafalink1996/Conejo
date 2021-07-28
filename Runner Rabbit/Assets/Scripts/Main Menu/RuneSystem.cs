using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 

public class RuneSystem : MonoBehaviour
{
    public Image BGSelect;
    public Sprite NoRuneSprite;
    public GameObject ButtonSelcetRune1;
    public GameObject ButtonSelcetRune2;

    public GameObject UnequipButtonRune1;
    public GameObject UnequipButtonRune2;

    public TextMeshProUGUI RuneSlotName1;
    public TextMeshProUGUI RuneSlotName2;


    public TextMeshProUGUI[] Buy_EquipButtonsText;
    public GameObject[] CostTexts;

    public Image RuneSlot1Image;
    public Image RuneSlot2Image;

    private GameStats.Rune SelectedRuneID;


    private int PreviouslySelectedRune1;
    private int PreviouslySelectedRune2;

    public Button[] BuyEquiButtons;
    public int[] RuneCosts;
    public string[] RuneNames;
    public string[] Español_RuneNames;

    public GameObject[] RuneSelected;

    PowerMEnu myPowerShop;

    public GameObject[] RuneLocked;





    // Start is called before the first frame update
    void Start()
    {
        // SetSelectedRunes
        for (int i = 0; i < RuneSelected.Length; i++)
        {
            RuneSelected[i].SetActive(false);
        }

            myPowerShop = FindObjectOfType<PowerMEnu>();
        // See what runes are unlocked
        for (int i = 0; i < GameStats.stats.UnlockedRunes.Length; i++)
        {
            if(GameStats.stats.UnlockedRunes[i] == true)
            {

                
                TextMeshProUGUI CostTextTMP = CostTexts[i].GetComponent<TextMeshProUGUI>();
                
                if (GameStats.stats.LanguageSelect == 0)
                {
                    Buy_EquipButtonsText[i].text = "Equip";
                    CostTextTMP.text = "owned";
                } else if (GameStats.stats.LanguageSelect == 1)
                {
                    Buy_EquipButtonsText[i].text = "Equipar";
                    CostTextTMP.text = "Comprado";
                }
               
                GameObject CostCrystal = CostTexts[i].transform.GetChild(0).gameObject;
                CostCrystal.SetActive(false);

                RuneLocked[i].SetActive(false);


                //CostTexts[i].SetActive(false);
            }
            else
            {
                if (GameStats.stats.LanguageSelect == 0)
                {
                    Buy_EquipButtonsText[i].text = "Buy";
                } else if (GameStats.stats.LanguageSelect == 1){
                    Buy_EquipButtonsText[i].text = "Comprar";
                }

                RuneLocked[i].SetActive(true);



                // CostTexts[i].SetActive(true);
            }
        }

        // Equip Saved Runes

        if (GameStats.stats.Rune1ID != 0)
        {
            
            RuneSlot1Image.sprite = GameStats.stats.runeSprites[(int)GameStats.stats.Rune1-1];
            UnequipButtonRune1.SetActive(true);
            PreviouslySelectedRune1 = GameStats.stats.Rune1ID -1;
            BuyEquiButtons[GameStats.stats.Rune1ID - 1].gameObject.SetActive(false);

            if (GameStats.stats.LanguageSelect == 0) //ingles seleccionado
            {

                    RuneSlotName1.text = RuneNames[GameStats.stats.Rune1ID]; // rune Name
    
            } else if (GameStats.stats.LanguageSelect == 1) //español seleccionado
            {
               
                    RuneSlotName1.text = Español_RuneNames[GameStats.stats.Rune1ID]; //nombre Runa español
     
            }

            RuneSelected[PreviouslySelectedRune1].SetActive(true);
            Image RuneSelectedImage = RuneSelected[PreviouslySelectedRune1].GetComponent<Image>();
            RuneSelectedImage.color = new Color (0.5f, 0.95f, 0.95f, 1);

            Debug.Log("Rune1 has" + ((GameStats.Rune)PreviouslySelectedRune1 +1));
        }
        else
        {
            if (GameStats.stats.LanguageSelect == 0)
            {
                RuneSlotName1.text = RuneNames[0]; 
            } else if (GameStats.stats.LanguageSelect == 1)
            {
                RuneSlotName1.text = Español_RuneNames[0];
            }

        }
        if (GameStats.stats.Rune2ID != 0)
        {
            
            RuneSlot2Image.sprite = GameStats.stats.runeSprites[(int)GameStats.stats.Rune2-1];
            UnequipButtonRune2.SetActive(true);
            PreviouslySelectedRune2 = GameStats.stats.Rune2ID -1;
            BuyEquiButtons[GameStats.stats.Rune2ID - 1].gameObject.SetActive(false);

            if (GameStats.stats.LanguageSelect == 0)
            {
                RuneSlotName2.text = RuneNames[GameStats.stats.Rune2ID];
            }
            else if (GameStats.stats.LanguageSelect == 1)
            {
                RuneSlotName2.text = Español_RuneNames[GameStats.stats.Rune2ID];
            }

            RuneSelected[PreviouslySelectedRune2].SetActive(true);
            Image RuneSelectedImage = RuneSelected[PreviouslySelectedRune2 ].GetComponent<Image>();
            RuneSelectedImage.color = new Color(1f, 0.77f, 0.2f, 1);
            Debug.Log("Rune2 has" + ((GameStats.Rune)PreviouslySelectedRune2 +1));
        }
        else
        {
            if (GameStats.stats.LanguageSelect == 0)
            {
                RuneSlotName2.text = RuneNames[0];
            }
            else if (GameStats.stats.LanguageSelect == 1)
            {
                RuneSlotName2.text = Español_RuneNames[0];
            }
        }
    }


    public void DelayedStart()
    {
        for (int i = 0; i < GameStats.stats.UnlockedRunes.Length; i++)
        {
            if (GameStats.stats.UnlockedRunes[i] == true)
            {


                TextMeshProUGUI CostTextTMP = CostTexts[i].GetComponent<TextMeshProUGUI>();

                if (GameStats.stats.LanguageSelect == 0)
                {
                    Buy_EquipButtonsText[i].text = "Equip";
                    CostTextTMP.text = "owned";
                }
                else if (GameStats.stats.LanguageSelect == 1)
                {
                    Buy_EquipButtonsText[i].text = "Equipar";
                    CostTextTMP.text = "Comprado";
                }

                GameObject CostCrystal = CostTexts[i].transform.GetChild(0).gameObject;
                CostCrystal.SetActive(false);

                RuneLocked[i].SetActive(false);


                //CostTexts[i].SetActive(false);
            }
            else
            {
                if (GameStats.stats.LanguageSelect == 0)
                {
                    Buy_EquipButtonsText[i].text = "Buy";
                }
                else if (GameStats.stats.LanguageSelect == 1)
                {
                    Buy_EquipButtonsText[i].text = "Comprar";
                }

                RuneLocked[i].SetActive(true);



                // CostTexts[i].SetActive(true);
            }
        }

        // Equip Saved Runes

        if (GameStats.stats.Rune1ID != 0)
        {

            RuneSlot1Image.sprite = GameStats.stats.runeSprites[(int)GameStats.stats.Rune1 - 1];
            UnequipButtonRune1.SetActive(true);
            PreviouslySelectedRune1 = GameStats.stats.Rune1ID - 1;
            BuyEquiButtons[GameStats.stats.Rune1ID - 1].gameObject.SetActive(false);

            if (GameStats.stats.LanguageSelect == 0) //ingles seleccionado
            {

                RuneSlotName1.text = RuneNames[GameStats.stats.Rune1ID]; // rune Name

            }
            else if (GameStats.stats.LanguageSelect == 1) //español seleccionado
            {

                RuneSlotName1.text = Español_RuneNames[GameStats.stats.Rune1ID]; //nombre Runa español

            }

            RuneSelected[PreviouslySelectedRune1].SetActive(true);
            Image RuneSelectedImage = RuneSelected[PreviouslySelectedRune1].GetComponent<Image>();
            RuneSelectedImage.color = new Color(0.5f, 0.95f, 0.95f, 1);

            Debug.Log("Rune1 has" + ((GameStats.Rune)PreviouslySelectedRune1 + 1));
        }
        else
        {
            if (GameStats.stats.LanguageSelect == 0)
            {
                RuneSlotName1.text = RuneNames[0];
            }
            else if (GameStats.stats.LanguageSelect == 1)
            {
                RuneSlotName1.text = Español_RuneNames[0];
            }

        }
        if (GameStats.stats.Rune2ID != 0)
        {

            RuneSlot2Image.sprite = GameStats.stats.runeSprites[(int)GameStats.stats.Rune2 - 1];
            UnequipButtonRune2.SetActive(true);
            PreviouslySelectedRune2 = GameStats.stats.Rune2ID - 1;
            BuyEquiButtons[GameStats.stats.Rune2ID - 1].gameObject.SetActive(false);

            if (GameStats.stats.LanguageSelect == 0)
            {
                RuneSlotName2.text = RuneNames[GameStats.stats.Rune2ID];
            }
            else if (GameStats.stats.LanguageSelect == 1)
            {
                RuneSlotName2.text = Español_RuneNames[GameStats.stats.Rune2ID];
            }

            RuneSelected[PreviouslySelectedRune2].SetActive(true);
            Image RuneSelectedImage = RuneSelected[PreviouslySelectedRune2].GetComponent<Image>();
            RuneSelectedImage.color = new Color(1f, 0.77f, 0.2f, 1);
            Debug.Log("Rune2 has" + ((GameStats.Rune)PreviouslySelectedRune2 + 1));
        }
        else
        {
            if (GameStats.stats.LanguageSelect == 0)
            {
                RuneSlotName2.text = RuneNames[0];
            }
            else if (GameStats.stats.LanguageSelect == 1)
            {
                RuneSlotName2.text = Español_RuneNames[0];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < GameStats.stats.UnlockedRunes.Length; i++)
        {
            if (GameStats.stats.UnlockedRunes[i] == true)
            {
                
                TextMeshProUGUI CostTextTMP = CostTexts[i].GetComponent<TextMeshProUGUI>();
                if (GameStats.stats.LanguageSelect == 0)
                {
                    Buy_EquipButtonsText[i].text = "Equip"; Buy_EquipButtonsText[i].fontSize = 40;
                    CostTextTMP.text = "owned";
                }
                else if (GameStats.stats.LanguageSelect == 1)
                {
                    Buy_EquipButtonsText[i].text = "Equipar"; Buy_EquipButtonsText[i].fontSize = 25;
                    CostTextTMP.text = "Comprado";
                }
                GameObject CostCrystal = CostTexts[i].transform.GetChild(0).gameObject;
                CostCrystal.SetActive(false);

                //CostTexts[i].SetActive(false);
            }
            else
            {
                TextMeshProUGUI CostTextTMP = CostTexts[i].GetComponent<TextMeshProUGUI>();
                if (GameStats.stats.LanguageSelect == 0)
                {
                    
                    Buy_EquipButtonsText[i].text = "Buy"; Buy_EquipButtonsText[i].fontSize = 40;
                    CostTextTMP.text = "Cost: " + RuneCosts[i];
                }
                else if (GameStats.stats.LanguageSelect == 1)
                {
                   
                    Buy_EquipButtonsText[i].text = "Comprar"; Buy_EquipButtonsText[i].fontSize = 25;
                    CostTextTMP.text = "Costo: " + RuneCosts[i];
                }
                //CostTexts[i].SetActive(true);
            }
        }   
    }

    public void BuyOrEquipButton(int runeID)
    {
        if (GameStats.stats.UnlockedRunes[runeID - 1] == true)
        {
            // rune is unlocked
            BGSelect.enabled = true;
            ButtonSelcetRune1.SetActive(true);
            ButtonSelcetRune2.SetActive(true);
            BGSelect.gameObject.SetActive(true);
            SelectedRuneID = (GameStats.Rune)runeID;
            RuneSelected[runeID - 1].SetActive(true);
            Image RuneSelectedImage = RuneSelected[runeID - 1].GetComponent<Image>();
            RuneSelectedImage.color = Color.white;
        }
        else
        {
            //needs to buy rune
            if (GameStats.stats.crystals >= RuneCosts[runeID -1])
            {
                GameStats.stats.crystals -= RuneCosts[runeID -1];
                GameStats.stats.UnlockedRunes[runeID - 1] = true;
                RuneLocked[runeID -1].SetActive(false);
                GameStats.stats.SaveStats();
                GameStats.stats.UploadStats();
            }
            else
            {
                myPowerShop.NotEnoughCrystals();
            }
            
        }


    }

    public void SelectRuneSlot(int RuneSlotID)
    {
        if(RuneSlotID == 1)
        {
            //selected runeslot1
            if(PreviouslySelectedRune1 != 0)
            {
                UnequipRuneSlot(1);
            }
            
            RuneSlot1Image.sprite = GameStats.stats.runeSprites[(int)SelectedRuneID -1];
            GameStats.stats.Rune1 = SelectedRuneID;
            GameStats.stats.Rune1ID = (int)SelectedRuneID;
            BGSelect.gameObject.SetActive(false);
            ButtonSelcetRune1.SetActive(false);
            ButtonSelcetRune2.SetActive(false);
            BuyEquiButtons[(int)SelectedRuneID-1].gameObject.SetActive(false);
            PreviouslySelectedRune1 = (int)SelectedRuneID - 1;
            if (GameStats.stats.LanguageSelect == 0)
            {
                RuneSlotName1.text = RuneNames[(int)SelectedRuneID];
            } else if (GameStats.stats.LanguageSelect == 1)
            {
                RuneSlotName1.text = Español_RuneNames[(int)SelectedRuneID];
            }
            
            UnequipButtonRune1.SetActive(true);
            GameStats.stats.SaveStats();

            RuneSelected[PreviouslySelectedRune1].SetActive(true);
            Image RuneSelectedImage = RuneSelected[PreviouslySelectedRune1].GetComponent<Image>();
            RuneSelectedImage.color = new Color(0.5f, 0.95f, 0.95f, 1);
        }

        if (RuneSlotID == 2)
        {
            if(PreviouslySelectedRune2 != 0)
            {
                UnequipRuneSlot(2);
            }
            
            //selected runeslot2
            RuneSlot2Image.sprite = GameStats.stats.runeSprites[(int)SelectedRuneID - 1];
            GameStats.stats.Rune2 = SelectedRuneID;
            GameStats.stats.Rune2ID = (int)SelectedRuneID;
            BGSelect.gameObject.SetActive(false);
            ButtonSelcetRune1.SetActive(false);
            ButtonSelcetRune2.SetActive(false);
            BuyEquiButtons[(int)SelectedRuneID-1].gameObject.SetActive(false);
            PreviouslySelectedRune2 = (int)SelectedRuneID - 1;
            if (GameStats.stats.LanguageSelect == 0)
            {
                RuneSlotName2.text = RuneNames[(int)SelectedRuneID];
            } else if (GameStats.stats.LanguageSelect == 1)
            {
                RuneSlotName2.text = Español_RuneNames[(int)SelectedRuneID];
            }
                
            UnequipButtonRune2.SetActive(true);
            GameStats.stats.SaveStats();

            RuneSelected[PreviouslySelectedRune2].SetActive(true);
            Image RuneSelectedImage = RuneSelected[PreviouslySelectedRune2].GetComponent<Image>();
            RuneSelectedImage.color = new Color(1f, 0.77f, 0.2f, 1);
        }
    }

    public void UnequipRuneSlot(int RuneSlotID)
    {
        if (RuneSlotID == 1)
        {
            //selected runeslot1
            RuneSlot1Image.sprite = NoRuneSprite;
            GameStats.stats.Rune1 = GameStats.Rune.Default;
            GameStats.stats.Rune1ID = 0;
            BuyEquiButtons[PreviouslySelectedRune1].gameObject.SetActive(true);
            UnequipButtonRune1.SetActive(false);

            RuneSelected[PreviouslySelectedRune1].SetActive(false);
            Image RuneSelectedImage = RuneSelected[PreviouslySelectedRune1].GetComponent<Image>();
            RuneSelectedImage.color = Color.white;


            if (GameStats.stats.LanguageSelect == 0)
            {
                RuneSlotName1.text = RuneNames[0];
            }
            else if (GameStats.stats.LanguageSelect == 1)
            {
                RuneSlotName1.text = Español_RuneNames[0];
            }

            GameStats.stats.SaveStats();

        }

        if (RuneSlotID == 2)
        {
            //selected runeslot2
            RuneSlot2Image.sprite = NoRuneSprite;
            GameStats.stats.Rune2 = GameStats.Rune.Default;
            GameStats.stats.Rune2ID = 0;
            BuyEquiButtons[PreviouslySelectedRune2].gameObject.SetActive(true);
            UnequipButtonRune2.SetActive(false);

            RuneSelected[PreviouslySelectedRune2].SetActive(false);
            Image RuneSelectedImage = RuneSelected[PreviouslySelectedRune2].GetComponent<Image>();
            RuneSelectedImage.color = Color.white;

            if (GameStats.stats.LanguageSelect == 0)
            {
                RuneSlotName2.text = RuneNames[0];
            }
            else if (GameStats.stats.LanguageSelect == 1)
            {
                RuneSlotName2.text = Español_RuneNames[0];
            }

            GameStats.stats.SaveStats();

        }


    }

}
