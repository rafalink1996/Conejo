using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class StoreStats : MonoBehaviour
{

    public int Health;
    public int NumOfHearts;
    public GameObject[] hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;

    public TextMeshProUGUI lightManaNumber;
    public TextMeshProUGUI DarkManaNumber;

    public GameObject DarkManaPower;
    public GameObject LightManaPower;

    private Button DarkButton;
    private Button LightButton;

    public Image LightPowerRarity;
    public Image DarkPowerRarity;
   



    // power stats display

    public Image PowerImage;
    public TextMeshProUGUI PowerName;
    public TextMeshProUGUI Manacost;
    public TextMeshProUGUI PowerDamage;
    public TextMeshProUGUI powerDescription;
    public Image RarityColor;
    [SerializeField] TextMeshProUGUI RarityLevel;
        


    // Start is called before the first frame update
    void Start()
    {
        NumOfHearts = GameStats.stats.numOfHearts;
        Health = NumOfHearts;




       LightButton=  LightManaPower.GetComponent<Button>();
        DarkButton = DarkManaPower.GetComponent<Button>();


    }

    // Update is called once per frame
    void Update()
    {
        lightManaNumber.text = GameStats.stats.totalLightMana.ToString();
        DarkManaNumber.text = GameStats.stats.totalDarkMana.ToString();


        NumOfHearts = GameStats.stats.numOfHearts;
        Health = NumOfHearts;

        if (Health > NumOfHearts)
        {
            Health = NumOfHearts;
        }
        // number of current hearts is established

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Health)
            {
                hearts[i].GetComponent<Animator>().SetBool("Full", true);
            }
            else
            {
                hearts[i].GetComponent<Animator>().SetBool("Full", false);
            }

            // number of max hearts is established

            if (i < NumOfHearts)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }
        }

        DarkButton.image.sprite = GameStats.stats.powerDark.iconDark;
        LightButton.image.sprite = GameStats.stats.powerLight.iconLight;

        DarkPowerRarity.color = GameStats.stats.powerDark.rarityColor;
        LightPowerRarity.color = GameStats.stats.powerLight.rarityColor;

    }

    public void DarkPowerButton()
    {
        PowerImage.sprite = GameStats.stats.powerDark.iconDark;
        
        Manacost.text = GameStats.stats.powerDark.mana.ToString();
        PowerDamage.text = GameStats.stats.powerDark.Damage.ToString();
        if (GameStats.stats.LanguageSelect == 0)
        {
            PowerName.text = GameStats.stats.powerDark.name;
            powerDescription.text = GameStats.stats.powerDark.description;
            RarityLevel.text = (GameStats.stats.powerDark.Rarity).ToString();
        }
        else if (GameStats.stats.LanguageSelect == 1)
        {
            PowerName.text = GameStats.stats.powerDark.Español_Name;
            powerDescription.text = GameStats.stats.powerDark.Español_Description;
            RarityLevel.text = (GameStats.stats.powerDark.Rarity).ToString();
        }

       
        RarityColor.color = GameStats.stats.powerDark.rarityColor;
    }

    public void LightPowerButton()
    {
        PowerImage.sprite = GameStats.stats.powerLight.iconLight;
        
        Manacost.text = GameStats.stats.powerLight.mana.ToString();
        PowerDamage.text = GameStats.stats.powerLight.Damage.ToString();
        if (GameStats.stats.LanguageSelect == 0)
        {
            PowerName.text = GameStats.stats.powerLight.name;
            powerDescription.text = GameStats.stats.powerLight.description;
            RarityLevel.text = (GameStats.stats.powerLight.Rarity).ToString();
        } else if(GameStats.stats.LanguageSelect == 1)
        {
            PowerName.text = GameStats.stats.powerLight.Español_Name;
            powerDescription.text = GameStats.stats.powerLight.Español_Description;
            RarityLevel.text = (GameStats.stats.powerLight.Rarity).ToString();
        }
       
        RarityColor.color = GameStats.stats.powerLight.rarityColor;
    }

}

