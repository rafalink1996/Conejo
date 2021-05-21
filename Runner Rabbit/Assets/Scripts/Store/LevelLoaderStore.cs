using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelLoaderStore : MonoBehaviour
{

    public float transitiontime;
    public GameObject loadingScreen;
    public Slider slider;
    public int SceneIndex;

    [SerializeField] GameObject LevelCountNumber;
    [SerializeField] GameObject BossLevelImage;
    [SerializeField] LanguageManagerStore myLanguageManagerS;
    [SerializeField] TextMeshProUGUI LevelName;

    private void Start()
    {
        GameStats.stats.isInStore = true;
        GameStats.stats.SaveCurrentHearts = GameStats.stats.numOfHearts;
        GameStats.stats.SaveStats();

        if(GameStats.stats.LanguageSelect == 1)
        {
            if (GameStats.stats.LevelIndicator == 1)
            {
                LevelName.text = myLanguageManagerS.English_Library;
            }
            if (GameStats.stats.LevelIndicator == 2)
            {
                LevelName.text = myLanguageManagerS.English_Dungeon;
            }
            if (GameStats.stats.LevelIndicator == 3)
            {
                LevelName.text = myLanguageManagerS.English_IceRoom;
            }
            if (GameStats.stats.LevelIndicator == 4)
            {
                LevelName.text = myLanguageManagerS.English_Jungle;
            }
            if (GameStats.stats.LevelIndicator == 5)
            {
                LevelName.text = myLanguageManagerS.English_PortalRoom;
            }
        }
        if (GameStats.stats.LanguageSelect == 2)
        {
            if (GameStats.stats.LevelIndicator == 1)
            {
                LevelName.text = myLanguageManagerS.Español_Library;
            }
            if (GameStats.stats.LevelIndicator == 2)
            {
                LevelName.text = myLanguageManagerS.Español_Dungeon;
            }
            if (GameStats.stats.LevelIndicator == 3)
            {
                LevelName.text = myLanguageManagerS.Español_IceRoom;
            }
            if (GameStats.stats.LevelIndicator == 4)
            {
                LevelName.text = myLanguageManagerS.Español_Jungle;
            }
            if (GameStats.stats.LevelIndicator == 5)
            {
                LevelName.text = myLanguageManagerS.Español_PortalRoom;
            }
        }
        if (GameStats.stats.LanguageSelect == 3)
        {
            if (GameStats.stats.LevelIndicator == 1)
            {
                LevelName.text = myLanguageManagerS.Frances_Library;
            }
            if (GameStats.stats.LevelIndicator == 2)
            {
                LevelName.text = myLanguageManagerS.Frances_Dungeon;
            }
            if (GameStats.stats.LevelIndicator == 3)
            {
                LevelName.text = myLanguageManagerS.Frances_IceRoom;
            }
            if (GameStats.stats.LevelIndicator == 4)
            {
                LevelName.text = myLanguageManagerS.Frances_Jungle;
            }
            if (GameStats.stats.LevelIndicator == 5)
            {
                LevelName.text = myLanguageManagerS.Frances_PortalRoom;
            }
        }

        if(GameStats.stats.LevelCount < 2)
        {
            LevelCountNumber.SetActive(true);
            BossLevelImage.SetActive(false);
            TextMeshProUGUI Levelcounttext = LevelCountNumber.GetComponent<TextMeshProUGUI>();
             Levelcounttext.text = (GameStats.stats.LevelCount + 1).ToString();
        }
        else
        {
            LevelCountNumber.SetActive(false);
            BossLevelImage.SetActive(true);
        }

    }


    // Start is called before the first frame update
    public void ContinueButton()

    {
        GameStats.stats.isInStore = false;
        GameStats.stats.LevelCount += 1;
        GameStats.stats.CheckLevelIndicator();
        GameStats.stats.SaveLevelBackUp();
        GameStats.stats.SavedLevelPercentage = 0;
        
        GameStats.stats.SaveStats();
        string LevelToLoad = GameStats.stats.CheckLevel();

        if (GameStats.stats.LevelIndicator > GameStats.stats.LevelReached)
        {
            GameStats.stats.LevelReached = GameStats.stats.LevelIndicator;
        }

        
        
        //Debug.Log(LevelToLoad);
        StartCoroutine(LoadAsync(LevelToLoad));
        
       
    }

    public void GoToMainMenu()
    {
        GameStats.stats.SaveStats();

        StartCoroutine(LoadAsync("Main Menu"));
    }



    // Update is called once per frame
    IEnumerator LoadAsync(string SceneName)
    {

        yield return new WaitForSecondsRealtime(transitiontime);

        //loadScene


        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            //Debug.Log(progress);

            yield return null;
        }
    }


   
}
