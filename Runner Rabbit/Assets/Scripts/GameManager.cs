using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject spawnerUp;
    public GameObject SpawnerDown;
    public GameObject SpawnerMiddle;
    public GameObject Boss;
    public GameObject ProgressBar;

    public Image PowerRarity;
    public character cha;

    public Color darkcolor;
    public Color lightColor;





   private void Start()
    {
        cha = FindObjectOfType<character>();
        darkcolor = GameStats.stats.powerDark.rarityColor;
        lightColor = GameStats.stats.powerLight.rarityColor;

        if (cha.top)
        {
            PowerRarity.color = darkcolor;
        }
        else
        {
            PowerRarity.color = lightColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ( GameStats.stats.LevelCount == 3)
        {
            spawnerUp.SetActive(false);
            SpawnerDown.SetActive(false);
            SpawnerMiddle.SetActive(false);
            ProgressBar.SetActive(false);


            Boss.SetActive(true);



        }

        if (cha.top)
        {
            PowerRarity.color = darkcolor;
        } else
        {
            PowerRarity.color = lightColor;
            
        }

        
    }

   
}
