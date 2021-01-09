using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 

public class RuneSystem : MonoBehaviour
{
    public Image BGSelect;
    public GameObject ButtonSelcetRune1;
    public GameObject ButtonSelcetRune2;

    public GameObject UnequipButtonRune1;
    public GameObject UnequipButtonRune2;


    public TextMeshProUGUI[] Buy_EquipButtonsText;
    public GameObject[] CostTexts;

    public Image RuneSlot1Image;
    public Image RuneSlot2Image;

    private GameStats.Rune SelectedRuneID;

    public Button[] BuyEquiButtons;
    public int[] RuneCosts;

   
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < GameStats.stats.UnlockedRunes.Length; i++)
        {
            if(GameStats.stats.UnlockedRunes[i] == true)
            {
                Buy_EquipButtonsText[i].text = "Equip";
                CostTexts[i].SetActive(false);
            }
            else
            {
                Buy_EquipButtonsText[i].text = "Buy";
                CostTexts[i].SetActive(true);
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
                Buy_EquipButtonsText[i].text = "Equip";
                CostTexts[i].SetActive(false);
            }
            else
            {
                Buy_EquipButtonsText[i].text = "Buy";
                CostTexts[i].SetActive(true);
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
            SelectedRuneID = (GameStats.Rune)runeID;
        }
        else
        {
            //needs to buy rune
            if (GameStats.stats.crystals >= RuneCosts[runeID -1])
            {
                GameStats.stats.crystals -= RuneCosts[runeID -1];
                GameStats.stats.UnlockedRunes[runeID - 1] = true;
            }
            
        }
    }

    public void SelectRuneSlot(int RuneSlotID)
    {
        if(RuneSlotID == 1)
        {
            //selected runeslot1
            RuneSlot1Image.sprite = GameStats.stats.runeSprites[(int)SelectedRuneID -1];
            GameStats.stats.Rune1 = SelectedRuneID;
        }

        if (RuneSlotID == 2)
        {
            //selected runeslot2
            RuneSlot2Image.sprite = GameStats.stats.runeSprites[(int)SelectedRuneID - 1];
            GameStats.stats.Rune2 = SelectedRuneID;
        }
    }

}
