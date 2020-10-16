﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using TMPro;

public class OfflineTimer : MonoBehaviour
{
    public TextMeshProUGUI counterText; // pauseText, resumeText, msgText;

    public int counterValue, focusCounter = 1, pauseCounter;
    private DateTime lastMinimize;
    private double minimizedSeconds;
    private int TimerLenght = 18000;
    
    public Button GetCrystalsButton;

    void OnApplicationPause(bool isGamePause)
    {
        if (isGamePause)
        {
            pauseCounter++;
           // pauseText.text = "Paused : " + pauseCounter;
            GoToMinimize();

            Debug.Log("minimized");
        }

        if (!isGamePause)
        {
            Debug.Log("appunpaused");
        }
    }

    void OnApplicationFocus(bool isGameFocus)
    {
        if (isGameFocus)
        {
            focusCounter++;
            //resumeText.text = "Focused : " + focusCounter;
            GoToMaximize(1);
            GameStats.stats.SaveStats();

           //Debug.Log("maximize");
        }
    }

    // Use this for initialization
    void Start()
    {
        
        // set timer to saved gamestats timer
        TimerLenght = GameStats.stats.timedReward;


        //set lastminimize date to saved gamestats date
        long lastsavedtemp = Convert.ToInt64(GameStats.stats.timedRewardLastDate);
        DateTime savedDate = DateTime.FromBinary(lastsavedtemp);
        lastMinimize = savedDate;

        GoToMaximize(2);

     
            

        
        StartCoroutine("StartCounter");
        Application.runInBackground = true;

        if (TimerLenght <= 0)
        {
            GetCrystalsButton.interactable = true;
        }
        else
        {
            GetCrystalsButton.interactable = false;
        }




    }

    private void Update()
    {
        if (TimerLenght <= 0)
        {
            GetCrystalsButton.interactable = true;
            TimerLenght = 0;
        }
        else
        {
            GetCrystalsButton.interactable = false;
        }


    }

    IEnumerator StartCounter()
    {
        
        yield return new WaitForSeconds(1f);

        //svae current timer
        GameStats.stats.timedReward = TimerLenght;
        GameStats.stats.SaveStats();

        // display current timer in HH:MM:SS
        int hours = Mathf.FloorToInt(TimerLenght / 3600);
        int minutes = Mathf.FloorToInt((TimerLenght % 3600) / 60);
        int seconds = Mathf.FloorToInt(TimerLenght % 60);
        string formattedTime = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        //counterText.text = "Counter : " + counterValue.ToString();
        counterText.text = formattedTime;



        //counterValue++;
        TimerLenght--;
        



        StartCoroutine("StartCounter");
    }

    public void GoToMinimize()
    {
        lastMinimize = DateTime.Now;

        //Save last minmize into gamestas
        GameStats.stats.timedRewardLastDate = lastMinimize.ToBinary();
    }

    public void GoToMaximize(int focusOrStart)
    {
        if (focusOrStart == 1)
        {
            if (focusCounter >= 2) // first focus in on startup
            {
                minimizedSeconds = (DateTime.Now - lastMinimize).TotalSeconds;
                //msgText.text = "Total Minimized Seconds : " + ((Int32)minimizedSeconds).ToString();
                // counterValue += (Int32)minimizedSeconds;
                TimerLenght -= (Int32)minimizedSeconds;
                //Debug.Log("maximized on focus");
            }
        }
        if (focusOrStart == 2)
        {
            if (focusCounter <= 2)
            {
                minimizedSeconds = (DateTime.Now - lastMinimize).TotalSeconds;
                //msgText.text = "Total Minimized Seconds : " + ((Int32)minimizedSeconds).ToString();
                // counterValue += (Int32)minimizedSeconds;
                TimerLenght -= (Int32)minimizedSeconds;
                Debug.Log("maximized on start");
            }
           
        }
        
       

    }

     

    public void resetTimer()
    {
        TimerLenght = 18000;
    }


}
