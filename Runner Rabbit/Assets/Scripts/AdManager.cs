using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Audio;


public class AdManager : MonoBehaviour, IUnityAdsListener
{

    private string playStoreID = "3834045";
    private string appStoreID = "3834044";

    private string interstitialAd = "video";
    private string rewardedVideoAd = "rewardedVideo";

    public bool isTargetPlayStore;
    public bool isTestAd;

    public AudioMixer MainMixer;

   

    // Start is called before the first frame update
    void Start()
    {
        IniziatlizeAdvertisement();
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
        //throw new System.NotImplementedException();
    }
}
