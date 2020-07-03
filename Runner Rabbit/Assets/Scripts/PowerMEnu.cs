using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerMEnu : MonoBehaviour
{
    public Animator powerbuttontransition;
    
        
    // transition to power menu
    public GameObject mainmenu;
    public GameObject powermenu;
    public GameObject TowerDark;
    public GameObject TowerLight;


    public float transitionTimein;
    public float transitionTimeout;


    // store manager
    public float FenixFeatherCost;
    public float PortalBoostCost;
    public float CoinTicketCost;
    public float Level1toBossCost;
    public float level2Cost;

    public TextMeshProUGUI FenixFeather;
    public TextMeshProUGUI PortalBoost;
    public TextMeshProUGUI CoinTicket;


    private void Start()
    {
        FenixFeather.text = FenixFeatherCost.ToString();
        PortalBoost.text = PortalBoostCost.ToString();
        CoinTicket.text = CoinTicketCost.ToString();
        
    }



    public void PowerMenu ()
    {
        powerbuttontransition.SetTrigger("Powers");
       

        StartCoroutine(GoToPowersMenu());
    }

    public void PowerMenuBack()
    {
        powerbuttontransition.SetTrigger("Powers Out");
      

        StartCoroutine(backfromPowersMenu());
    }

    IEnumerator GoToPowersMenu ()
    {

        yield return new WaitForSeconds(transitionTimein);

        powermenu.SetActive(true);
        TowerDark.SetActive(false);
        TowerDark.SetActive(false);
        
        Debug.Log("powermenu!");

        yield return null;
    }

    IEnumerator backfromPowersMenu()
    {
        
        yield return new WaitForSeconds(transitionTimeout);

        mainmenu.SetActive(true);
        TowerDark.SetActive(true);
        TowerDark.SetActive(true);

        yield return null;
    }


    public void BuyItem(float ItemID)
    {
        if (ItemID == 1)
        {
            if (GameStats.stats.crystals >= CoinTicketCost)
            {
                GameStats.stats.crystals -= CoinTicketCost;
                GameStats.stats.CoinTicket = true;

            }
            else
            {
                Debug.Log("not enough crystals");
            }

        }

        if (ItemID == 2)
        {
            if (GameStats.stats.crystals >= PortalBoostCost)
            {
                GameStats.stats.crystals -= PortalBoostCost;
                GameStats.stats.PortalBoost = true;

            }
            else
            {
                Debug.Log("not enough crystals");
            }
        }

        if (ItemID == 3)
        {
            if (GameStats.stats.crystals >= FenixFeatherCost)
            {
                GameStats.stats.crystals -= FenixFeatherCost;
                GameStats.stats.fenixFeather = true;

            }
            else
            {
                Debug.Log("not enough crystals");
            }
        }
    }
}
