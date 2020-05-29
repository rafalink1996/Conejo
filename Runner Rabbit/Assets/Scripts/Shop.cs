﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{




    [Header("list of items sold")]
    [SerializeField] private Power[] LightpowerObject;
    [SerializeField] private Power[] DarkpowerObject;


    [Header("References")]
    [SerializeField] private Transform shopcontainer;
    [SerializeField] private GameObject ShopItemPrefab;


    

    private void Start()
    {
        

       


        PopulateShop();
        
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

           

            

            // this acces the prfab's component, change it based off item structure
            // WhitepowerShop (image button)
            // power image (image)
            // cost (textMeshProUGUI)

            //grab button, assign function to on click.
            powerobject.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(Po));
       

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



            // this acces the prfab's component, change it based off item structure
            // WhitepowerShop (image button)
            // power image (image)
            // cost (textMeshProUGUI)

            //grab button, assign function to on click.
            powerobject.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(Po));


            powerobject.transform.GetChild(1).GetComponent<Image>().sprite = Po.iconDark;
            powerobject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = Po.Cost.ToString();


        }
    }

    private void OnButtonClick(Power power)
    {
        Debug.Log(power.name);
    }

}
