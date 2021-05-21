using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{

    private float coins;


    public TextMeshProUGUI CoinCounter;
    public TextMeshProUGUI heartCostText;

    private GameObject childObj;

    [Header("List of Items Sold")]
    [SerializeField] public List<Power> LightpowerObject;
    [SerializeField] public List<Power> DarkpowerObject;


    [Header("References")]
    [SerializeField] public Transform shopcontainer;
    [SerializeField] public GameObject ShopItemPrefab;


    // BuyPowerDisplay

    public GameObject Display;
    public Image PowerImage;
    public TextMeshProUGUI PowerName;
    public TextMeshProUGUI Manacost;
    public TextMeshProUGUI PowerDamage;
    public TextMeshProUGUI powerDescription;
    public Button BuyButton;
    public Button BackButton;
    public TextMeshProUGUI PowerCost;
    [SerializeField] TextMeshProUGUI PowerTier;
    [SerializeField] Image PowerTierBG;



    public GameObject noCoinsPopUp;
    CanvasGroup NoCoinsCanvasG;
    public float costPerHeart;
    public float heartCost;
    public float lightManaCost;
    public float darkManaCost;

    private List<GameObject> PowersInStore = new List<GameObject>();
    [SerializeField] private List<Power> PowersInStorePower = new List<Power>();

    public TextMeshProUGUI LightManaCostText;
    public TextMeshProUGUI DarkManaCostText;

    public ParticleSystem BuyLightManaEffect;
    public ParticleSystem BuyDarkManaEffect;


    public int[] table;
    public int TotalWeight;

    [SerializeField] List<Power> UnlockedTier1Spells = null;
    [SerializeField] List<Power> UnlockedTier2Spells = null;
    [SerializeField] List<Power> UnlockedTier3Spells = null;
    [SerializeField] List<Power> UnlockedTier4Spells = null;


    [SerializeField] List<TablesPerLevel> TablesPerLevelList = null;

    [System.Serializable]
    public class TablesPerLevel
    {
        public int LevelIndicator;
        public int LevelCount;

        public int []TableValues;
    }




    private void Awake()
    {
        Time.timeScale = 1;
    }




    private void Start()
    {
        NoCoinsCanvasG = noCoinsPopUp.GetComponent<CanvasGroup>();

        if (GameStats.stats.LoadingSavedLevel == false)
        {
            if (GameStats.stats.Rune1 == GameStats.Rune.GreedRune || GameStats.stats.Rune2 == GameStats.Rune.GreedRune)
            {
                GameStats.stats.coins = Mathf.FloorToInt(GameStats.stats.coins * 1.25f);
            }

            if (GameStats.stats.Rune1 == GameStats.Rune.MerchandRune || GameStats.stats.Rune2 == GameStats.Rune.MerchandRune)
            {
                GameStats.stats.MerchantRune = true;
            }

        }


        LightpowerObject = GameStats.stats.UnlockedPowers;
        DarkpowerObject = GameStats.stats.UnlockedPowers;

        for (int i = 0; i < GameStats.stats.UnlockedPowers.Count; i++)
        {

            if (GameStats.stats.UnlockedPowers[i].Rarity == 1)
            {
                UnlockedTier1Spells.Add(GameStats.stats.UnlockedPowers[i]);
            }
            if (GameStats.stats.UnlockedPowers[i].Rarity == 2)
            {
                UnlockedTier2Spells.Add(GameStats.stats.UnlockedPowers[i]);
            }
            if (GameStats.stats.UnlockedPowers[i].Rarity == 3)
            {
                UnlockedTier3Spells.Add(GameStats.stats.UnlockedPowers[i]);
            }
            if (GameStats.stats.UnlockedPowers[i].Rarity == 4)
            {
                UnlockedTier4Spells.Add(GameStats.stats.UnlockedPowers[i]);
            }

        }

        TotalWeight = 0;
        CalculateTables(GameStats.stats.LevelIndicator, GameStats.stats.LevelCount);

        


        coins = GameStats.stats.coins;
        CoinCounter.text = coins.ToString();

        GameStats.stats.SaveStats();
        PopulateShop();

        for (int i = 0; i < PowersInStore.Count; i++)
        {
            TextMeshProUGUI PowerObjectCostText = PowersInStore[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>();
            if (GameStats.stats.MerchantRune == true)
            {
                PowerObjectCostText.text = ((PowersInStorePower[i].Cost) / 2).ToString();
            }
            else
            {
                PowerObjectCostText.text = ((PowersInStorePower[i].Cost).ToString());
            }

        }




        GameStats.stats.LoadingSavedLevel = false;


    }



    private void Update()
    {
        coins = GameStats.stats.coins;
        CoinCounter.text = coins.ToString();
        heartCost = costPerHeart * (GameStats.stats.numOfHearts - 2);
        //if(GameStats.stats.MerchantRune)
        //heartCost = GameStats.stats.numOfHearts * 25;

        //GameStats.stats.coins = coins;
        if (GameStats.stats.MerchantRune == true)
        {
            LightManaCostText.text = (lightManaCost / 2).ToString();
            DarkManaCostText.text = (darkManaCost / 2).ToString();
            heartCostText.text = Mathf.FloorToInt(heartCost / 2).ToString();

        }
        else
        {
            LightManaCostText.text = lightManaCost.ToString();
            DarkManaCostText.text = darkManaCost.ToString();
            heartCostText.text = heartCost.ToString();
        }
        if (GameStats.stats.numOfHearts == 9)
        {
            heartCostText.text = "---";
        }


        LightpowerObject = GameStats.stats.UnlockedPowers;
        DarkpowerObject = GameStats.stats.UnlockedPowers;

        for (int i = 0; i < PowersInStore.Count; i++)
        {
            TextMeshProUGUI PowerObjectCostText = PowersInStore[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>();
            if (GameStats.stats.MerchantRune == true)
            {
                PowerObjectCostText.text = ((PowersInStorePower[i].Cost) / 2).ToString();

            }
            else
            {
                PowerObjectCostText.text = ((PowersInStorePower[i].Cost).ToString());
            }

        }

    }



    private void PopulateShop()
    {
        foreach (var item in table)
        {
            TotalWeight += item;
        }
        

        for (int i = 0; i < 2; i++) /********** Light Powers *************/
        {

            
            int LootChance = Random.Range(0, TotalWeight);
            //foreach (var weight in table)
            for (int weight = 0; weight < table.Length; weight++)
            {
                if (LootChance <= table[weight])
                {
                    // instantiate power
                    if (weight == 0) //Tier 1
                    {
                        int T1 = Random.Range(0, UnlockedTier1Spells.Count);
                        Power PoT1 = UnlockedTier1Spells[T1];
                        GameObject PoT1Object = Instantiate(ShopItemPrefab, shopcontainer);
                        PowersInStore.Add(PoT1Object);
                        PowersInStorePower.Add(PoT1);
                        GameObject T1childSoldout = PoT1Object.transform.GetChild(4).gameObject;
                        Button Pot1Button = PoT1Object.GetComponent<Button>();
                        PoT1Object.GetComponent<Button>().onClick.AddListener(() => OnButtonClickLight(PoT1, T1childSoldout, Pot1Button));
                        PoT1Object.transform.GetChild(2).GetComponent<Image>().sprite = PoT1.iconLight;
                        PoT1Object.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = PoT1.Cost.ToString();
                        PoT1Object.transform.GetChild(0).GetComponent<Image>().color = PoT1.rarityColor;

                       

                        Debug.Log("awarded tier 1");
                        break;
                    }
                    else if (weight == 1) //Tier 2
                    {

                        int T2 = Random.Range(0, UnlockedTier2Spells.Count);
                        Power PoT2 = UnlockedTier2Spells[T2];
                        GameObject PoT2Object = Instantiate(ShopItemPrefab, shopcontainer);
                        PowersInStore.Add(PoT2Object);
                        PowersInStorePower.Add(PoT2);
                        GameObject T1childSoldout = PoT2Object.transform.GetChild(4).gameObject;
                        Button Pot1Button = PoT2Object.GetComponent<Button>();
                        PoT2Object.GetComponent<Button>().onClick.AddListener(() => OnButtonClickLight(PoT2, T1childSoldout, Pot1Button));
                        PoT2Object.transform.GetChild(2).GetComponent<Image>().sprite = PoT2.iconLight;
                        PoT2Object.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = PoT2.Cost.ToString();
                        PoT2Object.transform.GetChild(0).GetComponent<Image>().color = PoT2.rarityColor;
                        Debug.Log("awarded tier 2");
                        break;
                    }
                    else if (weight == 2) //Tier 3
                    {
                        int T3 = Random.Range(0, UnlockedTier3Spells.Count);
                        Power PoT3 = UnlockedTier3Spells[T3];
                        GameObject PoT3Object = Instantiate(ShopItemPrefab, shopcontainer);
                        PowersInStore.Add(PoT3Object);
                        PowersInStorePower.Add(PoT3);
                        GameObject T1childSoldout = PoT3Object.transform.GetChild(4).gameObject;
                        Button Pot1Button = PoT3Object.GetComponent<Button>();
                        PoT3Object.GetComponent<Button>().onClick.AddListener(() => OnButtonClickLight(PoT3, T1childSoldout, Pot1Button));
                        PoT3Object.transform.GetChild(2).GetComponent<Image>().sprite = PoT3.iconLight;
                        PoT3Object.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = PoT3.Cost.ToString();
                        PoT3Object.transform.GetChild(0).GetComponent<Image>().color = PoT3.rarityColor;
                        Debug.Log("awarded tier 3");
                        break;
                    }
                    else if (weight == 3) //Tier 4
                    {
                        int T4 = Random.Range(0, UnlockedTier4Spells.Count);
                        Power PoT4 = UnlockedTier4Spells[T4];
                        GameObject PoT4Object = Instantiate(ShopItemPrefab, shopcontainer);
                        PowersInStore.Add(PoT4Object);
                        PowersInStorePower.Add(PoT4);
                        GameObject T4childSoldout = PoT4Object.transform.GetChild(4).gameObject;
                        Button Pot4Button = PoT4Object.GetComponent<Button>();
                        PoT4Object.GetComponent<Button>().onClick.AddListener(() => OnButtonClickLight(PoT4, T4childSoldout, Pot4Button));
                        PoT4Object.transform.GetChild(2).GetComponent<Image>().sprite = PoT4.iconLight;
                        PoT4Object.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = PoT4.Cost.ToString();
                        PoT4Object.transform.GetChild(0).GetComponent<Image>().color = PoT4.rarityColor;
                        Debug.Log("awarded tier 4");
                        break;
                    }

                    else
                    {
                        Debug.Log("Power loot table  Error");
                    }

                }
                else
                {
                    LootChance -= table[weight];
                }
            }

        }

        for (int i = 0; i < 2; i++) /********** Dark Powers *************/
        {

            int LootChance = Random.Range(0, TotalWeight);
            //foreach (var weight in table)
            for (int weight = 0; weight < table.Length; weight++)
            {
                if (LootChance <= table[weight])
                {
                    // instantiate power
                    if (weight == 0) //Tier 1
                    {
                        int T1 = Random.Range(0, UnlockedTier1Spells.Count);
                        Power PoT1 = UnlockedTier1Spells[T1];
                        GameObject PoT1Object = Instantiate(ShopItemPrefab, shopcontainer);
                        PowersInStore.Add(PoT1Object);
                        PowersInStorePower.Add(PoT1);
                        GameObject T1childSoldout = PoT1Object.transform.GetChild(4).gameObject;
                        Button Pot1Button = PoT1Object.GetComponent<Button>();
                        PoT1Object.GetComponent<Button>().onClick.AddListener(() => OnButtonClickDark(PoT1, T1childSoldout, Pot1Button));
                        PoT1Object.transform.GetChild(2).GetComponent<Image>().sprite = PoT1.iconDark;
                        PoT1Object.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = PoT1.Cost.ToString();
                        PoT1Object.transform.GetChild(0).GetComponent<Image>().color = PoT1.rarityColor;



                        Debug.Log("awarded tier 1");
                        break;
                    }
                    else if (weight == 1) //Tier 2
                    {

                        int T2 = Random.Range(0, UnlockedTier2Spells.Count);
                        Power PoT2 = UnlockedTier2Spells[T2];
                        GameObject PoT2Object = Instantiate(ShopItemPrefab, shopcontainer);
                        PowersInStore.Add(PoT2Object);
                        PowersInStorePower.Add(PoT2);
                        GameObject T1childSoldout = PoT2Object.transform.GetChild(4).gameObject;
                        Button Pot1Button = PoT2Object.GetComponent<Button>();
                        PoT2Object.GetComponent<Button>().onClick.AddListener(() => OnButtonClickDark(PoT2, T1childSoldout, Pot1Button));
                        PoT2Object.transform.GetChild(2).GetComponent<Image>().sprite = PoT2.iconDark;
                        PoT2Object.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = PoT2.Cost.ToString();
                        PoT2Object.transform.GetChild(0).GetComponent<Image>().color = PoT2.rarityColor;
                        Debug.Log("awarded tier 2");
                        break;
                    }
                    else if (weight == 2) //Tier 3
                    {
                        int T3 = Random.Range(0, UnlockedTier3Spells.Count);
                        Power PoT3 = UnlockedTier3Spells[T3];
                        GameObject PoT3Object = Instantiate(ShopItemPrefab, shopcontainer);
                        PowersInStore.Add(PoT3Object);
                        PowersInStorePower.Add(PoT3);
                        GameObject T1childSoldout = PoT3Object.transform.GetChild(4).gameObject;
                        Button Pot1Button = PoT3Object.GetComponent<Button>();
                        PoT3Object.GetComponent<Button>().onClick.AddListener(() => OnButtonClickDark(PoT3, T1childSoldout, Pot1Button));
                        PoT3Object.transform.GetChild(2).GetComponent<Image>().sprite = PoT3.iconDark;
                        PoT3Object.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = PoT3.Cost.ToString();
                        PoT3Object.transform.GetChild(0).GetComponent<Image>().color = PoT3.rarityColor;
                        Debug.Log("awarded tier 3");
                        break;
                    }
                    else if (weight == 3) //Tier 4
                    {
                        int T4 = Random.Range(0, UnlockedTier4Spells.Count);
                        Power PoT4 = UnlockedTier4Spells[T4];
                        GameObject PoT4Object = Instantiate(ShopItemPrefab, shopcontainer);
                        PowersInStore.Add(PoT4Object);
                        PowersInStorePower.Add(PoT4);
                        GameObject T4childSoldout = PoT4Object.transform.GetChild(4).gameObject;
                        Button Pot4Button = PoT4Object.GetComponent<Button>();
                        PoT4Object.GetComponent<Button>().onClick.AddListener(() => OnButtonClickDark(PoT4, T4childSoldout, Pot4Button));
                        PoT4Object.transform.GetChild(2).GetComponent<Image>().sprite = PoT4.iconDark;
                        PoT4Object.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = PoT4.Cost.ToString();
                        PoT4Object.transform.GetChild(0).GetComponent<Image>().color = PoT4.rarityColor;
                        Debug.Log("awarded tier 4");
                        break;
                    }

                    else
                    {
                        Debug.Log("Power loot table  Error");
                    }

                }
                else
                {
                    LootChance -= table[weight];
                }
            }

        }
    }

   


    private void CalculateTables(int LevelIdicator = 1, int levelcount = 0)
    {
        for(int i = 0; i < TablesPerLevelList.Count; i++) //check Levels
        {
         if(TablesPerLevelList[i].LevelIndicator == LevelIdicator)
            {
                if(TablesPerLevelList[i].LevelCount == levelcount)
                {
                    if(UnlockedTier1Spells.Count != 0)
                    {
                        table[0] = TablesPerLevelList[i].TableValues[0];
                    }
                    else
                    {
                        table[0] = 0;
                    }
                    if (UnlockedTier2Spells.Count != 0)
                    {
                        table[1] = TablesPerLevelList[i].TableValues[1];
                    }
                    else
                    {
                        table[1] = 0;
                    }
                    if (UnlockedTier3Spells.Count != 0)
                    {
                        table[2] = TablesPerLevelList[i].TableValues[2];
                    }
                    else
                    {
                        table[2] = 0;
                    }
                    if (UnlockedTier4Spells.Count != 0)
                    {
                        table[3] = TablesPerLevelList[i].TableValues[3];
                    }
                    else
                    {
                        table[3] = 0;
                    }
                }
            }
        }
            
    }
    private void OnButtonClickLight(Power power, GameObject SoldOut, Button powerbutton)
    {

        BuyButton.onClick.AddListener(() => OnLightButtonBuy(power, SoldOut, powerbutton));
        Display.SetActive(true);

        PowerImage.sprite = power.iconLight;

        if (GameStats.stats.LanguageSelect == 0)
        {
            PowerName.text = power.name;
            powerDescription.text = power.description;

        }
        else if (GameStats.stats.LanguageSelect == 1)
        {
            PowerName.text = power.Español_Name;
            powerDescription.text = power.Español_Description;
        }

        PowerCost.text = power.Cost.ToString();
        Manacost.text = power.mana.ToString();
        PowerDamage.text = power.Damage.ToString();
        PowerTier.text = power.Rarity.ToString();
        PowerTierBG.color = power.rarityColor;

        /*
        Debug.Log(power.name);
        if (GameStats.stats.coins >= power.Cost)
        {
            GameStats.stats.powerLight = power;
            //GameStats.stats.lightPowerSprite = power.iconLight;
            //GameStats.stats.lightpowerID = power.id;
           // GameStats.stats.coins -= power.Cost;

            SoldOut.SetActive (true);
            powerbutton.interactable = false;

        }
        else
        {
            print("You don't have enough coins!!!");
            //Play sound
        }
        */
    }

    private void OnButtonClickDark(Power power, GameObject SoldOut, Button powerbutton)
    {

        BuyButton.onClick.AddListener(() => OnDarkButtonClicBuy(power, SoldOut, powerbutton));
        Display.SetActive(true);

        PowerImage.sprite = power.iconDark;
        if (GameStats.stats.LanguageSelect == 0)
        {
            PowerName.text = power.name;
            powerDescription.text = power.description;
        }
        else if (GameStats.stats.LanguageSelect == 1)
        {
            PowerName.text = power.Español_Name;
            powerDescription.text = power.Español_Description;
        }

        PowerCost.text = power.Cost.ToString();
        Manacost.text = power.mana.ToString();
        PowerDamage.text = power.Damage.ToString();
        PowerTier.text = power.Rarity.ToString();
        PowerTierBG.color = power.rarityColor;

        /*
        Debug.Log(power.name);
        if (GameStats.stats.coins >= power.Cost)
        {
            GameStats.stats.powerDark = power;
           // GameStats.stats.darkPowerSprite = power.iconDark;
            //GameStats.stats.DarkpowerID = power.id;
           // GameStats.stats.coins -= power.Cost;

            SoldOut.SetActive(true);
            powerbutton.interactable = false;
        }
        else
        {
            print("You don't have enough coins!!!");
            //Play sound
        }
        */
    }


    // buy power?

    public void OnLightButtonBuy(Power power, GameObject SoldOut, Button powerbutton)
    {
        if (GameStats.stats.MerchantRune == true)
        {
            if (GameStats.stats.coins >= power.Cost / 2)
            {
                GameStats.stats.powerLight = power;
                GameStats.stats.savedLightPowerID = GameStats.stats.powerLight.id;


                GameStats.stats.MerchantRune = false;
                GameStats.stats.coins -= (power.Cost / 2);

                if (GameStats.stats.MoneySpent < 2000)
                {
                    GameStats.stats.MoneySpent += power.Cost / 2;
                }


                SoldOut.SetActive(true);
                powerbutton.interactable = false;
                BuyButton.onClick.RemoveAllListeners();
                Display.SetActive(false);

            }
            else
            {
                notEnoughCoins();
                //StartCoroutine(NotEnoughCoins());
                //print("You don't have enough coins!!!");
                //Play sound
            }
        }
        else
        {
            if (GameStats.stats.coins >= power.Cost)
            {
                GameStats.stats.powerLight = power;
                GameStats.stats.savedLightPowerID = GameStats.stats.powerLight.id;


                GameStats.stats.coins -= power.Cost;


                if (GameStats.stats.MoneySpent < 2000)
                {
                    GameStats.stats.MoneySpent += power.Cost;
                }


                SoldOut.SetActive(true);
                powerbutton.interactable = false;
                BuyButton.onClick.RemoveAllListeners();
                Display.SetActive(false);

            }
            else
            {
                notEnoughCoins();
                //StartCoroutine(NotEnoughCoins());
                //print("You don't have enough coins!!!");
                //Play sound
            }
        }


    }



    public void OnDarkButtonClicBuy(Power power, GameObject SoldOut, Button powerbutton)

    {

        if (GameStats.stats.MerchantRune == true)
        {
            if (GameStats.stats.coins >= power.Cost / 2)
            {
                GameStats.stats.powerDark = power;
                GameStats.stats.savedDarkPowerID = GameStats.stats.powerDark.id;



                GameStats.stats.MerchantRune = false;
                GameStats.stats.coins -= (power.Cost / 2);


                if (GameStats.stats.MoneySpent < 2000)
                {
                    GameStats.stats.MoneySpent += power.Cost / 2;
                }

                SoldOut.SetActive(true);
                powerbutton.interactable = false;
                BuyButton.onClick.RemoveAllListeners();
                Display.SetActive(false);
            }
            else
            {
                notEnoughCoins();
                //StartCoroutine(NotEnoughCoins());
                //print("You don't have enough coins!!!");
                //Play sound
            }
        }
        else
        {
            if (GameStats.stats.coins >= power.Cost)
            {
                GameStats.stats.powerDark = power;
                GameStats.stats.savedDarkPowerID = GameStats.stats.powerDark.id;




                GameStats.stats.coins -= power.Cost;


                if (GameStats.stats.MoneySpent < 2000)
                {
                    GameStats.stats.MoneySpent += power.Cost;
                }

                SoldOut.SetActive(true);
                powerbutton.interactable = false;
                BuyButton.onClick.RemoveAllListeners();
                Display.SetActive(false);
            }
            else
            {
                notEnoughCoins();
                //StartCoroutine(NotEnoughCoins());
                //print("You don't have enough coins!!!");
                //Play sound
            }
        }

    }

    public void Back()
    {
        BuyButton.onClick.RemoveAllListeners();
        Display.SetActive(false);

    }



    public void OnButtonClickHeart()
    {
        if (GameStats.stats.numOfHearts < 18)
        {
            if (GameStats.stats.MerchantRune == true)
            {
                if (GameStats.stats.coins >= heartCost / 2)
                {
                    GameStats.stats.numOfHearts += 2;
                    GameStats.stats.coins -= heartCost / 2;
                    GameStats.stats.MerchantRune = false;
                    GameStats.stats.SaveCurrentHearts = GameStats.stats.numOfHearts;
                    GameStats.stats.SaveStats();
                    if (GameStats.stats.MoneySpent < 1000)
                    {
                        GameStats.stats.MoneySpent += heartCost / 2;
                    }
                    //print("Bought heart");
                }
                else
                {
                    notEnoughCoins();
                    //StartCoroutine(NotEnoughCoins());
                    //print("You don't have enough coins!!!");
                    //Play sound
                }
            }
            else
            {
                if (GameStats.stats.coins >= heartCost)
                {
                    GameStats.stats.numOfHearts += 2;
                    GameStats.stats.coins -= heartCost;
                    GameStats.stats.SaveCurrentHearts = GameStats.stats.numOfHearts;
                    GameStats.stats.SaveStats();
                    if (GameStats.stats.MoneySpent < 2000)
                    {
                        GameStats.stats.MoneySpent += heartCost;
                    }
                    //print("Bought heart");
                }
                else
                {
                    notEnoughCoins();
                    //StartCoroutine(NotEnoughCoins());
                    //print("You don't have enough coins!!!");
                    //Play sound
                }
            }

        }
        else
        {
            // print("You have max hearts");
        }
    }
    public void OnButtonLightMana()
    {
        if (GameStats.stats.MerchantRune == true)
        {
            if (GameStats.stats.coins >= lightManaCost / 2)
            {
                GameStats.stats.totalLightMana += 10;
                BuyLightManaEffect.Play();

                GameStats.stats.coins -= lightManaCost / 2;
                GameStats.stats.MerchantRune = false;
                if (GameStats.stats.MoneySpent < 2000)
                {
                    GameStats.stats.MoneySpent += lightManaCost / 2;
                }
                //print("Bought Light Mana");
            }
            else
            {
                notEnoughCoins();
                //StartCoroutine(NotEnoughCoins());
                //print("You don't have enough coins!!!");
                //Play sound
            }
        }
        else
        {
            if (GameStats.stats.coins >= lightManaCost)
            {
                GameStats.stats.totalLightMana += 10;
                GameStats.stats.coins -= lightManaCost;
                if (GameStats.stats.MoneySpent < 2000)
                {
                    GameStats.stats.MoneySpent += lightManaCost;
                }
                // print("Bought Light Mana");
            }
            else
            {
                notEnoughCoins();
                //StartCoroutine(NotEnoughCoins());
                //print("You don't have enough coins!!!");
                //Play sound
            }
        }

    }
    public void OnButtonDarkMana()
    {
        if (GameStats.stats.MerchantRune == true)
        {
            if (GameStats.stats.coins >= darkManaCost / 2)
            {
                GameStats.stats.totalDarkMana += 10;
                BuyDarkManaEffect.Play();
                GameStats.stats.coins -= darkManaCost / 2;
                GameStats.stats.MerchantRune = false;
                if (GameStats.stats.MoneySpent < 2000)
                {
                    GameStats.stats.MoneySpent += darkManaCost / 2;
                }
                // print("Bought Dark Mana");
            }
            else
            {
                notEnoughCoins();
                //StartCoroutine(NotEnoughCoins());
                //print("You don't have enough coins!!!");
                //Play sound
            }
        }
        else
        {
            if (GameStats.stats.coins >= darkManaCost)
            {
                GameStats.stats.totalDarkMana += 10;
                GameStats.stats.coins -= darkManaCost;
                if (GameStats.stats.MoneySpent < 2000)
                {
                    GameStats.stats.MoneySpent += darkManaCost;
                }
                //print("Bought Dark Mana");
            }
            else
            {
                notEnoughCoins();
                //StartCoroutine(NotEnoughCoins());
                //print("You don't have enough coins!!!");
                //Play sound
            }
        }

    }


    void notEnoughCoins()
    {
        //print("You don't have enough coins!!!");
        LeanTween.cancel(NoCoinsCanvasG.gameObject);

        LeanTween.alphaCanvas(NoCoinsCanvasG, 1, 0.5f);
        LeanTween.alphaCanvas(NoCoinsCanvasG, 0, 0.5f).setDelay(1);

    }

    /*
    IEnumerator NotEnoughCoins()
    {
        noCoinsPopUp.SetActive(true);
        yield return new WaitForSeconds(2);
        noCoinsPopUp.SetActive(false);
        


    }
    */


/* previous Populateshop
 
   private void PopulateShop()
{
    foreach (var item in table)
    {
        TotalWeight += item;
    }

    for (int i = 0; i < 2; i++)
    {

        int LootChance = Random.Range(1, TotalWeight);
        //foreach (var weight in table)
        for (int weight = 0; weight < table.Length; weight++)
        {
            if (LootChance <= table[weight])
            {
                // instantiate power
                if (weight == 0) //Tier 1
                {
                    Debug.Log("awarded tier 1");
                }
                if (weight == 1) //Tier 2
                {
                    Debug.Log("awarded tier 2");
                }
                if (weight == 2) //Tier 3
                {
                    Debug.Log("awarded tier 3");
                }
                if (weight == 3) //Tier 4
                {
                    Debug.Log("awarded tier 4");
                }

            }
            else
            {
                LootChance -= table[weight];
            }
        }


        var r = Random.Range(0, LightpowerObject.Count);
        var tmp = LightpowerObject[i];
        LightpowerObject[i] = LightpowerObject[r];
        LightpowerObject[r] = tmp;

        Power Po = LightpowerObject[i];
        GameObject powerobject = Instantiate(ShopItemPrefab, shopcontainer);
        PowersInStore.Add(powerobject);
        PowersInStorePower.Add(Po);
        GameObject childSoldout = powerobject.transform.GetChild(4).gameObject;
        Button PowerButton = powerobject.GetComponent<Button>();






        // this acces the prfab's component, change it based off item structure
        // WhitepowerShop (image button)
        // power image (image)
        // cost (textMeshProUGUI)

        //grab button, assign function to on click.
        powerobject.GetComponent<Button>().onClick.AddListener(() => OnButtonClickLight(Po, childSoldout, PowerButton));



        powerobject.transform.GetChild(2).GetComponent<Image>().sprite = Po.iconLight;
        powerobject.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = Po.Cost.ToString();
        powerobject.transform.GetChild(0).GetComponent<Image>().color = Po.rarityColor;




    }

    for (int i = 0; i < 2; i++)
    {
        var r = Random.Range(0, DarkpowerObject.Count);
        var tmp = DarkpowerObject[i];
        DarkpowerObject[i] = DarkpowerObject[r];
        DarkpowerObject[r] = tmp;

        Power Po = DarkpowerObject[i];
        GameObject powerobject = Instantiate(ShopItemPrefab, shopcontainer);
        PowersInStore.Add(powerobject);
        PowersInStorePower.Add(Po);
        GameObject childSoldout = powerobject.transform.GetChild(4).gameObject;
        Button PowerButton = powerobject.GetComponent<Button>();




        // this acces the prfab's component, change it based off item structure
        // WhitepowerShop (image button)
        // power image (image)
        // cost (textMeshProUGUI)

        //grab button, assign function to on click.
        powerobject.GetComponent<Button>().onClick.AddListener(() => OnButtonClickDark(Po, childSoldout, PowerButton));


        powerobject.transform.GetChild(2).GetComponent<Image>().sprite = Po.iconDark;
        powerobject.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = Po.Cost.ToString();
        powerobject.transform.GetChild(0).GetComponent<Image>().color = Po.rarityColor;



    }
}
 */ 

}
