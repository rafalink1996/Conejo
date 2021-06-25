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
using UnityEngine.SceneManagement;




public class AdManager : MonoBehaviour
{



    public AudioMixer MainMixer;


    public int RewardCoins;
    public int RewardCrystals;

    public GameObject rewardColect;

    public TextMeshProUGUI RewardDisplay1;
    public TextMeshProUGUI RewardDisplay2;
    public TextMeshProUGUI RewardDisplay3;


    public GameObject deathscreen;

    public Button AdButton;

    public GameObject ConfirmWatchAdObject;

    public LevelLoaderGame levelLoaderGame;


    // Failed To Load Rewarded
    [SerializeField] GameObject FailedtoShowGameObject = null;
    [SerializeField] TextMeshProUGUI FailedAdDescriptionText = null;
    string FailedTLoadText;

    bool intersticialAdLoaded;




    // Google admob

    private string adUnitId;

    string IntersticialAD_ID = "ca-app-pub-4145591567952062/3601130590"; // IOS = ca-app-pub-4145591567952062/3601130590 *** // *** Android = ca-app-pub-4145591567952062/9052767822 *** // *** Test =ca-app-pub-3940256099942544/4411468910
    string RewardedAD_ID = "ca-app-pub-4145591567952062/2259633924"; //IOS = ca-app-pub-4145591567952062/2259633924 ***//*** Android = ca-app-pub-4145591567952062/5433140916 *** //*** Test = ca-app-pub-3940256099942544/1712485313

    private RewardedAd rewardedAd;
    private InterstitialAd interstitial;


    public bool probandoAdmob;
    bool FailedToLoadRewarded = false;
    bool FailedToLoadIntersticial = false;

    public GameObject LoadingAdObject;


    public int LoadRetryRewarded;
    public int LoadRetryIntersticial;



    [SerializeField] Image AdLoadedImage = null;



    [SerializeField] GameObject store = null;
    [SerializeField] GameObject MainMenu = null;

    bool TimeForReward = false;
    bool adClosed = false;

    bool adIsLoaded = false;






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

        if (AdLoadedImage != null)
        {
            AdLoadedImage.color = Color.red;
        }

        FailedToLoadRewarded = false;
        LoadRetryRewarded = 0;
        LoadRetryIntersticial = 0;


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

        

        // **************** Remove this code before build ************************ //
        //List<string> deviceIds = new List<string>();
        //deviceIds.Add("14d1fff363b2cda9939aac6cb791aaef");
        //RequestConfiguration requestConfiguration = new RequestConfiguration
        //    .Builder()
        //    .SetTestDeviceIds(deviceIds)
        //    .build();

        //MobileAds.SetRequestConfiguration(requestConfiguration);
        // **********************************************************************   //

        Scene currentScene = SceneManager.GetActiveScene();
        string SceneName = currentScene.name;

        if (SceneName == "Store" || SceneName == "Main Menu")
        {
            RequestRewardedVideoAd();
        }
        else
        {
            RequestInterstitial();
        }

        #endregion

        #region Initialize Ads and check if remove ads has been bought.

        if (GameStats.stats.NoAdsBought == false)
        {

            if (AdButton != null)
            {
                AdButton.interactable = false;
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

        TimeForReward = false;
        adClosed = false;


    }

    private void Update()
    {
        if (adClosed == true)
        {
            StartCoroutine(ActivateUIAfterAdClosed());
            adClosed = false;
        }
        if (TimeForReward == true)
        {
            StartCoroutine(WaitToShowReward());
            TimeForReward = false;
        }
       

        if (adIsLoaded)
        {
            if(AdButton != null)
            {
                AdButton.interactable = true;
            } 
        }
        else
        {
            if (AdButton != null)
            {
                AdButton.interactable = false;
            }
        }
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
            else if (FailedToLoadRewarded)
            {
                FailedAdDescriptionText.text = FailedTLoadText;
                FailedtoShowGameObject.SetActive(true);
            }
            else
            {
                // show ad loading
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
        if (!FailedToLoadIntersticial)
        {
            if (GameStats.stats.NoAdsBought == false)
            {
                LoadingAdObject.SetActive(true);
                if (intersticialAdLoaded)
                {
                    
                    this.interstitial.Show();
                }
                else
                {
                  Invoke("PlayInterstitialAD()", 1);
                }
                

            }
            else
            {
                BackToMainMenuIntersticial();

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


    // *********************************************************  //
    // ******************** ADmob Events ***********************  //
    // *********************************************************  //

    // ************** Rewarded video ads events ****************  //

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        if (AdLoadedImage != null)
        {
            AdLoadedImage.color = Color.green;
        }
        LoadRetryRewarded = 0;
        adIsLoaded = true;
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        /* MonoBehaviour.print(
             "HandleRewardedAdFailedToLoad event received with message: "
                              + args.Message);
         Debug.Log("ad failed to load");*/

        if (LoadRetryRewarded > 2)
        {
            FailedToLoadRewarded = true;
            FailedTLoadText = "Faield due to: " + args.Message;

            if (AdLoadedImage != null)
            {
                AdLoadedImage.color = Color.black;
            }
        }
        else
        {
            LoadRetryRewarded += 1;
            RequestRewardedVideoAd();
        }
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MainMixer.SetFloat("MasterVolume", -80);
        if (store != null)
        {
            store.SetActive(false);
        }
        if (MainMenu != null)
        {
            MainMenu.SetActive(false);
        }
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        if (FailedtoShowGameObject != null)
        {
            FailedtoShowGameObject.SetActive(true);
            FailedAdDescriptionText.text = args.Message;
        }
        MainMixer.SetFloat("MasterVolume", 0);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        //RequestRewardedVideoAd();
        MainMixer.SetFloat("MasterVolume", 0);
        adClosed = true;
        
    }
    
    public void HandleUserEarnedReward(object sender, Reward args)
    {
        MainMixer.SetFloat("MasterVolume", 0);
       
        TimeForReward = true;
    }


    // ************** intersticial video ads events ****************  //

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        //adIsLoaded = true;
        intersticialAdLoaded = true;
        LoadRetryIntersticial = 0;

    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {

        if (LoadRetryIntersticial > 2)
        {
            FailedToLoadIntersticial = true;
        }
        else
        {
            LoadRetryIntersticial += 1;
            RequestInterstitial();
        }


    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        LoadingAdObject.SetActive(false);

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

    IEnumerator WaitToShowReward()
    {
        yield return new WaitForEndOfFrame();
        adIsLoaded = false;
        if (store != null)
        {
            store.SetActive(true);
        }
        if (MainMenu != null)
        {
            MainMenu.SetActive(true);
        }
        if (rewardColect != null)
        {
            rewardColect.SetActive(true);
        }
        if (AdLoadedImage != null)
        {
            AdLoadedImage.color = Color.blue;
        }
        if(AdButton!= null)
        {
            AdButton.interactable = false;
        }

    }

    IEnumerator ActivateUIAfterAdClosed()
    {
        yield return new WaitForEndOfFrame();

        if (store != null)
        {
            store.SetActive(true);
        }
        if (MainMenu != null)
        {
            MainMenu.SetActive(true);
        }
        if (AdLoadedImage != null)
        {
            AdLoadedImage.color = Color.red;
        }
    }

    

    public void RetryToLoadAD()
    {
        if (FailedToLoadRewarded)
        {
            RequestRewardedVideoAd();
        }
        else
        {
            // do nothing
        }
    }

}



