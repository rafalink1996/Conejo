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



    public GameObject noCoinsPopUp;
    public float costPerHeart;
    public float heartCost;
    public float lightManaCost;
    public float darkManaCost;

    private List<GameObject> PowersInStore = new List<GameObject>();
    [SerializeField] private List<Power> PowersInStorePower = new List<Power>();

    public TextMeshProUGUI LightManaCostText;
    public TextMeshProUGUI DarkManaCostText;






    private void Start()
    {
        if (GameStats.stats.Rune1 == GameStats.Rune.GreedRune || GameStats.stats.Rune2 == GameStats.Rune.GreedRune)
        {
            GameStats.stats.coins = Mathf.FloorToInt(coins * 1.25f);
        }

        if (GameStats.stats.Rune1 == GameStats.Rune.MerchandRune || GameStats.stats.Rune2 == GameStats.Rune.MerchandRune)
        {
            GameStats.stats.MerchantRune = true;
        }
        LightpowerObject = GameStats.stats.UnlockedPowers;
        DarkpowerObject = GameStats.stats.UnlockedPowers;

        coins = GameStats.stats.coins;
        CoinCounter.text = coins.ToString();

        GameStats.stats.SaveStats();
        PopulateShop();

        for (int i = 0; i < PowersInStore.Count; i++)
        {
            TextMeshProUGUI PowerObjectCostText = PowersInStore[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>();
            if(GameStats.stats.MerchantRune == true)
            {
                PowerObjectCostText.text = ((PowersInStorePower[i].Cost) / 2).ToString();
            }
            else
            {
                PowerObjectCostText.text = ((PowersInStorePower[i].Cost).ToString());
            }
            
        }
            

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
            LightManaCostText.text = (lightManaCost/2).ToString();
            DarkManaCostText.text = (darkManaCost / 2).ToString();
            heartCostText.text = Mathf.FloorToInt(heartCost/2).ToString();
           
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
        for (int i = 0; i < 2; i++)

        {
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

    private void OnButtonClickLight(Power power, GameObject SoldOut, Button powerbutton)
    {

        BuyButton.onClick.AddListener(() => OnLightButtonBuy(power, SoldOut, powerbutton));
        Display.SetActive(true);

        PowerImage.sprite = power.iconLight;
        PowerName.text = power.name;
        Manacost.text = power.mana.ToString();
        PowerDamage.text = power.Damage.ToString();
        powerDescription.text = power.description;
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
        PowerName.text = power.name;
        Manacost.text = power.mana.ToString();
        PowerDamage.text = power.Damage.ToString();
        powerDescription.text = power.description;
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
            if (GameStats.stats.coins >= power.Cost/2)
            {
                GameStats.stats.powerLight = power;
                GameStats.stats.savedLightPowerID = GameStats.stats.powerLight.id;
               
               
                GameStats.stats.MerchantRune = false;
                GameStats.stats.coins -= (power.Cost / 2);
                
                if (GameStats.stats.MoneySpent < 1000)
                {
                    GameStats.stats.MoneySpent += power.Cost/2;
                }


                SoldOut.SetActive(true);
                powerbutton.interactable = false;
                BuyButton.onClick.RemoveAllListeners();
                Display.SetActive(false);

            }
            else
            {
                StartCoroutine(NotEnoughCoins());
                print("You don't have enough coins!!!");
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
                

                if (GameStats.stats.MoneySpent < 1000)
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
                StartCoroutine(NotEnoughCoins());
                print("You don't have enough coins!!!");
                //Play sound
            }
        }
       

    }


 
    public void OnDarkButtonClicBuy(Power power, GameObject SoldOut, Button powerbutton)

    {
        
        if (GameStats.stats.MerchantRune == true)
        {
            if (GameStats.stats.coins >= power.Cost/2)
            {
                GameStats.stats.powerDark = power;
                GameStats.stats.savedDarkPowerID = GameStats.stats.powerDark.id;


                
               GameStats.stats.MerchantRune = false;
               GameStats.stats.coins -= (power.Cost / 2);
                

                if (GameStats.stats.MoneySpent < 1000)
                {
                    GameStats.stats.MoneySpent += power.Cost/2;
                }

                SoldOut.SetActive(true);
                powerbutton.interactable = false;
                BuyButton.onClick.RemoveAllListeners();
                Display.SetActive(false);
            }
            else
            {
                StartCoroutine(NotEnoughCoins());
                print("You don't have enough coins!!!");
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
                

                if (GameStats.stats.MoneySpent < 1000)
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
                StartCoroutine(NotEnoughCoins());
                print("You don't have enough coins!!!");
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
        if (GameStats.stats.numOfHearts < 9)
        {
            if(GameStats.stats.MerchantRune == true)
            {
                if (GameStats.stats.coins >= heartCost/2)
                {
                    GameStats.stats.numOfHearts += 1;
                    GameStats.stats.coins -= heartCost/2;
                    GameStats.stats.MerchantRune = false;
                    GameStats.stats.SaveCurrentHearts = GameStats.stats.numOfHearts;
                    GameStats.stats.SaveStats();
                    if (GameStats.stats.MoneySpent < 1000)
                    {
                        GameStats.stats.MoneySpent += heartCost/2;
                    }
                    //print("Bought heart");
                }
                else
                {
                    StartCoroutine(NotEnoughCoins());
                    print("You don't have enough coins!!!");
                    //Play sound
                }
            }
            else
            {
                if (GameStats.stats.coins >= heartCost)
                {
                    GameStats.stats.numOfHearts += 1;
                    GameStats.stats.coins -= heartCost;
                    GameStats.stats.SaveCurrentHearts = GameStats.stats.numOfHearts;
                    GameStats.stats.SaveStats();
                    if (GameStats.stats.MoneySpent < 1000)
                    {
                        GameStats.stats.MoneySpent += heartCost;
                    }
                    //print("Bought heart");
                }
                else
                {
                    StartCoroutine(NotEnoughCoins());
                    print("You don't have enough coins!!!");
                    //Play sound
                }
            }
           
        }
        else
        {
            print("You have max hearts");
        }
    }
    public void OnButtonLightMana()
    {
        if(GameStats.stats.MerchantRune == true)
        {
            if (GameStats.stats.coins >= lightManaCost/2)
            {
                GameStats.stats.totalLightMana += 10;
                GameStats.stats.coins -= lightManaCost/2;
                GameStats.stats.MerchantRune = false;
                if (GameStats.stats.MoneySpent < 1000)
                {
                    GameStats.stats.MoneySpent += lightManaCost/2;
                }
                print("Bought Light Mana");
            }
            else
            {
                StartCoroutine(NotEnoughCoins());
                print("You don't have enough coins!!!");
                //Play sound
            }
        }
        else
        {
            if (GameStats.stats.coins >= lightManaCost)
            {
                GameStats.stats.totalLightMana += 10;
                GameStats.stats.coins -= lightManaCost;
                if (GameStats.stats.MoneySpent < 1000)
                {
                    GameStats.stats.MoneySpent += lightManaCost;
                }
                print("Bought Light Mana");
            }
            else
            {
                StartCoroutine(NotEnoughCoins());
                print("You don't have enough coins!!!");
                //Play sound
            }
        }
       
    }
    public void OnButtonDarkMana()
    {
        if (GameStats.stats.MerchantRune == true)
        {
            if (GameStats.stats.coins >= darkManaCost/2)
            {
                GameStats.stats.totalDarkMana += 10;
                GameStats.stats.coins -= darkManaCost/2;
                GameStats.stats.MerchantRune = false;
                if (GameStats.stats.MoneySpent < 1000)
                {
                    GameStats.stats.MoneySpent += darkManaCost/2;
                }
                print("Bought Dark Mana");
            }
            else
            {
                StartCoroutine(NotEnoughCoins());
                print("You don't have enough coins!!!");
                //Play sound
            }
        }
        else
        {
            if (GameStats.stats.coins >= darkManaCost)
            {
                GameStats.stats.totalDarkMana += 10;
                GameStats.stats.coins -= darkManaCost;
                if (GameStats.stats.MoneySpent < 1000)
                {
                    GameStats.stats.MoneySpent += darkManaCost;
                }
                print("Bought Dark Mana");
            }
            else
            {
                StartCoroutine(NotEnoughCoins());
                print("You don't have enough coins!!!");
                //Play sound
            }
        }
       
    }




    IEnumerator NotEnoughCoins()
    {
        noCoinsPopUp.SetActive(true);
        yield return new WaitForSeconds(2);
        noCoinsPopUp.SetActive(false);
        


    }

}
