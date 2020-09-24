using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradesShop : MonoBehaviour
{
    private float heartCost;
    public TextMeshProUGUI heartCostText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        heartCost = GameStats.stats.numOfHearts * 50;
        heartCostText.text = heartCost.ToString();
    }
    public void OnButtonClickHeart()
    {
        
        if (GameStats.stats.coins >= heartCost)
        {
            print("Bought heart");
            GameStats.stats.numOfHearts += 1;

        }
        else
        {
            print("You don't have enough coins!!!");
            //Play sound
        }
    }
}
