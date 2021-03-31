using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpsDisplay : MonoBehaviour
{

    public Image X2Ticket, fenixFeather, portalBoost;
    
    // Start is called before the first frame update
    void Start()
    {
        if (GameStats.stats.CoinTicket == true)
        {
            X2Ticket.enabled = true;
        }
        else
        {
            X2Ticket.enabled = false;
        }

        if (GameStats.stats.fenixFeather == true)
        {
            fenixFeather.enabled = true;
        }
        else
        {
            fenixFeather.enabled = false;
        }
        if (GameStats.stats.PortalBoost == true)
        {
            portalBoost.enabled = true;
        }
        else
        {
            portalBoost.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStats.stats.fenixFeather == true)
        {
            fenixFeather.enabled = true;
        }
        else
        {
            fenixFeather.enabled = false;
        }
    }
}
