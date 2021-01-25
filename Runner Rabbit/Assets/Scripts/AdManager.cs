using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Audio;
using TMPro;


public class AdManager : MonoBehaviour, IUnityAdsListener
{

    private string playStoreID = "3834045";
    private string appStoreID = "3834044";

    private string interstitialAd = "video";
    private string rewardedVideoAd = "rewardedVideo";

    public bool isTargetPlayStore;
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


    // Start is called before the first frame update
    void Start()
    {

        Advertisement.AddListener(this);
        IniziatlizeAdvertisement();

        RewardCoins = 100 + (25 * (GameStats.stats.LevelIndicator - 2));
        if (RewardDisplay1 != null)
        {
            RewardDisplay1.text = RewardCoins.ToString();
        }
        else
        {
            Debug.Log("no text");

        }
        if (RewardDisplay2 != null)
        {
            RewardDisplay2.text = RewardCoins.ToString();
        }
        else
        {
            Debug.Log("no text");

        }

        if (RewardDisplay3 != null)
        {
            RewardDisplay3.text = RewardCoins.ToString();
        }
        else
        {
            Debug.Log("no text");

        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void IniziatlizeAdvertisement()
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
        if (!Advertisement.IsReady(rewardedVideoAd)){
            return;
        }
        else
        {
            Advertisement.Show(rewardedVideoAd);
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
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Failed:
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Finished:
                if (placementId == rewardedVideoAd)
                {
                    if (rewardColect != null)
                    {
                        rewardColect.SetActive(true);
                    }
                    else if (revive)
                    {
                        //reviveCharacter();
                    }
                    
                    Debug.Log("finished rewarded");
                }
                if (placementId == interstitialAd)
                {
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

   /* public void reviveCharacter()
    {
        cha.Health = cha.NumOfHearts;
        deathscreen.SetActive(false);
    }


    public void toggleRevive()
    {
        if (revive == false)
        {
            revive = true;
        }
        else
        {
            revive = false;
        }
       
    }
   */

}
