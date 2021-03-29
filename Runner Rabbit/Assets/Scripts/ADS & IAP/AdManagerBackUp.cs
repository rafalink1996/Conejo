using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;

public class AdManagerBackUp : MonoBehaviour //, IUnityAdsListener
{

    /*
    private string playStoreID = "4056747";  //"3834045";
    private string appStoreID = "4056746";   //"3834044";

    private string AdGameID;



    private string interstitialAd = "video";
    private string rewardedVideoAd = "rewardedVideo";

    public bool isTargetPlayStore;
    public bool AutomaticIDPlacement;
    public bool isTestAd;

    public AudioMixer MainMixer;


    public int RewardCoins;
    public int RewardCrystals;

    public GameObject rewardColect;

    public TextMeshProUGUI RewardDisplay1;
    public TextMeshProUGUI RewardDisplay2;
    public TextMeshProUGUI RewardDisplay3;

    public bool revive;
    // public character cha;
    public GameObject deathscreen;

    public Button AdButton;
    public GameObject ConfirmWatchAdObject;

    public LevelLoaderGame levelLoaderGame;


    private string Android_InterstitialAd = "Interstitial_Android";
    private string Android_RewardeVideoAd = "Rewarded_Android";
    private string IOS_InterstitialAD = "Interstitial_iOS";
    private string IOS_RewardedVideoAd = "Rewarded_iOS";




    // Start is called before the first frame update
    void Start()
    {

        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            AdGameID = appStoreID;


        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            AdGameID = playStoreID;
        }
        else
        {
            AutomaticIDPlacement = false;
        }


        if (GameStats.stats.NoAdsBought == false)
        {
            if (AdButton != null)
            {
                AdButton.onClick.AddListener(ShowConfirmationScreen);
            }

            Advertisement.AddListener(this);
            IniziatlizeAdvertisement();

            RewardCoins = 100 + (25 * (GameStats.stats.LevelIndicator - 2));
            if (RewardDisplay1 != null)
            {
                RewardDisplay1.text = RewardCoins.ToString();
            }
            else
            {
                //Debug.Log("no text");

            }
            if (RewardDisplay2 != null)
            {
                RewardDisplay2.text = RewardCoins.ToString();
            }
            else
            {
                // Debug.Log("no text");

            }

            if (RewardDisplay3 != null)
            {
                RewardDisplay3.text = RewardCoins.ToString();
            }
            else
            {
                // Debug.Log("no text");

            }
        }
        else
        {
            if (AdButton != null)
            {
                AdButton.onClick.RemoveAllListeners();
                AdButton.onClick.AddListener(ShowReardWhenNoADS);
            }
        }



    }


    public void showInterstitialAdCheck()
    {
        if (GameStats.stats.NoAdsBought == false)
        {
            PlayInterstitialAD();
        }
        else
        {
            levelLoaderGame.backToMainMenu();
        }
    }



    void ShowReardWhenNoADS()
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


    private void IniziatlizeAdvertisement()
    {
        if (AutomaticIDPlacement)
        {
            Advertisement.Initialize(AdGameID, isTestAd);

        }
        else
        {
            if (isTargetPlayStore)
            {
                Advertisement.Initialize(playStoreID, isTestAd); return;
            }
            else
            {
                Advertisement.Initialize(appStoreID, isTestAd);
            }
        }


    }

    public void PlayInterstitialAD()
    {
        if (GameStats.stats.NoAdsBought == false)
        {
            if (!Advertisement.IsReady(interstitialAd))
            {
                return;
            }
            else
            {
                Advertisement.Show(interstitialAd);
            }
        }
        else
        {
            if (levelLoaderGame != null)
            {
                levelLoaderGame.backToMainMenu();
            }
        }

    }

    public void PlayRewardeVideoAd()
    {
        if (GameStats.stats.NoAdsBought == false)
        {
            if (!Advertisement.IsReady(rewardedVideoAd))
            {
                return;
            }
            else
            {
                Advertisement.Show(rewardedVideoAd);
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

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {

        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {

        //throw new System.NotImplementedException();
        //MainMixer.SetFloat("Sound", -80);
        //MainMixer.SetFloat("Music", -80);
        MainMixer.SetFloat("MasterVolume", -80);

    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Failed:
                if (levelLoaderGame != null)
                {
                    levelLoaderGame.backToMainMenu();
                }
                MainMixer.SetFloat("MasterVolume", 0);

                break;

            case ShowResult.Skipped:

                if (levelLoaderGame != null)
                {
                    levelLoaderGame.backToMainMenu();
                }
                MainMixer.SetFloat("MasterVolume", 0);

                break;
            case ShowResult.Finished:
                if (placementId == rewardedVideoAd)
                {
                    if (rewardColect != null)
                    {
                        rewardColect.SetActive(true);
                    }
                    // MainMixer.SetFloat("Sound", GameStats.stats.AudioVolume);
                    // MainMixer.SetFloat("Music", GameStats.stats.MusicVolume);
                    MainMixer.SetFloat("MasterVolume", 0);

                    Debug.Log("finished rewarded");
                }
                if (placementId == interstitialAd)
                {
                    //MainMixer.SetFloat("Sound", GameStats.stats.AudioVolume);
                    //MainMixer.SetFloat("Music", GameStats.stats.MusicVolume);
                    MainMixer.SetFloat("MasterVolume", 0);
                    if (levelLoaderGame != null)
                    {
                        levelLoaderGame.backToMainMenu();
                    }

                    Debug.Log("finished interstisial");
                }
                break;
        }
        //throw new System.NotImplementedException();
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




    ************************************ AD MANAGER BACKUP 2 ****************************************
    *   --------------------------------------------------------------------------------------------*
    ****************************** (before Admob mediation cleanup) *********************************
    
    
    
    

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
using GoogleMobileAds.Common;


public class AdManager : MonoBehaviour, IUnityAdsListener
{

    private string playStoreID = "4056747";  //"3834045";
    private string appStoreID = "4056746";   //"3834044";

    private string AdGameID;



    private string interstitialAd;
    private string rewardedVideoAd;

    public bool isTargetPlayStore;
    public bool AutomaticIDPlacement;
    public bool isTestAd;

    public AudioMixer MainMixer;


    public int RewardCoins;
    public int RewardCrystals;

    public GameObject rewardColect;

    public TextMeshProUGUI RewardDisplay1;
    public TextMeshProUGUI RewardDisplay2;
    public TextMeshProUGUI RewardDisplay3;

    public bool revive;
    // public character cha;
    public GameObject deathscreen;

    public Button AdButton;
    public GameObject ConfirmWatchAdObject;

    public LevelLoaderGame levelLoaderGame;


    private string Android_InterstitialAd = "Interstitial_Android";
    private string Android_RewardeVideoAd = "Rewarded_Android";
    private string IOS_InterstitialAD = "Interstitial_iOS";
    private string IOS_RewardedVideoAd = "Rewarded_iOS";



    // Google admob

    private RewardedAd rewardedAd;
    private string adUnitId;
    public bool probandoAdmob;



    // Start is called before the first frame update
    void Start()
    {
        #region Set Application Platform

#if UNITY_EDITOR
        adUnitId = "unused";
#elif UNITY_ANDROID
        adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
        adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
        adUnitId = "unexpected_platform";
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            AdGameID = appStoreID;
            interstitialAd = IOS_InterstitialAD;
            rewardedVideoAd = IOS_RewardedVideoAd;
            adUnitId = "ca-app-pub-3940256099942544/1712485313";



        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            AdGameID = playStoreID;
            interstitialAd = Android_InterstitialAd;
            rewardedVideoAd = Android_RewardeVideoAd;
            adUnitId = "ca-app-pub-3940256099942544/5224354917";
        }
        else
        {
            AutomaticIDPlacement = false;
            if (!isTargetPlayStore)
            {
                AdGameID = appStoreID;
                interstitialAd = IOS_InterstitialAD;
                rewardedVideoAd = IOS_RewardedVideoAd;
                adUnitId = "ca-app-pub-3940256099942544/1712485313";
            }
            else if (isTargetPlayStore)
            {
                AdGameID = playStoreID;
                interstitialAd = Android_InterstitialAd;
                rewardedVideoAd = Android_RewardeVideoAd;
                adUnitId = "ca-app-pub-3940256099942544/5224354917";

            }
            else
            {
                adUnitId = "unexpected_platform";
            }
        }

#endif


        #endregion

        #region Initialize Ads and check if remove ads has been bought.

        if (GameStats.stats.NoAdsBought == false)
        {
            if (AdButton != null)
            {
                AdButton.onClick.AddListener(ShowConfirmationScreen);
            }

            Advertisement.AddListener(this);
            IniziatlizeAdvertisement();
            MobileAds.Initialize(initStatus => { });

           this.rewardedAd = new RewardedAd(adUnitId);

            // Called when an ad request has successfully loaded.
            this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
            // Called when an ad request failed to load.
            this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
            // Called when an ad is shown.
            this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
            // Called when an ad request failed to show.
            this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
            // Called when the user should be rewarded for interacting with the ad.
            this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
            // Called when the ad is closed.
            this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

            AdRequest request = new AdRequest.Builder().Build();
            this.rewardedAd.LoadAd(request);


            RewardCoins = 100 + (25 * (GameStats.stats.LevelIndicator - 2));
            if (RewardDisplay1 != null)
            {
                RewardDisplay1.text = RewardCoins.ToString();
            }
            else
            {
                //Debug.Log("no text");

            }
            if (RewardDisplay2 != null)
            {
                RewardDisplay2.text = RewardCoins.ToString();
            }
            else
            {
                // Debug.Log("no text");

            }

            if (RewardDisplay3 != null)
            {
                RewardDisplay3.text = RewardCoins.ToString();
            }
            else
            {
                // Debug.Log("no text");

            }
        }
        else
        {
            if (AdButton != null)
            {
                AdButton.onClick.RemoveAllListeners();
                AdButton.onClick.AddListener(ShowReardWhenNoADS);
            }
        }

        #endregion



    }


    public void showInterstitialAdCheck()
    {
        if (GameStats.stats.NoAdsBought == false)
        {
            PlayInterstitialAD();
        }
        else
        {
            levelLoaderGame.backToMainMenu();
        }
    }



    void ShowReardWhenNoADS()
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


    private void IniziatlizeAdvertisement()
    {

        Advertisement.Initialize(AdGameID, isTestAd);


    }

    public void PlayInterstitialAD()
    {

        if (!Advertisement.IsReady(interstitialAd))
        {
            return;
        }
        else
        {
            Advertisement.Show(interstitialAd);
        }



    }

    public void PlayRewardeVideoAd()
    {
        if (!probandoAdmob)
        {
            if (GameStats.stats.NoAdsBought == false)
            {
                if (!Advertisement.IsReady(rewardedVideoAd))
                {
                    return;
                }
                else
                {
                    Advertisement.Show(rewardedVideoAd);
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
        else
        {
            if (this.rewardedAd.IsLoaded())
            {
                this.rewardedAd.Show();
            }

        }
       
    }

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {

        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {

     ;
        MainMixer.SetFloat("MasterVolume", -80);

    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Failed:
                if (levelLoaderGame != null)
                {
                    levelLoaderGame.backToMainMenu();
                }
                MainMixer.SetFloat("MasterVolume", 0);

                break;

            case ShowResult.Skipped:

                if (levelLoaderGame != null)
                {
                    levelLoaderGame.backToMainMenu();
                }
                MainMixer.SetFloat("MasterVolume", 0);
                
                break;
            case ShowResult.Finished:
                if (placementId == rewardedVideoAd)
                {
                    if (rewardColect != null)
                    {
                        rewardColect.SetActive(true);
                    }
                    // MainMixer.SetFloat("Sound", GameStats.stats.AudioVolume);
                    // MainMixer.SetFloat("Music", GameStats.stats.MusicVolume);
                    MainMixer.SetFloat("MasterVolume", 0);

                    Debug.Log("finished rewarded");
                }
                if (placementId == interstitialAd)
                {
                    //MainMixer.SetFloat("Sound", GameStats.stats.AudioVolume);
                    //MainMixer.SetFloat("Music", GameStats.stats.MusicVolume);
                    MainMixer.SetFloat("MasterVolume", 0);
                    if (levelLoaderGame != null)
                    {
                        levelLoaderGame.backToMainMenu();
                    }

                    Debug.Log("finished interstisial");
                }
                break;
        }
        //throw new System.NotImplementedException();
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



    // ADmob Tests


    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;

        if (rewardColect != null)
        {
            rewardColect.SetActive(true);
        }
       
    }
}


*/
}
