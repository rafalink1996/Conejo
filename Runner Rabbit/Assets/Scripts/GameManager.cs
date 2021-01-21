using System.Collections;
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
    public GameObject Boss;
    public GameObject ProgressBar;

    public Image PowerRarity;
    public character cha;

    public Color darkcolor;
    public Color lightColor;

    
    public Button ThePauseButton;

    public Slider MusicSlider;
    public Slider SoundSlider;
    public AudioMixer audioMixer;
   





   private void Start()
    {
        ThePauseButton.interactable = false;
        cha = FindObjectOfType<character>();
        darkcolor = GameStats.stats.powerDark.rarityColor;
        lightColor = GameStats.stats.powerLight.rarityColor;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStats.stats.LevelCount == 2)
        {
            spawnerUp.SetActive(false);
            SpawnerDown.SetActive(false);
            spawnerUpTwo.SetActive(true);
            spawnerDownTwo.SetActive(true);
            SpawnerMiddle.SetActive(true);
        }
        if ( GameStats.stats.LevelCount == 3)
        {
            spawnerUp.SetActive(false);
            SpawnerDown.SetActive(false);
            spawnerUpTwo.SetActive(false);
            spawnerDownTwo.SetActive(false);
            SpawnerMiddle.SetActive(false);
            ProgressBar.SetActive(false);
            Boss.SetActive(true);

        }

        if (cha.top)
        {
            PowerRarity.color = darkcolor;
        } else
        {
            PowerRarity.color = lightColor;
            
        }

        
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
