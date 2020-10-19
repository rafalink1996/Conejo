﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoaderGame : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public GameObject EndLevelAnimation;
    public Animator transition;

    public GameObject EnemySpawner1;
    public GameObject EnemySpawner2;
    public GameObject EnemySpawnerHand;

    public HouseSpawner EndlessHosue;
    public character cha;
    //public BossWyrm bossWyrm;

    public float transitiontime;
    public float levelTime;
    public float levelcountdown;

    public Slider TimerSlider;
    bool timeOver = false;

    // Start is called before the first frame update
    void Start()
    {
        if(GameStats.stats.LevelCount == 1)
        {
            levelTime = 50 + (25* (GameStats.stats.LevelIndicator -1));

        }

        if (GameStats.stats.LevelCount > 1)
        {
            levelTime = 100 + (25 * (GameStats.stats.LevelIndicator - 1));
        }
        StartCoroutine(loadloader());

        if (GameStats.stats.PortalBoost == false)
        {
            levelcountdown = 0;
        }
        if (GameStats.stats.PortalBoost == true)
        {
            levelcountdown = levelTime/2;
            //GameStats.stats.PortalBoost = false;
        }

        TimerSlider.maxValue = levelTime;
        GameStats.stats.spawnHouse = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        levelcountdown += 1 * Time.deltaTime;
        TimerSlider.value = levelcountdown;

        if (levelcountdown >= levelTime * 0.93f)
        {
            EnemySpawner1.SetActive(false);
            EnemySpawner2.SetActive(false);
            EnemySpawnerHand.SetActive(false);
            cha.endlevel = true;
            
        }
  
    }

    IEnumerator loadloader()
    {
        while (true)
        {

            if (GameStats.stats.LevelCount == 3)
            {

                if (GameStats.stats.bossDead == true)
                {
                    yield return new WaitForSecondsRealtime(5);
                    EndlessHosue.spawnhouse();
                    GameStats.stats.PortalBoost = false;
                    
                    
                    StartCoroutine(loadAsyncGame(1));
                }

            }
            else
            {

                if (TimerSlider.value >= levelTime && !timeOver)
                {
                    timeOver = true;
                    yield return new WaitForSecondsRealtime(1);
                    EndlessHosue.spawnhouse();
                    levelTime = 0;
                    GameStats.stats.PortalBoost = false;
                    
                    StartCoroutine(loadAsyncGame(1));
                    
                }

            }
            yield return null;
        }

    }



    IEnumerator loadAsyncGame(int SceneIndex)

    {



        Debug.Log("gameChangeInitiated");
        yield return new WaitForSecondsRealtime(2);
        // play animation
        EndLevelAnimation.SetActive(true);





        //wait
        yield return new WaitForSecondsRealtime(transitiontime);

        //loadScene


        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            Debug.Log(progress);

            yield return null;


        }
    }


    // if player dies back to main menú button

    public void backToMainMenu()

    {
        loadingScreen.SetActive(true);
        StartCoroutine(loadAsyncMainMenu());
        Time.timeScale = 1;
        GameStats.stats.CoinTicket = false;

    }

    public void backtoMainMenuPauseButton()
    {
        loadingScreen.SetActive(true);
        StartCoroutine(loadAsyncMainMenu());
        Time.timeScale = 1;
        // save level indicator and count for resume;


    }



    IEnumerator loadAsyncMainMenu()

    {

        Debug.Log("gameChangeInitiated");
        yield return new WaitForSecondsRealtime(1);
        // play animation
        transition.SetTrigger("Start");





        //wait
        yield return new WaitForSecondsRealtime(transitiontime);

        //loadScene


        AsyncOperation operation = SceneManager.LoadSceneAsync(0);

        loadingScreen.SetActive(true);
        Time.timeScale = 1;


        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            Debug.Log(progress);

            yield return null;


        }
    }
}
