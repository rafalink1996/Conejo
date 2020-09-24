using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject spawnerUp;
    public GameObject SpawnerDown;
    public GameObject SpawnerMiddle;
    public GameObject Boss;
    public GameObject ProgressBar;

    public Image PowerRarity;
    public character cha;

    public Color darkcolor;
    public Color lightColor;

    
    public Button ThePauseButton;

   





   private void Start()
    {
        ThePauseButton.interactable = false;
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

        StartCoroutine(WaitForInteractable());
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

    public void PauseButton()
    {
        Time.timeScale = 0;
        GameIsPaused = true;
    }
    public void ResumeButton()
    {
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    IEnumerator WaitForInteractable()
    {
        yield return new WaitForSecondsRealtime(5);
        ThePauseButton.interactable = true;
        


    }
        

   
}
