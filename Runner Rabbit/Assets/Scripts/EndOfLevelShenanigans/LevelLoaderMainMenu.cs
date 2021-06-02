using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoaderMainMenu : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public GameObject transition;
    public float transitiontime;
    public GameObject playbuttontransition;

    public GameObject StartButton;
  

    public GameObject NewRunButton;
    public GameObject ContinueRunButton;

    private void Start()
    {

        if (GameStats.stats.RunInProgress == true)
        {
            StartButton.SetActive(false);
            NewRunButton.SetActive(true);
            ContinueRunButton.SetActive(true);
        }
        else
        {
            StartButton.SetActive(true);
            NewRunButton.SetActive(false);
            ContinueRunButton.SetActive(false);
        }
        GameStats.stats.SaveStats();
        transition.SetActive(false);



    }

    public void LoadLevel()

    {

        if (GameStats.stats.LevelBought == true)
        {

            GameStats.stats.ResetStats();
            GameStats.stats.SavedLevelPercentage = 0;
            GameStats.stats.LevelIndicator = GameStats.stats.leveBoughtID;
           // GameStats.stats.RunInProgress = true;
            GameStats.stats.SavedLevelIndicator = GameStats.stats.LevelIndicator;
            GameStats.stats.SavedLevelCount = GameStats.stats.LevelCount;
            GameStats.stats.LevelBought = false;
            GameStats.stats.leveBoughtID = 1;
            GameStats.stats.RunInProgressPortalBoost = false;
            GameStats.stats.SavedLevelPercentage = 0;
            GameStats.stats.RunInProgress = false;

            GameStats.stats.coins = GameStats.stats.LevelBoughtCoins;

            if (GameStats.stats.ExtraHearts == true)
            {

                GameStats.stats.numOfHearts += 4;
                GameStats.stats.HealToFull();
                GameStats.stats.ExtraHearts = false;
                
            }

            if (GameStats.stats.ManaJar == true)
            {
                GameStats.stats.totalDarkMana += 30;
                GameStats.stats.totalLightMana += 30;


                GameStats.stats.ManaJar = false;
                
            }

            GameStats.stats.SaveStats();
         
            
           
            string LeveleToLoadName = GameStats.stats.CheckLevel();
            StartCoroutine(loadAsync(LeveleToLoadName));

        }
        else
        {
            GameStats.stats.SavedLevelPercentage = 0;
            GameStats.stats.ResetStats();
            GameStats.stats.SavedLevelIndicator = GameStats.stats.LevelIndicator;
            GameStats.stats.SavedLevelCount = GameStats.stats.LevelCount;
            GameStats.stats.RunInProgressPortalBoost = false;
            GameStats.stats.SavedLevelPercentage = 0;
            GameStats.stats.RunInProgress = false;

            if (GameStats.stats.ExtraHearts == true)
            {

                GameStats.stats.numOfHearts += 4;
                GameStats.stats.HealToFull();
                GameStats.stats.ExtraHearts = false;
               // GameStats.stats.SaveStats();
            }

            if (GameStats.stats.ManaJar == true)
            {
                GameStats.stats.totalDarkMana += 30;
                GameStats.stats.totalLightMana += 30;


                GameStats.stats.ManaJar = false;
                //
            }
            GameStats.stats.SaveStats();

            //GameStats.stats.RunInProgress = true;

            StartCoroutine(loadAsync("Level 1 (Library)"));
        }
        
    }

    public void LoadSavedLevel()
    {
        if (GameStats.stats.isInStore == true)
        {
            GameStats.stats.LevelIndicator = GameStats.stats.SavedLevelIndicator;
            GameStats.stats.LevelCount = GameStats.stats.SavedLevelCount;
            GameStats.stats.CheckLevelIndicator();
            GameStats.stats.CheckSavedPowers();
            GameStats.stats.RunInProgressPortalBoost = true;
            GameStats.stats.LoadingSavedLevel = true;
            StartCoroutine(loadAsync("Store"));

            
        }
        else
        {
            GameStats.stats.LevelIndicator = GameStats.stats.SavedLevelIndicator;
            GameStats.stats.LevelCount = GameStats.stats.SavedLevelCount;
            GameStats.stats.CheckLevelIndicator();
            GameStats.stats.CheckSavedPowers();
            GameStats.stats.RunInProgressPortalBoost = true;
            GameStats.stats.LoadingSavedLevel = true;
            string LevelToLoad = GameStats.stats.CheckLevel();
            StartCoroutine(loadAsync(LevelToLoad));
           
        }

        
    }
    
        
    
    


    IEnumerator loadAsync(string  SceneName)

    {
        // play animation
        transition.SetActive(true);
        FindObjectOfType<AudioManager>().Play("TransitionSound");


        //wait
        yield return new WaitForSecondsRealtime(transitiontime);

        //loadScene
        playbuttontransition.SetActive(false);

        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            //Debug.Log(progress);

            yield return null;


        }
    }
}
