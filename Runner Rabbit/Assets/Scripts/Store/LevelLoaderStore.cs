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
        GameStats.stats.UploadStats();


        if (GameStats.stats.LevelCount == 0)
        {
            LevelCountNumber.SetActive(true);
            BossLevelImage.SetActive(false);
            TextMeshProUGUI Levelcounttext = LevelCountNumber.GetComponent<TextMeshProUGUI>();
            Levelcounttext.text = (GameStats.stats.LevelCount + 1).ToString();
            checkNextLevelName(GameStats.stats.LevelIndicator);
        }
         else if (GameStats.stats.LevelCount == 1)
        {
            LevelCountNumber.SetActive(true);
            BossLevelImage.SetActive(false);
            TextMeshProUGUI Levelcounttext = LevelCountNumber.GetComponent<TextMeshProUGUI>();
            Levelcounttext.text = (GameStats.stats.LevelCount + 1).ToString();
            checkNextLevelName(GameStats.stats.LevelIndicator);
        }
        else if (GameStats.stats.LevelCount == 3)
        {
            LevelCountNumber.SetActive(true);
            BossLevelImage.SetActive(false);
            TextMeshProUGUI Levelcounttext = LevelCountNumber.GetComponent<TextMeshProUGUI>();
            Levelcounttext.text = (GameStats.stats.LevelCount + -2).ToString();
            checkNextLevelName(GameStats.stats.LevelIndicator + 1);
        }
        else
        {
            LevelCountNumber.SetActive(false);
            BossLevelImage.SetActive(true);
            checkNextLevelName(GameStats.stats.LevelIndicator);
        }

        GameStats.stats.CloudAchievements();
        ServicesManager.instance.SumbitMonstersDefeatedScore(Mathf.FloorToInt(GameStats.stats.monstersKilled));
        GameStats.stats.SaveStats();
        GameStats.stats.UploadStats();

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

        ServicesManager.instance.SubmitScoreToLeaderBoard(GameStats.stats.LevelIndicator);
        ServicesManager.instance.StoreCloudData();



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


    void checkNextLevelName(int level)
    {
        if (GameStats.stats.LanguageSelect == 0)
        {
            if (level == 1)
            {
                LevelName.text = myLanguageManagerS.English_Library;
            }
            if (level == 2)
            {
                LevelName.text = myLanguageManagerS.English_Dungeon;
            }
            if (level == 3)
            {
                LevelName.text = myLanguageManagerS.English_IceRoom;
            }
            if (level == 4)
            {
                LevelName.text = myLanguageManagerS.English_Jungle;
            }
            if (level == 5)
            {
                LevelName.text = myLanguageManagerS.English_PortalRoom;
            }
            if (level == 6)
            {
                LevelName.text = "Tower exterior";
            }
        }
        if (GameStats.stats.LanguageSelect == 1)
        {
            if (level == 1)
            {
                LevelName.text = myLanguageManagerS.Español_Library;
            }
            if (level == 2)
            {
                LevelName.text = myLanguageManagerS.Español_Dungeon;
            }
            if (level == 3)
            {
                LevelName.text = myLanguageManagerS.Español_IceRoom;
            }
            if (level == 4)
            {
                LevelName.text = myLanguageManagerS.Español_Jungle;
            }
            if (level == 5)
            {
                LevelName.text = myLanguageManagerS.Español_PortalRoom;
            }
            if (level == 6)
            {
                LevelName.text = "Exterior de la torre";
            }
        }
        if (GameStats.stats.LanguageSelect == 2)
        {
            if (level == 1)
            {
                LevelName.text = myLanguageManagerS.Frances_Library;
            }
            if (level == 2)
            {
                LevelName.text = myLanguageManagerS.Frances_Dungeon;
            }
            if (level == 3)
            {
                LevelName.text = myLanguageManagerS.Frances_IceRoom;
            }
            if (level == 4)
            {
                LevelName.text = myLanguageManagerS.Frances_Jungle;
            }
            if (level == 5)
            {
                LevelName.text = myLanguageManagerS.Frances_PortalRoom;
            }
            if (level == 6)
            {
                LevelName.text = "Tower exterior";
            }
        }

    }
}
