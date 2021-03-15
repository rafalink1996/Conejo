using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;


public class AdManager : MonoBehaviour, IUnityAdsListener
{

    private string playStoreID = "3834045";
    private string appStoreID = "3834044";

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
   
    


    // Start is called before the first frame update
    void Start()
    {

        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            AdGameID = appStoreID;
            
        }else if (Application.platform == RuntimePlatform.Android)
        {
            AdGameID = playStoreID;
        }
        else
        {
            AutomaticIDPlacement = false;
        }


        if (GameStats.stats.NoAdsBought == false)
        {
            if (AdButton != null){
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

  
}
