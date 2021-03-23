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



    // power stats display

    public Image PowerImage;
    public TextMeshProUGUI PowerName;
    public TextMeshProUGUI Manacost;
    public TextMeshProUGUI PowerDamage;
    public TextMeshProUGUI powerDescription;
        


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

    }

    public void DarkPowerButton()
    {
        PowerImage.sprite = GameStats.stats.powerDark.iconDark;
        PowerName.text = GameStats.stats.powerDark.name;
        Manacost.text = GameStats.stats.powerDark.mana.ToString();
        PowerDamage.text = GameStats.stats.powerDark.Damage.ToString();
        powerDescription.text = GameStats.stats.powerDark.description;
    }

    public void LightPowerButton()
    {
        PowerImage.sprite = GameStats.stats.powerLight.iconLight;
        PowerName.text = GameStats.stats.powerLight.name;
        Manacost.text = GameStats.stats.powerLight.mana.ToString();
        PowerDamage.text = GameStats.stats.powerLight.Damage.ToString();
        powerDescription.text = GameStats.stats.powerLight.description;
    }

}

