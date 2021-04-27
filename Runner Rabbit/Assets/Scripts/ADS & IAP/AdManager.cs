﻿
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using GoogleMobileAds.Api.Mediation.UnityAds;




public class AdManager : MonoBehaviour
{



    public AudioMixer MainMixer;


   int RewardCoins;
   int RewardCrystals;

    public GameObject rewardColect;

    public TextMeshProUGUI RewardDisplay1;
    public TextMeshProUGUI RewardDisplay2;
    public TextMeshProUGUI RewardDisplay3;


    public GameObject deathscreen;

    public Button AdButton;
    public GameObject ConfirmWatchAdObject;

    public LevelLoaderGame levelLoaderGame;


    // Google admob

    private string adUnitId;

    string IntersticialAD_ID = "ca-app-pub-3940256099942544/4411468910"; // IOS = ca-app-pub-4145591567952062/3601130590 //  Android = ca-app-pub-4145591567952062/9052767822
    string RewardedAD_ID = "ca-app-pub-3940256099942544/1712485313"; //IOS = ca-app-pub-4145591567952062/2259633924 // Android = ca-app-pub-4145591567952062/5433140916

    private RewardedAd rewardedAd;
    private InterstitialAd interstitial;


    public bool probandoAdmob;
    public GameObject AdFailedToLoadObject;
    





    // Start is called before the first frame update
    void Start()
    {
        #region Set Application Platform

#if UNITY_EDITOR
        adUnitId = "unused";
#elif UNITY_ANDROID
        adUnitId = "ca-app-pub-4145591567952062~5689303547";
#elif UNITY_IPHONE
        adUnitId = "ca-app-pub-4145591567952062~5970814077";
#else
        adUnitId = "unexpected_platform";
#endif

        MobileAds.Initialize((initStatus) =>
        {
            Dictionary<string, AdapterStatus> map = initStatus.getAdapterStatusMap();
            foreach (KeyValuePair<string, AdapterStatus> keyValuePair in map)
            {
                string className = keyValuePair.Key;
                AdapterStatus status = keyValuePair.Value;
                switch (status.InitializationState)
                {
                    case AdapterState.NotReady:
                        // The adapter initialization did not complete.
                        MonoBehaviour.print("Adapter: " + className + " not ready.");
                        break;
                    case AdapterState.Ready:
                        // The adapter was successfully initialized.
                        MonoBehaviour.print("Adapter: " + className + " is initialized.");
                        break;
                }
            }
        });
  


    // Remove this code before build //
    List<string> deviceIds = new List<string>();
        deviceIds.Add("14d1fff363b2cda9939aac6cb791aaef");
        RequestConfiguration requestConfiguration = new RequestConfiguration
            .Builder()
            .SetTestDeviceIds(deviceIds)
            .build();

        MobileAds.SetRequestConfiguration(requestConfiguration);
        

       
  

        #endregion

        #region Initialize Ads and check if remove ads has been bought.

        if (GameStats.stats.NoAdsBought == false)
        {
            if (AdButton != null)
            {
                AdButton.onClick.AddListener(ShowConfirmationScreen);
            }

          

          
            


            RewardCoins = 100 + (25 * GameStats.stats.LevelIndicator);
            if (RewardDisplay1 != null)
            {
                RewardDisplay1.text = RewardCoins.ToString();
            }
            if (RewardDisplay2 != null)
            {
                RewardDisplay2.text = RewardCoins.ToString();
            }
            if (RewardDisplay3 != null)
            {
                RewardDisplay3.text = RewardCoins.ToString();
            }
        }
        else
        {
            if (AdButton != null)
            {
                AdButton.onClick.RemoveAllListeners();
                AdButton.onClick.AddListener(ShowRewardWhenNoADS);
            }
        }

        #endregion


      RequestRewardedVideoAd();
      RequestInterstitial();



    }

    public void RequestRewardedVideoAd()
    {
        this.rewardedAd = new RewardedAd(RewardedAD_ID);


        // ** Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // ** Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // ** Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // ** Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // ** Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // ** Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        this.rewardedAd.LoadAd(request);
    }

    public void PlayRewardeVideoAd()
    {

        if (GameStats.stats.NoAdsBought == false)
        {


            if (this.rewardedAd.IsLoaded())
            {
                this.rewardedAd.Show();
            } 
            
        }
        else
        {
            if (rewardColect != null)
            {
                rewardColect.SetActive(true);
            }
        }

    }
    public void RequestInterstitial()
    {

        this.interstitial = new InterstitialAd(IntersticialAD_ID);



        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);

    }

    public void PlayInterstitialAD()
    {

        if (GameStats.stats.NoAdsBought == false)
        {
            if (this.interstitial.IsLoaded())
            {
                this.interstitial.Show();
            } 

        }
        else
        {
            BackToMainMenuIntersticial();

        }



    }

    public void BackToMainMenuIntersticial()
    {
        levelLoaderGame.backToMainMenu();
    }



    void ShowRewardWhenNoADS()
    {
        if (rewardColect != null)
        {
            rewardColect.SetActive(true);
        }
    }

    void ShowConfirmationScreen()
    {
        ConfirmWatchAdObject.SetActive(true);
    }



    public void rewardPlayerCoins()
    {
        GameStats.stats.coins += RewardCoins;
        GameStats.stats.SaveStats();

    }

    public void RewardPlayerCrystals()
    {
        GameStats.stats.crystals += RewardCrystals;
        GameStats.stats.SaveStats();
    }



    // ADmob Events
  
    //Rewarded video ads events

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {

      //  PlayRewardeVideoAd();
       
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {

         MonoBehaviour.print(
             "HandleRewardedAdFailedToLoad event received with message: "
                              + args.Message);
         Debug.Log("ad failed to load");



       

        
        
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MainMixer.SetFloat("MasterVolume", -80);
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MainMixer.SetFloat("MasterVolume", 0);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MainMixer.SetFloat("MasterVolume", 0);
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        MainMixer.SetFloat("MasterVolume", 0);
        if (rewardColect != null)
        {
            rewardColect.SetActive(true);
        }
    }


    // intersticial Ad events

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
       // PlayInterstitialAD();
        
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        
        Debug.Log("ad failed to load");
       
        BackToMainMenuIntersticial();
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
        

    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MainMixer.SetFloat("MasterVolume", -80);
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MainMixer.SetFloat("MasterVolume", 0);
        BackToMainMenuIntersticial();
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {

    }
    
}








