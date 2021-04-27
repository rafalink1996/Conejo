
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour
{

    string Crystal80 = "com.darkelectron.magicbound.crystals80";
    string Crystal500 = "com.darkelectron.magicbound.crystals500";
    string Crystal1200 = "com.darkelectron.magicbound.crystals1200";
    string Crystal3000 = "com.darkelectron.magicbound.crystals3000";

    string SkinPack = "com.darkelectron.magicbound.skin_pack";
    string RemoveAds = "com.darkelectron.magicbound.remove_ads";

    public GameObject RestorePurchasesButton;


    private void Awake()
    {
        if (Application.platform != RuntimePlatform.IPhonePlayer)
        {
            DisableRestorePurchaseButton();
        }
    }

    public void OnPurchaseComplete (Product product)
    {
        if (product.definition.id == Crystal80)
        {
            // give the player 80 crystals
            GameStats.stats.crystals += 80;
            GameStats.stats.SaveStats();
        }

       else  if (product.definition.id == Crystal500)
        {
            // give the player 500 crystals
            GameStats.stats.crystals += 500;
            GameStats.stats.SaveStats();
        }
       else if (product.definition.id == Crystal1200)
        {
            // give the player 1200 crystals
            GameStats.stats.crystals += 1200;
            GameStats.stats.SaveStats();
        }
        else if (product.definition.id == Crystal3000)
        {
            // give the player 3000 crystals
            GameStats.stats.crystals += 3000;
            GameStats.stats.SaveStats();
        }
        else if (product.definition.id == SkinPack)
        {
            // unlock premium skins
            GameStats.stats.skinConditions[1] = true;
            GameStats.stats.SaveStats();
        }
        else if (product.definition.id == RemoveAds)
        {
            // remove all ads
            GameStats.stats.NoAdsBought = true;
            GameStats.stats.SaveStats();
        }
    }

    public void OnPurchaseFailed (Product product, PurchaseFailureReason reason)
    {
        Debug.Log("the product " + product.definition.id + " failed due to " + reason);
    }

    private void DisableRestorePurchaseButton()
    {
        RestorePurchasesButton.SetActive(false);
    }
}

