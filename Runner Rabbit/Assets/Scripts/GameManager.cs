﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject spawnerUp;
    public GameObject SpawnerDown;
    public GameObject spawnerUpTwo;
    public GameObject spawnerDownTwo;
    public GameObject SpawnerMiddle;
    public GameObject BossContainer;
    public string bossName;
    public GameObject ProgressBar;

    public Image PowerRarity;
    public character cha;

    public Color darkcolor;
    public Color lightColor;


    public Button ThePauseButton;

    public Slider MusicSlider;
    public Slider SoundSlider;
    public AudioMixer audioMixer;


    public GameObject StartAnimationUi;
    public GameObject StartAnimation;

    public bool FinalBoss;

    [SerializeField] ObjectPooler myObjectPooler;






    private void Start()
    {
        myObjectPooler = FindObjectOfType<ObjectPooler>();
        for (int i = 0; i < myObjectPooler.pools.Count; i++)
        {
            if (!myObjectPooler.pools[i].allLevels && GameStats.stats.LevelCount != myObjectPooler.pools[i].LevelID)
            {
                myObjectPooler.pools[i].Instantiate = false;
            }

            if(myObjectPooler.pools[i].Power == true)
            {
                myObjectPooler.pools[i].Instantiate = false;
                for (int ID = 0; ID < myObjectPooler.pools[i].PowerIds.Length; ID++)
                {
                    if (myObjectPooler.pools[i].PowerIds[ID] == GameStats.stats.powerLight.id || myObjectPooler.pools[i].PowerIds[ID] == GameStats.stats.powerDark.id)
                    {

                        myObjectPooler.pools[i].Instantiate = true;
                    }
                }

            }
        }

        StartCoroutine(DestroyStartingAnimations());
        GameIsPaused = false;
        ThePauseButton.interactable = false;
        cha = FindObjectOfType<character>();
        darkcolor = GameStats.stats.powerDark.rarityColor;
        lightColor = GameStats.stats.powerLight.rarityColor;
        Time.timeScale = 1f;
        if (cha.top)
        {
            PowerRarity.color = darkcolor;
        }
        else
        {
            PowerRarity.color = lightColor;
        }

        StartCoroutine(WaitForInteractable());


        audioMixer.SetFloat("MusicVolume", Mathf.Log10(GameStats.stats.MusicVolume) * 20);
        MusicSlider.value = GameStats.stats.MusicVolume;

        audioMixer.SetFloat("SoundVolume", Mathf.Log10(GameStats.stats.AudioVolume) * 20);
        SoundSlider.value = GameStats.stats.AudioVolume;
        if (GameStats.stats.LevelCount == 1 && !FinalBoss)
        {
            spawnerUp.SetActive(true);
            SpawnerDown.SetActive(true);
            spawnerUpTwo.SetActive(false);
            spawnerDownTwo.SetActive(false);
            SpawnerMiddle.SetActive(false);
            BossContainer.SetActive(false);
        }
        if (GameStats.stats.LevelCount == 2)
        {
            spawnerUp.SetActive(false);
            SpawnerDown.SetActive(false);
            spawnerUpTwo.SetActive(true);
            spawnerDownTwo.SetActive(true);
            SpawnerMiddle.SetActive(true);
            BossContainer.SetActive(false);
        }
        if (GameStats.stats.LevelCount == 3)
        {
            spawnerUp.SetActive(false);
            SpawnerDown.SetActive(false);
            spawnerUpTwo.SetActive(false);
            spawnerDownTwo.SetActive(false);
            SpawnerMiddle.SetActive(false);
            ProgressBar.SetActive(false);
            BossContainer.SetActive(true);
            GameObject boss = Instantiate(Resources.Load("Prefabs/" + bossName) as GameObject);
            boss.transform.SetParent(BossContainer.transform);
            boss.transform.localPosition = new Vector3(0, 0, 0);

        }

        if (FinalBoss)
        {
            ProgressBar.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (cha.top)
        {
            PowerRarity.color = darkcolor;
        }
        else
        {
            PowerRarity.color = lightColor;

        }
        if (GameIsPaused)
        {
            Time.timeScale = 0;
        }

    }

    IEnumerator DestroyStartingAnimations()
    {
        yield return new WaitForSeconds(5);
        Destroy(StartAnimation);
        Destroy(StartAnimationUi);
        Resources.UnloadUnusedAssets();
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


    public void SetMusicVolume(float Musicvolume)
    {

        audioMixer.SetFloat("MusicVolume", Mathf.Log10(Musicvolume) * 20);
        GameStats.stats.MusicVolume = Musicvolume;
        GameStats.stats.SaveStats();
    }

    public void SetSoundVolume(float Audiovolume)
    {
        audioMixer.SetFloat("SoundVolume", Mathf.Log10(Audiovolume) * 20);
        GameStats.stats.AudioVolume = Audiovolume;
        GameStats.stats.SaveStats();
    }



}
