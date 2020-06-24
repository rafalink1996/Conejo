﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{

    private float coins;
    
    public TextMeshProUGUI CoinCounter;
    

    private GameObject childObj;

    [Header("List of Items Sold")]
    [SerializeField] public Power[] LightpowerObject;
    [SerializeField] public Power[] DarkpowerObject;


    [Header("References")]
    [SerializeField] public Transform shopcontainer;
    [SerializeField] public GameObject ShopItemPrefab;




    private void Start()
    {


        coins = GameStats.stats.coins;
        CoinCounter.text = coins.ToString();
       
        PopulateShop();

    }

    private void Update()
    {
        coins = GameStats.stats.coins;
        CoinCounter.text = coins.ToString();
        
        //GameStats.stats.coins = coins;
    }

    private void PopulateShop()
    {
        for (int i = 0; i < 2; i++)

        {
            var r = Random.Range(0, LightpowerObject.Length);
            var tmp = LightpowerObject[i];
            LightpowerObject[i] = LightpowerObject[r];
            LightpowerObject[r] = tmp;

            Power Po = LightpowerObject[i];
            GameObject powerobject = Instantiate(ShopItemPrefab, shopcontainer);
            GameObject childSoldout = powerobject.transform.GetChild(3).gameObject;
            Button PowerButton = powerobject.GetComponent<Button>();






            // this acces the prfab's component, change it based off item structure
            // WhitepowerShop (image button)
            // power image (image)
            // cost (textMeshProUGUI)

            //grab button, assign function to on click.
            powerobject.GetComponent<Button>().onClick.AddListener(() => OnButtonClickLight(Po, childSoldout, PowerButton));
            


            powerobject.transform.GetChild(1).GetComponent<Image>().sprite = Po.iconLight;
            powerobject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = Po.Cost.ToString();
            
           


        }

        for (int i = 0; i < 2; i++)
        {
            var r = Random.Range(0, DarkpowerObject.Length);
            var tmp = DarkpowerObject[i];
            DarkpowerObject[i] = DarkpowerObject[r];
            DarkpowerObject[r] = tmp;

            Power Po = DarkpowerObject[i];
            GameObject powerobject = Instantiate(ShopItemPrefab, shopcontainer);
            GameObject childSoldout = powerobject.transform.GetChild(3).gameObject;
            Button PowerButton = powerobject.GetComponent<Button>();



            // this acces the prfab's component, change it based off item structure
            // WhitepowerShop (image button)
            // power image (image)
            // cost (textMeshProUGUI)

            //grab button, assign function to on click.
            powerobject.GetComponent<Button>().onClick.AddListener(() => OnButtonClickDark(Po, childSoldout, PowerButton));


            powerobject.transform.GetChild(1).GetComponent<Image>().sprite = Po.iconDark;
            powerobject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = Po.Cost.ToString();
           


        }
    }

    private void OnButtonClickLight(Power power, GameObject SoldOut, Button powerbutton)
    {
        Debug.Log(power.name);
        if (GameStats.stats.coins >= power.Cost)
        {
            GameStats.stats.powerLight = power;
            GameStats.stats.lightPowerSprite = power.iconLight;
            GameStats.stats.lightpowerID = power.id;
            GameStats.stats.coins -= power.Cost;

            SoldOut.SetActive (true);
            powerbutton.interactable = false;

        }
        else
        {
            print("You don't have enough coins!!!");
            //Play sound
        }
    }

    private void OnButtonClickDark(Power power, GameObject SoldOut, Button powerbutton)
    {
        Debug.Log(power.name);
        if (GameStats.stats.coins >= power.Cost)
        {
            GameStats.stats.powerDark = power;
            GameStats.stats.darkPowerSprite = power.iconDark;
            GameStats.stats.DarkpowerID = power.id;
            GameStats.stats.coins -= power.Cost;

            SoldOut.SetActive(true);
            powerbutton.interactable = false;
        }
        else
        {
            print("You don't have enough coins!!!");
            //Play sound
        }
    }
 

}
